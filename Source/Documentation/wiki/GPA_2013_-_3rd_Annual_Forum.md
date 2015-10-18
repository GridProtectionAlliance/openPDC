<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta http

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->

-equiv="Content-Type" content="text/html; charset=UTF-8" />

<title>2013 GPA Tutorial and User's Forum</title>

<link id="cc-layout-css" href="https://imgssl.constantcontact.com/ced/layouts/layout-1.css?version=2013.6.0-20130730.172926" rel="stylesheet" type="text/css" />

<link id="cc-base-css" href="https://imgssl.constantcontact.com/ced/themes/base.css?version=2013.6.0-20130730.172926" rel="stylesheet" type="text/css" />

<link id="cc-theme-css" href="https://imgssl.constantcontact.com/ced/themes/custom/custom.css?version=2013.6.0-20130730.172926" rel="stylesheet" type="text/css" />



<meta name="keywords" content="pmu,open source,atlanta,gpa,phasor,users group,tutorial" />
<script type="text/javascript">(window.NREUM||(NREUM={})).loader_config={xpid:"UwYAV1BACQQFXVdbAQ=="};window.NREUM||(NREUM={}),__nr_require=function(t,e,n){function r(n){if(!e[n]){var o=e[n]={exports:{}};t[n][0].call(o.exports,function(e){var o=t[n][1][e];return r(o?o:e)},o,o.exports)}return e[n].exports}if("function"==typeof __nr_require)return __nr_require;for(var o=0;o<n.length;o++)r(n[o]);return r}({QJf3ax:[function(t,e){function n(t){function e(e,n,a){t&&t(e,n,a),a||(a={});for(var c=s(e),u=c.length,f=i(a,o,r),d=0;u>d;d++)c[d].apply(f,n);return f}function a(t,e){u[t]=s(t).concat(e)}function s(t){return u[t]||[]}function c(){return n(e)}var u={};return{on:a,emit:e,create:c,listeners:s,_events:u}}function r(){return{}}var o="nr@context",i=t("gos");e.exports=n()},{gos:"7eSDFh"}],ee:[function(t,e){e.exports=t("QJf3ax")},{}],3:[function(t){function e(t){try{i.console&&console.log(t)}catch(e){}}var n,r=t("ee"),o=t(1),i={};try{n=localStorage.getItem("__nr_flags").split(","),console&&"function"==typeof console.log&&(i.console=!0,-1!==n.indexOf("dev")&&(i.dev=!0),-1!==n.indexOf("nr_dev")&&(i.nrDev=!0))}catch(a){}i.nrDev&&r.on("internal-error",function(t){e(t.stack)}),i.dev&&r.on("fn-err",function(t,n,r){e(r.stack)}),i.dev&&(e("NR AGENT IN DEVELOPMENT MODE"),e("flags: "+o(i,function(t){return t}).join(", ")))},{1:20,ee:"QJf3ax"}],4:[function(t){function e(t,e,n,i,s){try{c?c-=1:r("err",[s||new UncaughtException(t,e,n)])}catch(u){try{r("ierr",[u,(new Date).getTime(),!0])}catch(f){}}return"function"==typeof a?a.apply(this,o(arguments)):!1}function UncaughtException(t,e,n){this.message=t||"Uncaught error with no additional information",this.sourceURL=e,this.line=n}function n(t){r("err",[t,(new Date).getTime()])}var r=t("handle"),o=t(6),i=t("ee"),a=window.onerror,s=!1,c=0;t("loader").features.err=!0,t(3),window.onerror=e;try{throw new Error}catch(u){"stack"in u&&(t(4),t(5),"addEventListener"in window&&t(1),window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)&&t(2),s=!0)}i.on("fn-start",function(){s&&(c+=1)}),i.on("fn-err",function(t,e,r){s&&(this.thrown=!0,n(r))}),i.on("fn-end",function(){s&&!this.thrown&&c>0&&(c-=1)}),i.on("internal-error",function(t){r("ierr",[t,(new Date).getTime(),!0])})},{1:5,2:8,3:3,4:7,5:6,6:21,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],5:[function(t,e){function n(t){i.inPlace(t,["addEventListener","removeEventListener"],"-",r)}function r(t){return t[1]}var o=t("ee").create(),i=t(1)(o),a=t("gos");if(e.exports=o,n(window),"getPrototypeOf"in Object){for(var s=document;s&&!s.hasOwnProperty("addEventListener");)s=Object.getPrototypeOf(s);s&&n(s);for(var c=XMLHttpRequest.prototype;c&&!c.hasOwnProperty("addEventListener");)c=Object.getPrototypeOf(c);c&&n(c)}else XMLHttpRequest.prototype.hasOwnProperty("addEventListener")&&n(XMLHttpRequest.prototype);o.on("addEventListener-start",function(t){if(t[1]){var e=t[1];"function"==typeof e?this.wrapped=t[1]=a(e,"nr@wrapped",function(){return i(e,"fn-",null,e.name||"anonymous")}):"function"==typeof e.handleEvent&&i.inPlace(e,["handleEvent"],"fn-")}}),o.on("removeEventListener-start",function(t){var e=this.wrapped;e&&(t[1]=e)})},{1:22,ee:"QJf3ax",gos:"7eSDFh"}],6:[function(t,e){var n=t("ee").create(),r=t(1)(n);e.exports=n,r.inPlace(window,["requestAnimationFrame","mozRequestAnimationFrame","webkitRequestAnimationFrame","msRequestAnimationFrame"],"raf-"),n.on("raf-start",function(t){t[0]=r(t[0],"fn-")})},{1:22,ee:"QJf3ax"}],7:[function(t,e){function n(t,e,n){t[0]=o(t[0],"fn-",null,n)}var r=t("ee").create(),o=t(1)(r);e.exports=r,o.inPlace(window,["setTimeout","setInterval","setImmediate"],"setTimer-"),r.on("setTimer-start",n)},{1:22,ee:"QJf3ax"}],8:[function(t,e){function n(){u.inPlace(this,p,"fn-")}function r(t,e){u.inPlace(e,["onreadystatechange"],"fn-")}function o(t,e){return e}function i(t,e){for(var n in t)e[n]=t[n];return e}var a=t("ee").create(),s=t(1),c=t(2),u=c(a),f=c(s),d=window.XMLHttpRequest,p=["onload","onerror","onabort","onloadstart","onloadend","onprogress","ontimeout"];e.exports=a,window.XMLHttpRequest=function(t){var e=new d(t);try{a.emit("new-xhr",[],e),f.inPlace(e,["addEventListener","removeEventListener"],"-",o),e.addEventListener("readystatechange",n,!1)}catch(r){try{a.emit("internal-error",[r])}catch(i){}}return e},i(d,XMLHttpRequest),XMLHttpRequest.prototype=d.prototype,u.inPlace(XMLHttpRequest.prototype,["open","send"],"-xhr-",o),a.on("send-xhr-start",r),a.on("open-xhr-start",r)},{1:5,2:22,ee:"QJf3ax"}],9:[function(t){function e(t){var e=this.params,r=this.metrics;if(!this.ended){this.ended=!0;for(var i=0;c>i;i++)t.removeEventListener(s[i],this.listener,!1);if(!e.aborted){if(r.duration=(new Date).getTime()-this.startTime,4===t.readyState){e.status=t.status;var a=t.responseType,u="arraybuffer"===a||"blob"===a||"json"===a?t.response:t.responseText,f=n(u);if(f&&(r.rxSize=f),this.sameOrigin){var d=t.getResponseHeader("X-NewRelic-App-Data");d&&(e.cat=d.split(", ").pop())}}else e.status=0;r.cbTime=this.cbTime,o("xhr",[e,r,this.startTime])}}}function n(t){if("string"==typeof t&&t.length)return t.length;if("object"!=typeof t)return void 0;if("undefined"!=typeof ArrayBuffer&&t instanceof ArrayBuffer&&t.byteLength)return t.byteLength;if("undefined"!=typeof Blob&&t instanceof Blob&&t.size)return t.size;if("undefined"!=typeof FormData&&t instanceof FormData)return void 0;try{return JSON.stringify(t).length}catch(e){return void 0}}function r(t,e){var n=i(e),r=t.params;r.host=n.hostname+":"+n.port,r.pathname=n.pathname,t.sameOrigin=n.sameOrigin}if(window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)){t("loader").features.xhr=!0;var o=t("handle"),i=t(2),a=t("ee"),s=["load","error","abort","timeout"],c=s.length,u=t(1);t(4),t(3),a.on("new-xhr",function(){this.totalCbs=0,this.called=0,this.cbTime=0,this.end=e,this.ended=!1,this.xhrGuids={}}),a.on("open-xhr-start",function(t){this.params={method:t[0]},r(this,t[1]),this.metrics={}}),a.on("open-xhr-end",function(t,e){"loader_config"in NREUM&&"xpid"in NREUM.loader_config&&this.sameOrigin&&e.setRequestHeader("X-NewRelic-ID",NREUM.loader_config.xpid)}),a.on("send-xhr-start",function(t,e){var r=this.metrics,o=t[0],i=this;if(r&&o){var u=n(o);u&&(r.txSize=u)}this.startTime=(new Date).getTime(),this.listener=function(t){try{"abort"===t.type&&(i.params.aborted=!0),("load"!==t.type||i.called===i.totalCbs&&(i.onloadCalled||"function"!=typeof e.onload))&&i.end(e)}catch(n){try{a.emit("internal-error",[n])}catch(r){}}};for(var f=0;c>f;f++)e.addEventListener(s[f],this.listener,!1)}),a.on("xhr-cb-time",function(t,e,n){this.cbTime+=t,e?this.onloadCalled=!0:this.called+=1,this.called!==this.totalCbs||!this.onloadCalled&&"function"==typeof n.onload||this.end(n)}),a.on("xhr-load-added",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&!this.xhrGuids[n]&&(this.xhrGuids[n]=!0,this.totalCbs+=1)}),a.on("xhr-load-removed",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&this.xhrGuids[n]&&(delete this.xhrGuids[n],this.totalCbs-=1)}),a.on("addEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-added",[t[1],t[2]],e)}),a.on("removeEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-removed",[t[1],t[2]],e)}),a.on("fn-start",function(t,e,n){e instanceof XMLHttpRequest&&("onload"===n&&(this.onload=!0),("load"===(t[0]&&t[0].type)||this.onload)&&(this.xhrCbStart=(new Date).getTime()))}),a.on("fn-end",function(t,e){this.xhrCbStart&&a.emit("xhr-cb-time",[(new Date).getTime()-this.xhrCbStart,this.onload,e],e)})}},{1:"XL7HBI",2:10,3:8,4:5,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],10:[function(t,e){e.exports=function(t){var e=document.createElement("a"),n=window.location,r={};e.href=t,r.port=e.port;var o=e.href.split("://");return!r.port&&o[1]&&(r.port=o[1].split("/")[0].split("@").pop().split(":")[1]),r.port&&"0"!==r.port||(r.port="https"===o[0]?"443":"80"),r.hostname=e.hostname||n.hostname,r.pathname=e.pathname,r.protocol=o[0],"/"!==r.pathname.charAt(0)&&(r.pathname="/"+r.pathname),r.sameOrigin=!e.hostname||e.hostname===document.domain&&e.port===n.port&&e.protocol===n.protocol,r}},{}],11:[function(t,e){function n(t){return function(){r(t,[(new Date).getTime()].concat(i(arguments)))}}var r=t("handle"),o=t(1),i=t(2);"undefined"==typeof window.newrelic&&(newrelic=window.NREUM);var a=["setPageViewName","addPageAction","setCustomAttribute","finished","addToTrace","inlineHit","noticeError"];o(a,function(t,e){window.NREUM[e]=n("api-"+e)}),e.exports=window.NREUM},{1:20,2:21,handle:"D5DuLP"}],gos:[function(t,e){e.exports=t("7eSDFh")},{}],"7eSDFh":[function(t,e){function n(t,e,n){if(r.call(t,e))return t[e];var o=n();if(Object.defineProperty&&Object.keys)try{return Object.defineProperty(t,e,{value:o,writable:!0,enumerable:!1}),o}catch(i){}return t[e]=o,o}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],D5DuLP:[function(t,e){function n(t,e,n){return r.listeners(t).length?r.emit(t,e,n):void(r.q&&(r.q[t]||(r.q[t]=[]),r.q[t].push(e)))}var r=t("ee").create();e.exports=n,n.ee=r,r.q={}},{ee:"QJf3ax"}],handle:[function(t,e){e.exports=t("D5DuLP")},{}],XL7HBI:[function(t,e){function n(t){var e=typeof t;return!t||"object"!==e&&"function"!==e?-1:t===window?0:i(t,o,function(){return r++})}var r=1,o="nr@id",i=t("gos");e.exports=n},{gos:"7eSDFh"}],id:[function(t,e){e.exports=t("XL7HBI")},{}],G9z0Bl:[function(t,e){function n(){var t=p.info=NREUM.info,e=u.getElementsByTagName("script")[0];if(t&&t.licenseKey&&t.applicationID&&e){s(d,function(e,n){e in t||(t[e]=n)});var n="https"===f.split(":")[0]||t.sslForHttp;p.proto=n?"https://":"http://",a("mark",["onload",i()]);var r=u.createElement("script");r.src=p.proto+t.agent,e.parentNode.insertBefore(r,e)}}function r(){"complete"===u.readyState&&o()}function o(){a("mark",["domContent",i()])}function i(){return(new Date).getTime()}var a=t("handle"),s=t(1),c=window,u=c.document;t(2);var f=(""+location).split("?")[0],d={beacon:"bam.nr-data.net",errorBeacon:"bam.nr-data.net",agent:"js-agent.newrelic.com/nr-686.min.js"},p=e.exports={offset:i(),origin:f,features:{}};u.addEventListener?(u.addEventListener("DOMContentLoaded",o,!1),c.addEventListener("load",n,!1)):(u.attachEvent("onreadystatechange",r),c.attachEvent("onload",n)),a("mark",["firstbyte",i()])},{1:20,2:11,handle:"D5DuLP"}],loader:[function(t,e){e.exports=t("G9z0Bl")},{}],20:[function(t,e){function n(t,e){var n=[],o="",i=0;for(o in t)r.call(t,o)&&(n[i]=e(o,t[o]),i+=1);return n}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],21:[function(t,e){function n(t,e,n){e||(e=0),"undefined"==typeof n&&(n=t?t.length:0);for(var r=-1,o=n-e||0,i=Array(0>o?0:o);++r<o;)i[r]=t[e+r];return i}e.exports=n},{}],22:[function(t,e){function n(t){return!(t&&"function"==typeof t&&t.apply&&!t[i])}var r=t("ee"),o=t(1),i="nr@wrapper",a=Object.prototype.hasOwnProperty;e.exports=function(t){function e(t,e,r,a){function nrWrapper(){var n,i,s,u;try{i=this,n=o(arguments),s=r&&r(n,i)||{}}catch(d){f([d,"",[n,i,a],s])}c(e+"start",[n,i,a],s);try{return u=t.apply(i,n)}catch(p){throw c(e+"err",[n,i,p],s),p}finally{c(e+"end",[n,i,u],s)}}return n(t)?t:(e||(e=""),nrWrapper[i]=!0,u(t,nrWrapper),nrWrapper)}function s(t,r,o,i){o||(o="");var a,s,c,u="-"===o.charAt(0);for(c=0;c<r.length;c++)s=r[c],a=t[s],n(a)||(t[s]=e(a,u?s+o:o,i,s))}function c(e,n,r){try{t.emit(e,n,r)}catch(o){f([o,e,n,r])}}function u(t,e){if(Object.defineProperty&&Object.keys)try{var n=Object.keys(t);return n.forEach(function(n){Object.defineProperty(e,n,{get:function(){return t[n]},set:function(e){return t[n]=e,e}})}),e}catch(r){f([r])}for(var o in t)a.call(t,o)&&(e[o]=t[o]);return e}function f(e){try{t.emit("internal-error",e)}catch(n){}}return t||(t=r),e.inPlace=s,e.flag=i,e}},{1:21,ee:"QJf3ax"}]},{},["G9z0Bl",4,9]);</script><meta name="description" content="The 3rd annual GPA Tutorial and User�s Forum, hosted by NERC at their offices in Atlanta, GA, is scheduled for August 13 and 14.  Day 1 is a deep dive into GPA open source libraries and products.  Day 2 will focus on openHistorian 2.0 and openXDA.  Lunch will be provided on both days.  A reception will immediately follow the Day 1 session." /><script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
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

        <!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body id="a07e74qrvzl1">



<div class="cc-document" id="cc-container">

    <div id="cc-branding-outer">

    <div class="cc-panel" id="cc-branding-inner">

    <div id="cc-block6" class="cc-block">

<p><img width="528" height="148" title="GPA, improving the reliability and resiliency of the electric grid." align="center" alt="GPA, improving the reliability and resiliency of the electric grid." src="https://origin.ih.constantcontact.com/fs096/1106162504898/img/2.jpg" border="0" vspace="6" hspace="8"></p>

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

<H3 style="FONT-FAMILY: Helvetica, Calibri, Arial, sans-serif; COLOR: #3c3c3c"><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">Contact</SPAN></H3><SPAN class=cc-var title=Event.contactName>Brenda Moses</SPAN>&nbsp;<BR><SPAN>Grid Protection Alliance</SPAN>&nbsp;<BR><SPAN class=cc-var title=Event.contactEmail>bjmoses@gridprotectionalliance.org</SPAN>&nbsp;<BR><SPAN style="WHITE-SPACE: nowrap" class=baec5a81-e4d6-4674-97f3-e9220f0136c1>(423) 973-4731<A style="POSITION: static !important; MARGIN: 0px; WIDTH: 16px; BOTTOM: 0px; DISPLAY: inline; WHITE-SPACE: nowrap; FLOAT: none; HEIGHT: 16px; VERTICAL-ALIGN: middle; OVERFLOW: hidden; CURSOR: hand; RIGHT: 0px; TOP: 0px; LEFT: 0px" title="Call: (423) 973-4731" href="#"><IMG style="POSITION: static !important; MARGIN: 0px; WIDTH: 16px; BOTTOM: 0px; DISPLAY: inline; WHITE-SPACE: nowrap; FLOAT: none; HEIGHT: 16px; VERTICAL-ALIGN: middle; OVERFLOW: hidden; CURSOR: hand; RIGHT: 0px; TOP: 0px; LEFT: 0px" title="Call: (423) 973-4731" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAAKLSURBVHjadJPfS5NhFMe/21xvuhXRyJAZroiSrJnbRdT7vrAf5HBaK5RABmEEwQIvkpZ/QRcWXdSFw5soKaF0F7qZeLO13mGBDpQsf5CoxVKHOt0Pctp2uvEdrzG/V+c553w/54HnPDIiQiGpPMETABoB2AAYd9MRAMMAvGmX+RcAyAoBVJ7gZQDtABworH4AHWmX+bOMZdkjCoXiUzabvcAwzPSsob5p/VTNY9GcdpnxdmYZ9wJThSCtCr1e/4XjuNPd3d1KjUZzaGbI27ysqzGQoggAsLa1A7ehArrDxfDNr0oBlQB+wmKxbJFEL968SxoamsjkHaPU9l9piUo6A0RE1DG2QCWdASrpDAzJM5kMI8XecdjVxfEl+K9dxFgsgUvvR6HyBKHyBAEATyKLeGSsENuNcqk5kUjEGm7fzcYqr0ClVODl99+YXEvl6+c1amjVe+ahiGGYaUEQKnmeh91uL43rqheixjpdmzCL11er0PcjhrTLvMfUJsyKYUSeyWQ6enp6tgCgrKxsfbP8bB8AdE1G89cOReMAgOv+Cag8QXRNRkXAsDwcDr+am5tLCYKA3t7eo2dG+1vVK/MfpRPtA+MIReMYaKj+/xm9MiICx3EmpVL5wefzFavValis1u1vvHMkdfykCQC0kSGUTo+Ajmnx1dSC7IGD+UUCEYGIwLKsyWazrSeTSSIiMpnNf7Ttz5+ec96fr7/VnE0mk+QfHMzV3WjcKH/4rEr05QGFIA6HY4llWRLPRER+v3/HYrFMFQSIkNra2tVQKJSlfcSyLO0LECFWq3XF6XRGA4HAptTsdrsXeZ6fEHtl+31nAOA4rkUulz/I5XL63dQGgHEAN8Ph8AYA/BsAt4ube4GblQIAAAAASUVORK5CYII="></A></SPAN><BR>

</div>

<div id="cc-block8" class="cc-block">

<h3 style="color: rgb(60, 60, 60); font-family: Helvetica, Calibri, Arial, sans-serif;"><span style="color: rgb(153, 51, 0); font-size: 14pt;">When</span></h3>
<p><span style="color: rgb(51, 153, 102); font-size: 18pt;"><strong>August&nbsp;13 and 14, 2013</strong></span></p>
<p><span style="color: rgb(51, 153, 102); font-size: 18pt;"></span><span title="Event.addToCalendarLink" class="cc-var"><a title="Add to Calendar" id="lnkAddToCalendar" href="http://events.r20.constantcontact.com/register/addtocalendar?oeidk=a07e74qrvzkb2ce6be8" class="cc-calendar">Add to Calendar</a></span>&nbsp;</p>

</div>

<div id="cc-block9" class="cc-block">

<H3 style="FONT-FAMILY: Helvetica, Calibri, Arial, sans-serif; COLOR: #3c3c3c"><SPAN style="COLOR: #993300; FONT-SIZE: 14pt">Where</SPAN></H3>

<P>NERC - Atlanta Office<BR><SPAN class=cc-var title=Event.addressHtml>3353 Peachtree Road NE<br />Suite 600, North Tower<br />Atlanta, GA 30326</SPAN>&nbsp;<BR><SPAN style="COLOR: #993300">Location Provided by </SPAN><SPAN style="COLOR: #993300">NERC </SPAN><SPAN class=cc-var title=Event.map><img height="200" width="200" src="https://api.tiles.virtualearth.net/api/GetMap.ashx?ppl=24,,33.848072,-84.36689&amp;z=12&amp;h=200&amp;w=200
          " /></SPAN>&nbsp;<BR><SPAN style="COLOR: #993300" class=cc-var title=Event.googleDrivingDirectionsNoStyle><a title="Driving Directions" id="idDrivingDir" href="http://maps.google.com/maps?daddr=3353 Peachtree Road NE, Suite 600, North Tower, Atlanta, GA, 30326, US" target="_blank">Driving Directions</a></SPAN>&nbsp;&nbsp;</P>

<P><CITE><A style="COLOR: #3c3c3c" href="http://www.nerc.com/files/Atlanta_Office_Fact_Sheet.pdf" target=_blank>www.<B>nerc</B>.com/files/<B>Atlanta</B>_<B>Office</B>_Fact_Sheet.pdf</A></CITE></P>

<P><SPAN style="FONT-SIZE: 14pt"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif"><SPAN style="TEXT-DECORATION: underline"><SPAN style="COLOR: #993300; TEXT-DECORATION: underline"><B>This Year's Speakers:</B></SPAN></SPAN></SPAN></SPAN><SPAN style="FONT-SIZE: 14pt"><B>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </B></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><B>Alstom</B></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><B>&nbsp;&nbsp;&nbsp;&nbsp; </B>Vijay Sukhavasi</SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><B>Dominion Virginia Power </B></SPAN></P>

<P><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></SPAN><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">Kevin Jones</SPAN></SPAN></P>

<P><SPAN style="FONT-SIZE: 10pt"><STRONG><SPAN style="COLOR: #008000">Electric Power Research Institute</SPAN></STRONG></SPAN></P>

<P><SPAN style="FONT-SIZE: 10pt"><STRONG><SPAN style="COLOR: #008000">&nbsp;</SPAN></STRONG></SPAN><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; Tom Cooke</SPAN></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><B><SPAN style="COLOR: #008000"><B>New England ISO</B></SPAN></B></SPAN></P>

<P><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; Qiang 'Frankie'</SPAN></SPAN><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000"> Zhang</SPAN></SPAN><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000"> </SPAN></SPAN></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><B><SPAN style="COLOR: #008000">Oklahoma Gas and Electric</SPAN></B></SPAN></P>

<P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; Stephen Chisholm</SPAN></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;</SPAN></SPAN><SPAN style="FONT-SIZE: 10pt"><STRONG><SPAN style="COLOR: #008000">Tennessee Valley Authority</SPAN></STRONG></SPAN></P>

<P>&nbsp;&nbsp;&nbsp;<SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; Clay DeLoach </SPAN></SPAN></P>

<P>

<P><SPAN style="FONT-SIZE: 10pt"><STRONG><SPAN style="COLOR: #008000">University of Illinois Urbana-Champaign</SPAN></STRONG></SPAN></P>

<P><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; Tim Yardley/Erich Heine</SPAN></SPAN></P>

<P><STRONG><SPAN style="COLOR: #008000; FONT-SIZE: 12pt">&nbsp;</SPAN></STRONG><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><STRONG><STRONG><SPAN style="COLOR: #008000">Washington State University</SPAN></STRONG></STRONG></SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><STRONG><STRONG><SPAN style="COLOR: #008000">&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></STRONG></STRONG></SPAN><SPAN style="FONT-SIZE: 10pt"><SPAN style="COLOR: #008000"><SPAN style="COLOR: #008000">Mani</SPAN><SPAN style="COLOR: #008000"> Venkatasubramanian</SPAN></SPAN></SPAN></P>

<P>&nbsp;</P>

<P>

<P>&nbsp;&nbsp;</P>

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

<DIV></DIV>

<DIV></DIV>

<DIV></DIV>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P>&nbsp;</P>

<P></P>

<P></P>

<P></P>

</div>



</div>



</div>

<div class="cc-panel evm-rcol-main-hp" id="cc-content">

    <div id="cc-block1" class="cc-block">

<P style="TEXT-ALIGN: center"><STRONG><SPAN style="FONT-SIZE: 18pt"><SPAN style="COLOR: #008000">2013 Grid Protection Alliance (GPA)<BR>3rd Annual Tutorial and User's Forum</SPAN></SPAN></STRONG></P>

</div>

<div id="cc-block2" class="cc-block">

<P><SPAN style="COLOR: #008000; FONT-SIZE: 24pt">You're Invited!</SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 12pt"><STRONG>A&nbsp;full-day Technical Tutorial on code development for GPA products&nbsp;</STRONG></SPAN></P>

<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">The GPA Technical Tutorial on August&nbsp;13 from 8:00 a.m. to 5:00 p.m., is a deep dive into GPA open source libraries and products and is intended for C# developers looking to deploy and/or enhance them. Participating in this session is a good way to learn more about the <A style="COLOR: #3c3c3c" href="http://gsf.codeplex.com/" target=_blank><B>Grid Solutions Framework (GSF)</B></A>. &nbsp;The GSF can be used to process and manage streaming&nbsp;time-stamped data through a collection of configurable adapter components. &nbsp;Developers will gain a working knowledge of the framework, which will enable them to extend existing modules or develop new modules for the&nbsp;open source libraries.</SPAN></P>

<P><SPAN style="COLOR: #008000; FONT-SIZE: 10pt"><SPAN style="FONT-SIZE: 12pt"><STRONG>The User&#8217;s Forum for GPA&#8217;s open source projects</STRONG></SPAN></SPAN></P>

<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">The GPA User's Forum on August&nbsp;14 from 8:00 a.m. to 3:00 p.m., provides an opportunity for GPA product users to share implementation examples with one another.&nbsp; This session will educate those that are new to GPA open-source projects, inform developers about new software components, and provide insight from the industry on the practical application of the <A style="COLOR: #3c3c3c" href="https://gsf.codeplex.com/" target=_blank>GSF</A>, <A style="COLOR: #3c3c3c" href="https://openXDA.codeplex.com/" target=_blank>openXDA</A>, <A style="COLOR: #3c3c3c" href="https://openPG.codeplex.com/" target=_blank>openPG</A>, and <A style="COLOR: #3c3c3c" href="https://openPDC.codeplex.com/" target=_blank>openPDC</A>.&nbsp;&nbsp;Input collected during the GPA User&#8217;s Forum will be used to help prioritize GPA&#8217;s development work in 2014.</SPAN></P>

<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">GPA provides and supports software solutions for the electric utility industry. &nbsp;Our mission is to improve the reliability and resiliency of the electric grid, through state-of-the-art applications. &nbsp;All GPA software products are open source with no licensing fee.&nbsp; As a not-for-profit corporation, GPA seeks to build collaborative relationships among government agencies, regulators, vendors, and grid owner-operators. &nbsp;These GPA efforts incorporate and improve technologies to create a more secure, more robust, and smarter electric grid and facilitate grid modernization.</SPAN></P>

<P><SPAN style="COLOR: #000000; FONT-SIZE: 10pt">To download or get more information on GPA products, go to:</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-SIZE: 12pt"><SPAN style="COLOR: #000000"><A style="COLOR: #3c3c3c" href="http://gsf.codeplex.com/" target=_blank><B>http://gsf.codeplex.com</B></A><BR></SPAN><SPAN style="COLOR: #000000"><A style="COLOR: #3c3c3c" href="http://openxda.codeplex.com/" target=_blank><B>http://openXDA.codeplex.com</B></A></SPAN> </SPAN><BR><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-SIZE: 12pt"><A style="COLOR: #3c3c3c" href="http://openpg.codeplex.com/" target=_blank><B>http://openPG.codeplex.com</B></A></SPAN><BR><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-SIZE: 12pt"><A style="COLOR: #3c3c3c" href="http://openpdc.codeplex.com/" target=_blank><B>http://openPDC.codeplex.com</B></A></SPAN></P>

</div>

<div id="cc-block12" class="cc-block">

<SPAN title=Event.registerLink><A style="BACKGROUND-COLOR: #808080; WIDTH: 350px; FONT-FAMILY: Helvetica, Calibri, Arial, sans-serif; HEIGHT: 66px; COLOR: #fafafa" id=lnkRegister class=cc-register title="Register Now!" href="http://events.r20.constantcontact.com/register/eventReg?llr=cgvygggab&amp;oeidk=a07e74qrvzkb2ce6be8" target=_blank> 

<P><STRONG>Register Now!</STRONG></P>

<P><SPAN style="FONT-FAMILY: Comic Sans MS, Verdana, Helvetica, sans-serif; COLOR: #ffff00"><EM><STRONG><SPAN title=Event.registerLink>Early Registration Ends August 6 </SPAN></STRONG></EM></SPAN></P>

<P><SPAN style="FONT-FAMILY: Comic Sans MS, Verdana, Helvetica, sans-serif; COLOR: #ffff00"><EM><STRONG><SPAN title=Event.registerLink>&nbsp;</SPAN></STRONG></EM></SPAN></P>

<P><SPAN style="COLOR: #ffff00" title=Event.registerLink><SPAN style="FONT-FAMILY: Comic Sans MS, Verdana, Helvetica, sans-serif"><EM><STRONG><SPAN title=Event.registerLink>&nbsp;</SPAN></STRONG></EM></SPAN></SPAN></P></A></SPAN>&nbsp;

</div>

<div id="cc-block4" class="cc-block">

<A style="COLOR: #3c3c3c" href="http://visitor.r20.constantcontact.com/d.jsp?llr=cgvygggab&amp;p=oi&amp;m=1106162504898" shape=rect target=_blank><IMG border=0 alt="Join My Mailing List" vspace=5 src="https://imgssl.constantcontact.com/letters/images/1101093164665/jmml_opgr1_img1.gif"></A>

</div>

<div id="cc-block5" class="cc-block">

<H3><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000; FONT-SIZE: 10pt"><SPAN style="COLOR: #008000; FONT-SIZE: 12pt">August 13&nbsp;- Tentative Tutorial Agenda&nbsp;</SPAN></SPAN></H3>

<P style="TEXT-ALIGN: left"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;7:30 a.m. - Registration</SPAN></P>

<P style="TEXT-ALIGN: left"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:00 a.m. - Welcome&nbsp;and Introductions - Ritchie Carroll&nbsp;</SPAN></P>

<P style="TEXT-ALIGN: left"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:30 a.m. - Tutorial Presentations and Exercises</SPAN></P>

<P style="TEXT-ALIGN: left"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">10:00 a.m. - Break</SPAN></P>

<P style="TEXT-ALIGN: left"><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">10:15 a.m. - Tutorial Presentations and Exercises</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">11:45 a.m. - Lunch (provided)</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">12:30 p.m. - Tutorial Presentations and Exercises</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;</SPAN><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">2:00 p.m. - Break</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;2:15 p.m. - Tutorial Presentations and Exercises</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;5:00 p.m. - Adjourn</SPAN></P>

<H3><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;</SPAN><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #008000; FONT-SIZE: 12pt">August 14 - Tentative User's Forum Agenda</SPAN></H3>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;7:30 a.m. - Registration</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:00 a.m. - Welcome - Russell Robertson</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:15 a.m. - GOSSA - Fred Elmendorf</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:30 a.m. - openPDC 2.0 - Ritchie Carroll</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;8:45 a.m. - openPDC as applied by Alstom - Vijay Sukhavasi</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;</SPAN><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">9:15 a.m. - Alarming/openPDC Operations at New England ISO - Frankie Zhang</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;9:45 a.m. - Break</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">10:00 </SPAN><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;a.m. - Automated Fault Location at TVA - Clay DeLoach</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">10:30 a.m. - openXDA Use at Electric Power Research Institute&nbsp;- Tom Cooke</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">11:00 a.m. - WISP Gateway Testing -&nbsp;Ritchie Carroll</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">11:30 a.m. - SIEGate Development Update - Tim Yardley/Erich Heine/Ritchie Carroll</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">12:00 p.m. - Lunch (provided)</SPAN></P>

<P><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp; 1:00 p.m. - Linear Phase State Estimator at Dominion Virginia Power - Kevin Jones</SPAN>&nbsp;</P>

<P>

<P>

<P>&nbsp;<SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp; 1:30 p.m. - Use of Oscillation Monitoring System at Washington State University -</SPAN><SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mani&nbsp;Venkatasubramanian</SPAN></P>

<P>

<P>

<P>&nbsp; <SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #000000">2:00 p.m. - Historian Demonstration - Steven Chisholm/Ritchie Carroll</SPAN></P>

<P>

<P>

<P>

<P>&nbsp; <SPAN style="COLOR: #000000">2:30<SPAN style="FONT-FAMILY: Arial, Helvetica, sans-serif">p.m. - Closing Remarks - Russell Robertson</SPAN></SPAN></P>

<P>&nbsp;</P>

<P></P>

<P></P>

<P></P>

<P></P>

<P></P>

<P></P>

<P></P>

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
    <span class="dtstart"><span class="value-title" title="2013-08-13T08:00:00-0400"></span>2013-08-13T08:00:00-0400</span>
    <span class="dtend"><span class="value-title" title="2013-08-14T15:00:00-0400"></span>2013-08-14T15:00:00-0400</span>
    <span class="summary">2013 GPA Tutorial and User's Forum</span>
    <span class="location">3353 Peachtree Road NE, Suite 600, North Tower, Atlanta, GA, 30326, US</span>
    <a class="url" href="http://events.r20.constantcontact.com/register/event?llr=cgvygggab&oeidk=a07e74qrvzkb2ce6be8">http://events.r20.constantcontact.com/register/event?llr=cgvygggab&oeidk=a07e74qrvzkb2ce6be8</a>
</span>

<div id="component-config" data-component='{"config" : {"components" : []} }'></div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</html>
