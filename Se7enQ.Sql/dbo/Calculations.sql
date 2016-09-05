CREATE TABLE [dbo].[Calculations]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Expression] NVARCHAR(MAX) NOT NULL, 
    [CorrectResult] INT NOT NULL, 
    [WrongResult1] INT NOT NULL, 
    [WrongResult2] INT NOT NULL, 
    [WrongResult3] INT NOT NULL
)
