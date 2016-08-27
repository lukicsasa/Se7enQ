CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstPlayerId] INT NOT NULL, 
    [SecondPlayerId] INT NOT NULL, 
    [FirstPlayerPoints] NUMERIC NOT NULL, 
    [SecondPlayerPoints] NUMERIC NOT NULL, 
    [DatePlayed] DATETIME NOT NULL, 
    CONSTRAINT [FK_Game_User1] FOREIGN KEY ([FirstPlayerId]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT [FK_Game_User2] FOREIGN KEY ([SecondPlayerId]) REFERENCES [dbo].[User]([Id])

)
