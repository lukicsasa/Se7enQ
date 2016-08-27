CREATE TABLE [dbo].[WordSynonyms]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [CorrectAnswer1] NVARCHAR(MAX) NOT NULL, 
    [CorrectAnswer2] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer1] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer2] NVARCHAR(MAX) NOT NULL
)
