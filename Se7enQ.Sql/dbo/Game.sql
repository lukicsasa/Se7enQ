CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [FirstPlayerId] INT NOT NULL, 
    [SecondPlayerId] INT NULL, 
    [FirstPlayerPoints] NUMERIC NOT NULL DEFAULT 0, 
    [SecondPlayerPoints] NUMERIC NOT NULL DEFAULT 0, 
    [DatePlayed] DATETIME NOT NULL, 
    [GameQuestions] INT NULL, 
    [FirstPlayerAnswer] NCHAR(100) NULL, 
    [SecondPlayerAnswer] NCHAR(100) NULL, 
    CONSTRAINT [FK_Game_User1] FOREIGN KEY ([FirstPlayerId]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT [FK_Game_User2] FOREIGN KEY ([SecondPlayerId]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT [FK_Game_Questions] FOREIGN KEY ([GameQuestions]) REFERENCES [dbo].[GameQuestions]([Id])



)
