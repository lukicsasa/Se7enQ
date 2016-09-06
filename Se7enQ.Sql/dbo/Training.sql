CREATE TABLE [dbo].[Training]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Calculations] BIT NOT NULL DEFAULT 0, 
    [GeneralKnowledge] BIT NOT NULL DEFAULT 0, 
    [LogicArray] BIT NOT NULL DEFAULT 0, 
    [Memory] BIT NOT NULL DEFAULT 0, 
    [Projections] BIT NOT NULL DEFAULT 0, 
    [WordDefinition] BIT NOT NULL DEFAULT 0, 
    [WordSynonyms] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Training_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

)
