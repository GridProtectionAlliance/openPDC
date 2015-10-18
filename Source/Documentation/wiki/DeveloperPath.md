

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>DeveloperPath</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div class="wikidoc">

<h2>The Path to Becoming an openPDC Developer</h2>

The easiest wasy to become a developer for the openPDC project is to start providing &quot;patches of value&quot;. Anyone can upload code for us to review:

<a href="http://openpdc.codeplex.com/SourceControl/UploadPatch.aspx">upload patch</a>. If your patch is accepted (i.e., it is a useful new feature or bug fix) the code will be merged into the current code set - any added attributions and copyrights will remain.

 You can use other open-source code in your patches but it must be compatible with the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/license.md">TVA Open Source License</a>. Providing patches that add true value set you on the path to becoming a &quot;trusted&quot; developer on the openPDC project. Trusted developers have &quot;check-out&quot; rights to

 the source code and can directly upload changes to the current code set.<br>

<br>

Looking forward to your patches!<br>

<h2>Code Rules</h2>

<h3>Formatting</h3>

<h4>Code Regions</h4>

All of the code used by the openPDC must be formatted using &quot;Regions&quot; snippet. If you expect to have your patch or code update included within the project it must follow this convention. All the snippets used by the project can be found in the Contributor

 Resources in the Snippets folder.<br>

<br>

To install the snippets copy the *.snippet files to the file location that is defined for your code snippets. The file location can be found by selecting &quot;Tools&quot; &gt; &quot;Code Snippet Manager&quot; from within Visual Studio then choosing Visual

 C# in the Language dropdown and selecting My Code Snippets. The folder is typically &quot;...\My Documents\Visual Studio 2008\Code Snippets\Visual C#\My Code Snippets&quot;.<br>

<h4>Headers</h4>

Additionally all code must have a consistent header. We have developed a macro to include the standard code header that can be found in the Contributor Resources in the Macros folder. The following instructions will create this Visual Studio macro. Once defined

 you can insert the common header from within Visual Studio into any file by pressing &quot;Ctrl&#43;Alt&#43;H&quot;. Installation steps follow:<br>

<br>

First, install the project macro:<br>

<ol>

<li>Go to “Tools” / “Macros” / “Macros IDE” </li><li>Right click “MyMacros” and select &quot;Add&quot; / “Add Module” </li><li>Enter name “ProjectMacros”, then select the &quot;Add&quot; button </li><li>Select all default code by pressing &quot;Ctrl&#43;A&quot; </li><li>Press the &quot;delete&quot; key to remove all existing code </li><li>Paste in code from the &quot;ProjectMacros.vb&quot; found in this folder </li><li>Right click “References” in the Project Explorer and select “Add Reference” </li><li>Select “System.DirectoryServices.dll” </li><li>Select the &quot;Add&quot; button, then select the &quot;OK&quot; button </li><li>Select “File” / “Save MyMacros” </li><li>Close “Macros IDE”</li></ol>

<br>

Second, assign a shortcut key to the macro:<br>

<ol>

<li>Go to “View” / “Toolbars” / “Customize...” </li><li>Click “Keyboard...” button in the bottom left corner </li><li>Type “MyMacros” into “Show commands containing:” text box </li><li>Select “Macros.MyMacros.ProjectMacros.InsertHeader” </li><li>Select “Text Editor” from the “Use new shortcut in:” list </li><li>Click in the “Press shortcut keys:” text box </li><li>Press the “Ctrl”, “Alt” and “H” key (text box should say Ctrl&#43;Alt&#43;H) </li><li>Click the “Assign” button, then click “OK” </li><li>Click the “Close” button on the “Customize” window </li><li>Open a C# code window, click anywhere in the file </li><li>Press Ctrl&#43;Alt&#43;H, header will be inserted at top of document</li></ol>

<br>

Note all steps are executed from within Visual Studio. These instructions have only been tested with Visual Studio 2008.<br>

<h3>Check-in Rules</h3>

If you have been granted developer access, please adhere to the following rules:<br>

<ol>

<li>Do not check in code that will not build. </li><li>All code should be formatted using the &quot;Regions&quot; snippet. </li><li>All public and/or protected members should have a fully populated XML comment.

</li><li>All check-in&#39;s must have a comment - please make it relevant. </li><li>Check-in comment should have a project prefix. For example, prefix check-in descriptions for the Synchrophasor project with &quot;Synchrophasor: &quot;.

</li><li>Do not leave debug code in the system unless it is properly regioned (#if DEBUG).

</li><li>Do not check-out all files in a solution and/or project. </li><li>Keep total number of files checked-out to the absolute minimum needed. </li><li>If possible, keep files checked-out within the same solution. </li><li>Don&#39;t keep files checked-out for an excessive period of time. Shelve changes before you go on vacation or change projects and uncheck &quot;Preserve pending changes locally&quot;.

</li><li>Do not check-in unfinished work - shelve the changes instead remembering to uncheck &quot;Preserve pending changes locally&quot;.

</li><li>If multiple developers will be working on a large portion of code that will need to be checked-out for a long time, please contact the coordinators to create a branch for the project.

</li><li>Please contact one of the project coordinators before adding a new project to any of the solutions so they will have an idea of what&#39;s being added and why.

</li><li>Without prior coordination large contributions should be posted as a &quot;patch&quot; so it can be properly reviewed.</li></ol>

<br>

Note that some of the rules could be enforced by TFS but the codeplex TFS is a shared system, so for now we are simply using the honor system.<br>

</div>

</div>

<div id="footer">

<hr />



</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


