CREATE TABLE [dbo].[GeneralKnowledge]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [CorrectAnswer] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer1] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer2] NVARCHAR(MAX) NOT NULL, 
    [WrongAnswer3] NVARCHAR(MAX) NOT NULL
)
