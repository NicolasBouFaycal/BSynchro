Set up the Project :
1) Pull the Master Branch
2) Open Microsoft SQL Server Management Studio
3) Create the New Db called BSynchro (if the DB is created using another name , please change the extention string Database=... in the appsettings.json  )
4) Go to ASP .NET Core Web API then open Package manager console (it can be foud under the tools->Nuget Package Manager->package manager console)
5) The migration folder is present under the BSynchro.Persistence Project  so no need to add migration
6) Run in Package Manager Console (Update-Database -Project BSynchro.Persistence -StartupProject BSynchro.API)
7) The Db tables will be created then input some data to the "Customer" table from  Microsoft SQL Server Management Studio   (right click on the table then edit top 200 rows )
8) Now you can run the Backend Project and test the api's from swagger .
9) For Frontend, please find the Set up of angular project in README.md of the master branch in BSynchro-frontend Repository(https://github.com/NicolasBouFaycal/BSynchro-frontend)
10) All the Features and the Bonus are done ! 
