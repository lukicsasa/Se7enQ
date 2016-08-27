CREATE TABLE [dbo].[WordDefinition]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [CorrectAnswer] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer1] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer2] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer3] NVARCHAR(MAX) NOT NULL, 
    [Word] NVARCHAR(MAX) NOT NULL
)
