<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>2012 GPA Tutorial and User's Forum</title>
<link id="cc-layout-css" href="https://imgssl.constantcontact.com/ced/layouts/layout-1.css?version=2012.6.0-20120726.140749" rel="stylesheet" type="text/css" />
<link id="cc-base-css" href="https://imgssl.constantcontact.com/ced/themes/base.css?version=2012.6.0-20120726.140749" rel="stylesheet" type="text/css" />
<link id="cc-theme-css" href="https://imgssl.constantcontact.com/ced/themes/custom/custom.css?version=2012.6.0-20120726.140749" rel="stylesheet" type="text/css" />
<meta name="keywords" content="pmu,open source,atlanta,gpa,phasor,users group,tutorial" />
<script type="text/javascript">(window.NREUM||(NREUM={})).loader_config={xpid:"UwYAV1BACQQFXVdbAQ=="};window.NREUM||(NREUM={}),__nr_require=function(t,e,n){function r(n){if(!e[n]){var o=e[n]={exports:{}};t[n][0].call(o.exports,function(e){var o=t[n][1][e];return r(o?o:e)},o,o.exports)}return e[n].exports}if("function"==typeof __nr_require)return __nr_require;for(var o=0;o<n.length;o++)r(n[o]);return r}({QJf3ax:[function(t,e){function n(t){function e(e,n,a){t&&t(e,n,a),a||(a={});for(var c=s(e),u=c.length,f=i(a,o,r),d=0;u>d;d++)c[d].apply(f,n);return f}function a(t,e){u[t]=s(t).concat(e)}function s(t){return u[t]||[]}function c(){return n(e)}var u={};return{on:a,emit:e,create:c,listeners:s,_events:u}}function r(){return{}}var o="nr@context",i=t("gos");e.exports=n()},{gos:"7eSDFh"}],ee:[function(t,e){e.exports=t("QJf3ax")},{}],3:[function(t){function e(t){try{i.console&&console.log(t)}catch(e){}}var n,r=t("ee"),o=t(1),i={};try{n=localStorage.getItem("__nr_flags").split(","),console&&"function"==typeof console.log&&(i.console=!0,-1!==n.indexOf("dev")&&(i.dev=!0),-1!==n.indexOf("nr_dev")&&(i.nrDev=!0))}catch(a){}i.nrDev&&r.on("internal-error",function(t){e(t.stack)}),i.dev&&r.on("fn-err",function(t,n,r){e(r.stack)}),i.dev&&(e("NR AGENT IN DEVELOPMENT MODE"),e("flags: "+o(i,function(t){return t}).join(", ")))},{1:20,ee:"QJf3ax"}],4:[function(t){function e(t,e,n,i,s){try{c?c-=1:r("err",[s||new UncaughtException(t,e,n)])}catch(u){try{r("ierr",[u,(new Date).getTime(),!0])}catch(f){}}return"function"==typeof a?a.apply(this,o(arguments)):!1}function UncaughtException(t,e,n){this.message=t||"Uncaught error with no additional information",this.sourceURL=e,this.line=n}function n(t){r("err",[t,(new Date).getTime()])}var r=t("handle"),o=t(6),i=t("ee"),a=window.onerror,s=!1,c=0;t("loader").features.err=!0,t(3),window.onerror=e;try{throw new Error}catch(u){"stack"in u&&(t(4),t(5),"addEventListener"in window&&t(1),window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)&&t(2),s=!0)}i.on("fn-start",function(){s&&(c+=1)}),i.on("fn-err",function(t,e,r){s&&(this.thrown=!0,n(r))}),i.on("fn-end",function(){s&&!this.thrown&&c>0&&(c-=1)}),i.on("internal-error",function(t){r("ierr",[t,(new Date).getTime(),!0])})},{1:5,2:8,3:3,4:7,5:6,6:21,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],5:[function(t,e){function n(t){i.inPlace(t,["addEventListener","removeEventListener"],"-",r)}function r(t){return t[1]}var o=t("ee").create(),i=t(1)(o),a=t("gos");if(e.exports=o,n(window),"getPrototypeOf"in Object){for(var s=document;s&&!s.hasOwnProperty("addEventListener");)s=Object.getPrototypeOf(s);s&&n(s);for(var c=XMLHttpRequest.prototype;c&&!c.hasOwnProperty("addEventListener");)c=Object.getPrototypeOf(c);c&&n(c)}else XMLHttpRequest.prototype.hasOwnProperty("addEventListener")&&n(XMLHttpRequest.prototype);o.on("addEventListener-start",function(t){if(t[1]){var e=t[1];"function"==typeof e?this.wrapped=t[1]=a(e,"nr@wrapped",function(){return i(e,"fn-",null,e.name||"anonymous")}):"function"==typeof e.handleEvent&&i.inPlace(e,["handleEvent"],"fn-")}}),o.on("removeEventListener-start",function(t){var e=this.wrapped;e&&(t[1]=e)})},{1:22,ee:"QJf3ax",gos:"7eSDFh"}],6:[function(t,e){var n=t("ee").create(),r=t(1)(n);e.exports=n,r.inPlace(window,["requestAnimationFrame","mozRequestAnimationFrame","webkitRequestAnimationFrame","msRequestAnimationFrame"],"raf-"),n.on("raf-start",function(t){t[0]=r(t[0],"fn-")})},{1:22,ee:"QJf3ax"}],7:[function(t,e){function n(t,e,n){t[0]=o(t[0],"fn-",null,n)}var r=t("ee").create(),o=t(1)(r);e.exports=r,o.inPlace(window,["setTimeout","setInterval","setImmediate"],"setTimer-"),r.on("setTimer-start",n)},{1:22,ee:"QJf3ax"}],8:[function(t,e){function n(){u.inPlace(this,p,"fn-")}function r(t,e){u.inPlace(e,["onreadystatechange"],"fn-")}function o(t,e){return e}function i(t,e){for(var n in t)e[n]=t[n];return e}var a=t("ee").create(),s=t(1),c=t(2),u=c(a),f=c(s),d=window.XMLHttpRequest,p=["onload","onerror","onabort","onloadstart","onloadend","onprogress","ontimeout"];e.exports=a,window.XMLHttpRequest=function(t){var e=new d(t);try{a.emit("new-xhr",[],e),f.inPlace(e,["addEventListener","removeEventListener"],"-",o),e.addEventListener("readystatechange",n,!1)}catch(r){try{a.emit("internal-error",[r])}catch(i){}}return e},i(d,XMLHttpRequest),XMLHttpRequest.prototype=d.prototype,u.inPlace(XMLHttpRequest.prototype,["open","send"],"-xhr-",o),a.on("send-xhr-start",r),a.on("open-xhr-start",r)},{1:5,2:22,ee:"QJf3ax"}],9:[function(t){function e(t){var e=this.params,r=this.metrics;if(!this.ended){this.ended=!0;for(var i=0;c>i;i++)t.removeEventListener(s[i],this.listener,!1);if(!e.aborted){if(r.duration=(new Date).getTime()-this.startTime,4===t.readyState){e.status=t.status;var a=t.responseType,u="arraybuffer"===a||"blob"===a||"json"===a?t.response:t.responseText,f=n(u);if(f&&(r.rxSize=f),this.sameOrigin){var d=t.getResponseHeader("X-NewRelic-App-Data");d&&(e.cat=d.split(", ").pop())}}else e.status=0;r.cbTime=this.cbTime,o("xhr",[e,r,this.startTime])}}}function n(t){if("string"==typeof t&&t.length)return t.length;if("object"!=typeof t)return void 0;if("undefined"!=typeof ArrayBuffer&&t instanceof ArrayBuffer&&t.byteLength)return t.byteLength;if("undefined"!=typeof Blob&&t instanceof Blob&&t.size)return t.size;if("undefined"!=typeof FormData&&t instanceof FormData)return void 0;try{return JSON.stringify(t).length}catch(e){return void 0}}function r(t,e){var n=i(e),r=t.params;r.host=n.hostname+":"+n.port,r.pathname=n.pathname,t.sameOrigin=n.sameOrigin}if(window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)){t("loader").features.xhr=!0;var o=t("handle"),i=t(2),a=t("ee"),s=["load","error","abort","timeout"],c=s.length,u=t(1);t(4),t(3),a.on("new-xhr",function(){this.totalCbs=0,this.called=0,this.cbTime=0,this.end=e,this.ended=!1,this.xhrGuids={}}),a.on("open-xhr-start",function(t){this.params={method:t[0]},r(this,t[1]),this.metrics={}}),a.on("open-xhr-end",function(t,e){"loader_config"in NREUM&&"xpid"in NREUM.loader_config&&this.sameOrigin&&e.setRequestHeader("X-NewRelic-ID",NREUM.loader_config.xpid)}),a.on("send-xhr-start",function(t,e){var r=this.metrics,o=t[0],i=this;if(r&&o){var u=n(o);u&&(r.txSize=u)}this.startTime=(new Date).getTime(),this.listener=function(t){try{"abort"===t.type&&(i.params.aborted=!0),("load"!==t.type||i.called===i.totalCbs&&(i.onloadCalled||"function"!=typeof e.onload))&&i.end(e)}catch(n){try{a.emit("internal-error",[n])}catch(r){}}};for(var f=0;c>f;f++)e.addEventListener(s[f],this.listener,!1)}),a.on("xhr-cb-time",function(t,e,n){this.cbTime+=t,e?this.onloadCalled=!0:this.called+=1,this.called!==this.totalCbs||!this.onloadCalled&&"function"==typeof n.onload||this.end(n)}),a.on("xhr-load-added",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&!this.xhrGuids[n]&&(this.xhrGuids[n]=!0,this.totalCbs+=1)}),a.on("xhr-load-removed",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&this.xhrGuids[n]&&(delete this.xhrGuids[n],this.totalCbs-=1)}),a.on("addEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-added",[t[1],t[2]],e)}),a.on("removeEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-removed",[t[1],t[2]],e)}),a.on("fn-start",function(t,e,n){e instanceof XMLHttpRequest&&("onload"===n&&(this.onload=!0),("load"===(t[0]&&t[0].type)||this.onload)&&(this.xhrCbStart=(new Date).getTime()))}),a.on("fn-end",function(t,e){this.xhrCbStart&&a.emit("xhr-cb-time",[(new Date).getTime()-this.xhrCbStart,this.onload,e],e)})}},{1:"XL7HBI",2:10,3:8,4:5,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],10:[function(t,e){e.exports=function(t){var e=document.createElement("a"),n=window.location,r={};e.href=t,r.port=e.port;var o=e.href.split("://");return!r.port&&o[1]&&(r.port=o[1].split("/")[0].split("@").pop().split(":")[1]),r.port&&"0"!==r.port||(r.port="https"===o[0]?"443":"80"),r.hostname=e.hostname||n.hostname,r.pathname=e.pathname,r.protocol=o[0],"/"!==r.pathname.charAt(0)&&(r.pathname="/"+r.pathname),r.sameOrigin=!e.hostname||e.hostname===document.domain&&e.port===n.port&&e.protocol===n.protocol,r}},{}],11:[function(t,e){function n(t){return function(){r(t,[(new Date).getTime()].concat(i(arguments)))}}var r=t("handle"),o=t(1),i=t(2);"undefined"==typeof window.newrelic&&(newrelic=window.NREUM);var a=["setPageViewName","addPageAction","setCustomAttribute","finished","addToTrace","inlineHit","noticeError"];o(a,function(t,e){window.NREUM[e]=n("api-"+e)}),e.exports=window.NREUM},{1:20,2:21,handle:"D5DuLP"}],gos:[function(t,e){e.exports=t("7eSDFh")},{}],"7eSDFh":[function(t,e){function n(t,e,n){if(r.call(t,e))return t[e];var o=n();if(Object.defineProperty&&Object.keys)try{return Object.defineProperty(t,e,{value:o,writable:!0,enumerable:!1}),o}catch(i){}return t[e]=o,o}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],D5DuLP:[function(t,e){function n(t,e,n){return r.listeners(t).length?r.emit(t,e,n):void(r.q&&(r.q[t]||(r.q[t]=[]),r.q[t].push(e)))}var r=t("ee").create();e.exports=n,n.ee=r,r.q={}},{ee:"QJf3ax"}],handle:[function(t,e){e.exports=t("D5DuLP")},{}],XL7HBI:[function(t,e){function n(t){var e=typeof t;return!t||"object"!==e&&"function"!==e?-1:t===window?0:i(t,o,function(){return r++})}var r=1,o="nr@id",i=t("gos");e.exports=n},{gos:"7eSDFh"}],id:[function(t,e){e.exports=t("XL7HBI")},{}],G9z0Bl:[function(t,e){function n(){var t=p.info=NREUM.info,e=u.getElementsByTagName("script")[0];if(t&&t.licenseKey&&t.applicationID&&e){s(d,function(e,n){e in t||(t[e]=n)});var n="https"===f.split(":")[0]||t.sslForHttp;p.proto=n?"https://":"http://",a("mark",["onload",i()]);var r=u.createElement("script");r.src=p.proto+t.agent,e.parentNode.insertBefore(r,e)}}function r(){"complete"===u.readyState&&o()}function o(){a("mark",["domContent",i()])}function i(){return(new Date).getTime()}var a=t("handle"),s=t(1),c=window,u=c.document;t(2);var f=(""+location).split("?")[0],d={beacon:"bam.nr-data.net",errorBeacon:"bam.nr-data.net",agent:"js-agent.newrelic.com/nr-686.min.js"},p=e.exports={offset:i(),origin:f,features:{}};u.addEventListener?(u.addEventListener("DOMContentLoaded",o,!1),c.addEventListener("load",n,!1)):(u.attachEvent("onreadystatechange",r),c.attachEvent("onload",n)),a("mark",["firstbyte",i()])},{1:20,2:11,handle:"D5DuLP"}],loader:[function(t,e){e.exports=t("G9z0Bl")},{}],20:[function(t,e){function n(t,e){var n=[],o="",i=0;for(o in t)r.call(t,o)&&(n[i]=e(o,t[o]),i+=1);return n}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],21:[function(t,e){function n(t,e,n){e||(e=0),"undefined"==typeof n&&(n=t?t.length:0);for(var r=-1,o=n-e||0,i=Array(0>o?0:o);++r<o;)i[r]=t[e+r];return i}e.exports=n},{}],22:[function(t,e){function n(t){return!(t&&"function"==typeof t&&t.apply&&!t[i])}var r=t("ee"),o=t(1),i="nr@wrapper",a=Object.prototype.hasOwnProperty;e.exports=function(t){function e(t,e,r,a){function nrWrapper(){var n,i,s,u;try{i=this,n=o(arguments),s=r&&r(n,i)||{}}catch(d){f([d,"",[n,i,a],s])}c(e+"start",[n,i,a],s);try{return u=t.apply(i,n)}catch(p){throw c(e+"err",[n,i,p],s),p}finally{c(e+"end",[n,i,u],s)}}return n(t)?t:(e||(e=""),nrWrapper[i]=!0,u(t,nrWrapper),nrWrapper)}function s(t,r,o,i){o||(o="");var a,s,c,u="-"===o.charAt(0);for(c=0;c<r.length;c++)s=r[c],a=t[s],n(a)||(t[s]=e(a,u?s+o:o,i,s))}function c(e,n,r){try{t.emit(e,n,r)}catch(o){f([o,e,n,r])}}function u(t,e){if(Object.defineProperty&&Object.keys)try{var n=Object.keys(t);return n.forEach(function(n){Object.defineProperty(e,n,{get:function(){return t[n]},set:function(e){return t[n]=e,e}})}),e}catch(r){f([r])}for(var o in t)a.call(t,o)&&(e[o]=t[o]);return e}function f(e){try{t.emit("internal-error",e)}catch(n){}}return t||(t=r),e.inPlace=s,e.flag=i,e}},{1:21,ee:"QJf3ax"}]},{},["G9z0Bl",4,9]);</script><meta name="description" content="The second annual GPA Tutorial and User�s Forum is scheduled for August 21 and 22, 2012, and will be hosted by NERC at their offices in Atlanta, Georgia.  Day 1 is a deep dive into GPA open source libraries and products. Day 2 will focus on phasor gateways (GEP) and openPDC.  Lunch will be provided on both days with a reception on Tuesday night." /><script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.17/jquery-ui.min.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function() {
            jQuery('span').attr('title', '');
            jQuery('.cc-footer').css('display', 'none');
        });
    </script>
    <script type="text/javascript" src="/core/components/uxCommon/cc.overlay.js?20140602110824"></script>
<script type="text/javascript" src="/core/js/jquery/1.5.2/plugins/jquery.ux.infoPopup.js?20140602110824"></script>
<link href="/core/css/jquery/1.5.2/plugins/jquery.ux.infoPopup.css?20140602110824" media="all" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="/resource/js/evp/common/frameworks/jquery/plugin/validate/jquery.validate.min.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/util/util-lang.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/util/util-log.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/util/util-component.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/util/util-select.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/util/util-context.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/data.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/ui.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/user/tracking.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/common/global.js?20140602110824"></script>
<link href="/resource/css/evp/common/event/component/payment/option/propay/propay-common.css?20140602110824" rel="stylesheet" type="text/css" media="all"/>
<link href="/resource/css/evp/common/global.css?20140602110824" rel="stylesheet" type="text/css" media="all"/>
<script type="text/javascript" src="/resource/js/evp/registrant/global.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/event/component/registrants/registrants.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/event/component/payment/option/propay/propay.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/workflow/review/review.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/decline/workflow/so/decline.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/register/items.js?20140602110824"></script>
<script type="text/javascript" src="/resource/js/evp/registrant/register/registration.js?20140602110824"></script>
<link href="/resource/css/evp/registrant/global.css?20140602110824" rel="stylesheet" type="text/css" media="all"/>
<link href="/resource/css/evp/registrant/event/component/registrants.css?20140602110824" rel="stylesheet" type="text/css" media="all"/>
<link href="/resource/css/evp/registrant/event/component/payment/option/propay.css?20140602110824" rel="stylesheet" type="text/css" media="all"/>
<script type="text/javascript">
    evp.common.context.addConfig({
        model : {
            defaultRequestData : {
                'oeidk' : 'a07e61z27h2169407fe'
            }
        }
    });
</script>
</head>
<body id="a07e61z27h71">
<!--HtmlToGmd.Body-->
<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>
<hr />
<div id="NavigationMenu">
<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">
<tr>
<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>
</tr>
</table>
</div>
<hr />
<!--/HtmlToGmd.Body-->
<div class="cc-document" id="cc-container">
    <div id="cc-branding-outer">
    <div class="cc-panel" id="cc-branding-inner">
    <div id="cc-block6" class="cc-block">
<P><IMG title="GPA, improving the reliability and resiliency of the electric grid." border=0 hspace=8 alt="GPA, improving the reliability and resiliency of the electric grid." vspace=6 align=center src="https://origin.ih.constantcontact.com/fs096/1106162504898/img/2.jpg" width=528 height=148></P>
</div>
</div>
<div id="cc-positioned-1">
    
</div>
<div id="cc-positioned-2">
    
</div>
</div>
<div id="cc-content-outer">
    <div id="cc-content-inner">
    <div id="cc-positioned-3">
    
</div>
<div id="cc-positioned-4">
    
</div>
<div id="cc-content-sub-outer">
    <div class="cc-panel" id="cc-content-sub-inner">
    <div id="cc-block7" class="cc-block">
<H3 style="FONT-FAMILY: Helvetica, Arial, sans-serif; COLOR: #3c3c3c"><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">Contact</SPAN></H3><SPAN class=cc-var title=Event.contactName>Brenda Moses</SPAN>&nbsp;<BR><SPAN class=cc-var title=Event.contactOrganization>Grid Protection Alliance</SPAN>&nbsp;<BR><SPAN class=cc-var title=Event.contactEmail>bjmoses@gridprotectionalliance.org</SPAN>&nbsp;<BR>(423) 973-4731<BR>
</div>
<div id="cc-block8" class="cc-block">
<H3 style="FONT-FAMILY: Helvetica, Arial, sans-serif; COLOR: #3c3c3c"><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">When</SPAN></H3>
<P><SPAN style="COLOR: #339966; FONT-SIZE: 18pt"><STRONG>August 21 and 22, 2012</STRONG></SPAN></P>
<P><SPAN style="COLOR: #339966; FONT-SIZE: 18pt"></SPAN><SPAN class=cc-var title=Event.addToCalendarLink><a title="Add to my calendar" id="lnkAddToCalendar" href="http://events.r20.constantcontact.com/register/addtocalendar?oeidk=a07e61z27h2169407fe" class="cc-calendar">Add to my calendar</a></SPAN>&nbsp;</P>
</div>
<div id="cc-block9" class="cc-block">
<H3 style="FONT-FAMILY: Helvetica, Arial, sans-serif; COLOR: #3c3c3c"><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">Where</SPAN></H3>
<P>NERC - Atlanta Office<BR><SPAN class=cc-var title=Event.addressHtml>3353 Peachtree Road NE<br />Suite 600, North Tower<br />Atlanta, GA 30326</SPAN>&nbsp;<BR><SPAN style="COLOR: #993300">Location Provided by </SPAN><SPAN style="COLOR: #993300">NERC </SPAN><SPAN class=cc-var title=Event.map><img height="200" width="200" src="https://api.tiles.virtualearth.net/api/GetMap.ashx?ppl=24,,33.84816,-84.366806&amp;z=12&amp;h=200&amp;w=200
          " /></SPAN>&nbsp;<BR><SPAN style="COLOR: #993300" class=cc-var title=Event.googleDrivingDirectionsNoStyle><a title="Driving Directions" id="idDrivingDir" href="http://maps.google.com/maps?daddr=3353 Peachtree Road NE, Suite 600, North Tower, Atlanta, GA, 30326, US" target="_blank">Driving Directions</a></SPAN>&nbsp;&nbsp;</P>
<P><CITE><A style="COLOR: #3c3c3c" href="http://www.nerc.com/files/Atlanta_Office_Fact_Sheet.pdf" target=_blank>www.<B>nerc</B>.com/files/<B>Atlanta</B>_<B>Office</B>_Fact_Sheet.pdf</A></CITE></P>
<P><SPAN style="FONT-SIZE: 14pt"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif"><SPAN style="TEXT-DECORATION: underline"><SPAN style="COLOR: #993300; TEXT-DECORATION: underline"><B>Industry Speakers Include</B></SPAN></SPAN><SPAN style="COLOR: #993300"><B></B></SPAN><SPAN style="COLOR: #993300"><STRONG>:</STRONG></SPAN><STRONG>&nbsp;</STRONG>&nbsp;</SPAN><B>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN></P>
<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><B>Alstom Power&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN><SPAN style="COLOR: #008000; FONT-SIZE: 12pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <SPAN style="FONT-SIZE: 10pt">Barbara Motteler</SPAN></SPAN></P>
<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><SPAN style="FONT-SIZE: 10pt"></SPAN></SPAN><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><B>Dominion Virginia Power&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">Kyle Thomas / </SPAN><SPAN style="COLOR: #008000">Kevin Jones</SPAN></SPAN></P>
<P><SPAN style="FONT-SIZE: 12pt"><STRONG><SPAN style="COLOR: #008000">Entergy&nbsp;</SPAN></STRONG></SPAN><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <SPAN style="FONT-SIZE: 10pt">Rubal KC</SPAN></SPAN></P>
<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><B><SPAN style="COLOR: #008000"><SPAN style="FONT-SIZE: 12pt"><B>New England ISO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN></SPAN></B></SPAN><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000">Qiang 'Frankie'</SPAN></SPAN><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000"> Zhang</SPAN></SPAN><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000"> </SPAN></SPAN></SPAN></P>
<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><B><SPAN style="COLOR: #008000">Oklahoma Gas and Electric&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></B><SPAN style="COLOR: #008000; FONT-SIZE: 10pt">Stephen Chisholm</SPAN></SPAN></P>
<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><B><SPAN style="COLOR: #008000">T</SPAN>ennessee Valley Authority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN><SPAN style="COLOR: #008000; FONT-SIZE: 10pt">Theo&nbsp;Laughner</SPAN></P>
<P><SPAN style="COLOR: #008000"><SPAN style="FONT-SIZE: 12pt"><STRONG><STRONG><SPAN style="COLOR: #008000; FONT-SIZE: 12pt">Washington State University &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></STRONG></STRONG></SPAN></SPAN><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">Mani</SPAN><SPAN style="COLOR: #008000"> Venkatasubramanian</SPAN></SPAN></P>
<P><SPAN style="COLOR: #008000"><SPAN style="FONT-SIZE: 12pt"><STRONG>Western Electric Coordinating Council </STRONG></SPAN><SPAN style="FONT-SIZE: 10pt">Godfrey Capiral</SPAN></SPAN></P>
<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif"><SPAN style="TEXT-DECORATION: underline"><STRONG><SPAN style="COLOR: #993300; TEXT-DECORATION: underline"><SPAN style="FONT-SIZE: 14pt"><SPAN style="TEXT-DECORATION: underline"><SPAN style="COLOR: #993300; TEXT-DECORATION: underline"><B>Tuitorial Highlights</B></SPAN></SPAN></SPAN></SPAN></STRONG></SPAN><STRONG><SPAN style="COLOR: #993300"><SPAN style="FONT-SIZE: 14pt"><SPAN style="COLOR: #993300"><B>:</B></SPAN></SPAN></SPAN></STRONG></SPAN></P>
<UL>
<LI style="TEXT-ALIGN: left; COLOR: #008000; FONT-SIZE: 11pt" align="left">Deploying custom calculations and action adapters</LI>
<LI style="TEXT-ALIGN: left; COLOR: #008000; FONT-SIZE: 11pt" align="left">Developing new adapters and calculations </LI>
<LI style="TEXT-ALIGN: left; COLOR: #008000; FONT-SIZE: 11pt" align="left">Extended code level overview of Time Series Framework</LI>
<LI style="TEXT-ALIGN: left; COLOR: #008000; FONT-SIZE: 11pt" align="left">Establishing a distributed archive</LI></UL>
<P style="TEXT-ALIGN: left; COLOR: #008000; FONT-SIZE: 11pt">&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
<P>&nbsp;</P>
</div>
</div>
</div>
<div class="cc-panel" id="cc-content">
    <div id="cc-block1" class="cc-block">
<P><STRONG><SPAN style="FONT-SIZE: 18pt"><SPAN style="COLOR: #008000">2012 Grid Protection Alliance (GPA) Tutorial and User's Forum</SPAN></SPAN></STRONG></P>
</div>
<div id="cc-block2" class="cc-block">
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">GPA is pleased to invite you to participate in (1) a full-day <B>Technical Tutorial</B> on developing the code neccessary to&nbsp;extend GPA products and/or (2) the <B>User&#8217;s Forum</B> for GPA&#8217;s open source projects, including the Open Time Series Framework (openTSF), Open Phasor Data Concentrator (openPDC), and Open Phasor Gateway (openPG), to be held on August 21 and 22, 2012, at NERC&#8217;s Atlanta Offices.</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">The GPA Technical Tutorial on August 21 from 8 a.m. to 5 p.m., is a deep dive into GPA open source libraries and products and is intended for C# developers looking to deploy and/or enhance them. Participating in this session is a good way to learn more about the openTSF. &nbsp;The openTSF can be used to process and manage streaming of time-stamped data through a collection of configurable adapter components. &nbsp;Developers will gain a working knowledge of the framework, which will enable them to extend existing modules or develop new modules to add to open libraries.</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">The GPA User's Forum on August 22 from 8 a.m. to 3 p.m., provides an opportunity for GPA product users to share implementation examples with one another.&nbsp; This session will educate those that are new to GPA open source projects, inform developers about new software components, and provide insight from the industry on the practical application of the openTSF, openPDC, and openPG. &nbsp;&nbsp;Input collected during the GPA User&#8217;s Forum will be used to help prioritize GPA&#8217;s development work in 2013.</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">GPA provides and supports software solutions for the electric utility industry. &nbsp;Our mission is to improve the reliability and resiliency of the electric grid, through state-of-the-art applications. &nbsp;All GPA software products are open source.&nbsp; As a not-for-profit corporation, GPA seeks to build collaborative relationships among government agencies, regulators, vendors, and grid owner-operators. &nbsp;These GPA efforts incorporate and improve technologies to create a more secure, more robust, and smarter electric grid.</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">To download or get more information on GPA products, go to:</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt"><A style="COLOR: #3c3c3c" href="http://timeseriesframework.codeplex.com/"><B>http:\\timeseriesframework.codeplex.com</B></A></SPAN><BR><SPAN style="COLOR: #000000; FONT-SIZE: 10pt"><A style="COLOR: #3c3c3c" href="http://openpdc.codeplex.com/"><B>http:\\openPDC.codeplex.com</B></A></SPAN><BR><SPAN style="COLOR: #000000; FONT-SIZE: 10pt"><A style="COLOR: #3c3c3c" href="http://openpg.codeplex.com/"><B>http:\\openPG.codeplex.com</B></A></SPAN></P>
</div>
<div id="cc-block10" class="cc-block">
<P style="TEXT-ALIGN: center"><SPAN style="COLOR: #339966; FONT-SIZE: 18pt"><A style="BACKGROUND-COLOR: #808080; WIDTH: 449px; FONT-FAMILY: Helvetica, Arial, sans-serif; HEIGHT: 98px; COLOR: #fafafa" id=lnkRegister class=cc-register title="Register Now!" href="http://events.r20.constantcontact.com/register/eventReg?llr=cgvygggab&amp;oeidk=a07e61z27h2169407fe" target=_blank>Register Now!&nbsp; Early Registration Ends July 31</A></SPAN></P>
<P>&nbsp;</P>
<P style="TEXT-ALIGN: center"><SPAN style="COLOR: #339966; FONT-SIZE: 12pt"><STRONG>Receipt For Your Registration</STRONG></SPAN></P>
<P style="TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 12pt"><SPAN style="COLOR: #339966"><STRONG>When registration is complete and payment through Google Checkout has been successfully&nbsp;submitted, you will automatically receive a confirmation email/receipt.&nbsp; Please save this email since it will be your receipt for the registration fee payment.&nbsp;&nbsp;</STRONG></SPAN>&nbsp;</SPAN></P>
<P>&nbsp;</P>
</div>
<div id="cc-block4" class="cc-block">
<A href="http://visitor.r20.constantcontact.com/d.jsp?llr=cgvygggab&amp;p=oi&amp;m=1106162504898" shape=rect target=_blank><IMG border=0 alt="Join My Mailing List" vspace=5 src="https://imgssl.constantcontact.com/letters/images/1101093164665/jmml_opgr1_img1.gif"></A>
</div>
<div id="cc-block5" class="cc-block">
<H3><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">User Forum Agenda</SPAN></H3>
<P>&nbsp;<SPAN style="COLOR: #000000; FONT-SIZE: 10pt"> 7:30 a.m. - Registration</SPAN></P>
<P style="TEXT-ALIGN: left"><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 8:00 a.m. -&nbsp;Welcome&nbsp;from NERC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mark Lauby</SPAN></P>
<P style="TEXT-ALIGN: left"><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 8:30 a.m. - Grid Open Source Software Alliance (GOSSA)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; John Allen</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 8:45 a.m. - openPDC, Version&nbsp;1.5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ritchie Carroll</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 9:30 a.m. - Break</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 9:45 am. - openPDC Integration in Control Centers&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Barb Motteler</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">10:15 a.m. - Synchophasor Data Systems at Dominion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kyle Thomas/Kevin Jones</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">10:45 a.m. -&nbsp;openPDC-Based Real-Time Appplications Update&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mani Venkatasubramanian</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">11:15 a.m. -&nbsp;openPDC Implementation and Experience at ISO NE&nbsp;&nbsp;&nbsp;&nbsp;Frankie Zhang</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">11:45 a.m. - Lunch</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">12:30 p.m. -&nbsp;Fault Location&nbsp;Engine (openFLE)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Theo Laughner</SPAN></P>
<P style="TEXT-ALIGN: left"><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 1:00 p.m. -&nbsp;Synchrophasor Data System Deployment at WECC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Godfrey Capiral</SPAN></P>
<P style="TEXT-ALIGN: left"><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 1:30 p.m. - Entergy openPG&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rubal KC</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 2:00 p.m. - Historian 2.0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Steven Chisholm</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp; 2:30 p.m. - Wrap up and Discussion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Russell Robertson</SPAN></P>
<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">&nbsp;&nbsp;3:00 p.m. - Adjourn</SPAN></P>
</div>
</div>
</div>
</div>
<div id="cc-site-info-outer">
    <div class="cc-panel" id="cc-site-info">
    
</div>
</div>
</div>
<script type="text/javascript">
   var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
   var _gaq = _gaq || [];
    // use jquery if it's available
   if( window.jQuery != null ) { 
      jQuery.getScript(gaJsHost + "google-analytics.com/ga.js", function(){
          try {
              if( window.console ) window.console.log("Google Analytics : Through jQuery logged");
              
              _gaq.push(['_setAccount', 'UA-2821686-8']);
              _gaq.push(['_trackPageview', 'Registration : Event Homepage']);
          }
          catch(err) {
              if( window.console ) window.console.log("Google Analytics : Through jQuery : Error");
          }
       });
   }
   else {
	   document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
       try {
          if (typeof(_gat) == 'object'){
            var pageTracker = _gat._getTracker("UA-2821686-8");
            if( window.console ) window.console.log("Google Analytics : Regular JS logged");
            pageTracker._trackPageview('Registration : Event Homepage');
          }
       }
       catch(err) {
           if( window.console ) window.console.log("Google Analytics : Regular JS : Error");
       }
   }
</script>
	<script language="javascript" type="text/javascript">
		jQuery(document).ready( function() {
	 		 
	      	  try {
	      		  
	      		  jQuery('body').css('background-color', '#fafafa');
	      		  jQuery('body').css('color', '#808080');
	      		  jQuery('body').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('h1').css('color', '#3c3c3c');
	      		  jQuery('h1').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('h2').css('color', '#3c3c3c');
	      		  jQuery('h2').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('h3:not(table h3)').css('color', '#3c3c3c');
	      		  jQuery('h3:not(table h3)').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('a').css('color', '#3c3c3c');
	      		  
	      		  jQuery('.side-title-colored').css('color', '#3c3c3c');
	      		  jQuery('.side-title-colored').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  
	      		  jQuery('#cc-content-sub-outer').css('background-color', '#fafafa');
	      		  jQuery('#cc-content-sub-inner').css('background-color', '#c8c8c8');
	      		  jQuery('#cc-content-sub-inner').css('color', '#fafafa');
	      		  jQuery('#cc-content-sub-inner').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('#cc-content-sub-inner').find('.cc-block').find('h3').css('color', '#3c3c3c');
	      		  jQuery('#cc-content-sub-inner').find('.cc-block').find('h3').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('#cc-content-sub-inner').find('.cc-block').find('a').css('color', '#3c3c3c');
	      		  
	      		  jQuery('.cc-register').css('background-color', '#808080');
			      jQuery('.cc-register').css('color', '#fafafa');
			      jQuery('.cc-register').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('.cc-btn-primary').css('background-color', '#808080');
	  		      jQuery('.cc-btn-primary').css('color', '#fafafa');
	  		      jQuery('.cc-btn-primary').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      		  jQuery('.cc-btn-secondary').css('background-color', '#808080');
	    		  jQuery('.cc-btn-secondary').css('color', '#fafafa');
	    		  jQuery('.cc-btn-secondary').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	    		  jQuery('.cc-btn-tertiary').css('background-color', '#808080');
	    		  jQuery('.cc-btn-tertiary').css('color', '#fafafa');
	    		  jQuery('.cc-btn-tertiary').css('font-family', "Helvetica, Calibri, Arial, sans-serif");
	      	  } catch( e ) {}
		});
 	</script>
<span id="event-meta-hcalendar" class="vevent" style="display:none;">
    <span class="dtstart"><span class="value-title" title="2012-08-21T08:00:00-0400"></span>2012-08-21T08:00:00-0400</span>
    <span class="dtend"><span class="value-title" title="2012-08-22T15:00:00-0400"></span>2012-08-22T15:00:00-0400</span>
    <span class="summary">2012 GPA Tutorial and User's Forum</span>
    <span class="location">3353 Peachtree Road NE, Suite 600, North Tower, Atlanta, GA, 30326, US</span>
    <a class="url" href="http://events.r20.constantcontact.com/register/event?llr=cgvygggab&oeidk=a07e61z27h2169407fe">http://events.r20.constantcontact.com/register/event?llr=cgvygggab&oeidk=a07e61z27h2169407fe</a>
</span>
<div id="component-config" data-component='{"config" : {"components" : []} }'></div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</html>
