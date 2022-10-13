# BugReportTest
This repository contains a sample project created with Blazor Web-Assembly (hosted) .NET 6.0.402 with a bug in the debugger. The bug was found while using Visual Studio 2022 Enterprise. 

**Bug Description:**     
While debugging, the client project shows newly instantiated object values as null when they do not behave as such. Instructions to replicate this while debugging are left as comments on the the BugReportTest.Client/Services/TestDataService.cs file. Newly instantiated objects with duplicate names as other objects, in the method, appear null while debugging. If they were truly null, then null reference exceptions would be thrown when calling methods on the object. They return the correct data to the UI, so there is no way for the objects to actually be null. 

**Bug "fix":**     
Changing the names of objects in a method to be unique, (meaning no other objects in that method or class file have the same name) makes the bug disappear. This only occurs in the client project.

## Startup Instructions
1. Clone into local repository
2. Set the startup project as BugReportTest.Server 
3. Launch the project with the BugReportTest.Server launch profile
4. Navigate to the BugReportTest.Client/Services/TestDataService.cs file and read comment instructions for where to place breakpoints
5. Click the "click me" button to load sample data and hit appropriate breakpoints
