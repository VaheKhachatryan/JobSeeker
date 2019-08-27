/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

print 'Deploying Seed Data...'
go
:r .\SeedData\InitializeCategories.sql
go

:r .\SeedData\InitializeCountries.sql
go

:r .\SeedData\InitializeEmploymentTypes.sql
go

:r .\SeedData\InitializeCities.sql
go