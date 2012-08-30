<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="openPDCManager.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>openPDC Manager</title>
    <link href="Styles/WebStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Silverlight.js"></script>
    
    <script type="text/javascript">
        var PromptUpgrade = "<p align='center'><br /><b>To view this web application you need to upgrade to a new version of <i>Microsoft Silverlight</i> by<br />" +
		                    "clicking the button below.</b><br /><br /><a href='http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0' " +
		                    "style='text-decoration:none'><img src='Images/NoSilverlight.jpg' alt='Get Microsoft Silverlight' style='border: " +
		                    "solid 2px #FFFFFF;' /></a><br /><br /><b>When installation is complete, restart your browser to activate Silverlight " +
		                    "content.</b></p>";
        var PromptInstall = "<p align='center'><br /><b>To view this web application you need to install <i>Microsoft Silverlight</i> by<br />" +
		                    "clicking the button below.</b><br /><br /><a href='http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0' " +
		                    "style='text-decoration:none'><img src='Images/NoSilverlight.jpg' alt='Get Microsoft Silverlight' style='border: " +
		                    "solid 2px #FFFFFF;' /></a><br /><br /><b>When installation is complete, restart your browser to activate Silverlight " +
		                    "content.</b></p>";            
		            
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
              appSource = sender.getHost().Source;
            }
            
            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
              return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " +  appSource + "\n" ;

            errMsg += "Code: "+ iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {           
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " +  args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
        function onSilverlightLoad(sender) {
            Silverlight.IsVersionAvailableOnLoad(sender); 
        }
        Silverlight.onUpgradeRequired = function() {
        document.getElementById("silverlightControlHost").innerHTML = PromptUpgrade;
        };
        Silverlight.onInstallRequired = function() {
        document.getElementById("silverlightControlHost").innerHTML = PromptInstall;
        };
    </script>
    
    <script type="text/javascript">
        window.onresize = resizeContent;
        function resizeContent() {
            var e = new Object();

            if (window.self && self.innerWidth) {
                e.width = self.innerWidth;
                e.height = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                e.width = document.documentElement.clientWidth;
                e.height = document.documentElement.clientHeight;
            }
            else {
                e.width = document.body.clientWidth;
                e.height = document.body.clientHeight;
            }

            //alert(e.height.toString() + "px");
            document.getElementById("form1").style.width = e.width.toString() + "px";
            document.getElementById("form1").style.height = e.height.toString() + "px";
        }
        
    </script>
        
</head>
<body onload="javascript:resizeContent();">
    <form id="form1" runat="server">        <!-- style="width:100%; height:100%;"> -->
        <div id="silverlightControlHost" style="height: 99%; width: 100%;">
            <object id="PcsSilverlightApp" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">            
		        <param name="source" value="ClientBin/openPDCManager.Silverlight.xap"/>
		        <param name="onError" value="onSilverlightError" />		        
		        <param name="onload" value="onSilverlightLoad" />
		        <param name="minRuntimeVersion" value="3.0.40624.0" />
		        <param name="autoUpgrade" value="true" />
		        <param name="initParams" value="BaseServiceUrl=<%=GetBaseServiceUrl %>,BingMapsKey=<%=GetBingMapsKey %>" />			        
		        <div id="SilverlightMessage">		  
		            <p align='center'>
		                <br />
		                <b>To view this web application you need to install <i>Microsoft Silverlight</i> by
		                <br /> 
		                clicking the button below.</b>
		                <br /><br />
		                <a href='http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0' style='text-decoration:none'>
		                    <img src='Images/NoSilverlight.jpg' alt='Get Microsoft Silverlight' style='border: solid 2px #FFFFFF;' />
		                </a>
		                <br /><br />
		                <b>When installation is complete, restart your browser to activate Silverlight content.</b>
		            </p>         
		        </div>
	        </object>
	        <iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"/>
	    </div>        
    </form>
</body>
</html>
