CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PayrollNumber] NVARCHAR(50) NOT NULL, 
    [Forename] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NOT NULL, 
    [Phone] NVARCHAR(20) NOT NULL, 
    [CellPhone] NVARCHAR(20) NOT NULL, 
    [StreetAddress] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Postcode] NVARCHAR(20) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
