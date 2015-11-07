

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en" class="" prefix="og: http://ogp.me/ns# profile: http://ogp.me/ns/profile#">

<head>

    <meta id="Com

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

patabilityMode" http-equiv="X-UA-Compatible" content="IE=edge" />

	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>The Open Source Phasor Data Concentrator - Custom Action Adapters - Unpublished Data</title>

<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

    

<body>

<div id="wrap">

    <div id="sub_heading" class="row">

        <div id="ProjectHeader">

            <div id="project_title_row" class="row">

                <div id="project_logo">

    <h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The&#32;Open&#32;Source&#32;Phasor&#32;Data&#32;Concentrator" /></a></h1>

</div>

</div>

</div>

</div>

    

<div class="Threads">

    <div class="ViewThread">

            <h1 class="page_title WordWrapBreakWord">

                Custom Action Adapters - Unpublished Data

            </h1>



            <!-- Posts List Header: Topics and Wiki Link -->

            <table class="PostsListHeader">

                <tr>

                    <td>

                     

                    </td>

                    <td>

                        <div class="WikiLink">

                                Wiki Link: [discussion:433859]

</div>

                    </td>

                </tr>

            </table>



            <!-- The list of posts -->

            



<div id="discussionsPostList" data-options-id="c7d2616b-40d8-4f72-8c16-1376f81db575">

    <script class="options" defer="defer" id="c7d2616b-40d8-4f72-8c16-1376f81db575" type="application/json">{"threadUrl":"http://openpdc.codeplex.com/discussions/433859","showEditor":false,"checkImageUrl":"http://download-codeplex.sec.s-msft.com/Images/v21031/check_answer.png"}</script>



    <div class="Posts" style="margin-top: 10px;">

    



<table cellpadding="0" cellspacing="0" style="width: 100%; margin-bottom: 0px; table-layout:fixed; border-collapse:collapse; border:  solid #BBB 1px; border-width: 1px;">

    



<tr id="PostPanel" class="Post" d:forid="1004227">

    <td id="PostDetailsCell_1004227" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1004227"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/20/2013 8:24:08 PM" LocalTimeTicks="1361420648">Feb 20, 2013 at 8:24 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004227" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="I&#32;am&#32;using&#32;both&#32;the&#32;OneSecondFrequencyAverager&#32;action&#32;adapter,&#32;provided&#32;by&#32;GPA,&#32;and&#32;also&#32;I&#32;have&#32;created&#32;two&#32;other&#32;action&#32;adapters,&#32;one&#32;to&#32;calculate&#32;one-second&#32;voltage&#32;phase&#32;angles&#32;and&#32;one&#32;to&#32;calculate&#32;&#32;one-second&#32;voltage&#32;phase&#32;angle&#32;slopes.&#32;My&#32;two&#32;adapters&#32;follow&#32;the&#32;example&#32;of&#32;the&#32;OneSecondFrequencyAverager,&#32;in&#32;that&#32;one&#32;adapter&#32;handled&#32;multiple&#32;input&#32;voltage&#32;phase&#32;angle&#32;measurements,&#32;writing&#32;to&#32;multiple&#32;output&#32;measurements.&#13;&#10;&#13;&#10;Even&#32;when&#32;I&#32;only&#32;use&#32;the&#32;provided&#32;OneSecondFrequencyAverager,&#32;with&#32;only&#32;9&#32;frequency&#32;measurements,&#32;I&#32;quickly&#32;get&#32;the&#32;error&#32;message&#58;&#32;&#13;&#10;&#91;&#60;adapter&#32;name&#62;&#93;&#32;There&#32;are&#32;&#60;n&#62;&#32;seconds&#32;of&#32;unpublished&#32;data&#32;in&#32;the&#32;action&#32;adapter&#32;concentration&#32;queue.&#13;&#10;&#13;&#10;The&#32;number&#32;of&#32;seconds&#32;climbs&#32;from&#32;the&#32;value&#32;2&#32;or&#32;3&#32;to&#32;6&#32;or&#32;7,&#32;which&#32;is&#32;when&#32;I&#32;disable&#32;the&#32;adapter&#40;s&#41;.&#32;When&#32;I&#32;use&#32;my&#32;own&#32;adapters,&#32;the&#32;problem&#32;is&#32;worse,&#32;and&#32;quicker&#32;to&#32;climb.&#13;&#10;&#13;&#10;The&#32;openPDC&#32;doesn&#39;t&#32;seem&#32;to&#32;use&#32;much&#32;CPU...&#32;is&#32;this&#32;a&#32;problem&#63;&#32;Is&#32;there&#32;some&#32;configuration&#32;that&#32;can&#32;alleviate&#32;this&#32;problem&#63;&#32;Or...">

        <div class="markDownOutput ">I am using both the OneSecondFrequencyAverager action adapter, provided by GPA, and also I have created two other action adapters, one to calculate one-second voltage phase angles and one to calculate one-second voltage phase angle slopes. My two adapters

 follow the example of the OneSecondFrequencyAverager, in that one adapter handled multiple input voltage phase angle measurements, writing to multiple output measurements.

<br>

<br>

Even when I only use the provided OneSecondFrequencyAverager, with only 9 frequency measurements, I quickly get the error message:

<br>

[&lt;adapter name&gt;] There are &lt;n&gt; seconds of unpublished data in the action adapter concentration queue.

<br>

<br>

The number of seconds climbs from the value 2 or 3 to 6 or 7, which is when I disable the adapter(s). When I use my own adapters, the problem is worse, and quicker to climb.

<br>

<br>

The openPDC doesn't seem to use much CPU... is this a problem? Is there some configuration that can alleviate this problem? Or...<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004227" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004228">

    <td id="PostDetailsCell_1004228" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1004228"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/20/2013 8:26:59 PM" LocalTimeTicks="1361420819">Feb 20, 2013 at 8:26 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004228" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="By&#32;the&#32;way,&#32;I&#32;also&#32;am&#32;using&#32;about&#32;7&#32;PowerCalculation&#32;adapters&#32;to&#32;calculate&#32;MW&#47;MVAR&#32;values,&#32;and&#32;7&#32;Dynamic&#32;Calculation&#32;adapters&#32;to&#32;calculate&#32;the&#32;MVA&#32;from&#32;the&#32;previous.&#32;Also,&#32;two&#32;other&#32;Dynamic&#32;Calculation&#32;adapters&#32;for&#32;miscellaneous&#32;use.&#32;And,&#32;about&#32;3000&#32;alarms.">

        <div class="markDownOutput ">By the way, I also am using about 7 PowerCalculation adapters to calculate MW/MVAR values, and 7 Dynamic Calculation adapters to calculate the MVA from the previous. Also, two other Dynamic Calculation adapters for miscellaneous use. And, about 3000 alarms.<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004228" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004230">

    <td id="PostDetailsCell_1004230" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1004230"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/20/2013 8:29:03 PM" LocalTimeTicks="1361420943">Feb 20, 2013 at 8:29 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004230" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="and&#32;more...&#32;I&#32;am&#32;using&#32;1.5.179&#32;of&#32;openPDC">

        <div class="markDownOutput ">and more... I am using 1.5.179 of openPDC<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004230" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004676">

    <td id="PostDetailsCell_1004676" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1004676"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/21/2013 1:58:54 PM" LocalTimeTicks="1361483934">Feb 21, 2013 at 1:58 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004676" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="I&#32;may&#32;have&#32;figured&#32;out&#32;my&#32;problem.&#13;&#10;&#13;&#10;I&#32;misunderstood&#32;the&#32;use&#32;of&#32;&#39;waitHandleNames&#39;&#32;and&#32;&#39;WaitHandleReleaseName&#39;.&#32;I&#32;was&#32;passing&#32;a&#32;value&#32;for&#32;&#39;waitHandleNames&#39;&#32;for&#32;adapters&#32;that&#32;should&#32;have&#32;had&#32;&#39;WaitHandleReleaseName&#39;&#32;-&#32;or&#32;so&#32;I&#32;now&#32;believe.&#32;My&#32;new&#32;assumsion&#58;&#32;action&#32;adapters&#32;that&#32;only&#32;work&#32;on&#32;&#39;first-level&#39;&#32;measurements&#32;&#40;incoming&#32;phase&#32;angles,&#32;magnitudes,&#32;frequencies,&#32;statistics&#41;&#32;should&#32;not&#32;have&#32;&#39;waitHandleNames&#39;,&#32;but&#32;may&#32;have&#32;&#39;WaitHandleReleaseName&#39;.&#32;If&#32;any&#32;action&#32;adapter&#32;creates&#32;output&#32;measurements&#32;to&#32;be&#32;used&#32;by&#32;subsequent&#32;action&#32;adapters,&#32;it&#32;should&#32;have&#32;a&#32;value&#32;for&#32;&#39;WaitHandleReleaseName&#39;.&#32;Action&#32;adapters&#32;that&#32;need&#32;to&#32;wait&#32;for&#32;calculated&#32;measurements&#32;by&#32;previous&#32;action&#32;adapters&#32;need&#32;to&#32;pass&#32;&#39;waitHandleNames&#39;,&#32;using&#32;the&#32;values&#32;of&#32;&#39;WaitHandleReleaseName&#39;&#32;for&#32;those&#32;previous&#32;action&#32;adapters.&#13;&#10;&#13;&#10;Is&#32;this&#32;correct&#63;&#32;Some&#32;GPA-provided&#32;action&#32;adapters,&#32;such&#32;as&#32;OneSecondFrequencyAverager&#32;and&#32;PowerCalculator&#32;don&#39;t&#32;advertise&#32;the&#32;use&#32;of&#32;&#39;WaitHandleReleaseName&#39;.&#32;If&#32;passed&#32;to&#32;those&#32;adapters,&#32;will&#32;the&#32;handle&#32;be&#32;released&#63;">

        <div class="markDownOutput ">I may have figured out my problem. <br>

<br>

I misunderstood the use of 'waitHandleNames' and 'WaitHandleReleaseName'. I was passing a value for 'waitHandleNames' for adapters that should have had 'WaitHandleReleaseName' - or so I now believe. My new assumsion: action adapters that only work on 'first-level'

 measurements (incoming phase angles, magnitudes, frequencies, statistics) should not have 'waitHandleNames', but may have 'WaitHandleReleaseName'. If any action adapter creates output measurements to be used by subsequent action adapters, it should have a

 value for 'WaitHandleReleaseName'. Action adapters that need to wait for calculated measurements by previous action adapters need to pass 'waitHandleNames', using the values of 'WaitHandleReleaseName' for those previous action adapters.

<br>

<br>

Is this correct? Some GPA-provided action adapters, such as OneSecondFrequencyAverager and PowerCalculator don't advertise the use of 'WaitHandleReleaseName'. If passed to those adapters, will the handle be released?<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004676" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004710">

    <td id="PostDetailsCell_1004710" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="TeamPost">

        <div class="Details">

            <a name="post1004710"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/staphen">staphen</a></div>

            <div class="UserRole">Coordinator</div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/21/2013 2:41:24 PM" LocalTimeTicks="1361486484">Feb 21, 2013 at 2:41 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004710" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="Hi&#32;patpentz,&#13;&#10;&#13;&#10;The&#32;external&#32;event&#32;handles&#32;are&#32;only&#32;relevant&#32;if&#32;an&#32;adapter&#32;is&#32;modifying&#32;an&#32;existing&#32;set&#32;of&#32;measurements.&#32;For&#32;example,&#32;say&#32;you&#32;have&#32;a&#32;data&#32;quality&#32;action&#32;adapter&#32;that&#32;is&#32;modifying&#32;the&#32;state&#32;flags&#32;of&#32;measurements&#32;that&#32;were&#32;generated&#32;by&#32;an&#32;input&#32;adapter.&#32;If&#32;another&#32;adapter&#32;needs&#32;to&#32;pass&#32;that&#32;data&#32;on&#32;to&#32;a&#32;historian,&#32;in&#32;order&#32;to&#32;guarantee&#32;that&#32;the&#32;state&#32;flags&#32;changes&#32;to&#32;show&#32;up&#32;there,&#32;the&#32;data&#32;quality&#32;adapter&#32;needs&#32;to&#32;provide&#32;a&#32;signal&#32;to&#32;the&#32;historian&#32;adapter&#32;to&#32;indicate&#32;that&#32;it&#32;is&#32;done&#32;processing&#32;that&#32;set&#32;of&#32;measurements.&#32;This&#32;is&#32;what&#32;the&#32;external&#32;event&#32;handles&#32;were&#32;designed&#32;for.&#13;&#10;&#13;&#10;Most&#32;adapters&#32;will&#32;create&#32;their&#32;own&#32;measurements,&#32;rather&#32;than&#32;modifying&#32;existing&#32;ones.&#32;Since&#32;the&#32;very&#32;existence&#32;of&#32;those&#32;measurements&#32;can&#32;be&#32;used&#32;as&#32;the&#32;trigger&#32;for&#32;other&#32;adapters&#32;to&#32;process&#32;them,&#32;then&#32;there&#32;is&#32;no&#32;need&#32;for&#32;a&#32;signaling&#32;mechanism&#32;like&#32;external&#32;event&#32;handles.&#32;As&#32;a&#32;result,&#32;the&#32;WaitHandleReleaseName&#32;connection&#32;string&#32;property&#32;does&#32;not&#32;exist&#32;by&#32;default,&#32;and&#32;most&#32;adapters&#32;do&#32;not&#32;support&#32;it.&#13;&#10;&#13;&#10;Also&#32;note&#32;that&#32;since&#32;the&#32;development&#32;of&#32;the&#32;feature,&#32;we&#32;have&#32;discovered&#32;a&#32;number&#32;of&#32;shortcomings&#32;with&#32;the&#32;external&#32;event&#32;handle&#32;system&#32;that&#32;can&#32;potentially&#32;cause&#32;problems&#32;in&#32;complex&#32;scenarios.&#32;As&#32;of&#32;openPDC&#32;v1.5.192,&#32;we&#32;have&#32;removed&#32;external&#32;event&#32;handles&#32;and&#32;included&#32;a&#32;new&#32;feature&#32;which&#32;we&#39;ve&#32;called&#32;&#34;Queue&#32;and&#32;Notify&#34;&#32;that&#32;addresses&#32;this&#32;problem.&#13;&#10;&#13;&#10;Stephen">

        <div class="markDownOutput ">Hi patpentz, <br>

<br>

The external event handles are only relevant if an adapter is modifying an existing set of measurements. For example, say you have a data quality action adapter that is modifying the state flags of measurements that were generated by an input adapter. If another

 adapter needs to pass that data on to a historian, in order to guarantee that the state flags changes to show up there, the data quality adapter needs to provide a signal to the historian adapter to indicate that it is done processing that set of measurements.

 This is what the external event handles were designed for. <br>

<br>

Most adapters will create their own measurements, rather than modifying existing ones. Since the very existence of those measurements can be used as the trigger for other adapters to process them, then there is no need for a signaling mechanism like external

 event handles. As a result, the WaitHandleReleaseName connection string property does not exist by default, and most adapters do not support it.

<br>

<br>

Also note that since the development of the feature, we have discovered a number of shortcomings with the external event handle system that can potentially cause problems in complex scenarios. As of openPDC v1.5.192, we have removed external event handles and

 included a new feature which we've called &quot;Queue and Notify&quot; that addresses this problem.

<br>

<br>

Stephen<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004710" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004715">

    <td id="PostDetailsCell_1004715" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="TeamPost">

        <div class="Details">

            <a name="post1004715"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/staphen">staphen</a></div>

            <div class="UserRole">Coordinator</div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/21/2013 2:56:30 PM" LocalTimeTicks="1361487390">Feb 21, 2013 at 2:56 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004715" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="This&#32;may&#32;also&#32;be&#32;worth&#32;noting&#32;to&#32;clear&#32;up&#32;any&#32;confusion.&#32;The&#32;dynamic&#32;calculator&#32;does&#32;mistakenly&#32;specify&#32;a&#32;WaitHandleReleaseName&#32;in&#32;its&#32;connection&#32;string.&#32;This&#32;parameter&#32;is&#32;not&#32;needed,&#32;and&#32;there&#32;is&#32;no&#32;reason&#32;for&#32;other&#32;adapters&#32;to&#32;specify&#32;WaitHandleNames&#32;in&#32;order&#32;to&#32;receive&#32;the&#32;measurements&#32;generated&#32;by&#32;the&#32;dynamic&#32;calculator.">

        <div class="markDownOutput ">This may also be worth noting to clear up any confusion. The dynamic calculator does mistakenly specify a WaitHandleReleaseName in its connection string. This parameter is not needed, and there is no reason for other adapters to specify WaitHandleNames

 in order to receive the measurements generated by the dynamic calculator.<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004715" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1004747">

    <td id="PostDetailsCell_1004747" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1004747"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/21/2013 4:00:24 PM" LocalTimeTicks="1361491224">Feb 21, 2013 at 4:00 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1004747" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="thanks.&#32;I&#32;am&#32;easily&#32;confused...&#32;I&#32;will&#32;no&#32;longer&#32;use&#32;either&#32;waitHandleNames&#32;or&#32;WaitHandleReleaseName">

        <div class="markDownOutput ">thanks. I am easily confused... I will no longer use either waitHandleNames or WaitHandleReleaseName<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1004747" class="Options" >

            

</div>

        

    </td>

</tr>



        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>

        



<tr id="PostPanel" class="Post" d:forid="1007161">

    <td id="PostDetailsCell_1007161" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="Post">

        <div class="Details">

            <a name="post1007161"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a></div>

            <div class="UserRole"></div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/26/2013 6:37:44 PM" LocalTimeTicks="1361932664">Feb 26, 2013 at 6:37 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1007161" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="I&#32;just&#32;read&#32;about&#32;the&#32;new&#32;&#39;Dependency&#39;&#32;mechanism.&#32;Thanks&#33;&#32;&#13;&#10;I&#32;assume&#32;that,&#32;as&#32;stated&#32;above,&#32;this&#32;only&#32;affects&#32;adapters&#32;that&#32;modify&#32;existing&#32;measurements.&#32;That&#32;is,&#32;an&#32;adapter&#32;needing&#32;measurements&#32;newly&#32;created&#32;by&#32;other&#32;adapters&#32;will&#32;not&#32;need&#32;any&#32;synchronization.&#32;If&#32;this&#32;is&#32;wrong,&#32;please&#32;let&#32;me&#32;know.">

        <div class="markDownOutput ">I just read about the new 'Dependency' mechanism. Thanks! <br>

I assume that, as stated above, this only affects adapters that modify existing measurements. That is, an adapter needing measurements newly created by other adapters will not need any synchronization. If this is wrong, please let me know.<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1007161" class="Options" >

            

</div>

        

    </td>

</tr>

        <tr><td colspan="3"><div class="PostSeparator"></div></td></tr>



<tr id="PostPanel" class="Post" d:forid="1007171">

    <td id="PostDetailsCell_1007171" style="vertical-align: top; border: solid #BBB 1px; border-bottom: none; border-left: none; border-top: none; width: 114px" class="TeamPost">

        <div class="Details">

            <a name="post1007171"></a>

            <div class="UserName" style="white-space: pre-wrap; word-wrap: break-word;"><a class="UserProfileLink" href="http://www.codeplex.com/site/users/view/staphen">staphen</a></div>

            <div class="UserRole">Coordinator</div>

            <div style="white-space: normal" class="SubText"><span class="smartDate" title="2/26/2013 6:52:11 PM" LocalTimeTicks="1361933531">Feb 26, 2013 at 6:52 PM</span></div>

            

</div>

    </td>

    <td id="PostContent_1007171" style="width: 100%; vertical-align: top;" 

        class=" discussionPost discussionListContent WordWrapBreakWord Post markDownOutput" 

        data-markdown="Yep,&#32;that&#32;is&#32;correct.">

        <div class="markDownOutput ">Yep, that is correct.<br>

</div>

        

    </td>

    <td style="vertical-align: top; width: 134px;" class="Post ">

        

        <div id="Options_1007171" class="Options" >

</div>

    </td>

</tr>

</table>

</div>

</div>

<hr />

    Migrated from <a href="http://openpdc.codeplex.com/discussions/433859">CodePlex</a> Oct 5, 2015 by <a href="https://github.com/ajstadlin">ajs</a>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>
