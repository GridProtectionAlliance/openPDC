//******************************************************************************************************
//  Startup.cs - Gbtc
//
//  Copyright © 2016, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  01/12/2016 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Security;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using GSF.IO;
using GSF.Web;
using GSF.Web.Hosting;
using GSF.Web.Security;
using GSF.Web.Shared;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Json;
using ModbusAdapters;
using Newtonsoft.Json;
using openPDC.Adapters;
using Owin;
using openPDC.Model;
using PhasorWebUI;

namespace openPDC
{
    public class HostedExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            Program.Host.LogException(context.Exception);
            base.Handle(context);
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Modify the JSON serializer to serialize dates as UTC - otherwise, timezone will not be appended
            // to date strings and browsers will select whatever timezone suits them
            JsonSerializerSettings settings = JsonUtility.CreateDefaultSerializerSettings();
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            JsonSerializer serializer = JsonSerializer.Create(settings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);
            AppModel model = Program.Host.Model;

            // Load security hub into application domain before establishing SignalR hub configuration, initializing default status and exception handlers
            try
            {
                using (new SecurityHub(
                    (message, updateType) => Program.Host.LogWebHostStatusMessage(message, updateType),
                    Program.Host.LogException
                )) { }
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new SecurityException($"Failed to load Security Hub, validate database connection string in configuration file: {ex.Message}", ex));
            }

            // Load shared hub into application domain, initializing default status and exception handlers
            try
            {
                using (new SharedHub(
                    (message, updateType) => Program.Host.LogWebHostStatusMessage(message, updateType),
                    Program.Host.LogException
                )) { }
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new SecurityException($"Failed to load Shared Hub: {ex.Message}", ex));
            }

            // Load phasor hub into application domain, initializing default status and exception handlers
            try
            {
                using (PhasorHub hub = new PhasorHub(
                    (message, updateType) => Program.Host.LogWebHostStatusMessage(message, updateType),
                    Program.Host.LogException
                ))
                {
                    WebExtensions.AddEmbeddedResourceAssembly(hub.GetType().Assembly);                  
                }
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new SecurityException($"Failed to load Phasor Hub: {ex.Message}", ex));
            }

            Load_ModbusAssembly();

            // Configure Windows Authentication for self-hosted web service
            HubConfiguration hubConfig = new HubConfiguration();
            HttpConfiguration httpConfig = new HttpConfiguration();

            // Make sure any hosted exceptions get propagated to service error handling
            httpConfig.Services.Replace(typeof(IExceptionHandler), new HostedExceptionHandler());

            // Enabled detailed client errors
            hubConfig.EnableDetailedErrors = true;

            // Enable GSF session management
            httpConfig.EnableSessions(AuthenticationOptions);

            // Enable GSF role-based security authentication
            app.UseAuthentication(AuthenticationOptions);

            // Enable cross-domain scripting default policy - controllers can manually
            // apply "EnableCors" attribute to class or an action to override default
            // policy configured here
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Global.DefaultCorsOrigins))
                    httpConfig.EnableCors(new EnableCorsAttribute(model.Global.DefaultCorsOrigins, model.Global.DefaultCorsHeaders, model.Global.DefaultCorsMethods) { SupportsCredentials = model.Global.DefaultCorsSupportsCredentials });
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new InvalidOperationException($"Failed to establish default CORS policy: {ex.Message}", ex));
            }

            // Load ServiceHub SignalR class
            app.MapSignalR(hubConfig);

            // Map service API controller
            try
            {
                httpConfig.Routes.MapHttpRoute(
                    name: "ServiceAPI",
                    routeTemplate: "Service/{action}/{command}/{returnValueTimeout}",
                    defaults: new { action = "Index", Controller = "Service", returnValueTimeout = RouteParameter.Optional }
                );
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new InvalidOperationException($"Failed to initialize service controller: {ex.Message}", ex));
            }

            // Map custom API controllers
            try
            {
                using (new GrafanaController()) { }

                httpConfig.Routes.MapHttpRoute(
                    name: "CustomAPIs",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { action = "Index", id = RouteParameter.Optional }
                );
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new InvalidOperationException($"Failed to initialize custom API controllers: {ex.Message}", ex));
            }

            // Set configuration to use reflection to setup routes
            httpConfig.MapHttpAttributeRoutes();

            // Load the WebPageController class and assign its routes
            app.UseWebApi(httpConfig);

            // Setup resolver for web page controller instances
            app.UseWebPageController(WebServer.Default, Program.Host.DefaultWebPage, model, typeof(AppModel), AuthenticationOptions);

            // Check for configuration issues before first request
            httpConfig.EnsureInitialized();
        }

        private void Load_ModbusAssembly()
        {
            try
            {
                // Wrap class reference in lambda function to force
                // assembly load errors to occur within the try-catch
                new Action(() =>
                {
                    // Make embedded resources of Modbus poller available to web server
                    using (ModbusPoller poller = new ModbusPoller())
                        WebExtensions.AddEmbeddedResourceAssembly(poller.GetType().Assembly);

                    ModbusPoller.RestoreConfigurations(FilePath.GetAbsolutePath("ModbusConfigs"));
                })();
            }
            catch (Exception ex)
            {
                Program.Host.LogException(new InvalidOperationException($"Failed to load Modbus assembly: {ex.Message}", ex));
            }
        }
        
        // Static Properties

        /// <summary>
        /// Gets the authentication options used for the hosted web server.
        /// </summary>
        public static AuthenticationOptions AuthenticationOptions { get; } = new AuthenticationOptions();
    }
}
