CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Username] NVARCHAR(MAX) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [ImageUrl] NVARCHAR(MAX) NULL, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [Admin] BIT NOT NULL DEFAULT 0 
)
