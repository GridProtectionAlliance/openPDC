
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
<title>OSCON Data 2011 - Lumberyard</title>
<meta name="description" content="Lumberyard is time series iSAX indexing stored in HBase for persistent and scalable index storage It’s interesting for Indexing large amounts of time series da…">
<!-- SL:end:notranslate -->
<meta name="robots" content="index">
<meta id='globalTrackingUrl' content="https://www.linkedin.com/li/track">
<!-- SL:start:notranslate -->
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta http-equiv="x-dns-prefetch-control" content="on">
<meta name="thumbnail" content="http://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail.jpg?cb=1317303673"/>
<!-- SL:end:notranslate -->
<link rel="shortcut icon" href="http://public.slidesharecdn.com/b/images/logo/linkedin-ss/linkedin_ss_favicon.ico?d0e5c05903">
<link rel="alternate" type="application/rss+xml" title="RSS" href="http://www.slideshare.net/rss/latest"/>
<link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="SlideShare Search">
<link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/app_critical.css?e92d50816e" media="screen" rel="stylesheet" type="text/css"/>
<!--[if IE 9]><link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/ie9_nav_bar_fix.css?8fb8af5274" media="screen" rel="stylesheet" type="text/css" /><![endif]-->
<link rel="alternate" hreflang="en" href="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<link rel="alternate" hreflang="es" href="http://es.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<link rel="alternate" hreflang="fr" href="http://fr.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<link rel="alternate" hreflang="de" href="http://de.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<link rel="alternate" hreflang="pt" href="http://pt.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<link rel="alternate" hreflang="x-default" href="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<script type="text/javascript">//<![CDATA[
var smtId="ab5bb963d";var smtDefaultStyles=false;var smtRedirect=true;var smtProt=(("https:"==document.location.protocol)?"https://":"http://");var smtPreRender=function(data){for(i in data){if(data[i].code==="en-us"){data[i].name="English";}}};var smtRedirectMapper=function(locale,sites){if(/^es/i.test(locale)){return null;}
if(locale in sites){return sites[locale];}
if(/^fr/i.test(locale)){return sites['fr-fr']||null;}
if(/^de/i.test(locale)){return sites['de-de']||null;}
return null;};var smtElmt=document.createElement('script');smtElmt.type="text/javascript";smtElmt.async=true;smtElmt.src=smtProt+"cdn01.smartling.com/ls/"+smtId+".js";script=document.getElementsByTagName("script")[0];script.parentNode.insertBefore(smtElmt,script);
//]]></script>
<meta content="authenticity_token" name="csrf-param"/>
<meta content="6+/QGOjRwwIfVMyZpxj3WRnkh1SDh2Ir0FdTeOgkPoQ=" name="csrf-token"/>
<meta content="index" name="robots"/>
<link href="http://public.slidesharecdn.com/b/ss_foundation/stylesheets/slideview_critical.css?8c8ca866a1" media="screen" rel="stylesheet" type="text/css"/>
<link href="http://public.slidesharecdn.com/b/stylesheets/ssplayer/combined_presentation.css?57bb70552a" media="screen" rel="stylesheet" type="text/css"/>
<link rel="dns-prefetch" href="//www.slideshare.net">
<link rel="dns-prefetch" href="//public.slidesharecdn.com">
<link rel="dns-prefetch" href="//image.slidesharecdn.com">
<link rel="dns-prefetch" href="//cdn.slidesharecdn.com">
<link rel="dns-prefetch" href="//cdn01.smartling.com">
<link rel="dns-prefetch" href="//www.linkedin.com">
<script type='text/javascript'>window.Modernizr=function(a,b,c){function d(a){t.cssText=a}function e(a,b){return d(x.join(a+";")+(b||""))}function f(a,b){return typeof a===b}function g(a,b){return!!~(""+a).indexOf(b)}function h(a,b){for(var d in a){var e=a[d];if(!g(e,"-")&&t[e]!==c)return"pfx"==b?e:!0}return!1}function i(a,b,d){for(var e in a){var g=b[a[e]];if(g!==c)return d===!1?a[e]:f(g,"function")?g.bind(d||b):g}return!1}function j(a,b,c){var d=a.charAt(0).toUpperCase()+a.slice(1),e=(a+" "+z.join(d+" ")+d).split(" ");return f(b,"string")||f(b,"undefined")?h(e,b):(e=(a+" "+A.join(d+" ")+d).split(" "),i(e,b,c))}function k(){o.input=function(c){for(var d=0,e=c.length;e>d;d++)E[c[d]]=!!(c[d]in u);return E.list&&(E.list=!(!b.createElement("datalist")||!a.HTMLDataListElement)),E}("autocomplete autofocus list placeholder max min multiple pattern required step".split(" ")),o.inputtypes=function(a){for(var d,e,f,g=0,h=a.length;h>g;g++)u.setAttribute("type",e=a[g]),d="text"!==u.type,d&&(u.value=v,u.style.cssText="position:absolute;visibility:hidden;",/^range$/.test(e)&&u.style.WebkitAppearance!==c?(q.appendChild(u),f=b.defaultView,d=f.getComputedStyle&&"textfield"!==f.getComputedStyle(u,null).WebkitAppearance&&0!==u.offsetHeight,q.removeChild(u)):/^(search|tel)$/.test(e)||(d=/^(url|email)$/.test(e)?u.checkValidity&&u.checkValidity()===!1:u.value!=v)),D[a[g]]=!!d;return D}("search tel url email datetime date month week time datetime-local number range color".split(" "))}var l,m,n="2.8.2",o={},p=!0,q=b.documentElement,r="modernizr",s=b.createElement(r),t=s.style,u=b.createElement("input"),v=":)",w={}.toString,x=" -webkit- -moz- -o- -ms- ".split(" "),y="Webkit Moz O ms",z=y.split(" "),A=y.toLowerCase().split(" "),B={svg:"http://www.w3.org/2000/svg"},C={},D={},E={},F=[],G=F.slice,H=function(a,c,d,e){var f,g,h,i,j=b.createElement("div"),k=b.body,l=k||b.createElement("body");if(parseInt(d,10))for(;d--;)h=b.createElement("div"),h.id=e?e[d]:r+(d+1),j.appendChild(h);return f=["&#173;",'<style id="s',r,'">',a,"</style>"].join(""),j.id=r,(k?j:l).innerHTML+=f,l.appendChild(j),k||(l.style.background="",l.style.overflow="hidden",i=q.style.overflow,q.style.overflow="hidden",q.appendChild(l)),g=c(j,a),k?j.parentNode.removeChild(j):(l.parentNode.removeChild(l),q.style.overflow=i),!!g},I=function(b){var c=a.matchMedia||a.msMatchMedia;if(c)return c(b)&&c(b).matches||!1;var d;return H("@media "+b+" { #"+r+" { position: absolute; } }",function(b){d="absolute"==(a.getComputedStyle?getComputedStyle(b,null):b.currentStyle).position}),d},J=function(){function a(a,e){e=e||b.createElement(d[a]||"div"),a="on"+a;var g=a in e;return g||(e.setAttribute||(e=b.createElement("div")),e.setAttribute&&e.removeAttribute&&(e.setAttribute(a,""),g=f(e[a],"function"),f(e[a],"undefined")||(e[a]=c),e.removeAttribute(a))),e=null,g}var d={select:"input",change:"input",submit:"form",reset:"form",error:"img",load:"img",abort:"img"};return a}(),K={}.hasOwnProperty;m=f(K,"undefined")||f(K.call,"undefined")?function(a,b){return b in a&&f(a.constructor.prototype[b],"undefined")}:function(a,b){return K.call(a,b)},Function.prototype.bind||(Function.prototype.bind=function(a){var b=this;if("function"!=typeof b)throw new TypeError;var c=G.call(arguments,1),d=function(){if(this instanceof d){var e=function(){};e.prototype=b.prototype;var f=new e,g=b.apply(f,c.concat(G.call(arguments)));return Object(g)===g?g:f}return b.apply(a,c.concat(G.call(arguments)))};return d}),C.flexbox=function(){return j("flexWrap")},C.flexboxlegacy=function(){return j("boxDirection")},C.canvas=function(){var a=b.createElement("canvas");return!(!a.getContext||!a.getContext("2d"))},C.canvastext=function(){return!(!o.canvas||!f(b.createElement("canvas").getContext("2d").fillText,"function"))},C.webgl=function(){return!!a.WebGLRenderingContext},C.touch=function(){var c;return"ontouchstart"in a||a.DocumentTouch&&b instanceof DocumentTouch?c=!0:H(["@media (",x.join("touch-enabled),("),r,")","{#modernizr{top:9px;position:absolute}}"].join(""),function(a){c=9===a.offsetTop}),c},C.geolocation=function(){return"geolocation"in navigator},C.postmessage=function(){return!!a.postMessage},C.websqldatabase=function(){return!!a.openDatabase},C.indexedDB=function(){return!!j("indexedDB",a)},C.hashchange=function(){return J("hashchange",a)&&(b.documentMode===c||b.documentMode>7)},C.history=function(){return!(!a.history||!history.pushState)},C.draganddrop=function(){var a=b.createElement("div");return"draggable"in a||"ondragstart"in a&&"ondrop"in a},C.websockets=function(){return"WebSocket"in a||"MozWebSocket"in a},C.rgba=function(){return d("background-color:rgba(150,255,150,.5)"),g(t.backgroundColor,"rgba")},C.hsla=function(){return d("background-color:hsla(120,40%,100%,.5)"),g(t.backgroundColor,"rgba")||g(t.backgroundColor,"hsla")},C.multiplebgs=function(){return d("background:url(https://),url(https://),red url(https://)"),/(url\s*\(.*?){3}/.test(t.background)},C.backgroundsize=function(){return j("backgroundSize")},C.borderimage=function(){return j("borderImage")},C.borderradius=function(){return j("borderRadius")},C.boxshadow=function(){return j("boxShadow")},C.textshadow=function(){return""===b.createElement("div").style.textShadow},C.opacity=function(){return e("opacity:.55"),/^0.55$/.test(t.opacity)},C.cssanimations=function(){return j("animationName")},C.csscolumns=function(){return j("columnCount")},C.cssgradients=function(){var a="background-image:",b="gradient(linear,left top,right bottom,from(#9f9),to(white));",c="linear-gradient(left top,#9f9, white);";return d((a+"-webkit- ".split(" ").join(b+a)+x.join(c+a)).slice(0,-a.length)),g(t.backgroundImage,"gradient")},C.cssreflections=function(){return j("boxReflect")},C.csstransforms=function(){return!!j("transform")},C.csstransforms3d=function(){var a=!!j("perspective");return a&&"webkitPerspective"in q.style&&H("@media (transform-3d),(-webkit-transform-3d){#modernizr{left:9px;position:absolute;height:3px;}}",function(b){a=9===b.offsetLeft&&3===b.offsetHeight}),a},C.csstransitions=function(){return j("transition")},C.fontface=function(){var a;return H('@font-face {font-family:"font";src:url("https://")}',function(c,d){var e=b.getElementById("smodernizr"),f=e.sheet||e.styleSheet,g=f?f.cssRules&&f.cssRules[0]?f.cssRules[0].cssText:f.cssText||"":"";a=/src/i.test(g)&&0===g.indexOf(d.split(" ")[0])}),a},C.generatedcontent=function(){var a;return H(["#",r,"{font:0/0 a}#",r,':after{content:"',v,'";visibility:hidden;font:3px/1 a}'].join(""),function(b){a=b.offsetHeight>=3}),a},C.video=function(){var a=b.createElement("video"),c=!1;try{(c=!!a.canPlayType)&&(c=new Boolean(c),c.ogg=a.canPlayType('video/ogg; codecs="theora"').replace(/^no$/,""),c.h264=a.canPlayType('video/mp4; codecs="avc1.42E01E"').replace(/^no$/,""),c.webm=a.canPlayType('video/webm; codecs="vp8, vorbis"').replace(/^no$/,""))}catch(d){}return c},C.audio=function(){var a=b.createElement("audio"),c=!1;try{(c=!!a.canPlayType)&&(c=new Boolean(c),c.ogg=a.canPlayType('audio/ogg; codecs="vorbis"').replace(/^no$/,""),c.mp3=a.canPlayType("audio/mpeg;").replace(/^no$/,""),c.wav=a.canPlayType('audio/wav; codecs="1"').replace(/^no$/,""),c.m4a=(a.canPlayType("audio/x-m4a;")||a.canPlayType("audio/aac;")).replace(/^no$/,""))}catch(d){}return c},C.localstorage=function(){try{return localStorage.setItem(r,r),localStorage.removeItem(r),!0}catch(a){return!1}},C.sessionstorage=function(){try{return sessionStorage.setItem(r,r),sessionStorage.removeItem(r),!0}catch(a){return!1}},C.webworkers=function(){return!!a.Worker},C.applicationcache=function(){return!!a.applicationCache},C.svg=function(){return!!b.createElementNS&&!!b.createElementNS(B.svg,"svg").createSVGRect},C.inlinesvg=function(){var a=b.createElement("div");return a.innerHTML="<svg/>",(a.firstChild&&a.firstChild.namespaceURI)==B.svg},C.smil=function(){return!!b.createElementNS&&/SVGAnimate/.test(w.call(b.createElementNS(B.svg,"animate")))},C.svgclippaths=function(){return!!b.createElementNS&&/SVGClipPath/.test(w.call(b.createElementNS(B.svg,"clipPath")))};for(var L in C)m(C,L)&&(l=L.toLowerCase(),o[l]=C[L](),F.push((o[l]?"":"no-")+l));return o.input||k(),o.addTest=function(a,b){if("object"==typeof a)for(var d in a)m(a,d)&&o.addTest(d,a[d]);else{if(a=a.toLowerCase(),o[a]!==c)return o;b="function"==typeof b?b():b,"undefined"!=typeof p&&p&&(q.className+=" "+(b?"":"no-")+a),o[a]=b}return o},d(""),s=u=null,function(a,b){function c(a,b){var c=a.createElement("p"),d=a.getElementsByTagName("head")[0]||a.documentElement;return c.innerHTML="x<style>"+b+"</style>",d.insertBefore(c.lastChild,d.firstChild)}function d(){var a=s.elements;return"string"==typeof a?a.split(" "):a}function e(a){var b=r[a[p]];return b||(b={},q++,a[p]=q,r[q]=b),b}function f(a,c,d){if(c||(c=b),k)return c.createElement(a);d||(d=e(c));var f;return f=d.cache[a]?d.cache[a].cloneNode():o.test(a)?(d.cache[a]=d.createElem(a)).cloneNode():d.createElem(a),!f.canHaveChildren||n.test(a)||f.tagUrn?f:d.frag.appendChild(f)}function g(a,c){if(a||(a=b),k)return a.createDocumentFragment();c=c||e(a);for(var f=c.frag.cloneNode(),g=0,h=d(),i=h.length;i>g;g++)f.createElement(h[g]);return f}function h(a,b){b.cache||(b.cache={},b.createElem=a.createElement,b.createFrag=a.createDocumentFragment,b.frag=b.createFrag()),a.createElement=function(c){return s.shivMethods?f(c,a,b):b.createElem(c)},a.createDocumentFragment=Function("h,f","return function(){var n=f.cloneNode(),c=n.createElement;h.shivMethods&&("+d().join().replace(/[\w\-]+/g,function(a){return b.createElem(a),b.frag.createElement(a),'c("'+a+'")'})+");return n}")(s,b.frag)}function i(a){a||(a=b);var d=e(a);return!s.shivCSS||j||d.hasCSS||(d.hasCSS=!!c(a,"article,aside,dialog,figcaption,figure,footer,header,hgroup,main,nav,section{display:block}mark{background:#FF0;color:#000}template{display:none}")),k||h(a,d),a}var j,k,l="3.7.0",m=a.html5||{},n=/^<|^(?:button|map|select|textarea|object|iframe|option|optgroup)$/i,o=/^(?:a|b|code|div|fieldset|h1|h2|h3|h4|h5|h6|i|label|li|ol|p|q|span|strong|style|table|tbody|td|th|tr|ul)$/i,p="_html5shiv",q=0,r={};!function(){try{var a=b.createElement("a");a.innerHTML="<xyz></xyz>",j="hidden"in a,k=1==a.childNodes.length||function(){b.createElement("a");var a=b.createDocumentFragment();return"undefined"==typeof a.cloneNode||"undefined"==typeof a.createDocumentFragment||"undefined"==typeof a.createElement}()}catch(c){j=!0,k=!0}}();var s={elements:m.elements||"abbr article aside audio bdi canvas data datalist details dialog figcaption figure footer header hgroup main mark meter nav output progress section summary template time video",version:l,shivCSS:m.shivCSS!==!1,supportsUnknownElements:k,shivMethods:m.shivMethods!==!1,type:"default",shivDocument:i,createElement:f,createDocumentFragment:g};a.html5=s,i(b)}(this,b),o._version=n,o._prefixes=x,o._domPrefixes=A,o._cssomPrefixes=z,o.mq=I,o.hasEvent=J,o.testProp=function(a){return h([a])},o.testAllProps=j,o.testStyles=H,o.prefixed=function(a,b,c){return b?j(a,b,c):j(a,"pfx")},q.className=q.className.replace(/(^|\s)no-js(\s|$)/,"$1$2")+(p?" js "+F.join(" "):""),o}(this,this.document);window._gaq=window._gaq||[];_gaq.push(['_setAccount','UA-2330466-1']);_gaq.push(['_setDomainName','.slideshare.net']);_gaq.push(['_addIgnoredRef','slideshare.net']);_gaq.push(['_setCustomVar',1,'member_type','LOGGEDOUT',1]);_gaq.push(['_trackPageview']);var _comscore=_comscore||[];_comscore.push({c1:"2",c2:"6402952"});var slideshare_object={user:{"login":"guest","userGroup":"non-member","fb_userid":null,"name":null,"su":false,"is_test_user":false,"has_uploads":null,"is_pro":"false","is_li_connected":false,"show_li_connect_cta":false,"has_privacy_enabled":null,"li_tracking_url":"https://www.linkedin.com/li/track","is_valid_fbuser":false,"loggedin":false,"id":null},timer:{start:(new Date()).getTime(),end:'',execTime:''},top_nav:{get_url:"/top_nav"},dev:false,fb_app_name:'slideshare',fb_permissions:'email,user_friends',fb_sdk_url:'//connect.facebook.net/en_US/sdk.js',fb_init_params:{appId:'2490221586',version:'v2.3',oauth:true,channelUrl:'//public.slidesharecdn.com/b/channel.html',status:true,cookie:true,xfbml:true},init:[],feature_flag:[],is_mobile:"",deploy_environment:"production",rum_pagekey:"desktop_slideview_loggedout",is_ssl:false};</script>
<meta content="http://public.slidesharecdn.com/b/images/artdeco/icons.svg?43e81fd2ef" name="ss-svg-icons"/>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_experiments.js?5cdb0c4b79" type="text/javascript"></script>
<link rel="dns-prefetch" href="//js.bizographics.com">
<script id="page-json" type="text/javascript">var sso_redirect_uri={"sso_redirect_uri":"nil"};</script>
<script id="adQueue" type="text/javascript">if(!slideshare_object.delayedLIAd){slideshare_object._adQueue=[];}</script>
<script type="text/javascript" id="ga-init">//<![CDATA[
window._gaq.push(['_setCustomVar',3,'source','not_set',3]);var Experiments=slideshare_object.utils.imports('Experiments'),experiments=new Experiments();window._gaq.push(['_trackEvent','bigfoot_slideview','pageload','clip_button_exp_'+experiments.getBucket('slideview-clip-button-exp-2'),undefined,true]);slideshare_object.deploy_environment='production';
//]]></script>
<link href="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" rel="canonical"/>
<link title="Slideshow json oEmbed Profile" type="application/json+oembed" href="http://www.slideshare.net/api/oembed/2?format=json&amp;url=http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" rel="alternate"/>
<link title="Slideshow xml oEmbed Profile" type="text/xml+oembed" href="http://www.slideshare.net/api/oembed/2?format=xml&amp;url=http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" rel="alternate"/>
<link media="handheld" href="http://www.slideshare.net/mobile/jpatanooga/oscon-data-2011-lumberyard" rel="alternate"/>
<link href="android-app://net.slideshare.mobile/slideshare-app/ss/9476155" rel="alternate"/>
<link href="ios-app://917418728/slideshare-app/ss/9476155" rel="alternate"/>
<!-- fb open graph meta tags -->
<meta content="2490221586" class="fb_og_meta" property="fb:app_id" name="fb_app_id"/>
<meta content="slideshare:presentation" class="fb_og_meta" property="og:type" name="og_type"/>
<meta content="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" class="fb_og_meta" property="og:url" name="og_url"/>
<meta content="http://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail-4.jpg?cb=1317303673" class="fb_og_meta" property="og:image" name="og_image"/>
<!-- SL:start:notranslate -->
<meta content="OSCON Data 2011 - Lumberyard" class="fb_og_meta" property="og:title" name="og_title"/>
<meta content="Lumberyard is time series iSAX indexing stored in HBase for persistent and scalable index storage It’s interesting for Indexing large amounts of time series da…" class="fb_og_meta" property="og:description" name="og_description"/>
<!-- SL:end:notranslate -->
<meta content="2011-09-29T13:38:34Z" class="fb_og_meta" property="slideshare:published" name="slideshow_published_time"/>
<meta content="http://www.slideshare.net/jpatanooga" class="fb_og_meta" property="slideshare:author" name="slideshow_author"/>
<meta content="4117" class="fb_og_meta" property="slideshare:view_count" name="slideshow_view_count"/>
<meta content="12" class="fb_og_meta" property="slideshare:embed_count" name="slideshow_embed_count"/>
<meta content="0" class="fb_og_meta" property="slideshare:comment_count" name="slideshow_comment_count"/>
<meta content="52" class="fb_og_meta" property="slideshare:download_count" name="slideshow_download_count"/>
<meta content="2011-09-29 13:38:34 UTC" class="fb_og_meta" property="slideshare:created_at" name="slideshow_created_at"/>
<meta content="2011-09-29 13:41:13 UTC" class="fb_og_meta" property="slideshare:updated_at" name="slideshow_updated_at"/>
<meta content="" class="fb_og_meta" property="slideshare:featured_on" name="slideshow_featured_on"/>
<meta content="3" class="fb_og_meta" property="slideshare:favorites_count" name="slideshow_favorites_count"/>
<meta content="Technology" class="fb_og_meta" property="slideshare:category" name="slideshow_category"/>
<!-- SL:start:notranslate -->
<meta name="twitter:card" value="player"/>
<meta name="twitter:site" value="@slideshare"/>
<meta class="twitter_player" value="https://www.slideshare.net/slideshow/embed_code/key/kqmHgRqgwDzBwf" name="twitter:player"/>
<meta name="twitter:player:width" value="342"/>
<meta name="twitter:player:height" value="291"/>
<meta class="twitter_title" value="OSCON Data 2011 - Lumberyard" name="twitter:title"/>
<meta class="twitter_image" value="https://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail-4.jpg?cb=1317303673" name="twitter:image"/>
<meta name="twitter:app:name:googleplay" content="SlideShare Android"/>
<meta name="twitter:app:id:googleplay" content="net.slideshare.mobile"/>
<meta name="twitter:app:url:googleplay" content="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"/>
<meta name="twitter:app:name:iphone" content="SlideShare iOS"/>
<meta name="twitter:app:id:iphone" content="917418728"/>
<meta name="twitter:app:url:iphone" content="slideshare-app://ss/9476155"/>
<meta name="twitter:app:name:ipad" content="SlideShare iOS"/>
<meta name="twitter:app:id:ipad" content="917418728"/>
<meta name="twitter:app:url:ipad" content="slideshare-app://ss/9476155"/>
<meta property="al:android:url" content="slideshare-app://ss/9476155"/>
<meta property="al:android:app_name" content="SlideShare Android"/>
<meta property="al:android:package" content="net.slideshare.mobile"/>
<meta property="al:ios:url" content="slideshare-app://ss/9476155"/>
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
OSCON Data 2011 - Lumberyard
</span>
<div class="stage valign-first-slide">
<a class="exit-fullscreen j-exit-fullscreen" style="display: none;">
<i class="fa fa-compress fa-2x"></i>
</a>
<div class="slide_container">
<section data-index="1" class="slide show" itemprop=image>
<img class="slide_image" src="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-728.jpg?cb=1317303673" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-1-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-1024.jpg?cb=1317303673" alt="LumberyardTime Series Indexing At Scale&lt;br /&gt;"/>
</section>
<section data-index="2" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-2-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-2-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-2-1024.jpg?cb=1317303673" alt="Today’s speaker – Josh Patterson&lt;br /&gt;josh@cloudera.com&lt;br /&gt;Master’s Thesis: self-organizing mesh networks&lt;br /&gt;Published..."/>
</section>
<section data-index="3" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-3-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-3-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-3-1024.jpg?cb=1317303673" alt="Agenda&lt;br /&gt;What is Lumberyard?&lt;br /&gt;A Short History of How We Got Here&lt;br /&gt;iSAX and Time series Data&lt;br /&gt;Use Cases and ..."/>
</section>
<section data-index="4" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-4-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-4-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-4-1024.jpg?cb=1317303673" alt="What is Lumberyard?&lt;br /&gt;Lumberyard is time series iSAX indexing stored in HBase for persistent and scalable index storage..."/>
</section>
<section data-index="5" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-5-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-5-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-5-1024.jpg?cb=1317303673" alt="A Short History of How We Got Here&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;"/>
</section>
<section data-index="6" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-6-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-6-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-6-1024.jpg?cb=1317303673" alt="NERC Sensor Data Collection&lt;br /&gt;openPDC PMU Data Collection circa 2009 &lt;br /&gt;&lt;ul&gt;&lt;li&gt;120 Sensors"/>
</section>
<section data-index="7" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-7-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-7-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-7-1024.jpg?cb=1317303673" alt="30 samples/second"/>
</section>
<section data-index="8" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-8-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-8-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-8-1024.jpg?cb=1317303673" alt="4.3B Samples/day"/>
</section>
<section data-index="9" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-9-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-9-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-9-1024.jpg?cb=1317303673" alt="Housed in Hadoop&lt;/li&gt;&lt;/li&gt;&lt;/ul&gt;&lt;li&gt;Story Time: Keogh, SAX, and the openPDC&lt;br /&gt;NERC wanted high res smart grid data track..."/>
</section>
<section data-index="10" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-10-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-10-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-10-1024.jpg?cb=1317303673" alt="What is time series data?&lt;br /&gt;Time series data is defined as a sequence of data points measured typically at successive t..."/>
</section>
<section data-index="11" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-11-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-11-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-11-1024.jpg?cb=1317303673" alt="Why Hadoop is Great for the OpenPDC&lt;br /&gt;Scenario&lt;br /&gt;1 million sensors, collecting sample / 5 min&lt;br /&gt;5 year retention ..."/>
</section>
<section data-index="12" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-12-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-12-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-12-1024.jpg?cb=1317303673" alt="Unstructured Data Explosion&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;(you)&lt;br /&gt;Complex, Unstructured&lt;br..."/>
</section>
<section data-index="13" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-13-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-13-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-13-1024.jpg?cb=1317303673" alt=" Digital universe grew by 62% last year to 800K petabytes and will grow to 1.2 “zettabytes” this year&lt;/li&gt;&lt;/li&gt;&lt;/ul&gt;&lt;li&gt;Ap..."/>
</section>
<section data-index="14" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-14-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-14-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-14-1024.jpg?cb=1317303673" alt=" Move complex and relational data into a single repository"/>
</section>
<section data-index="15" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-15-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-15-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-15-1024.jpg?cb=1317303673" alt="Stores Inexpensively"/>
</section>
<section data-index="16" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-16-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-16-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-16-1024.jpg?cb=1317303673" alt=" Keep raw data always available"/>
</section>
<section data-index="17" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-17-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-17-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-17-1024.jpg?cb=1317303673" alt=" Use industry standard hardware"/>
</section>
<section data-index="18" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-18-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-18-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-18-1024.jpg?cb=1317303673" alt="Processes at the Source"/>
</section>
<section data-index="19" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-19-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-19-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-19-1024.jpg?cb=1317303673" alt=" Eliminate ETL bottlenecks"/>
</section>
<section data-index="20" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-20-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-20-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-20-1024.jpg?cb=1317303673" alt=" Mine data first, govern later &lt;/li&gt;&lt;/ul&gt;MapReduce&lt;br /&gt;Hadoop Distributed File System (HDFS)&lt;br /&gt;"/>
</section>
<section data-index="21" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-21-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-21-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-21-1024.jpg?cb=1317303673" alt="What about this HBase stuff?&lt;br /&gt;In the beginning, there was the GFS and theMapReduce&lt;br /&gt;And it was Good&lt;br /&gt;(Then the..."/>
</section>
<section data-index="22" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-22-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-22-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-22-1024.jpg?cb=1317303673" alt="iSAX and Time Series Data&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;"/>
</section>
<section data-index="23" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-23-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-23-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-23-1024.jpg?cb=1317303673" alt="What is SAX?&lt;br /&gt;Symbolic Aggregate ApproXimation&lt;br /&gt;In this case, not XML.&lt;br /&gt;A symbolic representation of times ser..."/>
</section>
<section data-index="24" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-24-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-24-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-24-1024.jpg?cb=1317303673" alt="Lower bounding of Euclidean distance"/>
</section>
<section data-index="25" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-25-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-25-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-25-1024.jpg?cb=1317303673" alt="Lower bounding of the DTW distance"/>
</section>
<section data-index="26" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-26-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-26-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-26-1024.jpg?cb=1317303673" alt="Dimensionality Reduction"/>
</section>
<section data-index="27" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-27-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-27-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-27-1024.jpg?cb=1317303673" alt="Numerosity Reduction &lt;/li&gt;&lt;/ul&gt;Copyright 2010 Cloudera Inc. All rights reserved&lt;br /&gt;"/>
</section>
<section data-index="28" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-28-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-28-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-28-1024.jpg?cb=1317303673" alt="SAX in 60 Seconds&lt;br /&gt;Take time series T&lt;br /&gt;Convert to Piecewise Aggregate Approximation (PAA)&lt;br /&gt;Reduces dimensional..."/>
</section>
<section data-index="29" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-29-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-29-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-29-1024.jpg?cb=1317303673" alt="Why? Time Series Data is “Fuzzy”&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;"/>
</section>
<section data-index="30" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-30-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-30-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-30-1024.jpg?cb=1317303673" alt="Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;SAX: Fuzzy Things Become More Discrete&lt;br /&gt;"/>
</section>
<section data-index="31" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-31-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-31-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-31-1024.jpg?cb=1317303673" alt="How does SAX work?&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;1.5&lt;br /&gt;1.5&lt;br /&gt;1&lt;br /&gt;1&lt;br /&gt;0.5&lt;br /&gt;0.5..."/>
</section>
<section data-index="32" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-32-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-32-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-32-1024.jpg?cb=1317303673" alt="SAX and the Potential for Indexing&lt;br /&gt;The classic SAX representation offers the potential to be indexed&lt;br /&gt;If we choos..."/>
</section>
<section data-index="33" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-33-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-33-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-33-1024.jpg?cb=1317303673" alt="iSAX&lt;br /&gt;iSAX: indexableSymbolic Aggregate approXimation&lt;br /&gt;Modifies SAX to allow “extensible hashing” and a multi-reso..."/>
</section>
<section data-index="34" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-34-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-34-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-34-1024.jpg?cb=1317303673" alt="iSAX Word Properties&lt;br /&gt;Key concepts&lt;br /&gt;We can compare iSAX words of different cardinalities&lt;br /&gt;We can mix cardinali..."/>
</section>
<section data-index="35" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-35-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-35-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-35-1024.jpg?cb=1317303673" alt="iSAX Dynamic Cardinality&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;T = time series 1&lt;br /&gt;S = time series..."/>
</section>
<section data-index="36" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-36-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-36-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-36-1024.jpg?cb=1317303673" alt="How Does iSAX Indexing Work?&lt;br /&gt;Similar to a b-tree&lt;br /&gt;Nodes represents iSAX words&lt;br /&gt;Has internal nodes and leaf no..."/>
</section>
<section data-index="37" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-37-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-37-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-37-1024.jpg?cb=1317303673" alt="iSAX Indexing, Inserting, and Searching&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;{ 24 , 34 , 34 ,24 }&lt;br..."/>
</section>
<section data-index="38" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-38-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-38-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-38-1024.jpg?cb=1317303673" alt=" If we split this dimension, we add a bit"/>
</section>
<section data-index="39" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-39-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-39-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-39-1024.jpg?cb=1317303673" alt=" “10” becomes “100” (4) and “101” (5)"/>
</section>
<section data-index="40" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-40-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-40-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-40-1024.jpg?cb=1317303673" alt=" we’re now at cardinality of 8 &lt;/li&gt;&lt;/ul&gt;{ 48 , 34 , 34 ,24 }&lt;br /&gt;{ 58 , 34 , 34 ,24 }&lt;br /&gt;"/>
</section>
<section data-index="41" class="slide">
<i class="fa fa-spinner fa-spin"></i>
<img class="slide_image" src="" data-small="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-41-320.jpg?cb=1317303673" data-normal="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-41-728.jpg?cb=1317303673" data-full="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-41-1024.jpg?cb=1317303673" alt="Some Quick Numbers From the iSAX Paper&lt;br /&gt;100 million samples indexed, ½ TB of time series data&lt;br /&gt;Times&lt;br /&gt;linear s..."/>
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
<img class="j-tooltip-thumb tooltip-thumb" onerror="this.src=''" slide-thumb-1=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-1-320.jpg?cb=1317303673 slide-thumb-2=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-2-320.jpg?cb=1317303673 slide-thumb-3=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-3-320.jpg?cb=1317303673 slide-thumb-4=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-4-320.jpg?cb=1317303673 slide-thumb-5=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-5-320.jpg?cb=1317303673 slide-thumb-6=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-6-320.jpg?cb=1317303673 slide-thumb-7=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-7-320.jpg?cb=1317303673 slide-thumb-8=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-8-320.jpg?cb=1317303673 slide-thumb-9=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-9-320.jpg?cb=1317303673 slide-thumb-10=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-10-320.jpg?cb=1317303673 slide-thumb-11=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-11-320.jpg?cb=1317303673 slide-thumb-12=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-12-320.jpg?cb=1317303673 slide-thumb-13=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-13-320.jpg?cb=1317303673 slide-thumb-14=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-14-320.jpg?cb=1317303673 slide-thumb-15=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-15-320.jpg?cb=1317303673 slide-thumb-16=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-16-320.jpg?cb=1317303673 slide-thumb-17=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-17-320.jpg?cb=1317303673 slide-thumb-18=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-18-320.jpg?cb=1317303673 slide-thumb-19=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-19-320.jpg?cb=1317303673 slide-thumb-20=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-20-320.jpg?cb=1317303673 slide-thumb-21=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-21-320.jpg?cb=1317303673 slide-thumb-22=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-22-320.jpg?cb=1317303673 slide-thumb-23=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-23-320.jpg?cb=1317303673 slide-thumb-24=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-24-320.jpg?cb=1317303673 slide-thumb-25=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-25-320.jpg?cb=1317303673 slide-thumb-26=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-26-320.jpg?cb=1317303673 slide-thumb-27=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-27-320.jpg?cb=1317303673 slide-thumb-28=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-28-320.jpg?cb=1317303673 slide-thumb-29=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-29-320.jpg?cb=1317303673 slide-thumb-30=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-30-320.jpg?cb=1317303673 slide-thumb-31=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-31-320.jpg?cb=1317303673 slide-thumb-32=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-32-320.jpg?cb=1317303673 slide-thumb-33=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-33-320.jpg?cb=1317303673 slide-thumb-34=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-34-320.jpg?cb=1317303673 slide-thumb-35=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-35-320.jpg?cb=1317303673 slide-thumb-36=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-36-320.jpg?cb=1317303673 slide-thumb-37=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-37-320.jpg?cb=1317303673 slide-thumb-38=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-38-320.jpg?cb=1317303673 slide-thumb-39=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-39-320.jpg?cb=1317303673 slide-thumb-40=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-40-320.jpg?cb=1317303673 slide-thumb-41=http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/85/oscon-data-2011-lumberyard-41-320.jpg?cb=1317303673>
<span class="j-slidecount-label slidecount-label">1</span>
</div>
<div class="progress-tooltip-caret"></div>
</div>
</div>
<div class="progress-bar-spacing"></div>
<div class="j-tools bot-actions">
</div><!-- .bot-actions -->
<div class="j-tools bot-actions">
<a data-tooltip aria-haspopup="true" style="display: none" class="j-tooltip j-download action-download has-tip" title="Save this presentation" href="/login?from_source=%2Fjpatanooga%2Foscon-data-2011-lumberyard%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation" data-target="#login_modal" data-placement="top">
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
<span id="total-slides" class="j-total-slides">41</span>
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
<a href="/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva" title="Hadoop As The Platform For The Smar...">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail.jpg?cb=1327341063" alt="Hadoop As The Platform For The Smar..."/>
<span class="presentation-meta">
<span class="title">Hadoop As The Platform For The Smar...</span>
<span class="author">by&nbsp;Cloudera, Inc.</span>
<span class="view-count">4640&nbsp;views</span>
</span>
</a>
</li>
<li>
<a href="/vasujain/indexing-and-mining-a-billion-time-series-using-isax-20" title="Indexing and Mining a Billion Time ...">
<img class="j-thumbnail" data-original="//cdn.slidesharecdn.com/ss_thumbnails/jainvasupaperpptisax2-121107191852-phpapp01-thumbnail.jpg?cb=1352316162" alt="Indexing and Mining a Billion Time ..."/>
<span class="presentation-meta">
<span class="title">Indexing and Mining a Billion Time ...</span>
<span class="author">by&nbsp;Vasu Jain</span>
<span class="view-count">1882&nbsp;views</span>
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
<ul class="j-share-social-list share-social-list" data-canonical-url="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard">
<li class="facebook" data-network="facebook">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="Share on Facebook">Facebook</a>
</div>
</li>
<li class="twitter" data-network="twitter">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" data-text="OSCON Data 2011 - Lumberyard by @jpatanooga #hadoop #hbase" data-related="@jpatanooga" data-via="SlideShare" title="Tweet on Twitter">Twitter</a>
</div>
</li>
<li class="linkedin" data-network="linkedin">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" data-text="OSCON Data 2011 - Lumberyard by Josh Patterson via slideshare" title="Share on LinkedIn">LinkedIn</a>
</div>
</li>
<li class="googleplus" data-network="googleplus">
<div class="social-hover">
<a class="share-link" rel="nofollow" data-url="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="Share on Google+">Google+</a>
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
<meta itemprop="image" content="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-728.jpg?cb=1317303673">
<meta itemprop="thumbnailUrl" content="http://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail.jpg?cb=1317303673">
<meta itemprop="embedURL" content="https://www.slideshare.net/slideshow/embed_code/key/kqmHgRqgwDzBwf">
<meta itemprop="playerType" content="HTML5 Flash">
<meta itemprop="interactionCount" content="UserComments:0">
<meta itemprop="interactionCount" content="UserLikes:3">
<meta itemprop="interactionCount" content="UserDownloads:52">
<meta itemprop="interactionCount" content="UserPageVisits:4117">
<meta itemprop="interactionCount" content="UserPlays:4117">
<meta itemprop="interactionCount" content="UserPlusOnes:0" id="meta-google">
<meta itemprop="interactionCount" content="UserTweets:0" id="meta-twitter">
<div class="slideshow-title-container row add-padding-right">
<div class="small-10 columns">
<h1 class="notranslate slideshow-title-text" itemprop="headline">
<span class="j-title-breadcrumb">
OSCON Data 2011 - Lumberyard
</span>
</h1>
</div>
<div class="small-2 columns text-right format-views" data-views="views">
<span class="notranslate">
4,117<br>
</span>
</div>
</div>
<ul id="slideshow-actions" class="slideshow-actions">
<li class="item-action">
<button class="tiny art-deco share" data-action="share">Share</button>
</li>
<li class="item-action">
<button class="tiny art-deco like button" data-action="like" href="/signup?login_source=slideview.popup.like&amp;from=favorite&amp;layout=foundation&amp;from_source=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard" rel="nofollow">Like</button>
</li>
<li class="item-action">
<button class="tiny art-deco download button" data-action="download" href="/login?from_source=%2Fjpatanooga%2Foscon-data-2011-lumberyard%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation" rel="nofollow">
Download
</button>
</li>
</ul>
<div class="author-container add-padding-right" itemprop="author" itemscope itemtype="http://schema.org/Person">
<div class="left author-thumbnail">
<a href="/jpatanooga?utm_campaign=profiletracking&amp;utm_medium=sssite&amp;utm_source=ssslideview" class="author-photo-wrapper" title="jpatanooga" itemprop="url">
<img alt="Josh Patterson" class="author-photo" itemprop="image" src="//cdn.slidesharecdn.com/profile-photo-jpatanooga-48x48.jpg?cb=1440002081"/>
</a>
</div>
<div class="author-text">
<h2 style="display:inline;">
<a class="j-author-name" title="jpatanooga" rel="author" href="/jpatanooga?utm_campaign=profiletracking&amp;utm_medium=sssite&amp;utm_source=ssslideview" data-ga-cat="bigfoot_slideview" data-ga-action="authorlinkclick">
<span itemprop="name">Josh Patterson</span></a></h2><small class="lighter-color-text" itemprop="jobTitle">, Advisor at Skymind.io - Deep learning for Industry</small>
<small class="lighter-color-text"> at <span itemprop="worksFor">Skymind.io - Deep learning for Industry</span></small>
<div class="author-cta-container">
<div class="follow-container">
<span class="j-follow " data-contactee-id="30941782">
<a class="follow-btn" data-contactee="30941782" href="/signup?login_source=slideview.popup.follow&from=addcontact&from_source=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard">
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
<small>Published on <time datetime="2011-09-29T13:38:34Z" itemprop="datePublished">Sep 29, 2011</time></small>
</p>
<div id="nps_survey_placeholder"></div>
<div class="slideshow-description-container add-padding-right">
<div class="description row" data-ga-cat="bigfoot_slideview" data-ga-action="description>more">
<div class="large-10 columns">
<p id="slideshow-description-paragraph" class="notranslate">
Lumberyard is time series iSAX indexing stored in HBase for persistent and scalable index storage<br/><br/>It’s interesting for Indexing large amounts of time series data Low latency fuzzy pattern matching queries on time series data<br/><br/>Lumberyard is open source and ASF 2.0 Licensed at Github:<br/>https:&#x2F;&#x2F;github.com&#x2F;jpatanooga&#x2F;Lumberyard&#x2F;<br/><br/>This was the slide deck I gave at OSCON Data 2011
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
<a rel="nofollow" href="/featured/category/technology">Technology</a><span class="comma">, </span>
<a rel="nofollow" href="/featured/category/economy-finance">Economy &amp; Finance</a><span class="comma"></span>
</div>
</div>
<div class="slideshow-tabs-container show-for-medium-up">
<dl class="tabs" data-tab>
<dd class="active">
<a href="#comments-panel">
<i class="fa fa-comment"></i>
0 Comments
</a>
</dd>
<dd class="">
<a href="#likes-panel">
<i class="fa fa-heart"></i>
<span class="j-favs-count">
3 Likes
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
<a id="login-provider-slideshare" class="postfix" rel="nofollow" href="/signup?login_source=slideview.popup.comment&from=comments&from_source=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard">
<button type="button" class="postfix">Post</button>
</a>
</div>
</div>
</div>
</div>
</form>
<ul id="commentsList" class="user-list no-bullet">
<li>
<p class="empty-stat-box text-center">
<em>Be the first to comment</em>
</p>
</li>
</ul>
</div>
<div class="content" id="likes-panel">
<ul id="favsList" class="j-favs-list notranslate user-list no-bullet" itemtype="http://schema.org/UserLikes" itemscope>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="BhuwanBisht" itemprop="url" rel="nofollow" href="/BhuwanBisht?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="BhuwanBisht" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//public.slidesharecdn.com/b/images/user-48x48.png"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="BhuwanBisht" rel="nofollow" href="/BhuwanBisht?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Bhuwan Bisht</span>
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
7 months ago
</time>
</a>
</div>
</div>
</li>
<li itemtype="http://schema.org/Person" itemscope>
<div class="row">
<div class="small-1 columns thumbnail">
<a class="j-author-photo notranslate" title="bikash21" itemprop="url" rel="nofollow" href="/bikash21?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="bikash21" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-bikash21-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="bikash21" rel="nofollow" href="/bikash21?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Bikash Agrawal</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
,
<span>PhD. Research Fellow</span>
</span>
<span class="j-favoriter-org">
at
<span>Universitetet i Stavanger</span>
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
<a class="j-author-photo notranslate" title="pedr0teixeira" itemprop="url" rel="nofollow" href="/pedr0teixeira?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<img itemprop="image" class="j-lazy-thumb" alt="pedr0teixeira" src="//public.slidesharecdn.com/b/images/user-48x48.png" data-original="//cdn.slidesharecdn.com/profile-photo-pedr0teixeira-48x48.jpg"/>
</a>
</div>
<div class="small-11 columns">
<a class="favoriter notranslate" title="pedr0teixeira" rel="nofollow" href="/pedr0teixeira?utm_campaign=profiletracking&utm_medium=sssite&utm_source=ssslideshow">
<span class="j-username notranslate" data-ga-cat="bigfoot_slideview" data-ga-action="favoriteuserlinkclick" itemprop="name">Pedro Teixeira</span>
<span class="bioStub notranslate small-text light-color-text">
<span class="j-favoriter-role">
,
<span>Partner</span>
</span>
<span class="j-favoriter-org">
at
<span>INNVENT</span>
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
</ul>
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
4,117
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
12
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
52
</div>
<div class="small-8 columns stat-label">Comments</div>
<div class="small-4 columns stat-value text-right">
0
</div>
<div class="small-8 columns stat-label">Likes</div>
<div class="small-4 columns stat-value text-right">
3
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
<a class="action-flag" rel="nofollow" href="/signup?login_source=slideview.popup.flags&amp;from=flagss&amp;from_source=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard">
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
<li class="slide-note"></li>
<li class="slide-note"></li>
<li class="slide-note">I want to give some context about this project with a short story about hadoop and smartgrid dataThen I want to look deeper into how time series indexing works with iSAXAt the end, I’ll bring it all together with Lumberyard and how we might use it</li>
<li class="slide-note"></li>
<li class="slide-note"></li>
<li class="slide-note">Let’s set the stage in the context of story, why we were looking at big data for time series.</li>
<li class="slide-note">Ok, so how did we get to this point?Older SCADA systems take 1 data point per 2-4 seconds --- PMUs --- 30 times a sec, 120 PMUs, Growing by 10x factor</li>
<li class="slide-note"></li>
<li class="slide-note">So, I don’t have a smartgrid, how does this apply to me?</li>
<li class="slide-note">Ben Black wasn’t kidding when he said time series was growing fast</li>
<li class="slide-note"></li>
<li class="slide-note">Stealing line from Omer’s Hbasedeck ---- now recap the story we’ve told, and tease into “SAX”</li>
<li class="slide-note">Ok, so we’ve set the stage as to why time series data at scale is interesting to meNow let’s talk about some ways to deal with time series data with SAX and iSAX</li>
<li class="slide-note">Whats interesting about symbolic reps?Hashing Suffix Trees Markov Models Stealing ideas from text processing/ bioinformatics communityIt allows us to get a better “handle” on time series dataSince time series data can be very unwieldy in its “natural habitat”So, SAX? Whats interesting about that? What is it?While there are more than 200 different symbolic or discrete ways to approximate time series, none except SAX allows lower boundingLower bounding means the estimated distance in the reduced space is always less than or equal to the distance in the original space.</li>
<li class="slide-note">Dimensionality in this context means: “number of letters or numbers in the sequence ( {1, 2, 3, 4 } vs { 1.5, 3.5 } )Example: cardinality 2 == { a, b }</li>
<li class="slide-note"></li>
<li class="slide-note"></li>
<li class="slide-note">We make two parameter choices:“word size”, which is number of letters in the SAX “word”“alphabet size” which is the number of letters we use, or cardinality</li>
<li class="slide-note">iSAX offers a bit aware, quantitized, reduced representation with variable granularityWe could potentially have to search through up to 20% of the data in a single file due to data skew, and/or deal with empty files- If we have to look at 20% of the data in a lot of queries, we can be at most 5 times faster than complete sequential scan!</li>
<li class="slide-note">iSAX was developed for indexing SAXallows for a multi resolution representation similar to extensible hashing very fast approximate search</li>
<li class="slide-note">A “word” in this context means the letters or symbols representing a time series in SAX / iSAX formKey concepts (comparison of different cardinalities, mixed cardinalities inside a word)Now each symbol can have its own cardinalityWith iSAX, instead of letters we use numbers, and sometimes we use the bit representation of the numbersBit representations? What?When we increase the resolution we add bits to that dimension, or symbol of the wordIndividual symbol promotion is a key part of iSAX and directly supports the dynamic cardinality property</li>
<li class="slide-note">If we want to compare twoisax words of differing card, we have to promote the lesser to the higher cardComparison here means a measure of similarity, a distance functionHow do we promote cardinality? Remember the part about bit representation?If the firsts bits of S form a prefix, we use the rest of the bits of TIf the first bits of S for that position is less than T, we use ‘1’ for the rest of the positionsIf the first bits of S for that position are greater than T, we use ‘0’ for the rest…</li>
<li class="slide-note">Becomes a parent/internal nodeNow has two child nodesAll nodes in old leaf node are re-hashed into 1 of the 2 new child nodesBlock2:At each node as it traverses the treeIs converted to a iSAX word based on the params of that nodeBlock3:Index grows more “bushy” as more items insertedOur hashes actually gain “resolution” with more informationThis property allows us to continually subdivide the search space</li>
<li class="slide-note">Again, takes inspiration from btrees and extensible hashingThe framework converts each time series into an iSAX word before it inserts or searchesIndex is constructed with Given base card: bWord len: wThreshold: thIndex hierarchically subdivides the SAX space, dividing regions further as we insert more itemsNotice the dimensions being split (on individual symbols in the “words”) as we move down the treeIf you’ll notice, we can see the split mechanics illustrated near the bottom</li>
<li class="slide-note">Whats perfect accuracy worth to you?</li>
<li class="slide-note"></li>
<li class="slide-note">Sparky was a nice experiment, so I knew this Hbase stuff was good</li>
<li class="slide-note"></li>
<li class="slide-note">Contributions of this project are twofoldImplementation of the iSAX indexing algorithms in jmotifAddition of Hbase as the backend to iSAX indexes and jmotif</li>
<li class="slide-note">So you are saying “that’s great, but I don’t happen to have a smart grid at home…”</li>
<li class="slide-note"></li>
<li class="slide-note">Mention GE and Turbine data</li>
<li class="slide-note">On Monday Steve from google talked about working with genomic data --- genomic data is time seriesOur take home demo actually works with a small bit of genomic dataLots of chatter @ oscon about genomics, I just sat in one today</li>
<li class="slide-note">Find outline of image (can be tricky, can be done)Convery shape to 1d signal, time series formIndex with saxUse various string based tools now</li>
</div>
</div>
</div>
<div class="notranslate transcript add-padding-right j-transcript">
<h3 class="transcript-header">
<i class="fa fa-file-o"></i>
OSCON Data 2011 - Lumberyard
</h3>
<ol class="j-transcripts transcripts no-bullet no-style" itemprop="text">
<li>
1.
LumberyardTime Series Indexing At Scale&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-2-728.jpg?cb=1317303673" title="Today’s speaker – Josh Patterson&lt;br /&gt;josh@cloudera.com&lt;br ..." target="_blank">
2.
</a>
Today’s speaker – Josh Patterson&lt;br /&gt;josh@cloudera.com&lt;br /&gt;Master’s Thesis: self-organizing mesh networks&lt;br /&gt;Published in IAAI-09: TinyTermite: A Secure Routing Algorithm&lt;br /&gt;Conceived, built, and led Hadoop integration for the openPDC project at TVA&lt;br /&gt;Led small team which designed classification techniques for timeseries and Map Reduce&lt;br /&gt;Open source work at http://openpdc.codeplex.com&lt;br /&gt;Now: Sr. Solutions Architect at Cloudera&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;2&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-3-728.jpg?cb=1317303673" title="Agenda&lt;br /&gt;What is Lumberyard?&lt;br /&gt;A Short History of How..." target="_blank">
3.
</a>
Agenda&lt;br /&gt;What is Lumberyard?&lt;br /&gt;A Short History of How We Got Here&lt;br /&gt;iSAX and Time series Data&lt;br /&gt;Use Cases and Applications&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-4-728.jpg?cb=1317303673" title="What is Lumberyard?&lt;br /&gt;Lumberyard is time series iSAX ind..." target="_blank">
4.
</a>
What is Lumberyard?&lt;br /&gt;Lumberyard is time series iSAX indexing stored in HBase for persistent and scalable index storage&lt;br /&gt;It’s interesting for&lt;br /&gt;Indexing large amounts of time series data&lt;br /&gt;Low latency fuzzy pattern matching queries on time series data&lt;br /&gt;Lumberyard is open source and ASF 2.0 Licensed at Github:&lt;br /&gt;https://github.com/jpatanooga/Lumberyard/&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-5-728.jpg?cb=1317303673" title="A Short History of How We Got Here&lt;br /&gt;Copyright 2011 Clou..." target="_blank">
5.
</a>
A Short History of How We Got Here&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-6-728.jpg?cb=1317303673" title="NERC Sensor Data Collection&lt;br /&gt;openPDC PMU Data Collectio..." target="_blank">
6.
</a>
NERC Sensor Data Collection&lt;br /&gt;openPDC PMU Data Collection circa 2009 &lt;br /&gt;&lt;ul&gt;&lt;li&gt;120 Sensors
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-7-728.jpg?cb=1317303673" title="30 samples/second" target="_blank">
7.
</a>
30 samples/second
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-8-728.jpg?cb=1317303673" title="4.3B Samples/day" target="_blank">
8.
</a>
4.3B Samples/day
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-9-728.jpg?cb=1317303673" title="Housed in Hadoop&lt;/li&gt;&lt;/li&gt;&lt;/ul&gt;&lt;li&gt;Story Time: Keogh, SAX, ..." target="_blank">
9.
</a>
Housed in Hadoop&lt;/li&gt;&lt;/li&gt;&lt;/ul&gt;&lt;li&gt;Story Time: Keogh, SAX, and the openPDC&lt;br /&gt;NERC wanted high res smart grid data tracked&lt;br /&gt;Started openPDC project @ TVA&lt;br /&gt;http://openpdc.codeplex.com/&lt;br /&gt;We used Hadoop to store and process time series data&lt;br /&gt;https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/&lt;br /&gt;Needed to find “unbounded oscillations”&lt;br /&gt;Time series unwieldy to work with at scale&lt;br /&gt;We found “SAX” by Keogh and his folksfor dealing with time series&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-10-728.jpg?cb=1317303673" title="What is time series data?&lt;br /&gt;Time series data is defined ..." target="_blank">
10.
</a>
What is time series data?&lt;br /&gt;Time series data is defined as a sequence of data points measured typically at successive times spaced at uniform time intervals &lt;br /&gt;Examples in finance&lt;br /&gt;daily adjusted close price of a stock at the NYSE &lt;br /&gt;Example in Sensors / Signal Processing / Smart Grid&lt;br /&gt;sensor readings on a power grid occurring 30 times a second.&lt;br /&gt;For more reference on time series data&lt;br /&gt;http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/&lt;br /&gt;Copyright 2010 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-11-728.jpg?cb=1317303673" title="Why Hadoop is Great for the OpenPDC&lt;br /&gt;Scenario&lt;br /&gt;1 mi..." target="_blank">
11.
</a>
Why Hadoop is Great for the OpenPDC&lt;br /&gt;Scenario&lt;br /&gt;1 million sensors, collecting sample / 5 min&lt;br /&gt;5 year retention policy&lt;br /&gt;Storage needs of 15 TB&lt;br /&gt;Processing&lt;br /&gt;Single Machine: 15TB takes 2.2 DAYS to scan&lt;br /&gt;Hadoop @ 20 nodes: Same task takes 11 Minutes&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-12-728.jpg?cb=1317303673" title="Unstructured Data Explosion&lt;br /&gt;Copyright 2011 Cloudera In..." target="_blank">
12.
</a>
Unstructured Data Explosion&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;(you)&lt;br /&gt;Complex, Unstructured&lt;br /&gt;Relational&lt;br /&gt;&lt;ul&gt;&lt;li&gt; 2,500 exabytes of new information in 2012 with Internet as primary driver
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-13-728.jpg?cb=1317303673" title=" Digital universe grew by 62% last year to 800K petabytes a..." target="_blank">
13.
</a>
Digital universe grew by 62% last year to 800K petabytes and will grow to 1.2 “zettabytes” this year&lt;/li&gt;&lt;/li&gt;&lt;/ul&gt;&lt;li&gt;Apache Hadoop&lt;br /&gt;Open Source Distributed Storage and Processing Engine&lt;br /&gt;&lt;ul&gt;&lt;li&gt;Consolidates Mixed Data
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-14-728.jpg?cb=1317303673" title=" Move complex and relational data into a single repository" target="_blank">
14.
</a>
Move complex and relational data into a single repository
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-15-728.jpg?cb=1317303673" title="Stores Inexpensively" target="_blank">
15.
</a>
Stores Inexpensively
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-16-728.jpg?cb=1317303673" title=" Keep raw data always available" target="_blank">
16.
</a>
Keep raw data always available
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-17-728.jpg?cb=1317303673" title=" Use industry standard hardware" target="_blank">
17.
</a>
Use industry standard hardware
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-18-728.jpg?cb=1317303673" title="Processes at the Source" target="_blank">
18.
</a>
Processes at the Source
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-19-728.jpg?cb=1317303673" title=" Eliminate ETL bottlenecks" target="_blank">
19.
</a>
Eliminate ETL bottlenecks
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-20-728.jpg?cb=1317303673" title=" Mine data first, govern later &lt;/li&gt;&lt;/ul&gt;MapReduce&lt;br /&gt;Had..." target="_blank">
20.
</a>
Mine data first, govern later &lt;/li&gt;&lt;/ul&gt;MapReduce&lt;br /&gt;Hadoop Distributed File System (HDFS)&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-21-728.jpg?cb=1317303673" title="What about this HBase stuff?&lt;br /&gt;In the beginning, there w..." target="_blank">
21.
</a>
What about this HBase stuff?&lt;br /&gt;In the beginning, there was the GFS and theMapReduce&lt;br /&gt;And it was Good&lt;br /&gt;(Then they realized they needed low latency stuff)&lt;br /&gt;And thus BigTable was born, which begat…&lt;br /&gt;HBase: BigTable-like storage for Hadoop&lt;br /&gt;Open source&lt;br /&gt;Distributed&lt;br /&gt;Versioned&lt;br /&gt;Column-family oriented&lt;br /&gt;HBase leverages HDFS as BigTable leveraged GFS&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-22-728.jpg?cb=1317303673" title="iSAX and Time Series Data&lt;br /&gt;Copyright 2011 Cloudera Inc...." target="_blank">
22.
</a>
iSAX and Time Series Data&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-23-728.jpg?cb=1317303673" title="What is SAX?&lt;br /&gt;Symbolic Aggregate ApproXimation&lt;br /&gt;In ..." target="_blank">
23.
</a>
What is SAX?&lt;br /&gt;Symbolic Aggregate ApproXimation&lt;br /&gt;In this case, not XML.&lt;br /&gt;A symbolic representation of times series with some unique properties&lt;br /&gt;&lt;ul&gt;&lt;li&gt;Essentially a low pass filter
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-24-728.jpg?cb=1317303673" title="Lower bounding of Euclidean distance" target="_blank">
24.
</a>
Lower bounding of Euclidean distance
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-25-728.jpg?cb=1317303673" title="Lower bounding of the DTW distance" target="_blank">
25.
</a>
Lower bounding of the DTW distance
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-26-728.jpg?cb=1317303673" title="Dimensionality Reduction" target="_blank">
26.
</a>
Dimensionality Reduction
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-27-728.jpg?cb=1317303673" title="Numerosity Reduction &lt;/li&gt;&lt;/ul&gt;Copyright 2010 Cloudera Inc...." target="_blank">
27.
</a>
Numerosity Reduction &lt;/li&gt;&lt;/ul&gt;Copyright 2010 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-28-728.jpg?cb=1317303673" title="SAX in 60 Seconds&lt;br /&gt;Take time series T&lt;br /&gt;Convert to P..." target="_blank">
28.
</a>
SAX in 60 Seconds&lt;br /&gt;Take time series T&lt;br /&gt;Convert to Piecewise Aggregate Approximation (PAA)&lt;br /&gt;Reduces dimensionality of time series T&lt;br /&gt;Then Take PAA representation of T and discretize it into a small alphabet of symbols&lt;br /&gt;Symbols have a cardinality of a, or “number of values they could possibly represent”. &lt;br /&gt;We discretize by taking each PAA symbol and finding which horizontally predefined breakpoint the value falls in&lt;br /&gt;This gives us the SAX letter&lt;br /&gt;This complete process converts a time series T into a “SAX word”&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-29-728.jpg?cb=1317303673" title="Why? Time Series Data is “Fuzzy”&lt;br /&gt;Copyright 2011 Cloude..." target="_blank">
29.
</a>
Why? Time Series Data is “Fuzzy”&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-30-728.jpg?cb=1317303673" title="Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;SAX: ..." target="_blank">
30.
</a>
Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;SAX: Fuzzy Things Become More Discrete&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-31-728.jpg?cb=1317303673" title="How does SAX work?&lt;br /&gt;Copyright 2011 Cloudera Inc. All ri..." target="_blank">
31.
</a>
How does SAX work?&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;1.5&lt;br /&gt;1.5&lt;br /&gt;1&lt;br /&gt;1&lt;br /&gt;0.5&lt;br /&gt;0.5&lt;br /&gt;First convert the time series to PAA representation&lt;br /&gt;Then convert the PAA to symbols to SAX letters:&lt;br /&gt;baabccbc&lt;br /&gt;0&lt;br /&gt;0&lt;br /&gt;-&lt;br /&gt;0.5&lt;br /&gt;-&lt;br /&gt;0.5&lt;br /&gt;-&lt;br /&gt;1&lt;br /&gt;-&lt;br /&gt;1&lt;br /&gt;-&lt;br /&gt;1.5&lt;br /&gt;-&lt;br /&gt;1.5&lt;br /&gt;0&lt;br /&gt;0&lt;br /&gt;40&lt;br /&gt;60&lt;br /&gt;80&lt;br /&gt;100&lt;br /&gt;120&lt;br /&gt;0&lt;br /&gt;0&lt;br /&gt;40&lt;br /&gt;60&lt;br /&gt;80&lt;br /&gt;100&lt;br /&gt;120&lt;br /&gt;20&lt;br /&gt;20&lt;br /&gt;c&lt;br /&gt;c&lt;br /&gt;c&lt;br /&gt;b&lt;br /&gt;b&lt;br /&gt;b&lt;br /&gt;a&lt;br /&gt;(It takes linear time)&lt;br /&gt;a&lt;br /&gt;Slide Inspired by: http://www.cs.ucr.edu/~eamonn/SIGKDD_2007.ppt&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-32-728.jpg?cb=1317303673" title="SAX and the Potential for Indexing&lt;br /&gt;The classic SAX rep..." target="_blank">
32.
</a>
SAX and the Potential for Indexing&lt;br /&gt;The classic SAX representation offers the potential to be indexed&lt;br /&gt;If we choose a fixed cardinality of 8, a word length of 4, we end up with 84 (4,096) possible buckets to put time series in&lt;br /&gt;We could convert a query sequence into a SAX word, and check that “bucket” represented by that word for approximate search as the entries in that bucket are likely very good&lt;br /&gt;Exact search would require looking through multiple buckets using lower bounding&lt;br /&gt;Data skew presents a problem here&lt;br /&gt;Lot’s of data in one bucket means lots of scanning!&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-33-728.jpg?cb=1317303673" title="iSAX&lt;br /&gt;iSAX: indexableSymbolic Aggregate approXimation&lt;b..." target="_blank">
33.
</a>
iSAX&lt;br /&gt;iSAX: indexableSymbolic Aggregate approXimation&lt;br /&gt;Modifies SAX to allow “extensible hashing” and a multi-resolution representation&lt;br /&gt;Allows for both fast exact search&lt;br /&gt;And ultra fast approximate search&lt;br /&gt;Multi-resolution property allows us to index time series with zero overlap at leaf nodes&lt;br /&gt;Unlike R-trees and other spatial access methods&lt;br /&gt;Copyright 2010 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-34-728.jpg?cb=1317303673" title="iSAX Word Properties&lt;br /&gt;Key concepts&lt;br /&gt;We can compare ..." target="_blank">
34.
</a>
iSAX Word Properties&lt;br /&gt;Key concepts&lt;br /&gt;We can compare iSAX words of different cardinalities&lt;br /&gt;We can mix cardinalities per symbol in an iSAX word&lt;br /&gt;To compare two iSAX words of differing cardinalities&lt;br /&gt;We represent each symbol as the bits of its integer&lt;br /&gt;Examples&lt;br /&gt;Cardinality == 4, “1” as 01, “2” as 10 (4 characters, 0-3 integers)&lt;br /&gt;Cardinality == 8, “1” as 001, “2” as 010&lt;br /&gt;The trick is, when we “promote” a symbol to a higher cardinality, we add bits to its representation&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;iSAX Symbol&lt;br /&gt;{ 48 , 34 , 34 ,24 }&lt;br /&gt;{ 100, 11, 11, 10 }&lt;br /&gt;iSAX word:&lt;br /&gt;iSAX word in binary:&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-35-728.jpg?cb=1317303673" title="iSAX Dynamic Cardinality&lt;br /&gt;Copyright 2011 Cloudera Inc. ..." target="_blank">
35.
</a>
iSAX Dynamic Cardinality&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;T = time series 1&lt;br /&gt;S = time series 2&lt;br /&gt;(Sfully promoted)&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-36-728.jpg?cb=1317303673" title="How Does iSAX Indexing Work?&lt;br /&gt;Similar to a b-tree&lt;br /&gt;..." target="_blank">
36.
</a>
How Does iSAX Indexing Work?&lt;br /&gt;Similar to a b-tree&lt;br /&gt;Nodes represents iSAX words&lt;br /&gt;Has internal nodes and leaf nodes&lt;br /&gt;Leaf nodes fill up with items to a threshold&lt;br /&gt;Once full, a leaf node “splits”&lt;br /&gt;Each time series sequence to be inserted is converted to a iSAX word&lt;br /&gt;As we drop down levels in the tree with iSAX-”rehashes”&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-37-728.jpg?cb=1317303673" title="iSAX Indexing, Inserting, and Searching&lt;br /&gt;Copyright 2011..." target="_blank">
37.
</a>
iSAX Indexing, Inserting, and Searching&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;{ 24 , 34 , 34 ,24 }&lt;br /&gt;Split Mechanics&lt;br /&gt;&lt;ul&gt;&lt;li&gt; The value “2” at cardinality 4 is “10” in bits
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-38-728.jpg?cb=1317303673" title=" If we split this dimension, we add a bit" target="_blank">
38.
</a>
If we split this dimension, we add a bit
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-39-728.jpg?cb=1317303673" title=" “10” becomes “100” (4) and “101” (5)" target="_blank">
39.
</a>
“10” becomes “100” (4) and “101” (5)
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-40-728.jpg?cb=1317303673" title=" we’re now at cardinality of 8 &lt;/li&gt;&lt;/ul&gt;{ 48 , 34 , 34 ,24..." target="_blank">
40.
</a>
we’re now at cardinality of 8 &lt;/li&gt;&lt;/ul&gt;{ 48 , 34 , 34 ,24 }&lt;br /&gt;{ 58 , 34 , 34 ,24 }&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-41-728.jpg?cb=1317303673" title="Some Quick Numbers From the iSAX Paper&lt;br /&gt;100 million sam..." target="_blank">
41.
</a>
Some Quick Numbers From the iSAX Paper&lt;br /&gt;100 million samples indexed, ½ TB of time series data&lt;br /&gt;Times&lt;br /&gt;linear scan: 1800 minutes&lt;br /&gt;exact iSAX search 90 minutes&lt;br /&gt;ApproxiSAXsearch: 1.1 sec&lt;br /&gt;Quality of results&lt;br /&gt;avgrank of NN: 8th&lt;br /&gt;The bottom line&lt;br /&gt;we only have to look @ 0.001% of the data&lt;br /&gt;To find a great quality result in the top .0001% (NN)&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-42-728.jpg?cb=1317303673" title="SAX, iSAX, and jmotif&lt;br /&gt;Both SAX and iSAX are implemente..." target="_blank">
42.
</a>
SAX, iSAX, and jmotif&lt;br /&gt;Both SAX and iSAX are implemented in the jmotif project&lt;br /&gt;SeninPavel did the original SAX implementation&lt;br /&gt;Josh Patterson added the iSAX implementation&lt;br /&gt;(Exact search currently is not complete in iSAX)&lt;br /&gt;Check it out for yourself&lt;br /&gt;http://code.google.com/p/jmotif/&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-43-728.jpg?cb=1317303673" title="What if our Data was … Large?&lt;br /&gt;And we indexed … a lot o..." target="_blank">
43.
</a>
What if our Data was … Large?&lt;br /&gt;And we indexed … a lot of data&lt;br /&gt;(And the index got large?)&lt;br /&gt;iSAX Indexes actually store the sequence sample data&lt;br /&gt;This ends up taking potentially a lot of space&lt;br /&gt;NoSQL gets a bit interesting here&lt;br /&gt;Needed fast GETs and PUTs for index nodes&lt;br /&gt;HBase started to look attractive&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-44-728.jpg?cb=1317303673" title="HBase Strengths&lt;br /&gt;High write throughput&lt;br /&gt;Horizontal ..." target="_blank">
44.
</a>
HBase Strengths&lt;br /&gt;High write throughput&lt;br /&gt;Horizontal scalability&lt;br /&gt;Auto failover&lt;br /&gt;HDFS Benefits&lt;br /&gt;With denormalized design, we can lay in any arbitrary computation&lt;br /&gt;SQL is not Turing complete&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-45-728.jpg?cb=1317303673" title="Lumberyard: iSAX Indexing and HBase&lt;br /&gt;Jmotif implements ..." target="_blank">
45.
</a>
Lumberyard: iSAX Indexing and HBase&lt;br /&gt;Jmotif implements the core logic for iSAX&lt;br /&gt;Lumberyard takes this logic, and implements a storage backend&lt;br /&gt;We persist the nodes to rows in Hbase&lt;br /&gt;Our potential index size now scales up into the Terabytes&lt;br /&gt;We can now leverage Hbase’s properties in the storage tier&lt;br /&gt;Queries scan a few rows for approximate search&lt;br /&gt;An ancestor project to Lumberyard was called “Sparky”&lt;br /&gt;Indexed on content of files in HDFS (sensor / time range)&lt;br /&gt;https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/Sparky/&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-46-728.jpg?cb=1317303673" title="Use Cases and Applications&lt;br /&gt;Copyright 2011 Cloudera Inc..." target="_blank">
46.
</a>
Use Cases and Applications&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-47-728.jpg?cb=1317303673" title="How You Would Use iSAX and Lumberyard&lt;br /&gt;For fast fuzzy q..." target="_blank">
47.
</a>
How You Would Use iSAX and Lumberyard&lt;br /&gt;For fast fuzzy query lookups that don’t need a perfect best match&lt;br /&gt;Just a really good match (fast)&lt;br /&gt;(We’ll fix that exact search thing soon. Promise.)&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-48-728.jpg?cb=1317303673" title="Sensor Data and the openPDC&lt;br /&gt;Needed to find “unbounded ..." target="_blank">
48.
</a>
Sensor Data and the openPDC&lt;br /&gt;Needed to find “unbounded oscillations” in PMU (Smartgrid) Data&lt;br /&gt;TB’s of data stored in Hadoop&lt;br /&gt;MapReduce has an interesting property:&lt;br /&gt;Sorts numbers really fast via the “shuffle” process&lt;br /&gt;Also: my data was not sorted&lt;br /&gt;Check out the project&lt;br /&gt;http://openpdc.codeplex.com/&lt;br /&gt;https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/&lt;br /&gt;We used SAX and a spatial tree to create a 1NN classifier to detect signal patterns&lt;br /&gt;iSAX and Lumberyard allow for faster lookups&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-49-728.jpg?cb=1317303673" title="Genome Data as Time Series&lt;br /&gt;A, C, G, and T&lt;br /&gt;Could b..." target="_blank">
49.
</a>
Genome Data as Time Series&lt;br /&gt;A, C, G, and T&lt;br /&gt;Could be thought of as “1, 2, 3, and 4”!&lt;br /&gt;If we have sequence X, what is the “closest” subsequence in a genome that is most like it?&lt;br /&gt;Doesn’t have to be an exact match!&lt;br /&gt;Useful in proteomics as well&lt;br /&gt;1.5&lt;br /&gt;1.5&lt;br /&gt;A&lt;br /&gt;1&lt;br /&gt;1&lt;br /&gt;C&lt;br /&gt;0.5&lt;br /&gt;0.5&lt;br /&gt;G&lt;br /&gt;0&lt;br /&gt;0&lt;br /&gt;-&lt;br /&gt;0.5&lt;br /&gt;-&lt;br /&gt;0.5&lt;br /&gt;T&lt;br /&gt;-&lt;br /&gt;1&lt;br /&gt;-&lt;br /&gt;1&lt;br /&gt;-&lt;br /&gt;1.5&lt;br /&gt;-&lt;br /&gt;1.5&lt;br /&gt;0&lt;br /&gt;0&lt;br /&gt;40&lt;br /&gt;60&lt;br /&gt;80&lt;br /&gt;100&lt;br /&gt;120&lt;br /&gt;20&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-50-728.jpg?cb=1317303673" title="Images…as Time Series?&lt;br /&gt;Convert shapes to 1D signals&lt;br..." target="_blank">
50.
</a>
Images…as Time Series?&lt;br /&gt;Convert shapes to 1D signals&lt;br /&gt;Rotation and scale invariant&lt;br /&gt;We deal with rotation in algo&lt;br /&gt;0&lt;br /&gt;200&lt;br /&gt;400&lt;br /&gt;600&lt;br /&gt;800&lt;br /&gt;1000&lt;br /&gt;1200&lt;br /&gt;Slide Inspired by: http://www.cs.ucr.edu/~eamonn/SIGKDD_2007.ppt&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-51-728.jpg?cb=1317303673" title="Other fun Ideas&lt;br /&gt;Use Flumebase and Lumberyard together&lt;..." target="_blank">
51.
</a>
Other fun Ideas&lt;br /&gt;Use Flumebase and Lumberyard together&lt;br /&gt;http://www.flumebase.org/&lt;br /&gt;Could provide different query mechanics&lt;br /&gt;Use OpenTSDB with Lumberyard&lt;br /&gt;OpenTSB for raw data: http://opentsdb.net/&lt;br /&gt;Lumberyard for fuzzy pattern matching&lt;br /&gt;Image Pattern Matching&lt;br /&gt;Imaging could be interesting. Someone needs to write the plugin. (Contact me if interested).&lt;br /&gt;Use Lumberyard as a 1NN Classifier&lt;br /&gt;Check out “Fast time series classification using numerosity reduction” [4]&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-52-728.jpg?cb=1317303673" title="Areas to Improve&lt;br /&gt;SerDe mechanics&lt;br /&gt;Finish &lt;br /&gt;kNN..." target="_blank">
52.
</a>
Areas to Improve&lt;br /&gt;SerDe mechanics&lt;br /&gt;Finish &lt;br /&gt;kNN Search&lt;br /&gt;Exact Search&lt;br /&gt;MapReduce parallel Index construction&lt;br /&gt;Lots more testing&lt;br /&gt;More plugins to decompose data into time series form&lt;br /&gt;Image plugin would be interesting&lt;br /&gt;Performance&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-53-728.jpg?cb=1317303673" title="Try it Yourself at Home&lt;br /&gt;Download Lumberyard from githu..." target="_blank">
53.
</a>
Try it Yourself at Home&lt;br /&gt;Download Lumberyard from github&lt;br /&gt;https://github.com/jpatanooga/Lumberyard&lt;br /&gt;Build and Install on Single Machine&lt;br /&gt;Build with Ant&lt;br /&gt;Setup a few dependencies (Hadoop, Hbase, jmotif)&lt;br /&gt;Run genomic example: “Genome Data as Time Series”&lt;br /&gt;Search for patterns in some sample genome data&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-54-728.jpg?cb=1317303673" title="Lumberyard Summary&lt;br /&gt;Low latency queries &lt;br /&gt;on a lot ..." target="_blank">
54.
</a>
Lumberyard Summary&lt;br /&gt;Low latency queries &lt;br /&gt;on a lot of time series data&lt;br /&gt;Experimental, yet has some interesting applications&lt;br /&gt;Backed by HBase&lt;br /&gt;Open source ASF 2.0 Licensed&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-55-728.jpg?cb=1317303673" title="(Thank you for your time)&lt;br /&gt;Questions?&lt;br /&gt;Copyright 20..." target="_blank">
55.
</a>
(Thank you for your time)&lt;br /&gt;Questions?&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-56-728.jpg?cb=1317303673" title="Appendix A: Resources&lt;br /&gt;Copyright 2011 Cloudera Inc. All..." target="_blank">
56.
</a>
Appendix A: Resources&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;&lt;ul&gt;&lt;li&gt;Lumberyard
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-57-728.jpg?cb=1317303673" title="https://github.com/jpatanooga" target="_blank">
57.
</a>
https://github.com/jpatanooga
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-58-728.jpg?cb=1317303673" title="Cloudera" target="_blank">
58.
</a>
Cloudera
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-59-728.jpg?cb=1317303673" title="http://www.cloudera.com/blog" target="_blank">
59.
</a>
http://www.cloudera.com/blog
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-60-728.jpg?cb=1317303673" title="http://wiki.cloudera.com/" target="_blank">
60.
</a>
http://wiki.cloudera.com/
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-61-728.jpg?cb=1317303673" title="http://www.cloudera.com/blog/2011/03/simple-moving-average-..." target="_blank">
61.
</a>
http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/&lt;/li&gt;&lt;/ul&gt;Hadoop&lt;br /&gt;http://hadoop.apache.org/&lt;br /&gt;HBase&lt;br /&gt;http://hbase.apache.org/&lt;br /&gt;SAX &lt;br /&gt;Homepage&lt;br /&gt;http://www.cs.ucr.edu/~eamonn/SAX.htm&lt;br /&gt;Presentation&lt;br /&gt;http://www.cs.ucr.edu/~eamonn/SIGKDD_2007.ppt&lt;br /&gt;OpenPDC&lt;br /&gt;http://openpdc.codeplex.com/&lt;br /&gt;https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/&lt;br /&gt;The jmotif project provides some support classes for Lumberyard: &lt;br /&gt;http://code.google.com/p/jmotif/&lt;br /&gt;
</li>
<li>
<a href="http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-62-728.jpg?cb=1317303673" title="References&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights res..." target="_blank">
62.
</a>
References&lt;br /&gt;Copyright 2011 Cloudera Inc. All rights reserved&lt;br /&gt;SAX&lt;br /&gt;http://www.cs.ucr.edu/~eamonn/SAX.htm&lt;br /&gt;iSAX&lt;br /&gt;http://www.cs.ucr.edu/~eamonn/iSAX.pdf&lt;br /&gt;OpenPDC&lt;br /&gt;&lt;ul&gt;&lt;li&gt;http://openpdc.codeplex.com/&lt;/li&gt;&lt;/ul&gt;Xiaopeng Xi , Eamonn Keogh , Christian Shelton , Li Wei , Chotirat Ann Ratanamahatana, Fast time series classification using numerosity reduction, Proceedings of the 23rd international conference on Machine learning, p.1033-1040, June 25-29, 2006, Pittsburgh, Pennsylvania&lt;br /&gt;
</li>
</ol>
</div>
</div>
</div>
<aside id="side-panel" class="small-12 large-4 columns j-related-more-tab">
<ul class="lynda-list-above">
<header class="lynda-above-header">Learn more from world-class experts</header>
<li class="lynda-item  lynda-above">
<a data-ssid="9476155" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="153775" data-ssrank="0" data-designkey="a2" data-lynda-type="1" data-algorithm-id="110" data-source-model="110" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="top_visible" class="j-lynda-impression j-recommendation-tracking" title="Excel Data Analysis: Forecasting" href=http://www.lynda.com/Excel-tutorials/Excel-Data-Analysis-Forecasting/153775-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard&amp;utm_campaign=9476155_a2_153775&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Excel Data Analysis: Forecasting" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/153775-635455167990829911_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Excel Data Analysis: Forecasting
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
<li class="lynda-item  lynda-above">
<a data-ssid="9476155" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="116478" data-ssrank="1" data-designkey="a2" data-lynda-type="1" data-algorithm-id="110" data-source-model="110" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="top_visible" class="j-lynda-impression j-recommendation-tracking" title="Excel 2013 Essential Training" href=http://www.lynda.com/Excel-tutorials/Excel-2013-Essential-Training/116478-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard&amp;utm_campaign=9476155_a2_116478&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Excel 2013 Essential Training" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/116478-635455478253919432_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Excel 2013 Essential Training
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
<li class="lynda-item  lynda-above">
<a data-ssid="9476155" data-source-name="LYNDA_RECOMMENDER" data-lynda-id="114891" data-ssrank="2" data-designkey="a2" data-lynda-type="1" data-algorithm-id="110" data-source-model="110" data-language="" data-course-type="" data-urn-type="LyndaCourse" data-recommendation-group="top_visible" class="j-lynda-impression j-recommendation-tracking" title="Excel 2013: Pivot Tables in Depth" href=http://www.lynda.com/Excel-tutorials/Excel-2013-Pivot-Tables-Depth/114891-2.html?CID=l0%3Aen%3Aip%3Ase%3Aprosb%3As0%3A0%3Aall%3Aslideshare&amp;returnUrl=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard&amp;utm_campaign=9476155_a2_114891&amp;utm_medium=integrated-partnership&amp;utm_source=slideshare target="_blank">
<div class="lynda-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Excel 2013: Pivot Tables in Depth" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="https://cdn.lynda.com/courses/114891_88x158_thumb.jpg"/>
<div class="lynda-play-icon-overlay"></div>
</div>
<div class="lynda-content">
<div class="title">
Excel 2013: Pivot Tables in Depth
</div>
<div class="lynda-video-text"><strong class="copy-in-aria-label" aria-label="lynda"></strong><span class="copy-in-aria-label" aria-label=".com"></span> <strong class="all-caps copy-in-aria-label" aria-label="PREMIUM VIDEO"></strong></div>
</div>
</a>
</li>
</ul>
<dl class="tabs related-tabs small" data-tab>
<dd class="active"><a href="#related-tab-content" data-ga-cat="bigfoot_slideview" data-ga-action="relatedslideshows_tab">Recommended</a></dd>
<dd class="j-more-tab " data-ga-cat="bigfoot_slideview" data-ga-action="morebyuser_tab"><a href="#more-tab-content">More from this author</a></dd>
</dl>
<div class="tabs-content">
<ul id="related-tab-content" class="content active no-bullet notranslate" ab_variant="none">
<li class="j-related-item">
<a data-ssid="5091794" data-ssrank="0" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Hadoop As The Platform For The Smartgrid At TVA" href="/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Hadoop As The Platform For The Smartgrid At TVA" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail-2.jpg?cb=1327341063"/>
</div>
<div class="related-content">
<div class="title">
Hadoop As The Platform For The Smartgrid At TVA
</div>
<div class="author">Cloudera, Inc.</div>
<div class="j-related-views view-count format-views" data-views="views">4,640
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="15075521" data-ssrank="1" data-algo-id="21" data-source-name="BROWSEMAP" data-source-model="21" data-urn-type="Slideshow" data-score="1" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Indexing and Mining a Billion Time series using iSAX 2.0" href="/vasujain/indexing-and-mining-a-billion-time-series-using-isax-20">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Indexing and Mining a Billion Time series using iSAX 2.0" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/jainvasupaperpptisax2-121107191852-phpapp01-thumbnail-2.jpg?cb=1352316162"/>
</div>
<div class="related-content">
<div class="title">
Indexing and Mining a Billion Time series using iSAX 2.0
</div>
<div class="author">Vasu Jain</div>
<div class="j-related-views view-count format-views" data-views="views">1,882
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="51819671" data-ssrank="2" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="How to Build Deep Learning Models" href="/jpatanooga/how-to-build-deep-learning-models">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="How to Build Deep Learning Models" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/dlsmartdataconf20150817v1-150819163526-lva1-app6892-thumbnail-2.jpg?cb=1440002225"/>
</div>
<div class="related-content">
<div class="title">
How to Build Deep Learning Models
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">143
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="51261756" data-ssrank="3" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Deep learning with DL4J - Hadoop Summit 2015" href="/jpatanooga/deep-learning-with-dl4j-hadoop-summit-2015">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Deep learning with DL4J - Hadoop Summit 2015" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/deeplearninghadoopsummuit2015final-150804131806-lva1-app6892-thumbnail-2.jpg?cb=1438694392"/>
</div>
<div class="related-content">
<div class="title">
Deep learning with DL4J - Hadoop Summit 2015
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">110
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="47823150" data-ssrank="4" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Enterprise Deep Learning with DL4J" href="/jpatanooga/deep-learning-gdsc20150502v4">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Enterprise Deep Learning with DL4J" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/deeplearninggdsc20150502v4-150506075556-conversion-gate02-thumbnail-2.jpg?cb=1430917063"/>
</div>
<div class="related-content">
<div class="title">
Enterprise Deep Learning with DL4J
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">126
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="46294347" data-ssrank="5" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Deep Learning Intro - Georgia Tech - CSE6242 - March 2015" href="/jpatanooga/deep-learning-intro-georgia-tech-cse6242-march-2015">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Deep Learning Intro - Georgia Tech - CSE6242 - March 2015" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/deeplearninggatech20150323v1-150325193858-conversion-gate01-thumbnail-2.jpg?cb=1427330419"/>
</div>
<div class="related-content">
<div class="title">
Deep Learning Intro - Georgia Tech - CSE6242 - March 2015
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">381
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="46294303" data-ssrank="6" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Vectorization - Georgia Tech - CSE6242 - March 2015" href="/jpatanooga/vectorization-georgia-tech-cse">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Vectorization - Georgia Tech - CSE6242 - March 2015" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/gatechvectorization20150323-150325193643-conversion-gate01-thumbnail-2.jpg?cb=1427312302"/>
</div>
<div class="related-content">
<div class="title">
Vectorization - Georgia Tech - CSE6242 - March 2015
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">246
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="41571755" data-ssrank="7" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Chattanooga Hadoop Meetup - Hadoop 101 - November 2014" href="/jpatanooga/chattanooga-hadoop-meetup-hadoop-101-november-2014">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Chattanooga Hadoop Meetup - Hadoop 101 - November 2014" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/chadoophadoop101v3-141114132448-conversion-gate01-thumbnail-2.jpg?cb=1415971587"/>
</div>
<div class="related-content">
<div class="title">
Chattanooga Hadoop Meetup - Hadoop 101 - November 2014
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">450
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="39160774" data-ssrank="8" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Georgia Tech cse6242 - Intro to Deep Learning and DL4J" href="/jpatanooga/georgia-tech-cse6242-intro-to-deep-learning">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Georgia Tech cse6242 - Intro to Deep Learning and DL4J" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/gatechcse6242deeplearningv2-140916135744-phpapp01-thumbnail-2.jpg?cb=1410875961"/>
</div>
<div class="related-content">
<div class="title">
Georgia Tech cse6242 - Intro to Deep Learning and DL4J
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">1,022
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="39160727" data-ssrank="9" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Intro to Vectorization Concepts - GaTech cse6242" href="/jpatanooga/intro-to-vectorization-concepts-gatech">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Intro to Vectorization Concepts - GaTech cse6242" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/vectorization20140915-140916135606-phpapp02-thumbnail-2.jpg?cb=1410875842"/>
</div>
<div class="related-content">
<div class="title">
Intro to Vectorization Concepts - GaTech cse6242
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">598
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="35534160" data-ssrank="10" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="Hadoop Summit 2014 - San Jose - Introduction to Deep Learning on Hadoop" href="/jpatanooga/hadoop-summit-2014-san-jose-introduction-to-deep-learning-on-hadoop">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="Hadoop Summit 2014 - San Jose - Introduction to Deep Learning on Hadoop" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/hadoopsummit2014deeplearningfinal-140605121612-phpapp01-thumbnail-2.jpg?cb=1401970831"/>
</div>
<div class="related-content">
<div class="title">
Hadoop Summit 2014 - San Jose - Introduction to Deep Learning on Hadoop
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">5,130
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="28336040" data-ssrank="11" data-algo-id="" data-source-name="MORE_FROM_USER" data-source-model="" data-urn-type="Slideshow" data-score="" data-recommendation-group="bottom_visible" class="j-related-impression slideview_related_item j-recommendation-tracking" title="MLConf 2013: Metronome and Parallel Iterative Algorithms on YARN" href="/jpatanooga/metronome-ml-confnov2013v20131113">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb" alt="MLConf 2013: Metronome and Parallel Iterative Algorithms on YARN" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="http://cdn.slidesharecdn.com/ss_thumbnails/metronomemlconfnov2013v20131113-131117095223-phpapp02-thumbnail-2.jpg?cb=1384682135"/>
</div>
<div class="related-content">
<div class="title">
MLConf 2013: Metronome and Parallel Iterative Algorithms on YARN
</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">1,574
</div>
</div>
</a>
</li>
</ul>
<ul id="more-tab-content" class="content no-bullet notranslate " ab_variant="none">
<li class="j-related-item">
<a data-ssid="17636499" data-urn-type="Slideshow" title="Hadoop Summit EU 2013: Parallel Linear Regression, IterativeReduce, and YARN" href="/jpatanooga/hadoop-summit-eu-2013-parallel-linear-regression-iterativereduce-and-yarn" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Hadoop Summit EU 2013: Parallel Linear Regression, IterativeReduce, and YARN" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/hadoopsummiteu201327022013final-130324085852-phpapp01-thumbnail-2.jpg?cb=1364123817"/>
</div>
<div class="related-content">
<div class="title">Hadoop Summit EU 2013: Parallel Linear Regression, IterativeReduce, and YARN</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">
4,827
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="16041109" data-urn-type="Slideshow" title="Knitting boar atl_hug_jan2013_v2" href="/jpatanooga/knitting-boar-atlhugjan2013v2" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Knitting boar atl_hug_jan2013_v2" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/knittingboaratlhugjan2013v2-130117091600-phpapp01-thumbnail-2.jpg?cb=1358414195"/>
</div>
<div class="related-content">
<div class="title">Knitting boar atl_hug_jan2013_v2</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">
471
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="15389420" data-urn-type="Slideshow" title="Knitting boar - Toronto and Boston HUGs - Nov 2012" href="/jpatanooga/knitting-boar-toronto-hug-nov-2012" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Knitting boar - Toronto and Boston HUGs - Nov 2012" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/knittingboarhugsnov2012v2-4-121128101840-phpapp01-thumbnail-2.jpg?cb=1354114554"/>
</div>
<div class="related-content">
<div class="title">Knitting boar - Toronto and Boston HUGs - Nov 2012</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">
643
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="10519349" data-urn-type="Slideshow" title="LA HUG Dec 2011 - Recommendation Talk" href="/jpatanooga/la-hug-dec-2011-recommendation-talk" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="LA HUG Dec 2011 - Recommendation Talk" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/lahugmahoutcdh3recommendation06122011v3-111208121128-phpapp01-thumbnail-2.jpg?cb=1323348966"/>
</div>
<div class="related-content">
<div class="title">LA HUG Dec 2011 - Recommendation Talk</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">
2,611
</div>
</div>
</a>
</li>
<li class="j-related-item">
<a data-ssid="9545161" data-urn-type="Slideshow" title="Oct 2011 CHADNUG Presentation on Hadoop" href="/jpatanooga/oct-2011-chadnug-presentation-on-hadoop" data-source-name="MORE_FROM_USER" data-source-model="" data-recommendation-group="bottom_hidden" class="j-recommendation-tracking">
<div class="related-thumbnail">
<img class="j-thumbnail j-lazy-thumb j-lazy-thumb-click" alt="Oct 2011 CHADNUG Presentation on Hadoop" src="//public.slidesharecdn.com/b/images/thumbnail.png" data-original="//cdn.slidesharecdn.com/ss_thumbnails/chadnug03102011v1-111004121455-phpapp01-thumbnail-2.jpg?cb=1317733709"/>
</div>
<div class="related-content">
<div class="title">Oct 2011 CHADNUG Presentation on Hadoop</div>
<div class="author">Josh Patterson</div>
<div class="j-related-views view-count format-views" data-views="views">
2,126
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
<a class="smt-link" href="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard?smtNoRedir=1" title="OSCON Data 2011 - Lumberyard - English" lang="en" hreflang="en">English
</a>
</li>
<li class="smt-item j-es">
<a class="smt-link" href="http://es.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="OSCON Data 2011 - Lumberyard - Espanol" lang="es" hreflang="es">Espanol
</a>
</li>
<li class="smt-item j-pt">
<a class="smt-link" href="http://pt.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="OSCON Data 2011 - Lumberyard - Portugues" lang="pt" hreflang="pt">Portugues
</a>
</li>
<li class="smt-item j-fr">
<a class="smt-link" href="http://fr.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="OSCON Data 2011 - Lumberyard - Fran&ccedil;ais" lang="fr" hreflang="fr">Fran&ccedil;ais
</a>
</li>
<li class="smt-item j-de">
<a class="smt-link" href="http://de.slideshare.net/jpatanooga/oscon-data-2011-lumberyard" title="OSCON Data 2011 - Lumberyard - Deutsche" lang="de" hreflang="de">Deutsche
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
<button class="art-deco small tertiary button continue-download" data-reveal-id="login_modal" href="/login?from_source=%2Fjpatanooga%2Foscon-data-2011-lumberyard%3Ffrom_action%3Dsave&amp;from=download&amp;layout=foundation">No thanks. Continue to download.</button>
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
<script>$(window).load(function(){loadCSS("//public.slidesharecdn.com/b/ss_foundation/stylesheets/app.css?fc6747b305eab4929e9de90ae2a363baeec71eca");});</script>
<script type="text/javascript">$.extend(slideshare_object,{"is_free_author":false,"version_no":"1317303673","facebook_app_id":"2490221586","asset_id":"fc6747b305eab4929e9de90ae2a363baeec71eca","li_bar":{"get_url":"/li_bar"},"show_branding":1,"analytics_api_enabled":true,"dev":false,"doc":"osconlumberyard20110518v8-110929133838-phpapp02","jsplayer":{"start_slide":1,"disable_share":false,"iframe_code":"\u003Ciframe src=\"{iframe_url}\" width=\"{width}\" height=\"{height}\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard\" title=\"OSCON Data 2011 - Lumberyard\" target=\"_blank\"\u003EOSCON Data 2011 - Lumberyard\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/jpatanooga\" target=\"_blank\"\u003EJosh Patterson\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","rel_slide_urls":[],"autoplayOnEmbed":false,"pin_image_url":"http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-728.jpg?cb=1317303673","bambooleaf_presentation":false,"container":"svPlayerId","slide_titles":[],"is_only_private":false,"fullscreen_url":"/fullscreen/jpatanooga/oscon-data-2011-lumberyard","video_slides_count":0,"render_links":"default","twitter_recommended_users":"@jpatanooga","embed_sizes":{"presets":{"preset4":{"displaySize":{"width":70,"height":53},"size":{"width":595,"height":485}},"preset1":{"displaySize":{"width":40,"height":30},"size":{"width":340,"height":290}},"preset2":{"displaySize":{"width":50,"height":38},"size":{"width":425,"height":355}},"preset3":{"displaySize":{"width":60,"height":45},"size":{"width":510,"height":420}}},"config":{"defaultPreset":"preset2"}},"html_eotfont_url_suffix":"-eot.js","iframe_url":"//www.slideshare.net/slideshow/embed_code/key/kqmHgRqgwDzBwf","fullscreen_bgcolor":"jsplBgColorBlack","has_video":false,"stripped_title":"oscon-data-2011-lumberyard","player_bgcolor":"jsplBgColorBigfoot","image_bucket_location":"//image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02","ppt_location":"osconlumberyard20110518v8-110929133838-phpapp02","timestamp":1317303673,"bambooleaf_hash":false,"bambooleaf_enabled":false,"hosted_in":"slideview","bucket_location":"//html.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/","image_ready":true,"author_id":30941782,"slideview_url":"/jpatanooga/oscon-data-2011-lumberyard","preload_after_pageload":true,"wp_code":"[slideshare id=9476155\u0026doc=osconlumberyard20110518v8-110929133838-phpapp02]","lastscreen":{"related":[{"views":4640,"title":"Hadoop As The Platform For The Smar...","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02-thumbnail.jpg?cb=1327341063","url":"/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva","author_login":"cloudera","author":"Cloudera, Inc."},{"views":1882,"title":"Indexing and Mining a Billion Time ...","thumbnail":"//cdn.slidesharecdn.com/ss_thumbnails/jainvasupaperpptisax2-121107191852-phpapp01-thumbnail.jpg?cb=1352316162","url":"/vasujain/indexing-and-mining-a-billion-time-series-using-isax-20","author_login":"vasujain","author":"Vasu Jain"}],"url":"http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard"},"sharescreen":{"title":"OSCON Data 2011 - Lumberyard","url":"http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard","user_name":"","html":"\u003Cdiv class=\"shareScreen\"\u003E\n  \u003Ca href=\"#\" class=\"close\"\u003E\u0026times;\u003C/a\u003E\n  \u003Cul class=\"shareMethods\"\u003E\n    \u003Cli class=\"embed\"\u003E\n      \u003Clabel for=\"embed-code\"\u003EEmbed\u003C/label\u003E\n      \u003Cinput type='text' class=\"shareScreenEmbedCode\" value=\"code\" name=\"embed-code\" /\u003E\n    \u003C/li\u003E\n    \u003Cli class=\"url last\"\u003E\n      \u003Clabel for=\"embed-url\"\u003EURL\u003C/label\u003E\n      \u003Cinput type='text' class=\"shareScreenSSUrl\" value=\"code\" name=\"embed-url\" /\u003E\n\t\u003C/li\u003E\n  \u003C/ul\u003E\n  \u003Cform class=\"emailShare\"\u003E\n    \u003Cfieldset\u003E\n      \u003Clegend\u003EEmail this\u003C/legend\u003E\n      \u003Cinput type=\"hidden\" class=\"shareDefaultMessage\" value=\"I think you will find this useful.\" /\u003E\n      \u003Cul\u003E\n        \u003Cli\u003E\n          \u003Clabel for=\"name\"\u003EYour name\u003C/label\u003E\n          \u003Cinput class='shareScreenFromName' type=\"text\" value=\"\" /\u003E\n        \u003C/li\u003E\n        \u003Cli\u003E\n          \u003Clabel for=\"mailID\"\u003EEmail to\u003C/label\u003E\n          \u003Cinput class=\"shareScreenMailID\" type=\"text\" value=\"\" /\u003E\n        \u003C/li\u003E\n        \u003Cli class=\"submit\"\u003E\n          \u003Clabel\u003E\u0026nbsp;\u003C/label\u003E\n          \u003Cinput class=\"shareSprite\" type=\"submit\" value=\"\" /\u003E\n        \u003C/li\u003E        \n      \u003C/ul\u003E\n      \u003C/fieldset\u003E\n  \u003C/form\u003E\n\u003C/div\u003E\u003C!-- shareScreen ends here --\u003E","slideshow_id":9476155},"disable_eagerload":true,"is_private":false,"toolbar_html":"\n\u003C!-- using div.bar-[top, bottom]-margin to fix toolbar spacing with a taller progressbar (improve slide scrubbing UX) --\u003E\n\u003Cdiv class=\"j-progress-bar progress-bar-wrapper\"\u003E\n  \u003Cdiv class=\"progress-bar-spacing\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"buffered-bar\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"j-slides-loaded-bar progress-bar\"\u003E\u003C/div\u003E\n  \u003Cdiv class=\"j-progress-tooltip progress-tooltip\" style=\"display: none;\"\u003E\n    \u003Cdiv class=\"j-tooltip-content progress-tooltip-wrapper\"\u003E\n      \u003Cimg class=\"j-tooltip-thumb tooltip-thumb\" onerror=\"this.src=''\"\n      \u003E\n      \u003Cspan class=\"j-slidecount-label slidecount-label\"\u003E1\u003C/span\u003E\n    \u003C/div\u003E\n    \u003Cdiv class=\"progress-tooltip-caret\"\u003E\u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n\u003Cdiv class=\"progress-bar-spacing\"\u003E\u003C/div\u003E\n\n\n\n\u003Cdiv class=\"j-tools bot-actions\"\u003E\n\u003C/div\u003E\u003C!-- .bot-actions --\u003E\n\n\n  \u003Cdiv class=\"j-tools bot-actions\"\u003E\n    \u003Ca data-tooltip aria-haspopup=\"true\" style=\"display: none\" class=\"j-tooltip j-download action-download has-tip\" title=\"Save this \" href=\"/login?from_source=%2Fjpatanooga%2Foscon-data-2011-lumberyard%3Ffrom_action%3Dsave\u0026amp;from=download\u0026amp;layout=foundation\" data-target=\"#login_modal\" data-placement=\"top\"\u003E\n      \u003Ci class=\"fa fa-download fa-lg\" style=\"margin-top: 1px;\"\u003E\u003C/i\u003E\n    \u003C/a\u003E\n  \u003C/div\u003E\n\n    \u003Cdiv class=\"j-clips-actions clips-actions-bottom\"\u003E\n      \u003Ca id=\"clips-button-bottom\"\n        class=\"j-clips-button clip-button button small left\"\n        href=\"/signup?login_source=slideview.clip.like\u0026amp;from=clip\u0026amp;layout=foundation\u0026amp;from_source=\"\n        rel=\"nofollow\" data-reveal-id=\"login_modal\" style=\"display:none\"\u003E\n        \u003Cdiv class=\"svg-icon\"\u003E\n            \u003Csvg\u003E\u003Cuse data-size=\"small\" xlink:href=\"#clipboard-add-icon\"\u003E\u003C/use\u003E\u003C/svg\u003E\n        \u003C/div\u003E\n        \u003Cspan class=\"clip-button-text-clip notranslate copy-in-aria-label\" aria-label=\"Clip slide\" title=\"Clip to save this slide for later\"\u003E\u003C/span\u003E\n      \u003C/a\u003E\n      \u003Cdiv class=\"toast-toggle left\"\u003E\n        \u003Cdiv class=\"toggle j-toast-toggle\"\u003E\n          \u003Csvg\u003E\u003Cuse data-size=\"large\" xlink:href=\"#chevron-down-icon\"\u003E\u003C/use\u003E\u003C/svg\u003E\n        \u003C/div\u003E\n      \u003C/div\u003E\n    \u003C/div\u003E\n\n\u003Cscript\u003E\n  (function(win) {\n\n    var ss = win.slideshare_object,\n        Experiments = ss.utils.imports('Experiments'),\n        experiments = new Experiments();\n\n    // Update the toolbar elements as long as we're not embedded.\n    if (!ss.inIframe || (ss.inIframe \u0026\u0026 !ss.inIframe())) {\n      experiments.addClass('#clips-button-bottom', 'slideview-clip-button-exp-2');\n      experiments.addClass('.clip-button-top .clip-button', 'slideview-clip-button-exp-2');\n    }\n\n  }(window));\n\u003C/script\u003E\n\n\n\n  \u003Cdiv class=\"nav\"\u003E\n      \u003Cbutton id=\"btnPrevious\" title=\"Previous Slide\"\u003E\n        \u003Cdiv class=\"j-prev-btn arrow-left disabled\"\u003E\u003C/div\u003E\n      \u003C/button\u003E\n    \u003Clabel class=\"goToSlideLabel\"\u003E\n      \u003Cspan id=\"current-slide\" class=\"j-current-slide\"\u003E1\u003C/span\u003E\n      of\n      \u003Cspan id=\"total-slides\" class=\"j-total-slides\"\u003E1\u003C/span\u003E\n    \u003C/label\u003E\n      \u003Cbutton id=\"btnNext\" title=\"Next Slide\"\u003E\n        \u003Cdiv class=\"j-next-btn arrow-right disabled\"\u003E\u003C/div\u003E\n      \u003C/button\u003E\n  \u003C/div\u003E\n\n\n\n\u003Cdiv class=\"navActions\"\u003E\n\n\n\n    \u003Cbutton id=\"btnFullScreen\" class=\"j-tooltip btnFullScreen\" title=\"View Fullscreen\"\u003E\n      \u003Cspan class=\"fa fa-stack\"\u003E\n        \u003Ci class=\"fa fa-square fa-stack-2x\"\u003E\u003C/i\u003E\n        \u003Ci class=\"fa fa-expand fa-stack-1x\"\u003E\u003C/i\u003E\n      \u003C/span\u003E\n    \u003C/button\u003E\n    \u003Cbutton id=\"btnLeaveFullScreen\" class=\"j-tooltip btnLeaveFullScreen\" title=\"Exit Fullscreen\"\u003E\n      \u003Cspan class=\"fa-stack\"\u003E\n        \u003Ci class=\"fa fa-square fa-stack-2x\"\u003E\u003C/i\u003E\n        \u003Ci class=\"fa fa-compress fa-stack-1x\"\u003E\u003C/i\u003E\n      \u003C/span\u003E\n    \u003C/button\u003E\n\n\u003C/div\u003E\n\n\u003Cscript\u003E\n  (function(win) {\n    //Update the fullscreen button if on slideview clip button experient, version B\n    var ss = win.slideshare_object,\n        Experiments = ss.utils.imports('Experiments'),\n        experiments = new Experiments();\n\n    // Update the toolbar elements as long as we're not embedded.\n    if (!ss.inIframe || (ss.inIframe \u0026\u0026 !ss.inIframe())) {\n      experiments.addClass('.navActions', 'slideview-clip-button-exp-2');\n    }\n\n  }(window));\n\u003C/script\u003E\n\n\n","show_related_content":"1","next_prev_experiment":true,"spinner_url":"//public.slidesharecdn.com/b/images/ssplayer/loading_bigfoot.gif?8d8fb5905f","next_slideshow_pos":null,"meta_error_template":"\u003Cstyle type=\"text/css\"\u003E\n  .jsplayer-slide-error {\n    background-color: #000;\n    padding: 20% 0 13% !important;\n  }\n  .jsplayer-slide-error div {\n    text-align: center;\n  }\n  .jsplayer-slide-error img {\n    height: 79px !important;\n    margin: 0 0 10px;\n    width: 80px !important;\n  }\n  .jsplayer-slide-error .slide-error-body {\n    color: #eee;\n    font-family: 'Lucida Grande',Verdana, Arial, Helvetica, sans-serif;\n    padding: 0 !important;\n  }\n  .jsplayer-slide-error .slide-error-body p {\n    font-size: 0.8em;\n    line-height: 1.1em;\n    margin: 8px 0;\n  }   \n  .jsplayer-slide-error .slide-error-body input[type=button] {\n    margin: 7px 0 0;\n    padding: 7px 14px;\n  }\n\u003C/style\u003E\n\u003Cdiv class=\"jsplayer-slide-error\"\u003E\n  \u003Cdiv style=\"position:relative;\"\u003E\n    \u003Cimg src='//public.slidesharecdn.com/b/images/ssplayer/error_dudes-80x79.png' height=\"79\" width=\"80\" /\u003E\n    \u003Cdiv class=\"slide-error-body\"\u003E\n      \u003Cp\u003EWe have encountered an error.\u003C/p\u003E\n      \u003Cp\u003EPlease refresh the page.\u003C/p\u003E\n    \u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n","related_position":0,"replayscreen":{"html":"\u003Ca href=\"#\" class=\"j-replay-button replay-button\" \u003E\n  \u003Ci class=\"fa fa-refresh\"\u003E\u003C/i\u003E\n  View again\n\u003C/a\u003E"},"inpage_full_screen":true,"twitter_share_text":"OSCON Data 2011 - Lumberyard by @jpatanooga #hadoop #hbase","embed_code":"\u003Ciframe src=\"https://www.slideshare.net/slideshow/embed_code/key/kqmHgRqgwDzBwf\" width=\"427\" height=\"356\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard\" title=\"OSCON Data 2011 - Lumberyard\" target=\"_blank\"\u003EOSCON Data 2011 - Lumberyard\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/jpatanooga\" target=\"_blank\"\u003EJosh Patterson\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","share_text":"OSCON Data 2011 - Lumberyard by Josh Patterson via slideshare","track_slide_enable":1,"player_type":"presentation","page":1,"slide_count":41,"show_image_player":true,"slide_error_template":"\u003Cstyle type=\"text/css\"\u003E\n  .jsplayer-slide-error {\n    background-color: #000;\n    padding: 20% 0 13% !important;\n  }\n  .jsplayer-slide-error div {\n    text-align: center;\n  }\n  .jsplayer-slide-error img {\n    height: 79px !important;\n    margin: 0 0 10px;\n    width: 80px !important;\n  }\n  .jsplayer-slide-error .slide-error-body {\n    color: #eee;\n    font-family: 'Lucida Grande',Verdana, Arial, Helvetica, sans-serif;\n    padding: 0 !important;\n  }\n  .jsplayer-slide-error .slide-error-body p {\n    font-size: 0.8em;\n    line-height: 1.1em;\n    margin: 7px 0 11px;\n  }\n  .jsplayer-slide-error .slide-error-body input[type=button] {\n    margin: 7px 0 0;\n    padding: 7px 14px;\n  }\n\u003C/style\u003E\n\u003Cdiv class=\"jsplayer-slide-error\"\u003E\n  \u003Cdiv style=\"position:relative;\"\u003E\n    \u003Cimg src='//public.slidesharecdn.com/b/images/ssplayer/error_dudes-80x79.png' height=\"79\" width=\"80\" /\u003E\n    \u003Cdiv class=\"slide-error-body\"\u003E\n      \u003Cp\u003EWe were unable to load the slide.\u003C/p\u003E\n      \u003Cinput class=\"btn btn-large\" type=\"button\" value=\"Reload slide\" /\u003E\n    \u003C/div\u003E\n  \u003C/div\u003E\n\u003C/div\u003E\n","spinner_url_fullscreen":"//public.slidesharecdn.com/b/images/ssplayer/loading_black.gif?468e48bc3a","beacon_url":"stats.slideshare.net/1.gif","use_ssl":false,"mode":"image","id":9476155,"html_ttffont_url_suffix":".js"},"user":{"clipboards":null,"member_type":"non-member","clips_number":0},"comments":{"ajaxurl":"/~/slideshow/comments/9476155.json","captcha_url":"http://s3.amazonaws.com/ss-captchas/","total_count":0},"key":false,"presentationId":9476155,"activities":{"favorites":{"count":3,"url":"/~/slideshow/favorites_list/9476155.json","total":3}},"slideshow":{"user_login":"jpatanooga","is_clippable":true,"iframe_code":"\u003Ciframe src=\"{iframe_url}\" width=\"{width}\" height=\"{height}\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" scrolling=\"no\" style=\"border:1px solid #CCC; border-width:1px; margin-bottom:5px; max-width: 100%;\" allowfullscreen\u003E \u003C/iframe\u003E \u003Cdiv style=\"margin-bottom:5px\"\u003E \u003Cstrong\u003E \u003Ca href=\"https://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard\" title=\"OSCON Data 2011 - Lumberyard\" target=\"_blank\"\u003EOSCON Data 2011 - Lumberyard\u003C/a\u003E \u003C/strong\u003E from \u003Cstrong\u003E\u003Ca href=\"http://www.slideshare.net/jpatanooga\" target=\"_blank\"\u003EJosh Patterson\u003C/a\u003E\u003C/strong\u003E \u003C/div\u003E","pin_image_url":"http://cdn.slidesharecdn.com/ss_thumbnails/osconlumberyard20110518v8-110929133838-phpapp02-thumbnail-4.jpg?cb=1317303673","view_action_state":"unpublished","type":"presentation","title":"OSCON Data 2011 - Lumberyard","facade_slide_url":"http://image.slidesharecdn.com/osconlumberyard20110518v8-110929133838-phpapp02/95/oscon-data-2011-lumberyard-1-728.jpg?cb=1317303673","embed_sizes":{"presets":{"preset4":{"displaySize":{"width":70,"height":53},"size":{"width":595,"height":485}},"preset1":{"displaySize":{"width":40,"height":30},"size":{"width":340,"height":290}},"preset2":{"displaySize":{"width":50,"height":38},"size":{"width":425,"height":355}},"preset3":{"displaySize":{"width":60,"height":45},"size":{"width":510,"height":420}}},"config":{"defaultPreset":"preset2"}},"fullscreen_bg_color":"Black","social_urls":{"linkedin":"https://www.linkedin.com/cws/share?url=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard\u0026trk=SLIDESHARE","google":"https://plus.google.com/share?url=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard","twitter":"https://twitter.com/intent/tweet?via=SlideShare\u0026text=OSCON+Data+2011+-+Lumberyard+by+%40jpatanooga+%23hadoop+%23hbase+http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard","facebook":"https://facebook.com/sharer.php?u=http%3A%2F%2Fwww.slideshare.net%2Fjpatanooga%2Foscon-data-2011-lumberyard\u0026t=OSCON+Data+2011+-+Lumberyard"},"iframe_url":"https://www.slideshare.net/slideshow/embed_code/key/kqmHgRqgwDzBwf","zeroclipboard_url":"http://static.slidesharecdn.com/ZeroClipboardv2.swf","ss_url":"http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard","clip_counts":{},"wp_code":"[slideshare id=9476155\u0026doc=osconlumberyard20110518v8-110929133838-phpapp02]","total_slides":41,"user_name":"Josh Patterson","is_private":false,"show_related_content":"1","lead_form_url":"https://www.slideshare.net/slideshow/kqmHgRqgwDzBwf/lead-form","clips":{},"recommendations":{"designKey":"a2","finalRankerModel":"model_001"},"is_author_premium":false,"mobile_app_url":"slideshare-app://ss/9476155","allow_embeds":true,"id":"9476155"},"useHttp":1,"stripped_title":"oscon-data-2011-lumberyard","embeds_count":13,"default_tab":".svMoreAuthor","relative_static_origin_server":"//public.slidesharecdn.com/b/","slideshow_placeholder":"//public.slidesharecdn.com/b/images/thumbnail.png","startSlide":1,"category":{"featured":0},"totalSlides":41,"top_nav":{"get_url":"/top_nav"},"gam_cat_name":"technology","flagging":{"flagged_value":null},"bizo_partner_id":870,"userimage_placeholder":"//public.slidesharecdn.com/b/images/user-48x48.png","preview":"no","related_type":"related","stats":{"url":"http://www.slideshare.net/~/slideshow/stats/9476155.json"},"downloads":{"allow":true,"sp_isdwnl":true},"beacon_url":"stats.slideshare.net/1.gif","fb_app_name":"slideshare","pvt":0});</script>
<script src="http://public.slidesharecdn.com/b/slideview/scripts/combined_presentation_init.js?755d8a8058" type="text/javascript"></script>
<script type="text/javascript">$(document).ready(function(){var $el=$('#svPlayerId');var classMap={'document':'document_player','html':'html_player','infographic':'infographic_player','video':'video_player'}
player=new SSPlayer(slideshare_object.jsplayer);$(player).bind('slidechanged',function(e){if(typeof(loadDataForSlide)==='function'){loadDataForSlide(e.ssData.index);}});$el.addClass(classMap[player.config.player_type]);});</script>
<script src="http://public.slidesharecdn.com/b/ss_foundation/combined_player_clipping.js?0b344ffd18" type="text/javascript"></script>
<script>slideshare_object.add_signin_link('.j-favorite');slideshare_object.add_login_source('.j-favorite','slideview.top_toolbar.like');slideshare_object.add_login_source('.j-save','slideview.top_toolbar.download');slideshare_object.addSigninFrom('.j-favorite','favorite');slideshare_object.bindToModalLogin('.j-favorite');slideshare_object.bindToModalLogin('.j-save');slideshare_object.bind_favorites('#slideview-container');$(document).ready(function(){var mainContentHeight=$("#main-panel").height();var sidePanelItemHeight=$("#side-panel .j-related-item").first().outerHeight();var numItemToDisplay=Math.floor((mainContentHeight-200)/sidePanelItemHeight);$("#side-panel .tabs-content .content").each(function(){$(this).find(".j-related-item").slice(numItemToDisplay-2).remove();});var loadAdditionalFunctionality=function(){e=document.createElement('script');e.type='text/javascript';e.async=true;e.src='//public.slidesharecdn.com/b/ss_foundation/combined_slideview_loggedout.js?fc6747b305eab4929e9de90ae2a363baeec71eca';var s=document.getElementsByTagName('script')[0];s.parentNode.insertBefore(e,s);};$(window).load(function(){loadAdditionalFunctionality();});$('.j-lazy-thumb-click').lazyload({event:'more-tab-clicked'});$('.j-more-tab').on('click',function(){$('.j-lazy-thumb-click').trigger('more-tab-clicked');});$(window).load(function(){loadCSS("//public.slidesharecdn.com/b/ss_foundation/stylesheets/slideview.css?fc6747b305eab4929e9de90ae2a363baeec71eca");});});</script>
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
