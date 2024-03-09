//******************************************************************************************************
//  ServiceHost.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  09/02/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Principal;
using System.Threading;
using GSF;
using GSF.ComponentModel;
using GSF.Configuration;
using GSF.Diagnostics;
using GSF.IO;
using GSF.Security;
using GSF.Security.Model;
using GSF.ServiceProcess;
using GSF.TimeSeries;
using GSF.Web;
using GSF.Web.Hosting;
using GSF.Web.Model;
using GSF.Web.Model.Handlers;
using GSF.Web.Security;
using GSF.Web.Shared;
using GSF.Web.Shared.Model;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Hosting;
using openPDC.Model;

namespace openPDC;

public class ServiceHost : ServiceHostBase
{
    #region [ Members ]

    // Nested Types
    private class ReturnValueState
    {
        public readonly ManualResetEventSlim WaitHandle = new(false);
        public string ReturnValue;
    }

    // Constants
    private const int DefaultMaximumDiagnosticLogSize = 10;

    // Events

    /// <summary>
    /// Raised when there is a new status message reported to service.
    /// </summary>
    public event EventHandler<EventArgs<Guid, string, UpdateType>> UpdatedStatus;

    /// <summary>
    /// Raised when there is a new exception logged to service.
    /// </summary>
    public event EventHandler<EventArgs<Exception>> LoggedException;

    // Fields
    private readonly ConcurrentDictionary<ClientRequestInfo, ReturnValueState> m_returnValueStates;
    private IDisposable m_webAppHost;
    private bool m_serviceStopping;
    private bool m_disposed;

    #endregion

    #region [ Constructors ]

    /// <summary>
    /// Creates a new <see cref="ServiceHost"/> instance.
    /// </summary>
    public ServiceHost()
    {
        ServiceName = "openPDC";
        
        RestoreEmbeddedResources();
        
        m_returnValueStates = new ConcurrentDictionary<ClientRequestInfo, ReturnValueState>();
    }

    #endregion

    #region [ Properties ]

    /// <summary>
    /// Gets the configured default web page for the application.
    /// </summary>
    public string DefaultWebPage
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the model used for the application.
    /// </summary>
    public AppModel Model
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets current performance statistics.
    /// </summary>
    public string PerformanceStatistics => ServiceHelper?.PerformanceMonitor?.Status;

    #endregion

    #region [ Methods ]

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="ServiceHost"/> object and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool disposing)
    {
        if (m_disposed)
            return;

        try
        {
            if (!disposing)
                return;
                
            m_webAppHost?.Dispose();
        }
        finally
        {
            m_disposed = true;       // Prevent duplicate dispose.
            base.Dispose(disposing); // Call base class Dispose().
        }
    }

    /// <summary>
    /// Event handler for service starting operations.
    /// </summary>
    /// <param name="sender">Event source.</param>
    /// <param name="e">Event arguments containing command line arguments passed into service at startup.</param>
    protected override void ServiceStartingHandler(object sender, EventArgs<string[]> e)
    {
        // Handle base class service starting procedures
        base.ServiceStartingHandler(sender, e);

        // Make sure openPDC specific default service settings exist
        CategorizedSettingsElementCollection systemSettings = ConfigurationFile.Current.Settings["systemSettings"];
        CategorizedSettingsElementCollection securityProvider = ConfigurationFile.Current.Settings["securityProvider"];

        // Define set of default anonymous web resources for this site
        const string DefaultAnonymousResourceExpression = "^/@|^/Scripts/|^/Content/|^/Images/|^/fonts/|^/favicon.ico$";

        systemSettings.Add("CompanyName", "Grid Protection Alliance", "The name of the company who owns this instance of the openPDC.");
        systemSettings.Add("CompanyAcronym", "GPA", "The acronym representing the company who owns this instance of the openPDC.");
        systemSettings.Add("DiagnosticLogPath", FilePath.GetAbsolutePath(""), "Path for diagnostic logs.");
        systemSettings.Add("MaximumDiagnosticLogSize", DefaultMaximumDiagnosticLogSize, "The combined maximum size for the diagnostic logs in whole Megabytes; curtailment happens hourly. Set to zero for no limit.");
        systemSettings.Add("WebHostingEnabled", true, "Flag that determines if the web hosting engine is enabled.");
        systemSettings.Add("WebHostURL", "http://+:8280", "The web hosting URL for remote system management.");
        systemSettings.Add("WebRootPath", "wwwroot", "The root path for the hosted web server files. Location will be relative to install folder if full path is not specified.");
        systemSettings.Add("DefaultWebPage", "Index.cshtml", "The default web page for the hosted web server.");
        systemSettings.Add("DateFormat", "MM/dd/yyyy", "The default date format to use when rendering timestamps.");
        systemSettings.Add("TimeFormat", "HH:mm:ss.fff", "The default time format to use when rendering timestamps.");
        systemSettings.Add("BootstrapTheme", "Content/bootstrap.min.css", "Path to Bootstrap CSS to use for rendering styles.");
        systemSettings.Add("SubscriptionConnectionString", "server=localhost:6165; interface=0.0.0.0", "Connection string for data subscriptions to openPDC server.");
        systemSettings.Add("AuthenticationSchemes", AuthenticationOptions.DefaultAuthenticationSchemes, "Comma separated list of authentication schemes to use for clients accessing the hosted web server, e.g., Basic or NTLM.");
        systemSettings.Add("AuthFailureRedirectResourceExpression", AuthenticationOptions.DefaultAuthFailureRedirectResourceExpression, "Expression that will match paths for the resources on the web server that should redirect to the LoginPage when authentication fails.");
        systemSettings.Add("AnonymousResourceExpression", DefaultAnonymousResourceExpression, "Expression that will match paths for the resources on the web server that can be provided without checking credentials.");
        systemSettings.Add("AuthenticationToken", SessionHandler.DefaultAuthenticationToken, "Defines the token used for identifying the authentication token in cookie headers.");
        systemSettings.Add("SessionToken", SessionHandler.DefaultSessionToken, "Defines the token used for identifying the session ID in cookie headers.");
        systemSettings.Add("RequestVerificationToken", AuthenticationOptions.DefaultRequestVerificationToken, "Defines the token used for anti-forgery verification in HTTP request headers.");
        systemSettings.Add("LoginPage", AuthenticationOptions.DefaultLoginPage, "Defines the login page used for redirects on authentication failure. Expects forward slash prefix.");
        systemSettings.Add("AuthTestPage", AuthenticationOptions.DefaultAuthTestPage, "Defines the page name for the web server to test if a user is authenticated. Expects forward slash prefix.");
        systemSettings.Add("Realm", "", "Case-sensitive identifier that defines the protection space for the web based authentication and is used to indicate a scope of protection.");
        systemSettings.Add("DefaultCorsOrigins", "", "Comma-separated list of allowed origins (including http:// prefix) that define the default CORS policy. Use '*' to allow all or empty string to disable CORS.");
        systemSettings.Add("DefaultCorsHeaders", "*", "Comma-separated list of supported headers that define the default CORS policy. Use '*' to allow all or empty string to allow none.");
        systemSettings.Add("DefaultCorsMethods", "*", "Comma-separated list of supported methods that define the default CORS policy. Use '*' to allow all or empty string to allow none.");
        systemSettings.Add("DefaultCorsSupportsCredentials", true, "Boolean flag for the default CORS policy indicating whether the resource supports user credentials in the request.");
        systemSettings.Add("NominalFrequency", 60, "Defines the nominal system frequency for this instance of the openPDC");
        systemSettings.Add("DefaultCalculationLagTime", 6.0, "Defines the default lag-time value, in seconds, for template calculations");
        systemSettings.Add("DefaultCalculationLeadTime", 3.0, "Defines the default lead-time value, in seconds, for template calculations");
        systemSettings.Add("DefaultCalculationFramesPerSecond", 30, "Defines the default frames-per-second value for template calculations");
        systemSettings.Add("SystemName", "", "Name of system that will be prefixed to system level tags, when defined. Value should follow tag naming conventions, e.g., no spaces and all upper case.");

        DefaultWebPage = systemSettings["DefaultWebPage"].Value;

        Model = new AppModel();
        Model.Global.CompanyName = systemSettings["CompanyName"].Value;
        Model.Global.CompanyAcronym = systemSettings["CompanyAcronym"].Value;
        Model.Global.NodeID = Guid.Parse(systemSettings["NodeID"].Value);
        Model.Global.SubscriptionConnectionString = systemSettings["SubscriptionConnectionString"].Value;
        Model.Global.ApplicationName = "openPDC";
        Model.Global.ApplicationDescription = "openPDC System";
        Model.Global.ApplicationKeywords = "open source, utility, software, time-series, archive";
        Model.Global.DateFormat = systemSettings["DateFormat"].Value;
        Model.Global.TimeFormat = systemSettings["TimeFormat"].Value;
        Model.Global.DateTimeFormat = $"{Model.Global.DateFormat} {Model.Global.TimeFormat}";
        Model.Global.PasswordRequirementsRegex = securityProvider["PasswordRequirementsRegex"].Value;
        Model.Global.PasswordRequirementsError = securityProvider["PasswordRequirementsError"].Value;
        Model.Global.BootstrapTheme = systemSettings["BootstrapTheme"].Value;
        Model.Global.WebRootPath = FilePath.GetAbsolutePath(systemSettings["WebRootPath"].Value);
        Model.Global.DefaultCorsOrigins = systemSettings["DefaultCorsOrigins"].Value;
        Model.Global.DefaultCorsHeaders = systemSettings["DefaultCorsHeaders"].Value;
        Model.Global.DefaultCorsMethods = systemSettings["DefaultCorsMethods"].Value;
        Model.Global.DefaultCorsSupportsCredentials = systemSettings["DefaultCorsSupportsCredentials"].ValueAsBoolean(true);
        Model.Global.NominalFrequency = systemSettings["NominalFrequency"].ValueAsInt32(60);
        Model.Global.DefaultCalculationLagTime = systemSettings["DefaultCalculationLagTime"].ValueAsDouble(6.0);
        Model.Global.DefaultCalculationLeadTime = systemSettings["DefaultCalculationLeadTime"].ValueAsDouble(3.0);
        Model.Global.DefaultCalculationFramesPerSecond = systemSettings["DefaultCalculationFramesPerSecond"].ValueAsInt32(30);
        Model.Global.SystemName = systemSettings["SystemName"].Value;

        // Register a symbolic reference to global settings for use by default value expressions
        ValueExpressionParser.DefaultTypeRegistry.RegisterSymbol("Global", Model.Global);

        // Parse configured authentication schemes
        if (!Enum.TryParse(systemSettings["AuthenticationSchemes"].ValueAs(AuthenticationOptions.DefaultAuthenticationSchemes.ToString()), true, out AuthenticationSchemes authenticationSchemes))
            authenticationSchemes = AuthenticationOptions.DefaultAuthenticationSchemes;

        // Initialize web startup configuration
        Startup.AuthenticationOptions.AuthenticationSchemes = authenticationSchemes;
        Startup.AuthenticationOptions.AuthFailureRedirectResourceExpression = systemSettings["AuthFailureRedirectResourceExpression"].ValueAs(AuthenticationOptions.DefaultAuthFailureRedirectResourceExpression);
        Startup.AuthenticationOptions.AnonymousResourceExpression = systemSettings["AnonymousResourceExpression"].ValueAs(DefaultAnonymousResourceExpression);
        Startup.AuthenticationOptions.AuthenticationToken = systemSettings["AuthenticationToken"].ValueAs(SessionHandler.DefaultAuthenticationToken);
        Startup.AuthenticationOptions.SessionToken = systemSettings["SessionToken"].ValueAs(SessionHandler.DefaultSessionToken);
        Startup.AuthenticationOptions.RequestVerificationToken = systemSettings["RequestVerificationToken"].ValueAs(AuthenticationOptions.DefaultRequestVerificationToken);
        Startup.AuthenticationOptions.LoginPage = systemSettings["LoginPage"].ValueAs(AuthenticationOptions.DefaultLoginPage);
        Startup.AuthenticationOptions.AuthTestPage = systemSettings["AuthTestPage"].ValueAs(AuthenticationOptions.DefaultAuthTestPage);
        Startup.AuthenticationOptions.Realm = systemSettings["Realm"].ValueAs("");
        Startup.AuthenticationOptions.LoginHeader = $"<h3><img src=\"/Images/{Model.Global.ApplicationName}.png\"/> {Model.Global.ApplicationName}</h3>";

        // Validate that configured authentication test page does not evaluate as an anonymous resource nor a authentication failure redirection resource
        string authTestPage = Startup.AuthenticationOptions.AuthTestPage;

        if (Startup.AuthenticationOptions.IsAnonymousResource(authTestPage))
            throw new SecurityException($"The configured authentication test page \"{authTestPage}\" evaluates as an anonymous resource. Modify \"AnonymousResourceExpression\" setting so that authorization test page is not a match.");

        if (Startup.AuthenticationOptions.IsAuthFailureRedirectResource(authTestPage))
            throw new SecurityException($"The configured authentication test page \"{authTestPage}\" evaluates as an authentication failure redirection resource. Modify \"AuthFailureRedirectResourceExpression\" setting so that authorization test page is not a match.");

        if (Startup.AuthenticationOptions.AuthenticationToken == Startup.AuthenticationOptions.SessionToken)
            throw new InvalidOperationException("Authentication token must be different from session token in order to differentiate the cookie values in the HTTP headers.");

        ServiceHelper.UpdatedStatus += UpdatedStatusHandler;
        ServiceHelper.LoggedException += LoggedExceptionHandler;

        if (systemSettings["WebHostingEnabled"].ValueAs(true))
        {
            Thread startWebServer = new Thread(() =>
            {
                try
                {
                    // Attach to default web server events
                    WebServer webServer = WebServer.Default;
                    webServer.StatusMessage += WebServer_StatusMessage;
                    webServer.ExecutionException += LoggedExceptionHandler;

                    // Define types for Razor pages - self-hosted web service does not use view controllers so
                    // we must define configuration types for all paged view model based Razor views here:
                    webServer.PagedViewModelTypes.TryAdd("Devices.cshtml", new Tuple<Type, Type>(typeof(Device), typeof(DataHub)));
                    webServer.PagedViewModelTypes.TryAdd("Companies.cshtml", new Tuple<Type, Type>(typeof(Company), typeof(SharedHub)));
                    webServer.PagedViewModelTypes.TryAdd("Vendors.cshtml", new Tuple<Type, Type>(typeof(Vendor), typeof(SharedHub)));
                    webServer.PagedViewModelTypes.TryAdd("VendorDevices.cshtml", new Tuple<Type, Type>(typeof(VendorDevice), typeof(SharedHub)));
                    webServer.PagedViewModelTypes.TryAdd("Users.cshtml", new Tuple<Type, Type>(typeof(UserAccount), typeof(SecurityHub)));
                    webServer.PagedViewModelTypes.TryAdd("Groups.cshtml", new Tuple<Type, Type>(typeof(SecurityGroup), typeof(SecurityHub)));
                }
                catch (Exception ex)
                {
                    LogException(new InvalidOperationException($"Failed during web-server initialization: {ex.Message}", ex));
                    return;
                }

                const int RetryDelay = 1000;
                const int SleepTime = 200;
                const int LoopCount = RetryDelay / SleepTime;

                while (!m_serviceStopping)
                {
                    if (TryStartWebHosting(systemSettings["WebHostURL"].Value))
                    {
                        try
                        {
                            Minifier _ = new Minifier();

                            // Initiate pre-compile of base templates
                            RazorEngine<CSharpEmbeddedResource>.Default.PreCompile(LogException, "GSF.Web.Security.Views.");
                            RazorEngine<CSharpEmbeddedResource>.Default.PreCompile(LogException, "GSF.Web.Shared.Views.");
                            RazorEngine<CSharpEmbeddedResource>.Default.PreCompile(LogException);
                            RazorEngine<CSharp>.Default.PreCompile(LogException);
                        }
                        catch (Exception ex)
                        {
                            LogException(new InvalidOperationException($"Failed to initiate pre-compile of razor templates: {ex.Message}", ex));
                        }
                            
                        break;
                    }

                    for (int i = 0; i < LoopCount && !m_serviceStopping; i++)
                        Thread.Sleep(SleepTime);
                }
            })
            {
                IsBackground = true
            };

            startWebServer.Start();
        }

        // Define exception logger for CSV downloader
        CsvDownloadHandler.LogExceptionHandler = LogException;
    }

    private bool TryStartWebHosting(string webHostURL)
    {
        try
        {
            // Create new web application hosting environment
            m_webAppHost = WebApp.Start<Startup>(webHostURL);
            return true;
        }
        catch (TargetInvocationException ex)
        {
            LogException(new InvalidOperationException($"Failed to initialize web hosting: {ex.InnerException?.Message ?? ex.Message}", ex.InnerException ?? ex));
            return false;
        }
        catch (Exception ex)
        {
            LogException(new InvalidOperationException($"Failed to initialize web hosting: {ex.Message}", ex));
            return false;
        }
    }

    protected override void ServiceStoppingHandler(object sender, EventArgs e)
    {
        m_serviceStopping = true;

        ServiceHelper helper = ServiceHelper;

        try
        {
            base.ServiceStoppingHandler(sender, e);
        }
        catch (Exception ex)
        {
            LogException(new InvalidOperationException($"Service stopping handler exception: {ex.Message}", ex));
        }

        if (!(helper is null))
        {
            helper.UpdatedStatus -= UpdatedStatusHandler;
            helper.LoggedException -= LoggedExceptionHandler;
        }
    }

    private void WebServer_StatusMessage(object sender, EventArgs<string> e)
    {
        LogWebHostStatusMessage(e.Argument);
    }

    public void LogWebHostStatusMessage(string message, UpdateType type = UpdateType.Information)
    {
        LogStatusMessage($"[WEBHOST] {message}", type);
    }

    /// <summary>
    /// Logs a status message to connected clients.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="type">Type of message to log.</param>
    public void LogStatusMessage(string message, UpdateType type = UpdateType.Information)
    {
        DisplayStatusMessage(message, type);
    }

    /// <summary>
    /// Logs an exception to the service.
    /// </summary>
    /// <param name="ex">Exception to log.</param>
    public new void LogException(Exception ex)
    {
        base.LogException(ex);
        DisplayStatusMessage($"{ex.Message}", UpdateType.Alarm);
    }

    /// <summary>
    /// Sends a command request to the service.
    /// </summary>
    /// <param name="clientID">Client ID of sender.</param>
    /// <param name="principal">The principal used for role-based security.</param>
    /// <param name="userInput">Request string.</param>
    /// <param name="expectsReturnValue">Flag that determines if a command return value is expected.</param>
    /// <param name="returnValueTimeout">Timeout for return value response.</param>
    /// <returns>
    /// A tuple representing the response to the request.
    /// </returns>
    /// <remarks>
    /// Setting <paramref name="expectsReturnValue"/> to <c>true</c> will block the calling thread
    /// until a response is received or the timeout is reached.
    /// </remarks>
    public (HttpStatusCode statusCode, string response) SendCommand(Guid clientID, IPrincipal principal, string userInput, bool expectsReturnValue = false, int returnValueTimeout = 5000)
    {
        ClientRequest request = ClientRequest.Parse(userInput);

        if (request is null)
            return (HttpStatusCode.BadRequest, "Request not recognized.");

        if (SecurityProviderUtility.IsResourceSecurable(request.Command) && !SecurityProviderUtility.IsResourceAccessible(request.Command, principal))
        {
            ServiceHelper.UpdateStatus(clientID, UpdateType.Alarm, $"Access to \"{request.Command}\" is denied for user \"{principal?.Identity?.Name}\".\r\n\r\n");
            return (HttpStatusCode.Unauthorized, $"Access to \"{request.Command}\" is denied.");
        }

        ClientRequestHandler requestHandler = ServiceHelper.FindClientRequestHandler(request.Command);

        if (requestHandler is null)
        {
            ServiceHelper.UpdateStatus(clientID, UpdateType.Alarm, $"Command \"{request.Command}\" is not supported.\r\n\r\n");
            return (HttpStatusCode.NotFound, $"Command \"{request.Command}\" is not supported.");
        }

        // Establish client info for the current user
        ClientInfo clientInfo = new() { ClientID = clientID };
        clientInfo.SetClientUser(principal);

        // Set up request info
        ClientRequestInfo requestInfo = new(clientInfo, request);
        string response = null;

        // If expecting a return value, set up a wait handle to wait for response
        if (expectsReturnValue)
        {
            // Establish wait handle and result for return value state
            ReturnValueState state = new();
            bool signaled;

            try
            {
                // Track per client + command return value state
                m_returnValueStates[requestInfo] = state;

                // Execute command request (return value expected)
                requestHandler.HandlerMethod(requestInfo);

                // Wait for command return value
                signaled = state.WaitHandle.Wait(returnValueTimeout);
            }
            finally
            {
                m_returnValueStates.TryRemove(requestInfo, out _);
            }

            if (!signaled)
                return (HttpStatusCode.RequestTimeout, "Command return value request timed out.");

            response = state.ReturnValue;
        }
        else
        {
            // Execute command request (no return value expected)
            requestHandler.HandlerMethod(requestInfo);
        }

        return (HttpStatusCode.OK, response ?? (expectsReturnValue ? "" : "Request succeeded."));
    }

    // Intercept responses to client requests to capture return value
    protected override void SendResponseWithAttachment(ClientRequestInfo requestInfo, bool success, object attachment, string status, params object[] args)
    {
        static string ToStringRepresentation(object value, string separator)
        {
            return value switch
            {
                null => "null",
                Array array => string.Join(separator, array.OfType<object>().Select(val => ToStringRepresentation(val, " "))),
                _ => value.ToString()
            };
        }

        // Look for requests that were generated locally
        if (m_returnValueStates.TryGetValue(requestInfo, out ReturnValueState state) && state is not null)
        {
            state.ReturnValue = ToStringRepresentation(attachment, ",");
            state.WaitHandle?.Set();
        }

        base.SendResponseWithAttachment(requestInfo, success, attachment, status, args);
    }

    public void DisconnectClient(Guid clientID)
    {
        ServiceHelper.DisconnectClient(clientID);
    }

    private void UpdatedStatusHandler(object sender, EventArgs<Guid, string, UpdateType> e)
    {
        UpdatedStatus?.Invoke(sender, new EventArgs<Guid, string, UpdateType>(e.Argument1, e.Argument2, e.Argument3));
    }

    private void LoggedExceptionHandler(object sender, EventArgs<Exception> e)
    {
        LoggedException?.Invoke(sender, new EventArgs<Exception>(e.Argument));
    }

    #endregion

    #region [ Static ]

    internal static void RestoreEmbeddedResources()
    {
        try
        {
            // Access GSF.Web so its embedded resources can be restored on assembly load via the ModuleInitializer,
            // then ensure that NUglify.dll is loaded into the application domain in advance of web hosting startup
            // so it can be referenced by the Login.cshtml page during RazorEngine compilation - this corrects an
            // order of operations issue where NUglify.dll is not yet loaded when the Login.cshtml page is compiled
            if (WebExtensions.EmbeddedResourceExists("GSF.Web.NUglify.dll"))
                Assembly.LoadFrom(FilePath.GetAbsolutePath("NUglify.dll"));
        }
        catch (Exception ex)
        {
            LogMessage(MessageLevel.Error, nameof(RestoreEmbeddedResources), "Failed to pre-load NUglify embedded resource assembly", null, ex);
        }
    }

    private static void LogMessage(MessageLevel level, string eventName, string message, string details = null, Exception ex = null)
    {
        LogPublisher log = Logger.CreatePublisher(typeof(ServiceHost), MessageClass.Application);
        log.Publish(level, eventName, message, details, ex);
    }

    #endregion
}
