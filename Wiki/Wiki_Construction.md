# *openPDC* Wiki Construction
The following describes the general layout for the Wiki within the openPDC project repository.

## Folders and Content
### openPDC/Wiki
Wiki Root Folder
  * **Home.md** = Project Welcome and Overview.  Home.md is a candidate for the project's README.md document.
  * **Home.files/** = Subfolder Containing Wiki Home Page's Attachment Files
  * **Wiki_Index.md** = Table of Contents Style Directory of the Wiki Pages
  * **Wiki_Construction.md** = *This* Document

### openPDC/Wiki/Documents
Wiki Document Pages and Attachment Subfolders and Files
  * **{document_name}.md** = Wiki Document Pages
  * **{document_name}.files/** = Subfolder Containing Wiki Document Page's Attachment Files

### openPDC/Wiki/Archives/CodePlex
Legacy Original CodePlex Documentation Pages and Attachment Files
  * **{document_name}.html** = CodePlex Document Pages
  * **{document_name}.files/** = Subfolders Containing CodePlex Document Page's Attachment Files

## URL Links to Wiki Pages in the openPDC Repository
The openPDC Wiki is intended to be an independent subproject of the openPDC project.  A ***wiki*** branch is where all final wiki content should be committed before merging into the project ***master***.  This allows independent wiki authoring without affecting the project source code or build versions.
  * URL links related to wiki content should start with the following URL.
  **https://github.com/GridProtectionAlliance/openPDC/blob/master/**
    * For example, the URL for *This* document is:
      **https://github.com/GridProtectionAlliance/openPDC/blob/master/Wiki/Wiki_Construction.md**
    * These URLs only work after the ***wiki*** branch has been merged with the ***master***
  
---
Proposed Sep 5, 2015
Revised 20:22 EST
