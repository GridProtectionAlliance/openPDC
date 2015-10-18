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

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->

-equiv="Content-Type" content="text/html; charset=UTF-8" />

<title>Inaugural GPA User's Forum and GPA TSF Tutorial</title>

<link id="cc-layout-css" href="https://imgssl.constantcontact.com/ced/layouts/layout-1.css?version=20110830.183620.13" rel="stylesheet" type="text/css" />

<link id="cc-base-css" href="https://imgssl.constantcontact.com/ced/themes/base.css?version=20110830.183620.13" rel="stylesheet" type="text/css" />

<link id="cc-theme-css" href="https://imgssl.constantcontact.com/ced/themes/bamboo-1/bamboo-1.css?version=20110830.183620.13" rel="stylesheet" type="text/css" />



<meta name="keywords" content="pmu,open source,atlanta,gpa,phasor,users group,tutorial" />

<script type="text/javascript">(window.NREUM||(NREUM={})).loader_config={xpid:"UwYAV1BACQQFXVdbAQ=="};window.NREUM||(NREUM={}),__nr_require=function(t,e,n){function r(n){if(!e[n]){var o=e[n]={exports:{}};t[n][0].call(o.exports,function(e){var o=t[n][1][e];return r(o?o:e)},o,o.exports)}return e[n].exports}if("function"==typeof __nr_require)return __nr_require;for(var o=0;o<n.length;o++)r(n[o]);return r}({QJf3ax:[function(t,e){function n(t){function e(e,n,a){t&&t(e,n,a),a||(a={});for(var c=s(e),u=c.length,f=i(a,o,r),d=0;u>d;d++)c[d].apply(f,n);return f}function a(t,e){u[t]=s(t).concat(e)}function s(t){return u[t]||[]}function c(){return n(e)}var u={};return{on:a,emit:e,create:c,listeners:s,_events:u}}function r(){return{}}var o="nr@context",i=t("gos");e.exports=n()},{gos:"7eSDFh"}],ee:[function(t,e){e.exports=t("QJf3ax")},{}],3:[function(t){function e(t){try{i.console&&console.log(t)}catch(e){}}var n,r=t("ee"),o=t(1),i={};try{n=localStorage.getItem("__nr_flags").split(","),console&&"function"==typeof console.log&&(i.console=!0,-1!==n.indexOf("dev")&&(i.dev=!0),-1!==n.indexOf("nr_dev")&&(i.nrDev=!0))}catch(a){}i.nrDev&&r.on("internal-error",function(t){e(t.stack)}),i.dev&&r.on("fn-err",function(t,n,r){e(r.stack)}),i.dev&&(e("NR AGENT IN DEVELOPMENT MODE"),e("flags: "+o(i,function(t){return t}).join(", ")))},{1:20,ee:"QJf3ax"}],4:[function(t){function e(t,e,n,i,s){try{c?c-=1:r("err",[s||new UncaughtException(t,e,n)])}catch(u){try{r("ierr",[u,(new Date).getTime(),!0])}catch(f){}}return"function"==typeof a?a.apply(this,o(arguments)):!1}function UncaughtException(t,e,n){this.message=t||"Uncaught error with no additional information",this.sourceURL=e,this.line=n}function n(t){r("err",[t,(new Date).getTime()])}var r=t("handle"),o=t(6),i=t("ee"),a=window.onerror,s=!1,c=0;t("loader").features.err=!0,t(3),window.onerror=e;try{throw new Error}catch(u){"stack"in u&&(t(4),t(5),"addEventListener"in window&&t(1),window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)&&t(2),s=!0)}i.on("fn-start",function(){s&&(c+=1)}),i.on("fn-err",function(t,e,r){s&&(this.thrown=!0,n(r))}),i.on("fn-end",function(){s&&!this.thrown&&c>0&&(c-=1)}),i.on("internal-error",function(t){r("ierr",[t,(new Date).getTime(),!0])})},{1:5,2:8,3:3,4:7,5:6,6:21,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],5:[function(t,e){function n(t){i.inPlace(t,["addEventListener","removeEventListener"],"-",r)}function r(t){return t[1]}var o=t("ee").create(),i=t(1)(o),a=t("gos");if(e.exports=o,n(window),"getPrototypeOf"in Object){for(var s=document;s&&!s.hasOwnProperty("addEventListener");)s=Object.getPrototypeOf(s);s&&n(s);for(var c=XMLHttpRequest.prototype;c&&!c.hasOwnProperty("addEventListener");)c=Object.getPrototypeOf(c);c&&n(c)}else XMLHttpRequest.prototype.hasOwnProperty("addEventListener")&&n(XMLHttpRequest.prototype);o.on("addEventListener-start",function(t){if(t[1]){var e=t[1];"function"==typeof e?this.wrapped=t[1]=a(e,"nr@wrapped",function(){return i(e,"fn-",null,e.name||"anonymous")}):"function"==typeof e.handleEvent&&i.inPlace(e,["handleEvent"],"fn-")}}),o.on("removeEventListener-start",function(t){var e=this.wrapped;e&&(t[1]=e)})},{1:22,ee:"QJf3ax",gos:"7eSDFh"}],6:[function(t,e){var n=t("ee").create(),r=t(1)(n);e.exports=n,r.inPlace(window,["requestAnimationFrame","mozRequestAnimationFrame","webkitRequestAnimationFrame","msRequestAnimationFrame"],"raf-"),n.on("raf-start",function(t){t[0]=r(t[0],"fn-")})},{1:22,ee:"QJf3ax"}],7:[function(t,e){function n(t,e,n){t[0]=o(t[0],"fn-",null,n)}var r=t("ee").create(),o=t(1)(r);e.exports=r,o.inPlace(window,["setTimeout","setInterval","setImmediate"],"setTimer-"),r.on("setTimer-start",n)},{1:22,ee:"QJf3ax"}],8:[function(t,e){function n(){u.inPlace(this,p,"fn-")}function r(t,e){u.inPlace(e,["onreadystatechange"],"fn-")}function o(t,e){return e}function i(t,e){for(var n in t)e[n]=t[n];return e}var a=t("ee").create(),s=t(1),c=t(2),u=c(a),f=c(s),d=window.XMLHttpRequest,p=["onload","onerror","onabort","onloadstart","onloadend","onprogress","ontimeout"];e.exports=a,window.XMLHttpRequest=function(t){var e=new d(t);try{a.emit("new-xhr",[],e),f.inPlace(e,["addEventListener","removeEventListener"],"-",o),e.addEventListener("readystatechange",n,!1)}catch(r){try{a.emit("internal-error",[r])}catch(i){}}return e},i(d,XMLHttpRequest),XMLHttpRequest.prototype=d.prototype,u.inPlace(XMLHttpRequest.prototype,["open","send"],"-xhr-",o),a.on("send-xhr-start",r),a.on("open-xhr-start",r)},{1:5,2:22,ee:"QJf3ax"}],9:[function(t){function e(t){var e=this.params,r=this.metrics;if(!this.ended){this.ended=!0;for(var i=0;c>i;i++)t.removeEventListener(s[i],this.listener,!1);if(!e.aborted){if(r.duration=(new Date).getTime()-this.startTime,4===t.readyState){e.status=t.status;var a=t.responseType,u="arraybuffer"===a||"blob"===a||"json"===a?t.response:t.responseText,f=n(u);if(f&&(r.rxSize=f),this.sameOrigin){var d=t.getResponseHeader("X-NewRelic-App-Data");d&&(e.cat=d.split(", ").pop())}}else e.status=0;r.cbTime=this.cbTime,o("xhr",[e,r,this.startTime])}}}function n(t){if("string"==typeof t&&t.length)return t.length;if("object"!=typeof t)return void 0;if("undefined"!=typeof ArrayBuffer&&t instanceof ArrayBuffer&&t.byteLength)return t.byteLength;if("undefined"!=typeof Blob&&t instanceof Blob&&t.size)return t.size;if("undefined"!=typeof FormData&&t instanceof FormData)return void 0;try{return JSON.stringify(t).length}catch(e){return void 0}}function r(t,e){var n=i(e),r=t.params;r.host=n.hostname+":"+n.port,r.pathname=n.pathname,t.sameOrigin=n.sameOrigin}if(window.XMLHttpRequest&&XMLHttpRequest.prototype&&XMLHttpRequest.prototype.addEventListener&&!/CriOS/.test(navigator.userAgent)){t("loader").features.xhr=!0;var o=t("handle"),i=t(2),a=t("ee"),s=["load","error","abort","timeout"],c=s.length,u=t(1);t(4),t(3),a.on("new-xhr",function(){this.totalCbs=0,this.called=0,this.cbTime=0,this.end=e,this.ended=!1,this.xhrGuids={}}),a.on("open-xhr-start",function(t){this.params={method:t[0]},r(this,t[1]),this.metrics={}}),a.on("open-xhr-end",function(t,e){"loader_config"in NREUM&&"xpid"in NREUM.loader_config&&this.sameOrigin&&e.setRequestHeader("X-NewRelic-ID",NREUM.loader_config.xpid)}),a.on("send-xhr-start",function(t,e){var r=this.metrics,o=t[0],i=this;if(r&&o){var u=n(o);u&&(r.txSize=u)}this.startTime=(new Date).getTime(),this.listener=function(t){try{"abort"===t.type&&(i.params.aborted=!0),("load"!==t.type||i.called===i.totalCbs&&(i.onloadCalled||"function"!=typeof e.onload))&&i.end(e)}catch(n){try{a.emit("internal-error",[n])}catch(r){}}};for(var f=0;c>f;f++)e.addEventListener(s[f],this.listener,!1)}),a.on("xhr-cb-time",function(t,e,n){this.cbTime+=t,e?this.onloadCalled=!0:this.called+=1,this.called!==this.totalCbs||!this.onloadCalled&&"function"==typeof n.onload||this.end(n)}),a.on("xhr-load-added",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&!this.xhrGuids[n]&&(this.xhrGuids[n]=!0,this.totalCbs+=1)}),a.on("xhr-load-removed",function(t,e){var n=""+u(t)+!!e;this.xhrGuids&&this.xhrGuids[n]&&(delete this.xhrGuids[n],this.totalCbs-=1)}),a.on("addEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-added",[t[1],t[2]],e)}),a.on("removeEventListener-end",function(t,e){e instanceof XMLHttpRequest&&"load"===t[0]&&a.emit("xhr-load-removed",[t[1],t[2]],e)}),a.on("fn-start",function(t,e,n){e instanceof XMLHttpRequest&&("onload"===n&&(this.onload=!0),("load"===(t[0]&&t[0].type)||this.onload)&&(this.xhrCbStart=(new Date).getTime()))}),a.on("fn-end",function(t,e){this.xhrCbStart&&a.emit("xhr-cb-time",[(new Date).getTime()-this.xhrCbStart,this.onload,e],e)})}},{1:"XL7HBI",2:10,3:8,4:5,ee:"QJf3ax",handle:"D5DuLP",loader:"G9z0Bl"}],10:[function(t,e){e.exports=function(t){var e=document.createElement("a"),n=window.location,r={};e.href=t,r.port=e.port;var o=e.href.split("://");return!r.port&&o[1]&&(r.port=o[1].split("/")[0].split("@").pop().split(":")[1]),r.port&&"0"!==r.port||(r.port="https"===o[0]?"443":"80"),r.hostname=e.hostname||n.hostname,r.pathname=e.pathname,r.protocol=o[0],"/"!==r.pathname.charAt(0)&&(r.pathname="/"+r.pathname),r.sameOrigin=!e.hostname||e.hostname===document.domain&&e.port===n.port&&e.protocol===n.protocol,r}},{}],11:[function(t,e){function n(t){return function(){r(t,[(new Date).getTime()].concat(i(arguments)))}}var r=t("handle"),o=t(1),i=t(2);"undefined"==typeof window.newrelic&&(newrelic=window.NREUM);var a=["setPageViewName","addPageAction","setCustomAttribute","finished","addToTrace","inlineHit","noticeError"];o(a,function(t,e){window.NREUM[e]=n("api-"+e)}),e.exports=window.NREUM},{1:20,2:21,handle:"D5DuLP"}],gos:[function(t,e){e.exports=t("7eSDFh")},{}],"7eSDFh":[function(t,e){function n(t,e,n){if(r.call(t,e))return t[e];var o=n();if(Object.defineProperty&&Object.keys)try{return Object.defineProperty(t,e,{value:o,writable:!0,enumerable:!1}),o}catch(i){}return t[e]=o,o}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],D5DuLP:[function(t,e){function n(t,e,n){return r.listeners(t).length?r.emit(t,e,n):void(r.q&&(r.q[t]||(r.q[t]=[]),r.q[t].push(e)))}var r=t("ee").create();e.exports=n,n.ee=r,r.q={}},{ee:"QJf3ax"}],handle:[function(t,e){e.exports=t("D5DuLP")},{}],XL7HBI:[function(t,e){function n(t){var e=typeof t;return!t||"object"!==e&&"function"!==e?-1:t===window?0:i(t,o,function(){return r++})}var r=1,o="nr@id",i=t("gos");e.exports=n},{gos:"7eSDFh"}],id:[function(t,e){e.exports=t("XL7HBI")},{}],G9z0Bl:[function(t,e){function n(){var t=p.info=NREUM.info,e=u.getElementsByTagName("script")[0];if(t&&t.licenseKey&&t.applicationID&&e){s(d,function(e,n){e in t||(t[e]=n)});var n="https"===f.split(":")[0]||t.sslForHttp;p.proto=n?"https://":"http://",a("mark",["onload",i()]);var r=u.createElement("script");r.src=p.proto+t.agent,e.parentNode.insertBefore(r,e)}}function r(){"complete"===u.readyState&&o()}function o(){a("mark",["domContent",i()])}function i(){return(new Date).getTime()}var a=t("handle"),s=t(1),c=window,u=c.document;t(2);var f=(""+location).split("?")[0],d={beacon:"bam.nr-data.net",errorBeacon:"bam.nr-data.net",agent:"js-agent.newrelic.com/nr-686.min.js"},p=e.exports={offset:i(),origin:f,features:{}};u.addEventListener?(u.addEventListener("DOMContentLoaded",o,!1),c.addEventListener("load",n,!1)):(u.attachEvent("onreadystatechange",r),c.attachEvent("onload",n)),a("mark",["firstbyte",i()])},{1:20,2:11,handle:"D5DuLP"}],loader:[function(t,e){e.exports=t("G9z0Bl")},{}],20:[function(t,e){function n(t,e){var n=[],o="",i=0;for(o in t)r.call(t,o)&&(n[i]=e(o,t[o]),i+=1);return n}var r=Object.prototype.hasOwnProperty;e.exports=n},{}],21:[function(t,e){function n(t,e,n){e||(e=0),"undefined"==typeof n&&(n=t?t.length:0);for(var r=-1,o=n-e||0,i=Array(0>o?0:o);++r<o;)i[r]=t[e+r];return i}e.exports=n},{}],22:[function(t,e){function n(t){return!(t&&"function"==typeof t&&t.apply&&!t[i])}var r=t("ee"),o=t(1),i="nr@wrapper",a=Object.prototype.hasOwnProperty;e.exports=function(t){function e(t,e,r,a){function nrWrapper(){var n,i,s,u;try{i=this,n=o(arguments),s=r&&r(n,i)||{}}catch(d){f([d,"",[n,i,a],s])}c(e+"start",[n,i,a],s);try{return u=t.apply(i,n)}catch(p){throw c(e+"err",[n,i,p],s),p}finally{c(e+"end",[n,i,u],s)}}return n(t)?t:(e||(e=""),nrWrapper[i]=!0,u(t,nrWrapper),nrWrapper)}function s(t,r,o,i){o||(o="");var a,s,c,u="-"===o.charAt(0);for(c=0;c<r.length;c++)s=r[c],a=t[s],n(a)||(t[s]=e(a,u?s+o:o,i,s))}function c(e,n,r){try{t.emit(e,n,r)}catch(o){f([o,e,n,r])}}function u(t,e){if(Object.defineProperty&&Object.keys)try{var n=Object.keys(t);return n.forEach(function(n){Object.defineProperty(e,n,{get:function(){return t[n]},set:function(e){return t[n]=e,e}})}),e}catch(r){f([r])}for(var o in t)a.call(t,o)&&(e[o]=t[o]);return e}function f(e){try{t.emit("internal-error",e)}catch(n){}}return t||(t=r),e.inPlace=s,e.flag=i,e}},{1:21,ee:"QJf3ax"}]},{},["G9z0Bl",4,9]);</script><meta name="description" content="The Inaugural GPA User�s Forum and Time Series Framework Tutorial will be held at the Georgia Power Headquarters Building in Atlanta on September 6 and 7, 2011, 8 am - 5 pm.  Location hosted by Southern Company.  Lunch will be provided, both days." /><script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

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

<body id="a07e48trjzi1">



<div class="cc-document" id="cc-container">

    <div id="cc-branding-outer">

    <div class="cc-panel" id="cc-branding-inner">

    <div id="cc-block1" class="cc-block">

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

    <div id="cc-block2" class="cc-block">

<H3>Contact</H3><SPAN class=cc-var title=Event.contactName>Brenda Moses</SPAN>&nbsp;<BR><SPAN class=cc-var title=Event.contactOrganization>Grid Protection Alliance</SPAN>&nbsp;<BR><SPAN class=cc-var title=Event.contactEmail>bjmoses@gridprotectionalliance.org</SPAN>&nbsp;<BR>(423) 973-4731<BR>

</div>

<div id="cc-block5" class="cc-block">

<H3>When</H3><SPAN style="COLOR: #339966; FONT-SIZE: 18pt"><STRONG>September 6&nbsp;and 7, 2011 </STRONG></SPAN><BR><SPAN class=cc-var title=Event.addToCalendarLink><a title="Add to my calendar" id="lnkAddToCalendar" href="http://events.r20.constantcontact.com/register/addtocalendar?oeidk=a07e46l1y64fdadcaf2" class="cc-calendar">Add to my calendar</a></SPAN>&nbsp;<BR>

</div>

<div id="cc-block6" class="cc-block">

<h3>Where</h3>

<p><span>Georgia Power Building</span>&nbsp;<br><span title="Event.addressHtml" class="cc-var">241 Ralph McGill Boulevard NE<br />Atlanta, GA 30308</span>&nbsp;<br><span style="color: #993300;">Location Provided by&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Southern Company&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><br><span title="Event.map" class="cc-var"><img height="200" width="200" src="https://api.tiles.virtualearth.net/api/GetMap.ashx?ppl=24,,33.762936,-84.378624&amp;z=12&amp;h=200&amp;w=200

          " /></span>&nbsp;<br><span title="Event.googleDrivingDirectionsNoStyle" class="cc-var"><a title="Driving Directions" id="idDrivingDir" href="http://maps.google.com/maps?daddr=241 Ralph McGill Boulevard NE, Atlanta, GA, 30308, US" target="_blank">Driving Directions</a></span>&nbsp;&nbsp;</p>

<p><span style="font-size: 14pt;"><span style="color: #993300;"><b>Industry Speakers:</b></span><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </b></span><span style="color: #008000;"><span style="font-size: 12pt;"><b>Midwest ISO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></span>Ryan McCoy / James Pruitt</span></p>

<p><span style="color: #008000; font-size: 12pt;"><b>Oklahoma Gas &amp; Electric&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></span><span style="color: #008000;">Steve Chisholm</span></p>

<p><span style="color: #008000;">&nbsp;</span><span style="color: #008000;"><span style="font-size: 12pt;"><b>New England ISO &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </b></span>&nbsp;Qiang 'Frankie' Zhang</span><span style="color: #008000;">&nbsp;</span></p>

<p><span style="color: #993300; font-size: 14pt;"><b>University Speakers:</b></span><span style="color: #008000;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></span><span style="color: #008000; font-size: 12pt;"><b>KTH Royal Institute of Technology </b></span><span style="color: #008000;">Moustafa Chenine / Lars Nordstrom</span><span style="color: #008000;">&nbsp;</span></p>

<p><span style="color: #008000;"><b>Washington State <span style="font-size: 12pt;">University</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></span><span style="color: #008000;">Mani Venkatasubramanian</span></p>

<p><span style="color: #993300; font-size: 14pt;">Tutorial Highlights:</span></p>

<ul>

<li>

<div class="_mcePaste" style="display: inline;"></div>

<div class="_mcePaste" style="display: inline;"><span style="color: #008000;">Setting up and using OpenPDC</span></div>

</li>

<li>

<div class="_mcePaste" style="display: inline;"><span style="color: #339966;">&nbsp;</span></div>

<span style="color: #008000;">Establishing a distributed archive</span></li>

<li align="left" style="text-align: left; color: #008000; font-size: 11pt;">Deploying custom calculations and action adapters</li>

<li align="left" style="text-align: left; color: #008000; font-size: 11pt;">Developing new adapters and calculations </li>

<li align="left" style="text-align: left; color: #008000; font-size: 11pt;">Extended code level overview of Time Series Framework</li>

</ul>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

</div>



</div>



</div>

<div class="cc-panel" id="cc-content">

    <div id="cc-block3" class="cc-block">

<P><SPAN style="FONT-SIZE: 14pt"><SPAN style="COLOR: #008000">Inaugural Grid Protection Alliance User's Forum and&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></SPAN><SPAN style="FONT-SIZE: 14pt"><SPAN style="COLOR: #008000">Grid Protection Alliance&nbsp;Time Series Framework Tutorial</SPAN></SPAN></P>

</div>

<div id="cc-block4" class="cc-block">

<P>The Grid Protection Alliance (GPA) is pleased to invite you to participate in a full-day tutorial on the Time Series Framework (TSF), and the inaugural User&#8217;s&nbsp;Forum for GPA&#8217;s open-source projects, including the TSF, openPDC, and openPG, to be held September 6 and&nbsp;7, 2011, at the Georgia Power Building in Atlanta.</P>

<P>The TSF is an open-source project that houses most of the fundamental functionality of the openPDC, the openPG, the PMU connection tester, and other GPA open-source products.&nbsp; The TSF can be used to process and manage streaming, time-stamped data through a collection of configurable adapter components.&nbsp; The one-day tutorial on September 6, from 8 am to 5 pm, will include a comprehensive introduction to the TSF,&nbsp;and real world examples.&nbsp;&nbsp;Developers will gain&nbsp;a working knowledge of the framework, which will enable them to extend existing modules, or develope new modules to add to the library.</P>

<P>The User's Forum, on September 7, from 8 am to&nbsp;3&nbsp;pm,&nbsp;will educate those that are new to GPA&nbsp;open-source projects,&nbsp;inform developers about new software components, and provide insight from the industry on the practical application of the TSF, openPDC, and openPG.&nbsp; Your input during the forum will be used to help prioritize GPA&#8217;s development work in 2012.&nbsp;</P>

<P>GPA provides and supports software solutions for the electric utility&nbsp;industry.&nbsp; GPA&#8217;s mission is to improve the reliability and resiliency of the electric grid, through state-of-the-art applications.&nbsp; All GPA software products are open source.</P>

<P>As a not-for-profit corporation, GPA seeks to build collaborative&nbsp;relationships among&nbsp; government agencies, regulators, vendors, and grid owner-operators. &nbsp;These GPA efforts incorporate and improve technologies, to create a more secure, more robust, and smarter electric grid.</P>

<P>For more information about our products, go to:</P>

<P><A href="http://timeseriesframework.codeplex.com/">http:\\timeseriesframework.codeplex.com</A><BR><A href="http://openpdc.codeplex.com/">http:\\openPDC.codeplex.com</A><BR><A href="http://openpg.codeplex.com/">http:\\openPG.codeplex.com</A></P>

<P>&nbsp;</P>

<P>&nbsp;</P>

</div>

<div id="cc-block7" class="cc-block">

<SPAN title=Event.registerLink><A id=lnkRegister class=cc-register title="Register Now!" href="http://events.r20.constantcontact.com/register/eventReg?llr=cgvygggab&amp;oeidk=a07e46l1y64fdadcaf2" target=_blank>Register Now!</A></SPAN>&nbsp;

</div>

<div id="cc-block8" class="cc-block">

<A href="http://visitor.r20.constantcontact.com/d.jsp?llr=cgvygggab&amp;p=oi&amp;m=1106162504898" shape=rect target=_blank><IMG border=0 alt="Join My Mailing List" vspace=5 src="https://imgssl.constantcontact.com/letters/images/1101093164665/jmml_opgr1_img1.gif"></A>

</div>

<div id="cc-block9" class="cc-block">

<h3>User Forum Agenda</h3>

<p>8:00-8:05 Welcome, Introductions, Thank You to Southern (GPA)</p>

<p>8:05-8:20 Open Source Intro &#8211; Video (GPA)</p>

<p>8:20-8:50 openPDC Status / Objectives for v1.5 (GPA)</p>

<p>8:50-9:20 Oklahoma Gas &amp; Electric (Steve Chisholm)</p>

<p>9:20-9:30 Break</p>

<p>9:30-10:00 KTH Royal Institute of Tech (Luigi Vanfretti / Moustafa Chenine / Lars Nordstrom)</p>

<p>10:00-10:30 Midwest ISO (Ryan McCoy / James Pruitt)</p>

<p>10:30-11:00 New England ISO (Qiang 'Frankie' Zhang)</p>

<p>11:00-11:15 TVA &#8211; The TVA Code Library (Pinal Patel)</p>

<p>11:15-11:30 openPG Status / Throughput Demo (GPA)&nbsp;</p>

<p>11:30-12:30 Lunch / Networking</p>

<p>12:30-1:00 Washington State University (Vaithianathan 'Mani' Venkatasubramanian)</p>

<p>1:00-1:30 NERC Update / Product Road Map (GPA)</p>

<p>1:30-3:00 Facilitated discussion to establish GPA Product direction for 2012 (GPA)</p>

</div>



</div>



</div>



</div>

<div id="cc-site-info-outer">

    <div class="cc-panel" id="cc-site-info">

    

</div>



</div>



</div>



<div class="cc-footer" style="background-color: rgb(255, 255, 255); text-align: center; bottom: 0; left: 0; position: fixed; width: 100%; z-index: 999;">

    <div style="word-wrap: normal; padding: 5px 5px;">

        <a href="http://www.constantcontact.com/eventmarketing?pn=ROVING&cc=" target="_blank"><img border="0" src="https://imgssl.constantcontact.com/ui/images1/EVMTryItFreeToday.gif" /></a>

        <a href="http://www.constantcontact.com/eventmarketing?pn=ROVING&cc=" target="_blank"><img border="0" src="https://imgssl.constantcontact.com/ui/images1/EvMButton.gif" /></a>

</div>

</div>





<span id="event-meta-hcalendar" class="vevent" style="display:none;">

    <span class="dtstart"><span class="value-title" title="2011-09-06T08:00:00-0400"></span>2011-09-06T08:00:00-0400</span>

    <span class="dtend"><span class="value-title" title="2011-09-07T15:00:00-0400"></span>2011-09-07T15:00:00-0400</span>

    <span class="summary">Inaugural GPA User's Forum and GPA TSF Tutorial</span>

    <span class="location">241 Ralph McGill Boulevard NE, Atlanta, GA, 30308, US</span>

    <a class="url" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/GPA_2011_-_1st_Annual_Forum.md">http://events.r20.constantcontact.com/register/event?llr=cgvygggab&oeidk=a07e46l1y64fdadcaf2</a>

</span>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</html>
