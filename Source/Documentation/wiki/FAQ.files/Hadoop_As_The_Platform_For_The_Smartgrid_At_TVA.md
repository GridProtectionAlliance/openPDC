
<html lang="en">
<head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# 2490221586: http://ogp.me/ns/fb/2490221586#">
<meta charset="utf-8"/>
<meta name="viewport" 

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

content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no"/>
<meta name="include_mode" content="async">
<!-- SL:start:notranslate -->
<title>Hadoop As The Platform For The Smartgrid At TVA</title>
<meta name="description" content="Cloudera&#x27;s Josh Paterson presented how Hadoop is used as the platform for smartgrid technologies at the Tennessee Valley Authority. This presentation encompass…">
<!-- SL:end:notranslate -->
<meta name="robots" content="index">
<meta id='globalTrackingUrl' content="https://www.linkedin.com/li/track">
<!-- SL:start:notranslate -->
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta http-equiv="x-dns-prefetch-control" content="on">
<meta name="thumbnail" content="http://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail.jpg?cb=1327341063"/>
<!-- SL:end:notranslate -->
<link rel="shortcut icon" href="http://public.slidesharecdn.com/b/images/logo/linkedin-ss/linkedin_ss_favicon.ico?d0e5c05903">
<link rel="alternate" type="application/rss+xml" title="RSS" href="http://www.slideshare.net/rss/latest"/>
<link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="SlideShare Search">
<link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/app_critical.css?e92d50816e" media="screen" rel="stylesheet" type="text/css"/>
<!--[if IE 9]><link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/ie9_nav_bar_fix.css?8fb8af5274" media="screen" rel="stylesheet" type="text/css" /><![endif]-->
<link rel="alternate" hreflang="en" href="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<link rel="alternate" hreflang="es" href="http://es.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<link rel="alternate" hreflang="fr" href="http://fr.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<link rel="alternate" hreflang="de" href="http://de.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<link rel="alternate" hreflang="pt" href="http://pt.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<link rel="alternate" hreflang="x-default" href="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<script type="text/javascript">//<![CDATA[
var smtId="ab5bb963d";var smtDefaultStyles=false;var smtRedirect=true;var smtProt=(("https:"==document.location.protocol)?"https://":"http://");var smtPreRender=function(data){for(i in data){if(data[i].code==="en-us"){data[i].name="English";}}};var smtRedirectMapper=function(locale,sites){if(/^es/i.test(locale)){return null;}
if(locale in sites){return sites[locale];}
if(/^fr/i.test(locale)){return sites['fr-fr']||null;}
if(/^de/i.test(locale)){return sites['de-de']||null;}
return null;};var smtElmt=document.createElement('script');smtElmt.type="text/javascript";smtElmt.async=true;smtElmt.src=smtProt+"cdn01.smartling.com/ls/"+smtId+".js";script=document.getElementsByTagName("script")[0];script.parentNode.insertBefore(smtElmt,script);
//]]></script>
<meta content="authenticity_token" name="csrf-param"/>
<meta content="l6XSK0mrnFmOKo5v54gbRLzkotYPsoQfHsvDXP50wzU=" name="csrf-token"/>
<meta content="index" name="robots"/>
<link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/slideview_critical.css?8c8ca866a1" media="screen" rel="stylesheet" type="text/css"/>
<link href="http://public.slidesharecdn.com/b/stylesheets/ssplayer/combined_presentation.css?afc404d111" media="screen" rel="stylesheet" type="text/css"/>
<link rel="dns-prefetch" href="//www.slideshare.net">
<link rel="dns-prefetch" href="//public.slidesharecdn.com">
<link rel="dns-prefetch" href="//image.slidesharecdn.com">
<link rel="dns-prefetch" href="//cdn.slidesharecdn.com">
<link rel="dns-prefetch" href="//cdn01.smartling.com">
<link rel="dns-prefetch" href="//www.linkedin.com">
<script type='text/javascript'>window.Modernizr=function(a,b,c){function d(a){t.cssText=a}function e(a,b){return d(x.join(a+";")+(b||""))}function f(a,b){return typeof a===b}function g(a,b){return!!~(""+a).indexOf(b)}function h(a,b){for(var d in a){var e=a[d];if(!g(e,"-")&&t[e]!==c)return"pfx"==b?e:!0}return!1}function i(a,b,d){for(var e in a){var g=b[a[e]];if(g!==c)return d===!1?a[e]:f(g,"function")?g.bind(d||b):g}return!1}function j(a,b,c){var d=a.charAt(0).toUpperCase()+a.slice(1),e=(a+" "+z.join(d+" ")+d).split(" ");return f(b,"string")||f(b,"undefined")?h(e,b):(e=(a+" "+A.join(d+" ")+d).split(" "),i(e,b,c))}function k(){o.input=function(c){for(var d=0,e=c.length;e>d;d++)E[c[d]]=!!(c[d]in u);return E.list&&(E.list=!(!b.createElement("datalist")||!a.HTMLDataListElement)),E}("autocomplete autofocus list placeholder max min multiple pattern required step".split(" ")),o.inputtypes=function(a){for(var d,e,f,g=0,h=a.length;h>g;g++)u.setAttribute("type",e=a[g]),d="text"!==u.type,d&&(u.value=v,u.style.cssText="position:absolute;visibility:hidden;",/^range$/.test(e)&&u.style.WebkitAppearance!==c?(q.appendChild(u),f=b.defaultView,d=f.getComputedStyle&&"textfield"!==f.getComputedStyle(u,null).WebkitAppearance&&0!==u.offsetHeight,q.removeChild(u)):/^(search|tel)$/.test(e)||(d=/^(url|email)$/.test(e)?u.checkValidity&&u.checkValidity()===!1:u.value!=v)),D[a[g]]=!!d;return D}("search tel url email datetime date month week time datetime-local number range color".split(" "))}var l,m,n="2.8.2",o={},p=!0,q=b.documentElement,r="modernizr",s=b.createElement(r),t=s.style,u=b.createElement("input"),v=":)",w={}.toString,x=" -webkit- -moz- -o- -ms- ".split(" "),y="Webkit Moz O ms",z=y.split(" "),A=y.toLowerCase().split(" "),B={svg:"http://www.w3.org/2000/svg"},C={},D={},E={},F=[],G=F.slice,H=function(a,c,d,e){var f,g,h,i,j=b.createElement("div"),k=b.body,l=k||b.createElement("body");if(parseInt(d,10))for(;d--;)h=b.createElement("div"),h.id=e?e[d]:r+(d+1),j.appendChild(h);return f=["&#173;",'<style id="s',r,'">',a,"</style>"].join(""),j.id=r,(k?j:l).innerHTML+=f,l.appendChild(j),k||(l.style.background="",l.style.overflow="hidden",i=q.style.overflow,q.style.overflow="hidden",q.appendChild(l)),g=c(j,a),k?j.parentNode.removeChild(j):(l.parentNode.removeChild(l),q.style.overflow=i),!!g},I=function(b){var c=a.matchMedia||a.msMatchMedia;if(c)return c(b)&&c(b).matches||!1;var d;return H("@media "+b+" { #"+r+" { position: absolute; } }",function(b){d="absolute"==(a.getComputedStyle?getComputedStyle(b,null):b.currentStyle).position}),d},J=function(){function a(a,e){e=e||b.createElement(d[a]||"div"),a="on"+a;var g=a in e;return g||(e.setAttribute||(e=b.createElement("div")),e.setAttribute&&e.removeAttribute&&(e.setAttribute(a,""),g=f(e[a],"function"),f(e[a],"undefined")||(e[a]=c),e.removeAttribute(a))),e=null,g}var d={select:"input",change:"input",submit:"form",reset:"form",error:"img",load:"img",abort:"img"};return a}(),K={}.hasOwnProperty;m=f(K,"undefined")||f(K.call,"undefined")?function(a,b){return b in a&&f(a.constructor.prototype[b],"undefined")}:function(a,b){return K.call(a,b)},Function.prototype.bind||(Function.prototype.bind=function(a){var b=this;if("function"!=typeof b)throw new TypeError;var c=G.call(arguments,1),d=function(){if(this instanceof d){var e=function(){};e.prototype=b.prototype;var f=new e,g=b.apply(f,c.concat(G.call(arguments)));return Object(g)===g?g:f}return b.apply(a,c.concat(G.call(arguments)))};return d}),C.flexbox=function(){return j("flexWrap")},C.flexboxlegacy=function(){return j("boxDirection")},C.canvas=function(){var a=b.createElement("canvas");return!(!a.getContext||!a.getContext("2d"))},C.canvastext=function(){return!(!o.canvas||!f(b.createElement("canvas").getContext("2d").fillText,"function"))},C.webgl=function(){return!!a.WebGLRenderingContext},C.touch=function(){var c;return"ontouchstart"in a||a.DocumentTouch&&b instanceof DocumentTouch?c=!0:H(["@media (",x.join("touch-enabled),("),r,")","{#modernizr{top:9px;position:absolute}}"].join(""),function(a){c=9===a.offsetTop}),c},C.geolocation=function(){return"geolocation"in navigator},C.postmessage=function(){return!!a.postMessage},C.websqldatabase=function(){return!!a.openDatabase},C.indexedDB=function(){return!!j("indexedDB",a)},C.hashchange=function(){return J("hashchange",a)&&(b.documentMode===c||b.documentMode>7)},C.history=function(){return!(!a.history||!history.pushState)},C.draganddrop=function(){var a=b.createElement("div");return"draggable"in a||"ondragstart"in a&&"ondrop"in a},C.websockets=function(){return"WebSocket"in a||"MozWebSocket"in a},C.rgba=function(){return d("background-color:rgba(150,255,150,.5)"),g(t.backgroundColor,"rgba")},C.hsla=function(){return d("background-color:hsla(120,40%,100%,.5)"),g(t.backgroundColor,"rgba")||g(t.backgroundColor,"hsla")},C.multiplebgs=function(){return d("background:url(https://),url(https://),red url(https://)"),/(url\s*\(.*?){3}/.test(t.background)},C.backgroundsize=function(){return j("backgroundSize")},C.borderimage=function(){return j("borderImage")},C.borderradius=function(){return j("borderRadius")},C.boxshadow=function(){return j("boxShadow")},C.textshadow=function(){return""===b.createElement("div").style.textShadow},C.opacity=function(){return e("opacity:.55"),/^0.55$/.test(t.opacity)},C.cssanimations=function(){return j("animationName")},C.csscolumns=function(){return j("columnCount")},C.cssgradients=function(){var a="background-image:",b="gradient(linear,left top,right bottom,from(#9f9),to(white));",c="linear-gradient(left top,#9f9, white);";return d((a+"-webkit- ".split(" ").join(b+a)+x.join(c+a)).slice(0,-a.length)),g(t.backgroundImage,"gradient")},C.cssreflections=function(){return j("boxReflect")},C.csstransforms=function(){return!!j("transform")},C.csstransforms3d=function(){var a=!!j("perspective");return a&&"webkitPerspective"in q.style&&H("@media (transform-3d),(-webkit-transform-3d){#modernizr{left:9px;position:absolute;height:3px;}}",function(b){a=9===b.offsetLeft&&3===b.offsetHeight}),a},C.csstransitions=function(){return j("transition")},C.fontface=function(){var a;return H('@font-face {font-family:"font";src:url("https://")}',function(c,d){var e=b.getElementById("smodernizr"),f=e.sheet||e.styleSheet,g=f?f.cssRules&&f.cssRules[0]?f.cssRules[0].cssText:f.cssText||"":"";a=/src/i.test(g)&&0===g.indexOf(d.split(" ")[0])}),a},C.generatedcontent=function(){var a;return H(["#",r,"{font:0/0 a}#",r,':after{content:"',v,'";visibility:hidden;font:3px/1 a}'].join(""),function(b){a=b.offsetHeight>=3}),a},C.video=function(){var a=b.createElement("video"),c=!1;try{(c=!!a.canPlayType)&&(c=new Boolean(c),c.ogg=a.canPlayType('video/ogg; codecs="theora"').replace(/^no$/,""),c.h264=a.canPlayType('video/mp4; codecs="avc1.42E01E"').replace(/^no$/,""),c.webm=a.canPlayType('video/webm; codecs="vp8, vorbis"').replace(/^no$/,""))}catch(d){}return c},C.audio=function(){var a=b.createElement("audio"),c=!1;try{(c=!!a.canPlayType)&&(c=new Boolean(c),c.ogg=a.canPlayType('audio/ogg; codecs="vorbis"').replace(/^no$/,""),c.mp3=a.canPlayType("audio/mpeg;").replace(/^no$/,""),c.wav=a.canPlayType('audio/wav; codecs="1"').replace(/^no$/,""),c.m4a=(a.canPlayType("audio/x-m4a;")||a.canPlayType("audio/aac;")).replace(/^no$/,""))}catch(d){}return c},C.localstorage=function(){try{return localStorage.setItem(r,r),localStorage.removeItem(r),!0}catch(a){return!1}},C.sessionstorage=function(){try{return sessionStorage.setItem(r,r),sessionStorage.removeItem(r),!0}catch(a){return!1}},C.webworkers=function(){return!!a.Worker},C.applicationcache=function(){return!!a.applicationCache},C.svg=function(){return!!b.createElementNS&&!!b.createElementNS(B.svg,"svg").createSVGRect},C.inlinesvg=function(){var a=b.createElement("div");return a.innerHTML="<svg/>",(a.firstChild&&a.firstChild.namespaceURI)==B.svg},C.smil=function(){return!!b.createElementNS&&/SVGAnimate/.test(w.call(b.createElementNS(B.svg,"animate")))},C.svgclippaths=function(){return!!b.createElementNS&&/SVGClipPath/.test(w.call(b.createElementNS(B.svg,"clipPath")))};for(var L in C)m(C,L)&&(l=L.toLowerCase(),o[l]=C[L](),F.push((o[l]?"":"no-")+l));return o.input||k(),o.addTest=function(a,b){if("object"==typeof a)for(var d in a)m(a,d)&&o.addTest(d,a[d]);else{if(a=a.toLowerCase(),o[a]!==c)return o;b="function"==typeof b?b():b,"undefined"!=typeof p&&p&&(q.className+=" "+(b?"":"no-")+a),o[a]=b}return o},d(""),s=u=null,function(a,b){function c(a,b){var c=a.createElement("p"),d=a.getElementsByTagName("head")[0]||a.documentElement;return c.innerHTML="x<style>"+b+"</style>",d.insertBefore(c.lastChild,d.firstChild)}function d(){var a=s.elements;return"string"==typeof a?a.split(" "):a}function e(a){var b=r[a[p]];return b||(b={},q++,a[p]=q,r[q]=b),b}function f(a,c,d){if(c||(c=b),k)return c.createElement(a);d||(d=e(c));var f;return f=d.cache[a]?d.cache[a].cloneNode():o.test(a)?(d.cache[a]=d.createElem(a)).cloneNode():d.createElem(a),!f.canHaveChildren||n.test(a)||f.tagUrn?f:d.frag.appendChild(f)}function g(a,c){if(a||(a=b),k)return a.createDocumentFragment();c=c||e(a);for(var f=c.frag.cloneNode(),g=0,h=d(),i=h.length;i>g;g++)f.createElement(h[g]);return f}function h(a,b){b.cache||(b.cache={},b.createElem=a.createElement,b.createFrag=a.createDocumentFragment,b.frag=b.createFrag()),a.createElement=function(c){return s.shivMethods?f(c,a,b):b.createElem(c)},a.createDocumentFragment=Function("h,f","return function(){var n=f.cloneNode(),c=n.createElement;h.shivMethods&&("+d().join().replace(/[\w\-]+/g,function(a){return b.createElem(a),b.frag.createElement(a),'c("'+a+'")'})+");return n}")(s,b.frag)}function i(a){a||(a=b);var d=e(a);return!s.shivCSS||j||d.hasCSS||(d.hasCSS=!!c(a,"article,aside,dialog,figcaption,figure,footer,header,hgroup,main,nav,section{display:block}mark{background:#FF0;color:#000}template{display:none}")),k||h(a,d),a}var j,k,l="3.7.0",m=a.html5||{},n=/^<|^(?:button|map|select|textarea|object|iframe|option|optgroup)$/i,o=/^(?:a|b|code|div|fieldset|h1|h2|h3|h4|h5|h6|i|label|li|ol|p|q|span|strong|style|table|tbody|td|th|tr|ul)$/i,p="_html5shiv",q=0,r={};!function(){try{var a=b.createElement("a");a.innerHTML="<xyz></xyz>",j="hidden"in a,k=1==a.childNodes.length||function(){b.createElement("a");var a=b.createDocumentFragment();return"undefined"==typeof a.cloneNode||"undefined"==typeof a.createDocumentFragment||"undefined"==typeof a.createElement}()}catch(c){j=!0,k=!0}}();var s={elements:m.elements||"abbr article aside audio bdi canvas data datalist details dialog figcaption figure footer header hgroup main mark meter nav output progress section summary template time video",version:l,shivCSS:m.shivCSS!==!1,supportsUnknownElements:k,shivMethods:m.shivMethods!==!1,type:"default",shivDocument:i,createElement:f,createDocumentFragment:g};a.html5=s,i(b)}(this,b),o._version=n,o._prefixes=x,o._domPrefixes=A,o._cssomPrefixes=z,o.mq=I,o.hasEvent=J,o.testProp=function(a){return h([a])},o.testAllProps=j,o.testStyles=H,o.prefixed=function(a,b,c){return b?j(a,b,c):j(a,"pfx")},q.className=q.className.replace(/(^|\s)no-js(\s|$)/,"$1$2")+(p?" js "+F.join(" "):""),o}(this,this.document);window._gaq=window._gaq||[];_gaq.push(['_setAccount','UA-2330466-1']);_gaq.push(['_setDomainName','.slideshare.net']);_gaq.push(['_addIgnoredRef','slideshare.net']);_gaq.push(['_setCustomVar',1,'member_type','LOGGEDOUT',1]);_gaq.push(['_trackPageview']);var _comscore=_comscore||[];_comscore.push({c1:"2",c2:"6402952"});var slideshare_object={user:{"login":"guest","show_li_connect_cta":false,"li_tracking_url":"https://www.linkedin.com/li/track","userGroup":"non-member","has_privacy_enabled":null,"name":null,"loggedin":false,"id":null,"su":false,"is_test_user":false,"fb_userid":null,"has_uploads":null,"is_valid_fbuser":false,"is_li_connected":false,"is_pro":"false"},timer:{start:(new Date()).getTime(),end:'',execTime:''},top_nav:{get_url:"/top_nav"},dev:false,fb_app_name:'slideshare',fb_permissions:'email,user_friends',fb_sdk_url:'//connect.facebook.net/en_US/sdk.js',fb_init_params:{appId:'2490221586',version:'v2.3',oauth:true,channelUrl:'//public.slidesharecdn.com/b/channel.html',status:true,cookie:true,xfbml:true},init:[],feature_flag:[],is_mobile:"",deploy_environment:"production",rum_pagekey:"desktop_slideview_loggedout",is_ssl:false};</script>
<meta content="http://public.slidesharecdn.com/b/images/artdeco/icons.svg?43e81fd2ef" name="ss-svg-icons"/>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_experiments.js?5cdb0c4b79" type="text/javascript"></script>
<!-- RUM javascript -->
<script>//<![CDATA[
slideshare_object.rum={beacon_url:'//www.linkedin.com/lite/rum-track',report:{},fire:function(){}}
//]]></script>
<script>//<![CDATA[
(function(){var load_js_async=function(url){var script_tag=document.createElement('script');script_tag.type="text/javascript";script_tag.async=true;script_tag.src=url;document.getElementsByTagName("script")[0].parentNode.appendChild(script_tag);};load_js_async("http://public.slidesharecdn.com/b/javascripts/rum/combined_base.js?7376de6ef4");})();
//]]></script>
<!-- RUM javascript ends -->
<link rel="dns-prefetch" href="//js.bizographics.com">
<script id="page-json" type="text/javascript">var sso_redirect_uri={"sso_redirect_uri":"nil"};</script>
<script id="adQueue" type="text/javascript">if(!slideshare_object.delayedLIAd){slideshare_object._adQueue=[];}</script>
<script type="text/javascript" id="ga-init">//<![CDATA[
window._gaq.push(['_setCustomVar',3,'source','not_set',3]);var Experiments=slideshare_object.utils.imports('Experiments'),experiments=new Experiments();window._gaq.push(['_trackEvent','bigfoot_slideview','pageload','clip_button_exp_'+experiments.getBucket('slideview-clip-button-exp-2'),undefined,true]);slideshare_object.deploy_environment='production';
//]]></script>
<link href="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" rel="canonical"/>
<link title="Slideshow json oEmbed Profile" type="application/json+oembed" href="http://www.slideshare.net/api/oembed/2?format=json&amp;url=http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" rel="alternate"/>
<link title="Slideshow xml oEmbed Profile" type="text/xml+oembed" href="http://www.slideshare.net/api/oembed/2?format=xml&amp;url=http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" rel="alternate"/>
<link media="handheld" href="http://www.slideshare.net/mobile/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" rel="alternate"/>
<link href="android-app://net.slideshare.mobile/slideshare-app/ss/5091794" rel="alternate"/>
<link href="ios-app://917418728/slideshare-app/ss/5091794" rel="alternate"/>
<!-- fb open graph meta tags -->
<meta content="2490221586" class="fb_og_meta" property="fb:app_id" name="fb_app_id"/>
<meta content="slideshare:presentation" class="fb_og_meta" property="og:type" name="og_type"/>
<meta content="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" class="fb_og_meta" property="og:url" name="og_url"/>
<meta content="http://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail-4.jpg?cb=1327341063" class="fb_og_meta" property="og:image" name="og_image"/>
<!-- SL:start:notranslate -->
<meta content="Hadoop As The Platform For The Smartgrid At TVA" class="fb_og_meta" property="og:title" name="og_title"/>
<meta content="Cloudera&#x27;s Josh Paterson presented how Hadoop is used as the platform for smartgrid technologies at the Tennessee Valley Authority. This presentation encompass…" class="fb_og_meta" property="og:description" name="og_description"/>
<!-- SL:end:notranslate -->
<meta content="2010-08-30T16:01:47Z" class="fb_og_meta" property="slideshare:published" name="slideshow_published_time"/>
<meta content="http://www.slideshare.net/cloudera" class="fb_og_meta" property="slideshare:author" name="slideshow_author"/>
<meta content="4640" class="fb_og_meta" property="slideshare:view_count" name="slideshow_view_count"/>
<meta content="3" class="fb_og_meta" property="slideshare:embed_count" name="slideshow_embed_count"/>
<meta content="1" class="fb_og_meta" property="slideshare:comment_count" name="slideshow_comment_count"/>
<meta content="103" class="fb_og_meta" property="slideshare:download_count" name="slideshow_download_count"/>
<meta content="2010-08-30 16:01:47 UTC" class="fb_og_meta" property="slideshare:created_at" name="slideshow_created_at"/>
<meta content="2012-01-23 17:51:03 UTC" class="fb_og_meta" property="slideshare:updated_at" name="slideshow_updated_at"/>
<meta content="" class="fb_og_meta" property="slideshare:featured_on" name="slideshow_featured_on"/>
<meta content="8" class="fb_og_meta" property="slideshare:favorites_count" name="slideshow_favorites_count"/>
<meta content="Technology" class="fb_og_meta" property="slideshare:category" name="slideshow_category"/>
<!-- SL:start:notranslate -->
<meta name="twitter:card" value="player"/>
<meta name="twitter:site" value="@slideshare"/>
<meta class="twitter_player" value="https://www.slideshare.net/slideshow/embed_code/key/Iou4wVMUZodUY9" name="twitter:player"/>
<meta name="twitter:player:width" value="342"/>
<meta name="twitter:player:height" value="291"/>
<meta class="twitter_title" value="Hadoop As The Platform For The Smartgrid At TVA" name="twitter:title"/>
<meta class="twitter_image" value="https://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail-4.jpg?cb=1327341063" name="twitter:image"/>
<meta name="twitter:app:name:googleplay" content="SlideShare Android"/>
<meta name="twitter:app:id:googleplay" content="net.slideshare.mobile"/>
<meta name="twitter:app:url:googleplay" content="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"/>
<meta name="twitter:app:name:iphone" content="SlideShare iOS"/>
<meta name="twitter:app:id:iphone" content="917418728"/>
<meta name="twitter:app:url:iphone" content="slideshare-app://ss/5091794"/>
<meta name="twitter:app:name:ipad" content="SlideShare iOS"/>
<meta name="twitter:app:id:ipad" content="917418728"/>
<meta name="twitter:app:url:ipad" content="slideshare-app://ss/5091794"/>
<meta property="al:android:url" content="slideshare-app://ss/5091794"/>
<meta property="al:android:app_name" content="SlideShare Android"/>
<meta property="al:android:package" content="net.slideshare.mobile"/>
<meta property="al:ios:url" content="slideshare-app://ss/5091794"/>
<meta property="al:ios:app_store_id" content="917418728"/>
<meta property="al:ios:app_name" content="SlideShare iOS"/>
<!-- SL:end:notranslate -->
<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>
<body id="pagekey-slideshare_desktop_slideview_loggedout" class=" ">
<div id="main-nav" class="contain-to-grid fixed">
<div class="icon-bar four-up hide-for-medium-up icon-bar-custom">
<a class="item" href="/" aria-labelledby="#home">
<i class="icon-slideshare-logo"></i>
<label id="home">SlideShare</label>
</a>
<a class="item" href="/explore" aria-labelledby="#explore">
<i class="fa fa-compass"></i>
<label id="explore">Explore</label>
</a>
<a class="item j-open-mobile-search" aria-labelledby="#search">
<i class="fa fa-search"></i>
<label id="search">Search</label>
</a>
<a class="item" class="void_fancybox void_redirect_link" href="https://www.slideshare.net/login" aria-labelledby="#you">
<i class="fa fa-user"></i>
<label id="you">You</label>
</a>
</div>
<nav class="top-bar visible-for-medium-up" data-topbar>
<ul class="title-area">
<li class="name">
<a href="/">
<img id="main-navbar-logo" alt="LinkedIn SlideShare" src="http://public.slidesharecdn.com/b/images/logo/linkedin-ss/SS_Logo_White_Large.png?6d1f7a78a6">
</a>
</li>
</ul>
<section class="top-bar-section">
<ul class="right upload-create button-group">
<li class="has-form upload-create">
<a href="/upload" class="button radius secondary">Upload</a>
</li>
<li>
<a id="login" class="void_fancybox void_redirect_link" href="https://www.slideshare.net/login">Login</a>
</li>
<li>
<a id="signup" href="https://www.slideshare.net/signup" class="void_fancybox void_redirect_link" title="Signup now for a SlideShare account">Signup</a>
</li>
</ul>
<ul class="left">
<li class="divider"></li>
<li id="nav-search" class="has-form">
<form id="nav-search-form" method="get" action="/search/slideshow">
<div class="input-box">
<input name="searchfrom" type="hidden" value="header">
<input id="nav-search-query" type="text" placeholder="Search" name="q" value="" autocomplete="off">
<button class="button expand" type="submit"><i class="fa fa-search"></i></button>
<ul class='search-suggestions dropdown f-dropdown medium' style="display:none;"></ul>
</div>
</form>
</li>
</ul>
</section>
</nav>
<div class="visible-for-medium-up sub-navbar">
<div class="row">
<div class="container">
<ul class="sub-nav-cats left">
<li class="sub-nav-cat">
<a href="/" class="sub-nav-link" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="Home" rel="nofollow">Home</a>
</li>
<li class="sub-nav-cat">
<a href="/featured/category/technology" class="sub-nav-link" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="Technology" rel="nofollow">Technology</a>
</li>
<li class="sub-nav-cat">
<a href="/featured/category/education" class="sub-nav-link" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="Education" rel="nofollow">Education</a>
</li>
<li class="sub-nav-cat">
<a href="/explore" class="sub-nav-link" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="More Topics" rel="nofollow">More Topics</a>
</li>
</ul>
<ul class="sub-nav-cats right show-for-large-up sub-nav-link-ctas">
<li class="sub-nav-cat has-dropdown creators-hub-dropdown" data-dropdown="creators-hub-dropdown" data-options="is_hover:true;">
<a href="/ss/creators?from=sub-nav" class="sub-nav-link creators-hub" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="creators_hub">For Uploaders</a>
</li>
<li class="sub-nav-cat collect-leads-cta">
<a href="/lead-generation" class="sub-nav-link" data-ga-action="click" data-ga-cat="sub_nav_cat" data-ga-label="Collect Leads">Collect Leads</a>
</li>
</ul>
<ul id="creators-hub-dropdown" class="dropdown f-dropdown creators-hub-dropdown" data-dropdown-content>
<li>
<a href="/ss/creators/get-started?from=sub-nav" data-ga-cat="sub_nav_cat" data-ga-action="click" data-ga-label="creators_hub_gs" rel="nofollow">
Get Started</a>
</li>
<li class="divider"></li>
<li>
<a href="/ss/creators/tips-and-tricks?from=sub-nav" data-ga-cat="sub_nav_cat" data-ga-action="click" data-ga-label="creators_hub_tat" rel="nofollow">
Tips & Tricks</a>
</li>
<li class="divider"></li>
<li>
<a href="/ss/creators/tools?from=sub-nav" data-ga-cat="sub_nav_cat" data-ga-action="click" data-ga-label="creators_hub_tools" rel="nofollow">
Tools</a>
</li>
<li class="divider"></li>
<li>
<a href="/ss/creators/for-businesses?from=sub-nav" data-ga-cat="sub_nav_cat" data-ga-action="click" data-ga-label="creators_hub_bus" rel="nofollow">
For Business</a>
</li>
</ul>
</div>
</div>
</div>
</div>
<div class="wrapper">
<div id="main-nav-mobile-search">
<form name="mobile-search" action="/search/slideshow" method="get">
<div class="input-box">
<input type="text" placeholder="Search" name="q" value="" autocomplete="off">
<a class="button expand">
<i class="search-icon fa fa-search"></i>
<i class="search-spinner fa fa-spinner fa-spin"></i>
</a>
</div>
</form>
</div>
<div id="slideview-container" class="">
<div class="slideview-header-container row">
<div class="columns">
<div></div>
</div>
</div>
<div class="row">
<div id="main-panel" class="small-12 large-8 columns">
<div class="sectionElements">
<div class="j-clips-toolbar clips-toolbar ">
<div class="clips-progress progress">
<span class="j-clips-meter clip-meter meter" style="width:0%"></span>
</div>
<div class="j-clips-info clips-info">
<span class="j-clips-count clips-count copy-in-aria-label" aria-label="0"></span>
<span class="j-clips-count-text clips-count-text notranslate copy-in-aria-label" data-content-zero="Be the first to clip this slide" data-content-one="person clipped this slide" data-content-other="people clipped this slide"></span>
</div>
</div>
<div class="playerWrapper">
<div>
<!-- For slideview page , combined js for player is now combined with slideview javascripts for logged out users-->
<div class="player lightPlayer fluidImage presentation_player" id="svPlayerId">
<span class="j-fullscreen-title-banner fullscreen-title-banner" style="display: none;">
Hadoop As The Platform For The Smartgrid At TVA
</span>
<div class="stage valign-first-slide">
<a class="exit-fullscreen j-exit-fullscreen" style="display: none;">
<i class="fa fa-compress fa-2x"></i>
</a>
<div class="slide_container">
<section data-index="1" class="slide show" itemprop=image>
<img class="slide_image" src="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-728.jpg?cb=1327341063" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="2" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-2-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-2-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-2-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="3" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-3-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-3-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-3-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="4" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-4-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-4-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-4-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="5" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-5-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-5-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-5-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="6" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-6-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-6-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-6-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="7" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-7-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-7-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-7-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="8" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-8-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-8-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-8-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="9" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-9-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-9-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-9-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="10" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-10-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-10-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-10-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="11" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-11-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-11-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-11-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="12" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-12-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-12-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-12-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="13" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-13-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-13-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-13-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="14" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-14-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-14-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-14-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="15" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-15-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-15-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-15-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="16" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-16-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-16-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-16-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="17" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-17-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-17-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-17-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="18" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-18-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-18-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-18-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="19" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-19-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-19-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-19-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="20" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-20-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-20-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-20-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="21" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-21-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-21-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-21-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="22" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-22-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-22-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-22-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="23" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-23-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-23-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-23-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="24" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-24-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-24-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-24-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="25" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-25-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-25-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-25-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="26" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-26-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-26-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-26-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="27" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-27-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-27-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-27-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<section data-index="28" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-28-320.jpg?cb=1327341063" data-normal="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-28-728.jpg?cb=1327341063" data-full="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-28-1024.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smartgrid At TVA"/>
</section>
<div class="j-next-container next-container">
<div class="content-container">
<div class="next-slideshow-wrapper">
<div class="j-next-slideshow next-slideshow">
<div class="title-container">
<span class="title-text">Upcoming SlideShare</span>
</div>
<div class="j-next-url info">
<div class="thumb-container">
<img class="j-next-thumb thumb"/>
</div>
<div class="text-container">
<span class="j-next-title next-title"></span>
<span class="j-next-views next-views"></span>
</div>
</div>
</div>
<div class="next-timer">Loading in...<span class="j-timer-count timer-count">5</span></div>
<div class="j-next-cancel next-cancel">&#215;</div>
</div>
</div>
</div>
</div>
<div class="j-clips-toast clips-toast clipping row" style="display: none" data-timeout="5000" data-system-clipboard-title="My Clips" data-default-text="(default)">
<div class="column small-8">
<div class="clipboard-select">
Slide clipped to:
<a href="#" class="clips-toast-clipped" data-dropdown="clipboard-names-dropdown" data-options="align:top" aria-controls="clipboard-names-dropdown" aria-expanded="false" rel="nofollow">
<i class="fa fa-spinner fa-spin"></i>
<span class="j-clips-toast-clipped clips-toast-clipped"></span>
<i class="fa fa-angle-up"></i>
</a>
<div id="clipboard-names-dropdown" class="clipboard-names-dropdown-container f-dropdown" aria-hidden="true" data-dropdown-content>
<div class="clips-search">
<i class="fa fa-search"></i>
<input class="j-clips-search" type="text" placeholder="Search">
</div>
<ul class="j-clipboard-names-dropdown clipboard-names-dropdown no-bullet"></ul>
<div class="j-create-form-wrapper create-form-wrapper">
<button class="j-create-new create-new">
<i class="fa fa-plus-circle"></i>Create new clipboard
</button>
<form data-abide class="j-create-form create-form" style="display: none">
<div class="input-wrapper">
<label>
<input class="j-create-form-input" type="text" placeholder="Name your clipboard">
<small class="j-create-form-error error"></small>
</label>
</div>
</form>
</div>
</div>
</div>
</div>
<div class="column small-4">
<div class="share-cta-container right">
<span class='j-clip-share share-cta'>
<div class="svg-icon share-icon">
<svg><use data-size="small" xlink:href="#share-ios-icon"></use></svg>
</div>
Share Clip
</span>
</div>
</div>
</div>
</div> <!-- end stage -->
<div class="clip-button-top">
<a class="j-clips-button clip-button" href="/signup?login_source=slideview.clip.like&amp;from=clip&amp;layout=foundation&amp;from_source=" rel="nofollow" data-reveal-id="login_modal" style="display:none">
<div class="container">
<div class="svg-icon">
<svg><use data-size="small" xlink:href="#clipboard-add-icon"></use></svg>
</div>
<span class="clip-button-text-clip notranslate copy-in-aria-label" aria-label="Clip slide" title="Clip to save this slide for later"></span>
</div>
</a>
</div>
<div class="toolbar_wrapper j-player-toolbar">
<div class="toolbar normal">
<!-- using div.bar-[top, bottom]-margin to fix toolbar spacing with a taller progressbar (improve slide scrubbing UX) -->
<div class="j-progress-bar progress-bar-wrapper">
<div class="progress-bar-spacing"></div>
<div class="buffered-bar"></div>
<div class="j-slides-loaded-bar progress-bar"></div>
<div class="j-progress-tooltip progress-tooltip" style="display: none;">
<div class="j-tooltip-content progress-tooltip-wrapper">
<img class="j-tooltip-thumb tooltip-thumb" onerror="this.src=''" slide-thumb-1=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-320.jpg?cb=1327341063 slide-thumb-2=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-2-320.jpg?cb=1327341063 slide-thumb-3=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-3-320.jpg?cb=1327341063 slide-thumb-4=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-4-320.jpg?cb=1327341063 slide-thumb-5=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-5-320.jpg?cb=1327341063 slide-thumb-6=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-6-320.jpg?cb=1327341063 slide-thumb-7=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-7-320.jpg?cb=1327341063 slide-thumb-8=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-8-320.jpg?cb=1327341063 slide-thumb-9=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-9-320.jpg?cb=1327341063 slide-thumb-10=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-10-320.jpg?cb=1327341063 slide-thumb-11=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-11-320.jpg?cb=1327341063 slide-thumb-12=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-12-320.jpg?cb=1327341063 slide-thumb-13=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-13-320.jpg?cb=1327341063 slide-thumb-14=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-14-320.jpg?cb=1327341063 slide-thumb-15=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-15-320.jpg?cb=1327341063 slide-thumb-16=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-16-320.jpg?cb=1327341063 slide-thumb-17=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-17-320.jpg?cb=1327341063 slide-thumb-18=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-18-320.jpg?cb=1327341063 slide-thumb-19=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-19-320.jpg?cb=1327341063 slide-thumb-20=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-20-320.jpg?cb=1327341063 slide-thumb-21=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-21-320.jpg?cb=1327341063 slide-thumb-22=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-22-320.jpg?cb=1327341063 slide-thumb-23=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-23-320.jpg?cb=1327341063 slide-thumb-24=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-24-320.jpg?cb=1327341063 slide-thumb-25=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-25-320.jpg?cb=1327341063 slide-thumb-26=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-26-320.jpg?cb=1327341063 slide-thumb-27=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-27-320.jpg?cb=1327341063 slide-thumb-28=http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/85/hadoop-as-the-platform-for-the-smartgrid-at-tva-28-320.jpg?cb=1327341063>
<span class="j-slidecount-label slidecount-label">1</span>
</div>
<div class="progress-tooltip-caret"></div>
</div>
</div>
<div class="progress-bar-spacing"></div>
<div class="j-tools bot-actions">
</div><!-- .bot-actions -->
<div class="j-tools bot-actions">
<a data-tooltip aria-haspopup="true" style="display: none" class="j-tooltip j-download action-download has-tip" title="Save this presentation" href="/login?from_source=%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation" data-target="#login_modal" data-placement="top">
<i class="fa fa-download fa-lg" style="margin-top: 1px;"></i>
</a>
</div>
<div class="j-clips-actions clips-actions-bottom">
<a id="clips-button-bottom" class="j-clips-button clip-button button small left" href="/signup?login_source=slideview.clip.like&amp;from=clip&amp;layout=foundation&amp;from_source=" rel="nofollow" data-reveal-id="login_modal" style="display:none">
<div class="svg-icon">
<svg><use data-size="small" xlink:href="#clipboard-add-icon"></use></svg>
</div>
<span class="clip-button-text-clip notranslate copy-in-aria-label" aria-label="Clip slide" title="Clip to save this slide for later"></span>
</a>
<div class="toast-toggle left">
<div class="toggle j-toast-toggle">
<svg><use data-size="large" xlink:href="#chevron-down-icon"></use></svg>
</div>
</div>
</div>
<script>(function(win){var ss=win.slideshare_object,Experiments=ss.utils.imports('Experiments'),experiments=new Experiments();if(!ss.inIframe||(ss.inIframe&&!ss.inIframe())){experiments.addClass('#clips-button-bottom','slideview-clip-button-exp-2');experiments.addClass('.clip-button-top .clip-button','slideview-clip-button-exp-2');}}(window));</script>
<div class="nav">
<button id="btnPrevious" title="Previous Slide">
<div class="j-prev-btn arrow-left disabled"></div>
</button>
<label class="goToSlideLabel">
<span id="current-slide" class="j-current-slide">1</span>
of
<span id="total-slides" class="j-total-slides">28</span>
</label>
<button id="btnNext" title="Next Slide">
<div class="j-next-btn arrow-right"></div>
</button>
</div>
<div class="navActions">
<button id="btnFullScreen" class="j-tooltip btnFullScreen" title="View Fullscreen">
<span class="fa fa-stack">
<i class="fa fa-square fa-stack-2x"></i>
<i class="fa fa-expand fa-stack-1x"></i>
</span>
</button>
<button id="btnLeaveFullScreen" class="j-tooltip btnLeaveFullScreen" title="Exit Fullscreen">
<span class="fa-stack">
<i class="fa fa-square fa-stack-2x"></i>
<i class="fa fa-compress fa-stack-1x"></i>
</span>
</button>
</div>
<script>(function(win){var ss=win.slideshare_object,Experiments=ss.utils.imports('Experiments'),experiments=new Experiments();if(!ss.inIframe||(ss.inIframe&&!ss.inIframe())){experiments.addClass('.navActions','slideview-clip-button-exp-2');}}(window));</script>
</div>
</div>
<div class="image_maps"></div>
</div>
<div id="j-lead-form-placeholder" style="display:none">
</div>
</div>
</div>
<div id="lastScreen" style="display: none;">
<div class="lastScreen">
<div class="jsplLastScreenOverlay j-last-screen-overlay"></div>
<div class="pro-overlay j-lastscreen">
<div class="proSharingText">Like this presentation? Why not share!</div>
<ul class="lastActions j-last-screen-actions">
<li class="share-cta j-share-cta lastscreen-share-cta"><a class="share-btn"><span class="lastScreen-sprite"></span>Share</a></li>
<li class="email-cta j-email-cta"><a class="email-btn"><span class="lastScreen-sprite"></span>Email</a></li>
<li class="replay last">
<a class="replay-btn lastScreenReplay j-tooltip j-last-screen-replay" data-original-title="View again" title="View again">
<span class="lastScreen-sprite">&nbsp;</span>
</a>
</li>
<li class="close-btn lastScreen-sprite j-lastscreen-close">
<a>&nbsp;</a>
</li>
</ul>
<div class="related-presentations j-lastscreen-related">
<ul class="presentation-list">
<li>
<a href="/thepersuaders/hea-presentation-to-tourism-research-forum2" title="HEA Presentation To Tourism Researc...">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/hea-presentation-totourismresearchforum2-1210947998658672-9-thumbnail.jpg?cb=1210922702" alt="HEA Presentation To Tourism Researc..."/>
<span class="presentation-meta">
<span class="title">HEA Presentation To Tourism Researc...</span>
<span class="author">by&nbsp;Alex Gibson</span>
<span class="view-count">1395&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/jpatanooga/oscon-data-2011-lumberyard" title="OSCON Data 2011 - Lumberyard">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail.jpg?cb=1317303673" alt="OSCON Data 2011 - Lumberyard"/>
<span class="presentation-meta">
<span class="title">OSCON Data 2011 - Lumberyard</span>
<span class="author">by&nbsp;Josh Patterson</span>
<span class="view-count">4117&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/ISCTE-IUL_MIT_VC/building-global-innovators-4-edio" title="Building Global Innovators: 4ª edição">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/bgiapresentaohomepagerev-1-0-130509151823-phpapp01-thumbnail.jpg?cb=1368112750" alt="Building Global Innovators: 4ª edição"/>
<span class="presentation-meta">
<span class="title">Building Global Innovators: 4ª edição</span>
<span class="author">by&nbsp;Building Global I...</span>
<span class="view-count">3348&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/smtoday/beyond-the-meter-next-generation-smartgrid" title="Beyond the Meter: Next Generation S...">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/tecslides09-08-10-100909101542-phpapp01-thumbnail.jpg?cb=1284027410" alt="Beyond the Meter: Next Generation S..."/>
<span class="presentation-meta">
<span class="title">Beyond the Meter: Next Generation S...</span>
<span class="author">by&nbsp;Social Media Today</span>
<span class="view-count">2176&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/KenWood9/paladin-smartgrid-marketing-plan-rev-04c-48444044" title="Paladin SmartGrid Marketing Plan Re...">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/e5d32f8d-c7fb-4a92-b85c-4d4ce2ca9f30-150521163032-lva1-app6892-thumbnail.jpg?cb=1432225932" alt="Paladin SmartGrid Marketing Plan Re..."/>
<span class="presentation-meta">
<span class="title">Paladin SmartGrid Marketing Plan Re...</span>
<span class="author">by&nbsp;Ken Wood</span>
<span class="view-count">76&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/ISCTE-IUL_MIT_VC/pitch-presentation-slides-template" title="12-slide Pitch Presentation Template">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/pitchpresentationslidestemplate-130315050936-phpapp02-thumbnail.jpg?cb=1363326594" alt="12-slide Pitch Presentation Template"/>
<span class="presentation-meta">
<span class="title">12-slide Pitch Presentation Template</span>
<span class="author">by&nbsp;Building Global I...</span>
<span class="view-count">1801&nbsp;views</span>
</span>
</a>
</li>
</ul>
</div>
</div> <!-- end of div class pro-overlay -->
<div class="j-modal-share modal-share mobile-hide" style="display: none;" id="last-screen-modal-share" data-ga-track-category="" data-ga-track-action="">
<div class="j-modal-popup modal-popup">
<div class="j-modal-close modal-close"></div>
<div class="modal-content-wrapper">
<div class="j-modal-content modal-content" id="modal-content" data-slideshowid="">
<header class="j-tabs tabs">
<a id="button-share-tab" class="selected j-button-share-tab">Share SlideShare</a>
<hr class="divider"/>
</header>
<div class="j-share-tab share-tab">
<div>
<ul class="j-share-social-list share-social-list" data-canonical-url="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva">
<li class="facebook" data-network="facebook">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Share on Facebook">Facebook</a>
</div>
</li>
<li class="twitter" data-network="twitter">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" data-text="Hadoop As The Platform For The Smartgrid At TVA by @cloudera #hadoop #smartgrid" data-related="@cloudera" data-via="SlideShare" title="Tweet on Twitter">Twitter</a>
</div>
</li>
<li class="linkedin" data-network="linkedin">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" data-text="Hadoop As The Platform For The Smartgrid At TVA by Cloudera, Inc. via slideshare" title="Share on LinkedIn">LinkedIn</a>
</div>
</li>
<li class="googleplus" data-network="googleplus">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Share on Google+">Google+</a>
</div>
</li>
</ul>
</div>
<div class="section share-email">
<span class="header">Email</span>
<form id="share-email-form" class="j-share-email-form">
<input id="share-email-to" data-ga="to" class="j-share-email-to j-email-clear j-share-expand-trigger" name="recipients" placeholder="Enter email addresses"></input>
<div class="share-email-expand j-share-expand">
<input id="share-email-name" data-ga="name" class="j-share-email-name j-email-clear" name="name" type="text" placeholder="from..."></input>
<textarea id="share-email-msg" data-ga="msg" class="j-share-email-msg j-email-clear" name="msg" placeholder="add a message..."></textarea>
<span class="j-email-flash email-flash"></span>
<input id="share-email-send" data-ga="send" class="j-share-email-send button btn btn-inverse" type="submit" value="Send"/>
<div style="clear:both"></div>
</div>
</form>
<div id="email-sent" class="j-email-sent section"><div>
<span class="success-text">Email sent successfully!</span></div>
</div>
</div>
<div class="j-share-embed section share-embed">
<span class="header">Embed</span>
<textarea id="share-embed-link" class="j-share-embed-link j-share-expand-trigger" readonly data-ga="link"></textarea>
<div class="share-embed-options j-share-expand">
<div class="embed-size">
<span class="title">Size (px)</span>
<select class="j-embed-size-picker embed-size-picker j-update-embed" id="embed-size-picker" data-ga="size-picker"></select>
</div>
<div class="embed-start">
<span class="title">Start on</span>
<select class="j-embed-start-picker embed-start-picker j-update-embed" id="embed-start-picker" data-ga="start-picker"></select>
</div>
<div class="embed-show-related" style="display:none">
<input type="checkbox" name="related-content" checked="checked" class="j-embed-related-cbox embed-related-cbox j-update-embed" data-ga="related">
<span>Show related SlideShares at end</span>
</div>
</div>
</div>
<div class="wordpress-container section">
<span class="header">WordPress Shortcode</span>
<input type="text" name="embed-code" id="share-embed-wp" value="" readonly="readonly" class="j-share-embed-wp text quiet h-wpembedcode j-share-expand-trigger" data-ga="wp-link">
</div>
<div class="share-link-container section">
<span class="header">Link</span>
<input type="input" class="j-share-link-url j-share-expand-trigger" id="share-link-url" data-ga="link" readonly></input>
</div>
</div>
</div>
</div>
</div>
</div><!-- share modal -->
</div><!-- last screen ends here -->
</div>
</div>
<div class="slideshow-info-container" itemscope itemtype="http://schema.org/MediaObject">
<div class="slideshow-info">
<meta itemprop="inLanguage" content="en">
<meta itemprop="image" content="http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-728.jpg?cb=1327341063">
<meta itemprop="thumbnailUrl" content="http://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail.jpg?cb=1327341063">
<meta itemprop="embedURL" content="https://www.slideshare.net/slideshow/embed_code/key/Iou4wVMUZodUY9">
<meta itemprop="playerType" content="HTML5 Flash">
<meta itemprop="interactionCount" content="UserComments:1">
<meta itemprop="interactionCount" content="UserLikes:8">
<meta itemprop="interactionCount" content="UserDownloads:103">
<meta itemprop="interactionCount" content="UserPageVisits:4640">
<meta itemprop="interactionCount" content="UserPlays:4640">
<meta itemprop="interactionCount" content="UserPlusOnes:0" id="meta-google">
<meta itemprop="interactionCount" content="UserTweets:0" id="meta-twitter">
<div class="slideshow-title-container row add-padding-right">
<div class="small-10 columns">
<h1 class="notranslate slideshow-title-text" itemprop="headline">
<span class="j-title-breadcrumb">
Hadoop As The Platform For The Smartgrid At TVA
</span>
</h1>
</div>
<div class="small-2 columns text-right format-views" data-views="views">
<span class="notranslate">
4,640<br>
</span>
</div>
</div>
<ul id="slideshow-actions" class="slideshow-actions">
<li class="item-action">
<button class="tiny art-deco share" data-action="share">Share</button>
</li>
<li class="item-action">
<button class="tiny art-deco like button" data-action="like" href="/signup?login_source=slideview.popup.like&amp;from=favorite&amp;layout=foundation&amp;from_source=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva" rel="nofollow">Like</button>
</li>
<li class="item-action">
<button class="tiny art-deco download button" data-action="download" href="/login?from_source=%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation" rel="nofollow">
Download
</button>
</li>
</ul>
<div class="author-container add-padding-right" itemprop="author" itemscope itemtype="http://schema.org/Organization">
<div class="left author-thumbnail">
<a href="/cloudera?utm_campaign=profiletracking&amp;utm_medium=sssite&amp;utm_source=ssslideview" class="author-photo-wrapper" title="cloudera" itemprop="url">
<img alt="Cloudera, Inc." class="author-photo" itemprop="image" src="//cdn.slidesharecdn.com/profile-photo-cloudera-48x48.jpg?cb=1443039339"/>
</a>
</div>
<div class="author-text">
<h2 style="display:inline;">
<a class="j-author-name" title="cloudera" rel="author" href="/cloudera?utm_campaign=profiletracking&amp;utm_medium=sssite&amp;utm_source=ssslideview" data-ga-cat="bigfoot_slideview" data-ga-action="authorlinkclick">
<span itemprop="name">Cloudera, Inc.</span></a></h2>
<div class="author-cta-container">
<div class="follow-container">
<span class="j-follow " data-contactee-id="22512604">
<a class="follow-btn" data-contactee="22512604" href="/signup?login_source=slideview.popup.follow&from=addcontact&from_source=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva">
<i class="fa fa-plus"></i> Follow
</a>
<div class="j-follow-progress indicator">
<i class="fa fa-spinner fa-spin"></i>
</div>
</span>
</div>
</div>
</div>
</div>
<div class="social-share-container add-padding-right">
<button id="sv-linkedin-share" class="j-share-item button-li tiny radius" data-network="linkedin" data-ga-action="viralshareLinkedIn_click">
<i class="fa fa-linkedin fa-lg"></i>
<span class="separator"></span>
<span class="j-share-count share-count">0</span>
</button>
<button id="sv-facebook-share" class="j-share-item button-fb tiny radius" data-network="facebook" data-ga-action="viralsharefacebook">
<i class="fa fa-facebook fa-lg"></i>
<span class="separator"></span>
<span class="j-share-count share-count">0</span>
</button>
<button id="sv-twitter-share" class="j-share-item button-tw tiny radius" data-network="twitter" data-ga-action="viralsharetwitter_click">
<i class="fa fa-twitter fa-lg"></i>
<span class="separator"></span>
<span class="j-share-count share-count">0</span>
</button>
<button id="sv-google-share" class="j-share-item button-go tiny radius" data-network="google" data-ga-action="viralshareGooglePlusOne">
<i class="fa fa-google-plus fa-lg"></i>
<span class="separator"></span>
<span class="j-share-count share-count">0</span>
</button>
</div>
<p>
<small>Published on <time datetime="2010-08-30T16:01:47Z" itemprop="datePublished">Aug 30, 2010</time></small>
</p>
<div id="nps_survey_placeholder"></div>
<div class="slideshow-description-container add-padding-right">
<div class="description row" data-ga-cat="bigfoot_slideview" data-ga-action="description>more">
<div class="large-10 columns">
<p id="slideshow-description-paragraph" class="notranslate">
Cloudera&#x27;s Josh Paterson presented how Hadoop is used as the platform for smartgrid technologies at the Tennessee Valley Authority. This presentation encompasses a retrospective on the openPDC project, what Hadoop is, current smartgrid obsticles, and Cloudera Enterprise as The New Smartgrid Platform.
</p>
</div>
<div class="large-2 columns">
<button class="j-expand-text empty_btn_design">
...<i class="fa fa-caret-down"></i>
</button>
</div>
</div>
</div>
<div class="categories-container add-padding-right">
<span>Published in:</span>
<a rel="nofollow" href="/featured/category/technology">Technology</a><span class="comma"></span>
</div>
</div>
<div class="slideshow-tabs-container show-for-medium-up">
<dl class="tabs" data-tab>
<dd class="active">
<a href="#comments-panel">
<i class="fa fa-comment"></i>
1 Comment
</a>
</dd>
<dd class="">
<a href="#likes-panel">
<i class="fa fa-heart"></i>
<span class="j-favs-count">
8 Likes
</span>
</a>
</dd>
<dd>
<a href="#stats-panel" class="j-stats-tab">
<i class="fa fa-bar-chart"></i>
Statistics
</a>
</dd>
<dd>
<a href="#notes-panel">
<i class="fa fa-file-text"></i>
Notes
</a>
</dd>
</dl>
<div class="tabs-content">
<div id="comments-panel" class="content active commentsWrapper commentsNotes">
<ul class="hide">
<li id="commentsTemplate">
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate commenter" title="Commenter Title" rel="nofollow">
<img class="nickname" alt="Full Name" src="//public.slidesharecdn.com/b/images/user-48x48.png"/>
</a>
</div>
<div class="small-11 columns">
<a class="j-author-photo notranslate commenter" title="Commenter Title" rel="nofollow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="commentuserlinkclick">Full Name</span>
<span class="bioStub notranslate">
<span class="j-commenter-role"></span>
<span class="j-commenter-org"></span>
</span>
</a>
<div class="commentText notranslate">
Comment goes here.
</div>
<time class="commentTimestamp small-text lighter-color-text">12 hours ago</time>&nbsp;&nbsp;
<span class="commentMeta">
<span class="commentActions small-text">
<a href="#" class="j-action-delete">Delete</a>
<a href="#" class="j-reply">Reply</a>
<a href="#" class="j-action-spam">Spam</a>
<a href="#" class="j-action-block">Block</a>
</span>
</span>
<div id="confirmDialog" class="panel callout block-message">
<div>
<span class="title">Are you sure you want to</span>
<a href="#" id="yes">Yes</a>
<a href="#" id="no">No</a>
</div>
</div>
<div id="messageDialog" class="block-message">
Your message goes here
</div>
<span class="j-loading" style="display: none;">
<i class="fa fa-spinner fa-spin"></i>
</span>
</div>
</div>
</li>
</ul>
<form action="#" method="post" accept-charset="utf-8" id="postComment" class="j-comment-post postComment">
<div class="row">
<div class="small-1 columns thumbnail">
<div class="left">
<img class="nickname" alt="no profile picture user" src="//public.slidesharecdn.com/b/images/user-48x48.png"/>
</div>
</div>
<div class="small-11 columns">
<div class="row collapse">
<div class="small-10 columns">
<input class="j-post-comment-input comment-text" type="text" placeholder="Share your thoughts..."/>
</div>
<div class="small-2 columns">
<a id="login-provider-slideshare" class="postfix" rel="nofollow" href="/signup?login_source=slideview.popup.comment&from=comments&from_source=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva">
<button type="button" class="postfix">Post</button>
</a>
</div>
</div>
</div>
</div>
</form>
<ul id="commentsList" class="user-list no-bullet">
<li id="comment-1504825" class="comment author-41567095" itemtype="http://schema.org/UserComments" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="izouke" itemprop="url" rel="nofollow" href="/izouke?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshare">
<img itemprop="image" class="j-lazy-thumb" alt="izouke" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//public.slidesharecdn.com/b/images/user-48x48.png"/>
</a>
</div>
<div class="small-11 columns">
<span itemscope itemprop="creator" itemtype="http://www.schema.org/Person">
<a class="j-author-photo notranslate" title="izouke" itemprop="url" rel="nofollow" href="/izouke?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshare">
<span class="j-username notranslate" itemprop="name" data-ga-cat="bigfoot_slideview" data-ga-action="commentuserlinkclick">izouke</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-commenter-role">
<span itemprop="jobTitle"></span>
</span>
<span class="j-commenter-org">
<span itemprop="worksFor"></span>
</span>
</span>
</a>
</span>
<div class="commentText notranslate" itemprop="commentText">
GOOD AND INTERESTING
</div>
<time class="commentTimestamp small-text lighter-color-text" datetime="2012-07-11T03:10:15Z">
<span itemprop="commentTime">
3 years ago
</span>
</time>&nbsp;&nbsp;
<span class="commentMeta">
<span class="commentActions small-text">
<a href="#" class="j-reply">Reply</a>&nbsp;
</span>
</span>
<div id="confirmDialog-1504825" class="panel callout block-message">
<div>
<span class="title">Are you sure you want to</span>&nbsp;
<a id="yes">Yes</a>&nbsp;
<a id="no">No</a>
</div>
</div>
<div id="messageDialog" class="block-message">
Your message goes here
</div>
<span class="j-loading" style="display: none;">
<i class="fa fa-spinner fa-spin"></i>
</span>
</div>
</div>
</li>
</ul>
</div>
<div class="content" id="likes-panel">
<ul id="favsList" class="j-favs-list notranslate user-list no-bullet" itemtype="http://schema.org/UserLikes" itemscope>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="krzysztofzarzycki98" itemprop="url" rel="nofollow" href="/krzysztofzarzycki98?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="krzysztofzarzycki98" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-krzysztofzarzycki98-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="krzysztofzarzycki98" rel="nofollow" href="/krzysztofzarzycki98?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Krzysztof Zarzycki</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
,
<span>Big Data Architect</span>
</span>
<span class="j-favoriter-org">
at
<span>Contractor</span>
</span>
</span>
<div class="j-tags favTags"></div>
<time class="commentTimestamp small-text lighter-color-text">
1 year ago
</time>
</a>
</div>
</div>
</li>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="chaoyu0513" itemprop="url" rel="nofollow" href="/chaoyu0513?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="chaoyu0513" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-chaoyu0513-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="chaoyu0513" rel="nofollow" href="/chaoyu0513?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">James Chen</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
,
<span>Principal Consultant &amp; Sr. AVP</span>
</span>
<span class="j-favoriter-org">
at
<span>Etu Solution</span>
</span>
</span>
<div class="j-tags favTags"></div>
<time class="commentTimestamp small-text lighter-color-text">
2 years ago
</time>
</a>
</div>
</div>
</li>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="eddodds" itemprop="url" rel="nofollow" href="/eddodds?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="eddodds" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-eddodds-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="eddodds" rel="nofollow" href="/eddodds?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Ed Dodds</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
,
<span>Digital Strategist</span>
</span>
<span class="j-favoriter-org">
at
<span>Conmergence</span>
</span>
</span>
<div class="j-tags favTags">Tags <strong><a href='/tag/smartgrid' rel='nofollow'>smartgrid</a></strong> <strong><a href='/tag/hadoop' rel='nofollow'>hadoop</a></strong> <strong><a href='/tag/tennessee-valley-authority' rel='nofollow'>tennessee valley authority</a></strong> <strong><a href='/tag/tva' rel='nofollow'>tva</a></strong> <strong><a href='/tag/grid' rel='nofollow'>grid</a></strong></div>
<time class="commentTimestamp small-text lighter-color-text">
3 years ago
</time>
</a>
</div>
</div>
</li>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="terada" itemprop="url" rel="nofollow" href="/terada?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="terada" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//public.slidesharecdn.com/b/images/user-48x48.png"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="terada" rel="nofollow" href="/terada?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">terada</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
<span></span>
</span>
<span class="j-favoriter-org">
<span></span>
</span>
</span>
<div class="j-tags favTags"></div>
<time class="commentTimestamp small-text lighter-color-text">
4 years ago
</time>
</a>
</div>
</div>
</li>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="forbesjr" itemprop="url" rel="nofollow" href="/forbesjr?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="forbesjr" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-forbesjr-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="forbesjr" rel="nofollow" href="/forbesjr?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Elektrifi</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
<span></span>
</span>
<span class="j-favoriter-org">
at
<span>Elektrifi</span>
</span>
</span>
<div class="j-tags favTags"></div>
<time class="commentTimestamp small-text lighter-color-text">
4 years ago
</time>
</a>
</div>
</div>
</li>
</ul>
<div class="more-container text-center">
<a href="#" class="j-more-favs">
Show More
<div style="inline-block"><i class="fa fa-caret-down"></i></div>
</a>
</div>
</div>
<div class="content" id="downloads-panel">
<div class="empty-stat-box">No Downloads</div>
</div>
<div class="content" id="stats-panel">
<div class="row info-stats">
<div class="small-4 columns">
<strong>Views</strong>
<div class="row">
<div class="small-8 columns stat-label">Total Views</div>
<div class="small-4 columns stat-value text-right">
4,640
</div>
<div class="small-8 columns stat-label">On Slideshare</div>
<div class="j-slideshare-views small-4 columns stat-value text-right ">
0
</div>
<div class="small-8 columns stat-label">From Embeds</div>
<div class="j-embed-views small-4 columns stat-value text-right">
0
</div>
<div class="small-8 columns stat-label">Number of Embeds</div>
<div class="small-4 columns stat-value text-right">
3
</div>
</div>
</div>
<div class="small-4 columns">
<strong>Actions</strong>
<div class="row">
<div class="small-8 columns stat-label">Shares</div>
<div class="small-4 columns stat-value text-right j-total-shares">0</div>
<div class="small-8 columns stat-label">Downloads</div>
<div class="small-4 columns stat-value text-right ">
103
</div>
<div class="small-8 columns stat-label">Comments</div>
<div class="small-4 columns stat-value text-right">
1
</div>
<div class="small-8 columns stat-label">Likes</div>
<div class="small-4 columns stat-value text-right">
8
</div>
</div>
</div>
<div class="small-4 columns">
<strong>
Embeds
<span class="j-embed-views notranslate from-embed hint">0</span>
</strong>
<div class="j-info-embeds">
<div class="j-no-embeds no-embeds">No embeds</div>
<div class="row no-translate j-embeds-container" style="max-height:120px; overflow:auto;">
</div>
</div>
</div>
</div>
<hr>
<div class="row">
<div class="small-12 columns">
<strong class="copy-in-aria-label" aria-label="Report content"></strong><br>
<div class="flag flag-inappropriate">
<a class="action-flag" rel="nofollow" href="/signup?login_source=slideview.popup.flags&amp;from=flagss&amp;from_source=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva">
<span class="j-tooltip flagged copy-in-aria-label" title="This Presentation has been flagged" aria-label="Flagged as inappropriate"></span>
<span class="j-tooltip flag copy-in-aria-label" title="Flag this presentation as inappropriate" aria-label="Flag as inappropriate"></span>
</a>
</div>
<div>
<a href="http://www.linkedin.com/legal/copyright-policy" rel="nofollow" class="copy-in-aria-label" aria-label="Copyright Complaint"></a>
</div>
</div>
</div>
</div>
<div class="content" id="notes-panel">
<div id="empty-note" class="empty-stat-box">No notes for slide</div>
</div>
</div>
</div>
</div>
</div>
<aside id="side-panel" class="small-12 large-4 columns j-related-more-tab">
<dl class="tabs related-tabs small" data-tab>
<dd class="active"><a href="#related-tab-content" data-ga-cat="bigfoot_slideview" data-ga-action="relatedslideshows_tab">Recommended</a></dd>
<dd class="j-more-tab " data-ga-cat="bigfoot_slideview" data-ga-action="morebyuser_tab"><a href="#more-tab-content">More from this author</a></dd>
</dl>
<div class="tabs-content">
<ul id="related-tab-content" class="content active no-bullet notranslate" ab_variant="none">
<li class="lynda-item ">
<a data-ssid="5091794" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="105390" data-ssrank="0" data-designkey="b1" data-lynda-type="1" data-algorithm-id="123" data-source-model="123" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="bottom_visible" class="j-lynda-impression j-recommendation-tracking" title="Cloud Computing First Look" href=http://www.lynda.com/Business-Collaboration-tutorials/Cloud-Computing-First-Look/105390-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva&amp;utm_campaign=5091794_b1_105390&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Cloud Computing First Look" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/105390_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Cloud Computing First Look
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
<li class="lynda-item ">
<a data-ssid="5091794" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="174234" data-ssrank="1" data-designkey="b1" data-lynda-type="1" data-algorithm-id="123" data-source-model="123" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="bottom_visible" class="j-lynda-impression j-recommendation-tracking" title="Computer Security and Internet Safety Fundamentals" href=http://www.lynda.com/1Password-tutorials/Computer-Security-Internet-Safety-Fundamentals/174234-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva&amp;utm_campaign=5091794_b1_174234&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Computer Security and Internet Safety Fundamentals" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/174234-635548359118565260_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Computer Security and Internet Safety Fundamentals
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
<li class="lynda-item ">
<a data-ssid="5091794" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="362341" data-ssrank="2" data-designkey="b1" data-lynda-type="1" data-algorithm-id="123" data-source-model="123" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="bottom_visible" class="j-lynda-impression j-recommendation-tracking" title="Meeting the Challenge of Digital Transformation" href=http://www.lynda.com/Business-Intelligence-tutorials/Meeting-Challenge-Digital-Transformation/362341-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva&amp;utm_campaign=5091794_b1_362341&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Meeting the Challenge of Digital Transformation" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/362341-635605417933739036_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Meeting the Challenge of Digital Transformation
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="410395" data-ssrank="3" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="HEA Presentation To Tourism Research Forum2" href="/thepersuaders/hea-presentation-to-tourism-research-forum2">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="HEA Presentation To Tourism Research Forum2" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/hea-presentation-totourismresearchforum2-1210947998658672-9-thumbnail-2.jpg?cb=1210922702"/>
</div>
<div class="related-content">
<div class="title">
HEA Presentation To Tourism Research Forum2
</div>
<div class="author">Alex Gibson</div>
<div class="j-related-views view-count format-views" data-views="views">1,395
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="9476155" data-ssrank="4" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="OSCON Data 2011 - Lumberyard" href="/jpatanooga/oscon-data-2011-lumberyard">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="OSCON Data 2011 - Lumberyard" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail-2.jpg?cb=1317303673"/>
</div>
<div class="related-content">
<div class="title">
OSCON Data 2011 - Lumberyard
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">4,117
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="20882385" data-ssrank="5" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Building Global Innovators: 4ª edição" href="/ISCTE-IUL_MIT_VC/building-global-innovators-4-edio">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Building Global Innovators: 4ª edição" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/bgiapresentaohomepagerev-1-0-130509151823-phpapp01-thumbnail-2.jpg?cb=1368112750"/>
</div>
<div class="related-content">
<div class="title">
Building Global Innovators: 4ª edição
</div>
<div class="author">Building Global Innovators (BGI)</div>
<div class="j-related-views view-count format-views" data-views="views">3,348
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="5164817" data-ssrank="6" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Beyond the Meter: Next Generation SmartGrid" href="/smtoday/beyond-the-meter-next-generation-smartgrid">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Beyond the Meter: Next Generation SmartGrid" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/tecslides09-08-10-100909101542-phpapp01-thumbnail-2.jpg?cb=1284027410"/>
</div>
<div class="related-content">
<div class="title">
Beyond the Meter: Next Generation SmartGrid
</div>
<div class="author">Social Media Today</div>
<div class="j-related-views view-count format-views" data-views="views">2,176
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="48444044" data-ssrank="7" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Paladin SmartGrid Marketing Plan Rev 04c" href="/KenWood9/paladin-smartgrid-marketing-plan-rev-04c-48444044">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Paladin SmartGrid Marketing Plan Rev 04c" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/e5d32f8d-c7fb-4a92-b85c-4d4ce2ca9f30-150521163032-lva1-app6892-thumbnail-2.jpg?cb=1432225932"/>
</div>
<div class="related-content">
<div class="title">
Paladin SmartGrid Marketing Plan Rev 04c
</div>
<div class="author">Ken Wood</div>
<div class="j-related-views view-count format-views" data-views="views">76
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="17225044" data-ssrank="8" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="12-slide Pitch Presentation Template" href="/ISCTE-IUL_MIT_VC/pitch-presentation-slides-template">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="12-slide Pitch Presentation Template" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/pitchpresentationslidestemplate-130315050936-phpapp02-thumbnail-2.jpg?cb=1363326594"/>
</div>
<div class="related-content">
<div class="title">
12-slide Pitch Presentation Template
</div>
<div class="author">Building Global Innovators (BGI)</div>
<div class="j-related-views view-count format-views" data-views="views">1,801
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="7968312" data-ssrank="9" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Strategic Capability" href="/MazharIftikhar/strategic-capability">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Strategic Capability" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/4-strategiccapability-110514225543-phpapp02-thumbnail-2.jpg?cb=1305413805"/>
</div>
<div class="related-content">
<div class="title">
Strategic Capability
</div>
<div class="author">Mazhar Iftikhar (mazhariftikhar@gmail.com)</div>
<div class="j-related-views view-count format-views" data-views="views">7,943
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="43717622" data-ssrank="10" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Developing with the Go client for Apache Kafka" href="/charmalloc/developing-with-the-go-client-for-apache-kafka">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Developing with the Go client for Apache Kafka" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/developing-150120161125-conversion-gate02-thumbnail-2.jpg?cb=1421770335"/>
</div>
<div class="related-content">
<div class="title">
Developing with the Go client for Apache Kafka
</div>
<div class="author">Joe Stein</div>
<div class="j-related-views view-count format-views" data-views="views">5,329
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="44187551" data-ssrank="11" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Pitch Deck Templates for Startups" href="/nextviewvc/startup-pitch-deck-templates-next-view-ventures-slideshare">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Pitch Deck Templates for Startups" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/startuppitchdecktemplates-nextviewventures-slideshare-150202203720-conversion-gate01-thumbnail-2.jpg?cb=1422911081"/>
</div>
<div class="related-content">
<div class="title">
Pitch Deck Templates for Startups
</div>
<div class="author">NextView Ventures</div>
<div class="j-related-views view-count format-views" data-views="views">57,413
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="46174756" data-ssrank="12" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Pitch Deck Template &amp; Pitch Deck Example - Pitch Deck Coach" href="/PitchDeckCoach/the-ultimate-pitch-deck-template-by-pitchdeckcoach">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Pitch Deck Template &amp; Pitch Deck Example - Pitch Deck Coach" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/pitchdeckcoachtemplate-150323101614-conversion-gate01-thumbnail-2.jpg?cb=1440176009"/>
</div>
<div class="related-content">
<div class="title">
Pitch Deck Template &amp; Pitch Deck Example - Pitch Deck Coach
</div>
<div class="author">PitchDeckCoach</div>
<div class="j-related-views view-count format-views" data-views="views">15,755
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="24239339" data-ssrank="13" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="How To Make The Perfect Startup Pitch Deck" href="/Barcinno/the-perfect-startup-pitch-deck-24239339">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="How To Make The Perfect Startup Pitch Deck" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/theperfectstartuppitchdeck-130715035507-phpapp01-thumbnail-2.jpg?cb=1373938201"/>
</div>
<div class="related-content">
<div class="title">
How To Make The Perfect Startup Pitch Deck
</div>
<div class="author">Barcinno</div>
<div class="j-related-views view-count format-views" data-views="views">132,445
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="51681670" data-ssrank="14" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Innovation at 50x 081515" href="/sblank/innovation-at-50x-081515-51681670">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Innovation at 50x 081515" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/innovationat50x081515stz-150816052027-lva1-app6892-thumbnail-2.jpg?cb=1440190187"/>
</div>
<div class="related-content">
<div class="title">
Innovation at 50x 081515
</div>
<div class="author">Steve Blank</div>
<div class="j-related-views view-count format-views" data-views="views">70,613
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="23975462" data-ssrank="15" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="The Best Startup Investor Pitch Deck &amp; How to Present to Angels  &amp; Venture Capitalists" href="/Sky7777/the-best-startup-pitch-deck-how-to-present-to-angels-v-cs">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="The Best Startup Investor Pitch Deck &amp; How to Present to Angels  &amp; Venture Capitalists" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/thebeststartuppitchdeckhowtopresenttoangelsvcs-130706124526-phpapp01-thumbnail-2.jpg?cb=1438238415"/>
</div>
<div class="related-content">
<div class="title">
The Best Startup Investor Pitch Deck &amp; How to Present to Angels &amp; Venture Capi…&hellip;
</div>
<div class="author">J. Skyler Fernandes</div>
<div class="j-related-views view-count format-views" data-views="views">335,853
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="49096672" data-ssrank="16" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Build a Better Entrepreneur Pitch Deck" href="/ceigateway/build-a-better-entrepreneur-pitch-deck">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Build a Better Entrepreneur Pitch Deck" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/ceibuildabetterpitchdeckslidepresentation-150607190022-lva1-app6892-thumbnail-2.jpg?cb=1439909800"/>
</div>
<div class="related-content">
<div class="title">
Build a Better Entrepreneur Pitch Deck
</div>
<div class="author">Center For Entrepreneurial Innovation</div>
<div class="j-related-views view-count format-views" data-views="views">65,751
</div>
</div>
</a>
</li>
</ul>
<ul id="more-tab-content" class="content no-bullet notranslate " ab_variant="none">
<li class="j-related-item">
<a data-ssid="52818651" data-urn-type="Slideshow" title="Why Your Apache Spark Job is Failing" href="/cloudera/why-your-apache-spark-job-is-failing" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Why Your Apache Spark Job is Failing" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/wed-435pm-cloudera-kostassakellis-150915193745-lva1-app6891-thumbnail-2.jpg?cb=1442345960"/>
</div>
<div class="related-content">
<div class="title">Why Your Apache Spark Job is Failing</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
605
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="52818650" data-urn-type="Slideshow" title="Getting Apache Spark Customers to Production" href="/cloudera/getting-apache-spark-customers-to-production" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Getting Apache Spark Customers to Production" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/sparkmeetuphadoopsummit2015gettingtoproduction-150915193745-lva1-app6892-thumbnail-2.jpg?cb=1442345928"/>
</div>
<div class="related-content">
<div class="title">Getting Apache Spark Customers to Production</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
256
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="52678277" data-urn-type="Slideshow" title="LSA-ing Wikipedia with Apache Spark" href="/cloudera/lsaing-wikipedia-with-apache-spark" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="LSA-ing Wikipedia with Apache Spark" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/slidesharelsatalk-150911160241-lva1-app6891-thumbnail-2.jpg?cb=1441987850"/>
</div>
<div class="related-content">
<div class="title">LSA-ing Wikipedia with Apache Spark</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
365
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="52678002" data-urn-type="Slideshow" title="Estimating Financial Risk with Apache Spark" href="/cloudera/estimating-financial-risk-with-apache-spark" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Estimating Financial Risk with Apache Spark" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/slidesharerisktalk-150911155504-lva1-app6891-thumbnail-2.jpg?cb=1441987072"/>
</div>
<div class="related-content">
<div class="title">Estimating Financial Risk with Apache Spark</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
151
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="52064290" data-urn-type="Slideshow" title="Women in Big Data | Mike Olson" href="/cloudera/women-in-big-data-mike-olson" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Women in Big Data | Mike Olson" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/idfwomeninbigdataolson-150825201758-lva1-app6892-thumbnail-2.jpg?cb=1440533972"/>
</div>
<div class="related-content">
<div class="title">Women in Big Data | Mike Olson</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
3,580
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="51875396" data-urn-type="Slideshow" title="Why Apache Spark is the Heir to MapReduce in the Hadoop Ecosystem" href="/cloudera/why-apache-spark-is-the-heir-to-mapreduce-in-the-hadoop-ecosystem" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Why Apache Spark is the Heir to MapReduce in the Hadoop Ecosystem" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/sparkisheirtomapreduceinhadoop-150820200035-lva1-app6891-thumbnail-2.jpg?cb=1440100920"/>
</div>
<div class="related-content">
<div class="title">Why Apache Spark is the Heir to MapReduce in the Hadoop Ecosystem</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
1,977
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="51836817" data-urn-type="Slideshow" title="Spark on YARN: The Road Ahead" href="/cloudera/spark-on-yarn-the-road-ahead" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Spark on YARN: The Road Ahead" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/02marcelovanzen-150624000117-lva1-app6891-150819221946-lva1-app6891-thumbnail-2.jpg?cb=1440022844"/>
</div>
<div class="related-content">
<div class="title">Spark on YARN: The Road Ahead</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
481
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="50983771" data-urn-type="Slideshow" title="Cloudera for Internet of Things" href="/cloudera/cloudera-for-internet-of-things" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Cloudera for Internet of Things" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/clouderaforiot-clouderashowcase-07232015-150727190558-lva1-app6891-thumbnail-2.jpg?cb=1438024481"/>
</div>
<div class="related-content">
<div class="title">Cloudera for Internet of Things</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
769
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="50483152" data-urn-type="Slideshow" title="Cloudera Showcase Cask" href="/cloudera/cloudera-showcase-cask" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Cloudera Showcase Cask" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/clouderashowcasecask-150713204827-lva1-app6891-thumbnail-2.jpg?cb=1436820573"/>
</div>
<div class="related-content">
<div class="title">Cloudera Showcase Cask</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
602
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="48444123" data-urn-type="Slideshow" title="Contributing to Impala" href="/cloudera/contributing-to-impala" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Contributing to Impala" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/contribution-henry-meetup-march-2015-150521163210-lva1-app6891-thumbnail-2.jpg?cb=1432226044"/>
</div>
<div class="related-content">
<div class="title">Contributing to Impala</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
3,640
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="48346850" data-urn-type="Slideshow" title="Cloudera Cares + DataKind | 7 May 2015 | London, UK" href="/cloudera/cloudera-cares-datakind-7-may-2015-london-uk" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Cloudera Cares + DataKind | 7 May 2015 | London, UK" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/7maylondonfinal-150519172119-lva1-app6891-thumbnail-2.jpg?cb=1432056503"/>
</div>
<div class="related-content">
<div class="title">Cloudera Cares + DataKind | 7 May 2015 | London, UK</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
1,600
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="48346556" data-urn-type="Slideshow" title="Pervasive analytics through data &amp; analytic centricity" href="/cloudera/pervasive-analytics-through-data-analytic-centricity" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Pervasive analytics through data &amp; analytic centricity" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/pervasiveanalyticsthroughdataanalyticcentricity-2015-05-14-150519171442-lva1-app6891-thumbnail-2.jpg?cb=1435662000"/>
</div>
<div class="related-content">
<div class="title">Pervasive analytics through data &amp; analytic centricity</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
348
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="47847900" data-urn-type="Slideshow" title="Friction-free ETL: Automating data transformation with Impala | Strata + Hadoop World London 2015" href="/cloudera/no-etlstratalondon2015" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Friction-free ETL: Automating data transformation with Impala | Strata + Hadoop World London 2015" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/no-etl-strata-london-2015-150507044502-lva1-app6892-thumbnail-2.jpg?cb=1430974458"/>
</div>
<div class="related-content">
<div class="title">Friction-free ETL: Automating data transformation with Impala | Strata + Hado...</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
1,050
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="47599456" data-urn-type="Slideshow" title="The Journey to Success with Big Data" href="/cloudera/the-journey-to-success-with-big-data-47599456" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="The Journey to Success with Big Data" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/cloudera-thejourneytosuccesswithbigdata-singapore-april2015-nonotes-150430042230-conversion-gate01-thumbnail-2.jpg?cb=1430368023"/>
</div>
<div class="related-content">
<div class="title">The Journey to Success with Big Data</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
919
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="47578527" data-urn-type="Slideshow" title="Introduction to Cloudera Search Training" href="/cloudera/introduction-to-cloudera-search-training" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Introduction to Cloudera Search Training" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/webinarintrotosearchtrainingwheeler04-15-150429151540-conversion-gate02-thumbnail-2.jpg?cb=1432812601"/>
</div>
<div class="related-content">
<div class="title">Introduction to Cloudera Search Training</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">
467
</div>
</div>
</a>
</li>
</ul>
</div>
</aside>
</div>
</div>
<div id="first-clip-tour" class="hide">
</div>
<div id="clip-intention-tour" class="hide">
<ol class="joyride-list" data-joyride>
<li data-id="clips-button-bottom" data-text="Got it" data-options="prev_button: false; tip_location: top; tipAdjustmentY: -12;">
<h4 class="text-center">A particular slide catching your eye?</h4>
<p class="text-center">Clipping is a handy way to collect important slides you want to go back to later.</p>
</li>
</ol>
</div>
<footer>
<div class="row">
<div class="columns">
<div id="smt-lang-selector"></div>
<ul class="j-languages-selector language-links text-center">
<li class="smt-item j-www">
<a class="smt-link" href="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva?smtNoRedir=1" title="Hadoop As The Platform For The Smartgrid At TVA - English" lang="en" hreflang="en">English
</a>
</li>
<li class="smt-item j-es">
<a class="smt-link" href="http://es.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Hadoop As The Platform For The Smartgrid At TVA - Espanol" lang="es" hreflang="es">Espanol
</a>
</li>
<li class="smt-item j-pt">
<a class="smt-link" href="http://pt.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Hadoop As The Platform For The Smartgrid At TVA - Portugues" lang="pt" hreflang="pt">Portugues
</a>
</li>
<li class="smt-item j-fr">
<a class="smt-link" href="http://fr.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Hadoop As The Platform For The Smartgrid At TVA - Fran&ccedil;ais" lang="fr" hreflang="fr">Fran&ccedil;ais
</a>
</li>
<li class="smt-item j-de">
<a class="smt-link" href="http://de.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Hadoop As The Platform For The Smartgrid At TVA - Deutsche" lang="de" hreflang="de">Deutsche
</a>
</li>
</ul>
</div>
</div>
<div class="row">
<div class="columns">
<ul class="main-links text-center">
<li><a href="/about">About</a></li>
<li class="hidden-for-small"><a href="/developers">Dev & API</a></li>
<li><a href="http://blog.slideshare.net/">Blog</a></li>
<li><a href="/terms">Terms</a></li>
<li><a href="/privacy">Privacy</a></li>
<li><a href="http://www.linkedin.com/legal/copyright-policy">Copyright</a></li>
<li class="hidden-for-small"><a href="https://help.linkedin.com/app/answers/detail/a_id/53685/kw/slideshare">Support</a></li>
</ul>
</div>
</div>
<div class="row">
<div class="columns">
<ul class="social-links text-center">
<li>
<a title="Follow us on LinkedIn" href="http://www.linkedin.com/company/slideshare" class="fa fa-linkedin-square fa-lg" rel="nofollow" target="_blank"></a>
</li>
<li>
<a title="Follow us on SlideShare" href="http://www.facebook.com/slideshare" class="fa fa-facebook-square fa-lg" rel="nofollow" target="_blank"></a>
</li>
<li>
<a title="Follow us on Twitter" href="http://twitter.com/SlideShare" class="fa fa-twitter-square fa-lg" rel="nofollow" target="_blank"></a>
</li>
<li>
<a title="Follow us on Google+" href="http://www.google.com/+SlideShare" class="fa fa-google-plus-square fa-lg" rel="nofollow" target="_blank"></a>
</li>
<li>
<a href="http://www.slideshare.net/rss/latest" class="fa fa-rss-square fa-lg"></a>
</li>
</ul>
</div>
</div>
<div class="row">
<div class="columns">
<p class="copyright text-center">LinkedIn Corporation &copy; 2015</p>
<p></p>
</div>
</div>
</footer>
</div>
<div id="alert-modal" class="reveal-modal" data-reveal="">
<p></p>
<a class="close-reveal-modal">×</a>
</div>
<div class="modal_popup_container">
<div id="clipboard-share-modal" class="reveal-modal small mobile-hide" aria-hidden="true" aria-labelledby="modal-title" role="dialog" data-reveal data-ga-track-category="" data-ga-track-action="">
<div class="j-modal-popup modal-popup">
<div id="modal-content" class="j-modal-content">
<h4 class="j-modal-title modal-title notranslate">Share Clipboard</h4>
<hr/>
<a class="close-reveal-modal" href="#" aria-label="Close">&times;</a>
<div class="section share-email">
<form class="j-share-email-form">
<h5>Email</h5>
<input class="j-share-email-to j-email-clear notranslate" name="recipients" placeholder="Enter email addresses" title="Enter email addresses" type="text">
<div class="clearfix">
<input data-ga="name" class="j-share-email-name j-email-clear notranslate" name="name" type="text" placeholder="From" title="From">
<textarea class="j-share-email-msg j-email-clear notranslate share-message-textarea" name="message" placeholder="Add a message" title="Add a message"></textarea>
<div class="j-email-flash email-flash"></div>
<input id="share-email-send" class="button btn btn-inverse email-send-button notranslate" title="Send" type="submit" value="Send">
</div>
</form>
<div id="email-sent" class="j-email-sent sent-section">
<span class="success-text notranslate">Email sent successfully..</span>
</div>
</div>
<div class="row">
<ul class="j-share-social-list share-social-list" data-canonical-url="">
<li class="facebook" data-network="facebook">
<a class="share-link" rel="nofollow" title="Share on Facebook">Facebook</a>
</li>
<li class="twitter" data-network="twitter">
<a class="share-link" rel="nofollow" title="Tweet on Twitter">Twitter</a>
</li>
<li class="linkedin" data-network="linkedin">
<a class="share-link" rel="nofollow" title="Share on LinkedIn">LinkedIn</a>
</li>
<li class="googleplus" data-network="googleplus">
<div class="social-hover">
<a class="share-link" rel="nofollow" title="Share on Google+">Google+</a>
</div>
</li>
</ul>
</div>
<div class="row">
<div class="share-link-container">
<label for="share-link-url">Link</label>
<input id="share-link-url" class="j-share-link-url" type="text" data-ga="link"></input>
</div>
</div>
</div>
</div>
</div>
<div id="top-clipboards-modal" class="reveal-modal xlarge top-clipboards-modal" data-reveal aria-labelledby="modal-title" aria-hidden="true" role="dialog">
<h4 class="modal-title">Public clipboards featuring this slide</h4>
<hr/>
<button class="close-reveal-modal button-lrg" aria-label="Close">&times;</button>
<div class="loading text-center">
<svg><use data-size="small" xlink:href="#loader"></use></svg>
</div>
<div class="empty">
No public clipboards found for this slide
</div>
<div class="clipboards row">
<ul class="small-block-grid-1 medium-block-grid-2 large-block-grid-3"></ul>
</div>
</div>
<div id="download-interstitial-modal" class="download-interstitial reveal-modal medium" aria-hidden="false" role="dialog" data-reveal>
<div class="modal-content-container">
<a class="close-reveal-modal" href="#" aria-label="Close">&times;</a>
<div class="modal-content">
<div class="modal-inner-content">
<div class="row">
<h3 class="text-center">Save the most important slides with Clipping</h3>
</div>
<div class="row">
<!-- make only 8/12 columns and centered -->
<div class="medium-10 small-centered columns">
<p class="text-center">Clipping is a handy way to collect and organize the most important slides from a presentation. You can keep your great finds in clipboards organized around topics.</p>
<button class="art-deco small primary start-clipping">Start clipping</button>
<button class="art-deco small tertiary button continue-download" data-reveal-id="login_modal" href="/login?from_source=%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation">No thanks. Continue to download.</button>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_base.js?3f71b61149" type="text/javascript"></script>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_fbconnect.js?e5ea20fb78" type="text/javascript"></script>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_foundation_app.js?aa28fc7964" type="text/javascript"></script>
<script>$(window).load(function(){loadCSS("//public.slidesharecdn.com/b/ss_foundation/stylesheets/app.css?e85c54fee15ba7e3cfd0b177790a75c63688c6ea");});</script>
<script type="text/javascript">$.extend(slideshare_object,{"stats":{"url":"http://www.slideshare.net/~/slideshow/stats/5091794.json"},"downloads":{"sp_isdwnl":true,"allow":true},"gam_cat_name":"technology","useHttp":1,"version_no":"1327341063","category":{"featured":0},"fb_app_name":"slideshare","key":false,"top_nav":{"get_url":"/top_nav"},"totalSlides":28,"analytics_api_enabled":true,"facebook_app_id":"2490221586","asset_id":"e85c54fee15ba7e3cfd0b177790a75c63688c6ea","jsplayer":{"next_slideshow_pos":null,"wp_code":"[slideshare id=5091794\u0026doc=hadoopastheplatformforthesmartgridattva-100830160157-phpapp02]","slide_error_template":"\u003Cstyle type=\"text/css\"\u003E\n  .jsplayer-slide-error {\n    background-color: #000;\n    padding: 20% 0 13% !important;\n  }\n  .jsplayer-slide-error div {\n    text-align: center;\n  }\n  .jsplayer-slide-error img {\n    height: 79px !important;\n    margin: 0 0 10px;\n    width: 80px !important;\n  }\n  .jsplayer-slide-error .slide-error-body {\n    color: #eee;\n    font-family: 'Lucida Grande',Verdana, Arial, Helvetica, sans-serif;\n    padding: 0 !important;\n  }\n  .jsplayer-slide-error .slide-error-body p {\n    font-size: 0.8em;\n    line-height: 1.1em;\n    margin: 7px 0 11px;\n  }\n  .jsplayer-slide-error .slide-error-body input[type=button] {\n    margin: 7px 0 0;\n    padding: 7px 14px;\n  }\n\u003C/style\u003E\n\u003Cdiv class=\"jsplayer-slide-error\"\u003E\n  \u003Cdiv style=\"position:relative;\"\u003E\n    \u003Cimg src='//public.slidesharecdn.com/b/images/ssplayer/error_dudes-80x79.png' height=\"79\" width=\"80\" /\u003E\n    \u003Cdiv class=\"slide-error-body\"\u003E\n      \u003Cp\u003EWe were unable to load the slide.\u003C/p\u003E\n      \u003Cinput class=\"btn btn-large\" type=\"button\" value=\"Reload slide\" /\u003E\n    \u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n","spinner_url":"//public.slidesharecdn.com/b/images/ssplayer/loading_bigfoot.gif?8d8fb5905f","ppt_location":"hadoopastheplatformforthesmartgridattva-100830160157-phpapp02","html_eotfont_url_suffix":"-eot.js","image_ready":true,"iframe_code":"\u003Ciframe src=\"{iframe_url}\" width=\"{width}\" height=\"{height}\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva\" title=\"Hadoop As The Platform For The Smartgrid At TVA\" target=\"_blank\"\u003EHadoop As The Platform For The Smartgrid At TVA\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/cloudera\" target=\"_blank\"\u003ECloudera, Inc.\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","embed_code":"\u003Ciframe src=\"https://www.slideshare.net/slideshow/embed_code/key/Iou4wVMUZodUY9\" width=\"427\" height=\"356\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva\" title=\"Hadoop As The Platform For The Smartgrid At TVA\" target=\"_blank\"\u003EHadoop As The Platform For The Smartgrid At TVA\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/cloudera\" target=\"_blank\"\u003ECloudera, Inc.\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","twitter_recommended_users":"@cloudera","inpage_full_screen":true,"replayscreen":{"html":"\u003Ca href=\"#\" class=\"j-replay-button replay-button\" \u003E\n  \u003Ci class=\"fa fa-refresh\"\u003E\u003C/i\u003E\n  View again\n\u003C/a\u003E"},"bambooleaf_hash":false,"embed_sizes":{"config":{"defaultPreset":"preset2"},"presets":{"preset4":{"size":{"height":485,"width":595},"displaySize":{"height":53,"width":70}},"preset1":{"size":{"height":290,"width":340},"displaySize":{"height":30,"width":40}},"preset2":{"size":{"height":355,"width":425},"displaySize":{"height":38,"width":50}},"preset3":{"size":{"height":420,"width":510},"displaySize":{"height":45,"width":60}}}},"share_text":"Hadoop As The Platform For The Smartgrid At TVA by Cloudera, Inc. via slideshare","use_ssl":false,"timestamp":1327341063,"preload_after_pageload":true,"pin_image_url":"http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-728.jpg?cb=1327341063","player_bgcolor":"jsplBgColorBigfoot","image_bucket_location":"//image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02","bambooleaf_presentation":false,"disable_share":false,"player_type":"presentation","show_related_content":"1","fullscreen_url":"/fullscreen/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva","hosted_in":"slideview","iframe_url":"//www.slideshare.net/slideshow/embed_code/key/Iou4wVMUZodUY9","track_slide_enable":1,"mode":"image","start_slide":1,"slide_count":28,"twitter_share_text":"Hadoop As The Platform For The Smartgrid At TVA by @cloudera #hadoop #smartgrid","meta_error_template":"\u003Cstyle type=\"text/css\"\u003E\n  .jsplayer-slide-error {\n    background-color: #000;\n    padding: 20% 0 13% !important;\n  }\n  .jsplayer-slide-error div {\n    text-align: center;\n  }\n  .jsplayer-slide-error img {\n    height: 79px !important;\n    margin: 0 0 10px;\n    width: 80px !important;\n  }\n  .jsplayer-slide-error .slide-error-body {\n    color: #eee;\n    font-family: 'Lucida Grande',Verdana, Arial, Helvetica, sans-serif;\n    padding: 0 !important;\n  }\n  .jsplayer-slide-error .slide-error-body p {\n    font-size: 0.8em;\n    line-height: 1.1em;\n    margin: 8px 0;\n  }   \n  .jsplayer-slide-error .slide-error-body input[type=button] {\n    margin: 7px 0 0;\n    padding: 7px 14px;\n  }\n\u003C/style\u003E\n\u003Cdiv class=\"jsplayer-slide-error\"\u003E\n  \u003Cdiv style=\"position:relative;\"\u003E\n    \u003Cimg src='//public.slidesharecdn.com/b/images/ssplayer/error_dudes-80x79.png' height=\"79\" width=\"80\" /\u003E\n    \u003Cdiv class=\"slide-error-body\"\u003E\n      \u003Cp\u003EWe have encountered an error.\u003C/p\u003E\n      \u003Cp\u003EPlease refresh the page.\u003C/p\u003E\n    \u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n","spinner_url_fullscreen":"//public.slidesharecdn.com/b/images/ssplayer/loading_white.gif?5889cf60da","is_private":false,"show_image_player":true,"slideview_url":"/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva","id":5091794,"beacon_url":"stats.slideshare.net/1.gif","related_position":0,"html_ttffont_url_suffix":".js","is_only_private":false,"stripped_title":"hadoop-as-the-platform-for-the-smartgrid-at-tva","rel_slide_urls":[],"container":"svPlayerId","next_prev_experiment":true,"bambooleaf_enabled":false,"bucket_location":"//html.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/","author_id":22512604,"fullscreen_bgcolor":"jsplBgColorWhite","slide_titles":[],"toolbar_html":"\n\u003C!-- using div.bar-[top, bottom]-margin to fix toolbar spacing with a taller progressbar (improve slide scrubbing UX) --\u003E\n\u003Cdiv class=\"j-progress-bar progress-bar-wrapper\"\u003E\n  \u003Cdiv class=\"progress-bar-spacing\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"buffered-bar\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"j-slides-loaded-bar progress-bar\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"j-progress-tooltip progress-tooltip\" style=\"display: none;\"\u003E\n    \u003Cdiv class=\"j-tooltip-content progress-tooltip-wrapper\"\u003E\n      \u003Cimg class=\"j-tooltip-thumb tooltip-thumb\" onerror=\"this.src=''\"\n      \u003E\n      \u003Cspan class=\"j-slidecount-label slidecount-label\"\u003E1\u003C/span\u003E\n    \u003C/div\u003E\n    \u003Cdiv class=\"progress-tooltip-caret\"\u003E\u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n\u003Cdiv class=\"progress-bar-spacing\"\u003E\u003C/div\u003E\n\n\n\n\u003Cdiv class=\"j-tools bot-actions\"\u003E\n\u003C/div\u003E\u003C!-- .bot-actions --\u003E\n\n\n  \u003Cdiv class=\"j-tools bot-actions\"\u003E\n    \u003Ca data-tooltip aria-haspopup=\"true\" style=\"display: none\" class=\"j-tooltip j-download action-download has-tip\" title=\"Save this \" href=\"/login?from_source=%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva%3Ffrom_action%3Dsave\u0026amp;from=download\u0026amp;layout=foundation\" data-target=\"#login_modal\" data-placement=\"top\"\u003E\n      \u003Ci class=\"fa fa-download fa-lg\" style=\"margin-top: 1px;\"\u003E\u003C/i\u003E\n    \u003C/a\u003E\n  \u003C/div\u003E\n\n    \u003Cdiv class=\"j-clips-actions clips-actions-bottom\"\u003E\n      \u003Ca id=\"clips-button-bottom\"\n        class=\"j-clips-button clip-button button small left\"\n        href=\"/signup?login_source=slideview.clip.like\u0026amp;from=clip\u0026amp;layout=foundation\u0026amp;from_source=\"\n        rel=\"nofollow\" data-reveal-id=\"login_modal\" style=\"display:none\"\u003E\n        \u003Cdiv class=\"svg-icon\"\u003E\n            \u003Csvg\u003E\u003Cuse data-size=\"small\" xlink:href=\"#clipboard-add-icon\"\u003E\u003C/use\u003E\u003C/svg\u003E\n        \u003C/div\u003E\n        \u003Cspan class=\"clip-button-text-clip notranslate copy-in-aria-label\" aria-label=\"Clip slide\" title=\"Clip to save this slide for later\"\u003E\u003C/span\u003E\n      \u003C/a\u003E\n      \u003Cdiv class=\"toast-toggle left\"\u003E\n        \u003Cdiv class=\"toggle j-toast-toggle\"\u003E\n          \u003Csvg\u003E\u003Cuse data-size=\"large\" xlink:href=\"#chevron-down-icon\"\u003E\u003C/use\u003E\u003C/svg\u003E\n        \u003C/div\u003E\n      \u003C/div\u003E\n    \u003C/div\u003E\n\n\u003Cscript\u003E\n  (function(win) {\n\n    var ss = win.slideshare_object,\n        Experiments = ss.utils.imports('Experiments'),\n        experiments = new Experiments();\n\n    // Update the toolbar elements as long as we're not embedded.\n    if (!ss.inIframe || (ss.inIframe \u0026\u0026 !ss.inIframe())) {\n      experiments.addClass('#clips-button-bottom', 'slideview-clip-button-exp-2');\n      experiments.addClass('.clip-button-top .clip-button', 'slideview-clip-button-exp-2');\n    }\n\n  }(window));\n\u003C/script\u003E\n\n\n\n  \u003Cdiv class=\"nav\"\u003E\n      \u003Cbutton id=\"btnPrevious\" title=\"Previous Slide\"\u003E\n        \u003Cdiv class=\"j-prev-btn arrow-left disabled\"\u003E\u003C/div\u003E\n      \u003C/button\u003E\n    \u003Clabel class=\"goToSlideLabel\"\u003E\n      \u003Cspan id=\"current-slide\" class=\"j-current-slide\"\u003E1\u003C/span\u003E\n      of\n      \u003Cspan id=\"total-slides\" class=\"j-total-slides\"\u003E1\u003C/span\u003E\n    \u003C/label\u003E\n      \u003Cbutton id=\"btnNext\" title=\"Next Slide\"\u003E\n        \u003Cdiv class=\"j-next-btn arrow-right disabled\"\u003E\u003C/div\u003E\n      \u003C/button\u003E\n  \u003C/div\u003E\n\n\n\n\u003Cdiv class=\"navActions\"\u003E\n\n\n\n    \u003Cbutton id=\"btnFullScreen\" class=\"j-tooltip btnFullScreen\" title=\"View Fullscreen\"\u003E\n      \u003Cspan class=\"fa fa-stack\"\u003E\n        \u003Ci class=\"fa fa-square fa-stack-2x\"\u003E\u003C/i\u003E\n        \u003Ci class=\"fa fa-expand fa-stack-1x\"\u003E\u003C/i\u003E\n      \u003C/span\u003E\n    \u003C/button\u003E\n    \u003Cbutton id=\"btnLeaveFullScreen\" class=\"j-tooltip btnLeaveFullScreen\" title=\"Exit Fullscreen\"\u003E\n      \u003Cspan class=\"fa-stack\"\u003E\n        \u003Ci class=\"fa fa-square fa-stack-2x\"\u003E\u003C/i\u003E\n        \u003Ci class=\"fa fa-compress fa-stack-1x\"\u003E\u003C/i\u003E\n      \u003C/span\u003E\n    \u003C/button\u003E\n\n\u003C/div\u003E\n\n\u003Cscript\u003E\n  (function(win) {\n    //Update the fullscreen button if on slideview clip button experient, version B\n    var ss = win.slideshare_object,\n        Experiments = ss.utils.imports('Experiments'),\n        experiments = new Experiments();\n\n    // Update the toolbar elements as long as we're not embedded.\n    if (!ss.inIframe || (ss.inIframe \u0026\u0026 !ss.inIframe())) {\n      experiments.addClass('.navActions', 'slideview-clip-button-exp-2');\n    }\n\n  }(window));\n\u003C/script\u003E\n\n\n","page":1,"autoplayOnEmbed":false,"sharescreen":{"html":"\u003Cdiv class=\"shareScreen\"\u003E\n  \u003Ca href=\"#\" class=\"close\"\u003E\u0026times;\u003C/a\u003E\n  \u003Cul class=\"shareMethods\"\u003E\n    \u003Cli class=\"embed\"\u003E\n      \u003Clabel for=\"embed-code\"\u003EEmbed\u003C/label\u003E\n      \u003Cinput type='text' class=\"shareScreenEmbedCode\" value=\"code\" name=\"embed-code\" /\u003E\n    \u003C/li\u003E\n    \u003Cli class=\"url last\"\u003E\n      \u003Clabel for=\"embed-url\"\u003EURL\u003C/label\u003E\n      \u003Cinput type='text' class=\"shareScreenSSUrl\" value=\"code\" name=\"embed-url\" /\u003E\n\t\u003C/li\u003E\n  \u003C/ul\u003E\n  \u003Cform class=\"emailShare\"\u003E\n    \u003Cfieldset\u003E\n      \u003Clegend\u003EEmail this\u003C/legend\u003E\n      \u003Cinput type=\"hidden\" class=\"shareDefaultMessage\" value=\"I think you will find this useful.\" /\u003E\n      \u003Cul\u003E\n        \u003Cli\u003E\n          \u003Clabel for=\"name\"\u003EYour name\u003C/label\u003E\n          \u003Cinput class='shareScreenFromName' type=\"text\" value=\"\" /\u003E\n        \u003C/li\u003E\n        \u003Cli\u003E\n          \u003Clabel for=\"mailID\"\u003EEmail to\u003C/label\u003E\n          \u003Cinput class=\"shareScreenMailID\" type=\"text\" value=\"\" /\u003E\n        \u003C/li\u003E\n        \u003Cli class=\"submit\"\u003E\n          \u003Clabel\u003E\u0026nbsp;\u003C/label\u003E\n          \u003Cinput class=\"shareSprite\" type=\"submit\" value=\"\" /\u003E\n        \u003C/li\u003E        \n      \u003C/ul\u003E\n      \u003C/fieldset\u003E\n  \u003C/form\u003E\n\u003C/div\u003E\u003C!-- shareScreen ends here --\u003E","title":"Hadoop As The Platform For Th...","url":"http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva","slideshow_id":5091794,"user_name":""},"lastscreen":{"related":[{"views":1395,"title":"HEA Presentation To Tourism Researc...","url":"/thepersuaders/hea-presentation-to-tourism-research-forum2","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/hea-presentation-totourismresearchforum2-1210947998658672-9-thumbnail.jpg?cb=1210922702","author":"Alex Gibson","author_login":"thepersuaders"},{"views":4117,"title":"OSCON Data 2011 - Lumberyard","url":"/jpatanooga/oscon-data-2011-lumberyard","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail.jpg?cb=1317303673","author":"Josh Patterson","author_login":"jpatanooga"},{"views":3348,"title":"Building Global Innovators: 4\u00aa edi\u00e7\u00e3o","url":"/ISCTE-IUL_MIT_VC/building-global-innovators-4-edio","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/bgiapresentaohomepagerev-1-0-130509151823-phpapp01-thumbnail.jpg?cb=1368112750","author":"Building Global I...","author_login":"ISCTE-IUL_MIT_VC"},{"views":2176,"title":"Beyond the Meter: Next Generation S...","url":"/smtoday/beyond-the-meter-next-generation-smartgrid","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/tecslides09-08-10-100909101542-phpapp01-thumbnail.jpg?cb=1284027410","author":"Social Media Today","author_login":"smtoday"},{"views":76,"title":"Paladin SmartGrid Marketing Plan Re...","url":"/KenWood9/paladin-smartgrid-marketing-plan-rev-04c-48444044","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/e5d32f8d-c7fb-4a92-b85c-4d4ce2ca9f30-150521163032-lva1-app6892-thumbnail.jpg?cb=1432225932","author":"Ken Wood","author_login":"KenWood9"},{"views":1801,"title":"12-slide Pitch Presentation Template","url":"/ISCTE-IUL_MIT_VC/pitch-presentation-slides-template","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/pitchpresentationslidestemplate-130315050936-phpapp02-thumbnail.jpg?cb=1363326594","author":"Building Global I...","author_login":"ISCTE-IUL_MIT_VC"}],"url":"http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva"},"disable_eagerload":true,"has_video":false,"video_slides_count":0,"render_links":"default"},"embeds_count":8,"preview":"no","relative_static_origin_server":"//public.slidesharecdn.com/b/","presentationId":5091794,"startSlide":1,"related_type":"related","comments":{"captcha_url":"http://s3.amazonaws.com/ss-captchas/","ajaxurl":"/~/slideshow/comments/5091794.json","total_count":1},"bizo_partner_id":870,"userimage_placeholder":"//public.slidesharecdn.com/b/images/user-48x48.png","activities":{"favorites":{"count":5,"url":"/~/slideshow/favorites_list/5091794.json","total":8}},"default_tab":".svMoreAuthor","slideshow_placeholder":"//public.slidesharecdn.com/b/images/thumbnail.png","li_bar":{"get_url":"/li_bar"},"is_free_author":false,"flagging":{"flagged_value":null},"stripped_title":"hadoop-as-the-platform-for-the-smartgrid-at-tva","beacon_url":"stats.slideshare.net/1.gif","pvt":0,"show_branding":1,"user":{"clipboards":null,"member_type":"non-member","clips_number":0},"slideshow":{"wp_code":"[slideshare id=5091794\u0026doc=hadoopastheplatformforthesmartgridattva-100830160157-phpapp02]","iframe_code":"\u003Ciframe src=\"{iframe_url}\" width=\"{width}\" height=\"{height}\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva\" title=\"Hadoop As The Platform For The Smartgrid At TVA\" target=\"_blank\"\u003EHadoop As The Platform For The Smartgrid At TVA\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/cloudera\" target=\"_blank\"\u003ECloudera, Inc.\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","facade_slide_url":"http://image.slidesharecdn.com/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02/95/hadoop-as-the-platform-for-the-smartgrid-at-tva-1-728.jpg?cb=1327341063","embed_sizes":{"config":{"defaultPreset":"preset2"},"presets":{"preset4":{"size":{"height":485,"width":595},"displaySize":{"height":53,"width":70}},"preset1":{"size":{"height":290,"width":340},"displaySize":{"height":30,"width":40}},"preset2":{"size":{"height":355,"width":425},"displaySize":{"height":38,"width":50}},"preset3":{"size":{"height":420,"width":510},"displaySize":{"height":45,"width":60}}}},"fullscreen_bg_color":"White","title":"Hadoop As The Platform For The Smartgrid At TVA","pin_image_url":"http://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail-4.jpg?cb=1327341063","zeroclipboard_url":"http://static.slidesharecdn.com/ZeroClipboardv2.swf","user_login":"cloudera","show_related_content":"1","total_slides":28,"is_author_premium":true,"lead_form_url":"https://www.slideshare.net/slideshow/Iou4wVMUZodUY9/lead-form","iframe_url":"https://www.slideshare.net/slideshow/embed_code/key/Iou4wVMUZodUY9","clip_counts":{},"mobile_app_url":"slideshare-app://ss/5091794","is_private":false,"social_urls":{"linkedin":"https://www.linkedin.com/cws/share?url=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva\u0026trk=SLIDESHARE","twitter":"https://twitter.com/intent/tweet?via=SlideShare\u0026text=Hadoop+As+The+Platform+For+The+Smartgrid+At+TVA+by+%40cloudera+%23hadoop+%23smartgrid+http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva","google":"https://plus.google.com/share?url=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva","facebook":"https://facebook.com/sharer.php?u=http%3A%2F%2Fwww.slideshare.net%2Fcloudera%2Fhadoop-as-the-platform-for-the-smartgrid-at-tva\u0026t=Hadoop+As+The+Platform+For+The+Smartgrid+At+TVA"},"id":"5091794","recommendations":{"finalRankerModel":"model_001","designKey":"b1"},"type":"presentation","ss_url":"http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva","is_clippable":true,"allow_embeds":true,"clips":{},"user_name":"Cloudera, Inc.","view_action_state":"unpublished"},"dev":false,"doc":"hadoopastheplatformforthesmartgridattva-100830160157-phpapp02"});</script>
<script src="http://public.slidesharecdn.com/b/slideview/scripts/combined_presentation_init.js?755d8a8058" type="text/javascript"></script>
<script type="text/javascript">$(document).ready(function(){var $el=$('#svPlayerId');var classMap={'document':'document_player','html':'html_player','infographic':'infographic_player','video':'video_player'}
player=new SSPlayer(slideshare_object.jsplayer);$(player).bind('slidechanged',function(e){if(typeof(loadDataForSlide)==='function'){loadDataForSlide(e.ssData.index);}});$el.addClass(classMap[player.config.player_type]);});</script>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_player_clipping.js?0b344ffd18" type="text/javascript"></script>
<script>slideshare_object.add_signin_link('.j-favorite');slideshare_object.add_login_source('.j-favorite','slideview.top_toolbar.like');slideshare_object.add_login_source('.j-save','slideview.top_toolbar.download');slideshare_object.addSigninFrom('.j-favorite','favorite');slideshare_object.bindToModalLogin('.j-favorite');slideshare_object.bindToModalLogin('.j-save');slideshare_object.bind_favorites('#slideview-container');$(document).ready(function(){var mainContentHeight=$("#main-panel").height();var sidePanelItemHeight=$("#side-panel .j-related-item").first().outerHeight();var numItemToDisplay=Math.floor((mainContentHeight-200)/sidePanelItemHeight);$("#side-panel .tabs-content .content").each(function(){$(this).find(".j-related-item").slice(numItemToDisplay-2).remove();});var loadAdditionalFunctionality=function(){e=document.createElement('script');e.type='text/javascript';e.async=true;e.src='//public.slidesharecdn.com/b/ss_foundation/combined_slideview_loggedout.js?e85c54fee15ba7e3cfd0b177790a75c63688c6ea';var s=document.getElementsByTagName('script')[0];s.parentNode.insertBefore(e,s);};$(window).load(function(){loadAdditionalFunctionality();});$('.j-lazy-thumb-click').lazyload({event:'more-tab-clicked'});$('.j-more-tab').on('click',function(){$('.j-lazy-thumb-click').trigger('more-tab-clicked');});$(window).load(function(){loadCSS("//public.slidesharecdn.com/b/ss_foundation/stylesheets/slideview.css?e85c54fee15ba7e3cfd0b177790a75c63688c6ea");});});</script>
<noscript>
<img height="1" width="1" alt="" style="display:none;" src="//www.bizographics.com/collect/?pid=870&fmt=gif" alt="Bizographics tracking image"/>
</noscript>


<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>
</html>
