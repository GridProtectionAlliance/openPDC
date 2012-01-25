Database Updates
---------------------------------------

Updating the databases in openPDC requires a number of steps. At this time,
there are 5 different databases in openPDC. Four (MySQL, Oracle, SQL Server, 
and SQLite) require editing their respective openPDC.sql files. SQLite requires
running a script. Access is more involved. We'll start with the four standard
databases

MySQL, Oracle, SQL Server, and SQLite
1)  Open Synchrophasor.sln
2)  In the 'Data' folder, select the subfolder for the database you wish to 
    edit
3)  In that folder, open the openPDC.sql file
4)  Modify as needed
5)  Repeat steps 2-4 for the remaining databases

After completely those updates, we'll move on to Access.
6)  Close the solution. If the solution is not closed, the access files have a 
    habit of disappearing from the solution file, requiring you to re-add them
7)  Open the openPDC.mdb file in Access, and make your changes
8)  Duplicate your changes in openPDC-InitialDataSet.mdb and 
    openPDC-SampleDataSet.mdb
9)  Reopen the solution, and commit your changes

You're not done yet; one more step to initialise the SQLite databases

10) Close the solution to avoid any conflicts
11) Navigate to the Data\SQLite folder
12) Run db-update.bat
13) The update script will ask if you want to check in the database updates.
    Select Yes.

Your database changes are now complete!