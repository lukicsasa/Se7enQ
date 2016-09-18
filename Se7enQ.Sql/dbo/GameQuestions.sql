﻿CREATE TABLE [dbo].[GameQuestions]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [WordSynonyms1] INT NOT NULL, 
    [WordSynonyms2] INT NOT NULL, 
    [WordSynonyms3] INT NOT NULL, 
    [WordSynonyms4] INT NOT NULL, 
    [WordDefinitions1] INT NOT NULL, 
    [WordDefinitions2] INT NOT NULL, 
    [WordDefinitions3] INT NOT NULL, 
    [WordDefinitions4] INT NULL, 
    [LogicArray1] INT NULL, 
    [LogicArray2] INT NOT NULL, 
    [LogicArray3] INT NOT NULL, 
    [LogicArray4] INT NOT NULL, 
    [Calculations1] INT NOT NULL, 
    [Calculations2] INT NOT NULL, 
    [Calculations3] INT NOT NULL, 
    [Calculations4] INT NOT NULL, 
    [GeneralKnowledge1] INT NOT NULL, 
    [GeneralKnowledge2] INT NOT NULL, 
    [GeneralKnowledge3] INT NOT NULL, 
    [GeneralKnowledge4] INT NOT NULL,
	CONSTRAINT [FK_Synonyms1_Questions] FOREIGN KEY ([WordSynonyms1]) REFERENCES [dbo].[WordSynonyms]([Id]),
	CONSTRAINT [FK_Synonyms2_Questions] FOREIGN KEY ([WordSynonyms2]) REFERENCES [dbo].[WordSynonyms]([Id]),
	CONSTRAINT [FK_Synonyms3_Questions] FOREIGN KEY ([WordSynonyms3]) REFERENCES [dbo].[WordSynonyms]([Id]),
	CONSTRAINT [FK_Synonyms4_Questions] FOREIGN KEY ([WordSynonyms4]) REFERENCES [dbo].[WordSynonyms]([Id]),
	CONSTRAINT [FK_Definitions1_Questions] FOREIGN KEY ([WordDefinitions1]) REFERENCES [dbo].[WordDefinition]([Id]),
	CONSTRAINT [FK_Definitions2_Questions] FOREIGN KEY ([WordDefinitions2]) REFERENCES [dbo].[WordDefinition]([Id]),
	CONSTRAINT [FK_Definitions3_Questions] FOREIGN KEY ([WordDefinitions3]) REFERENCES [dbo].[WordDefinition]([Id]),
	CONSTRAINT [FK_Definitions4_Questions] FOREIGN KEY ([WordDefinitions4]) REFERENCES [dbo].[WordDefinition]([Id]),
	CONSTRAINT [FK_LogicArray1_Questions] FOREIGN KEY ([LogicArray1]) REFERENCES [dbo].[LogicArray]([Id]),
	CONSTRAINT [FK_LogicArray2_Questions] FOREIGN KEY ([LogicArray2]) REFERENCES [dbo].[LogicArray]([Id]),
	CONSTRAINT [FK_LogicArray3_Questions] FOREIGN KEY ([LogicArray3]) REFERENCES [dbo].[LogicArray]([Id]),
	CONSTRAINT [FK_LogicArray4_Questions] FOREIGN KEY ([LogicArray4]) REFERENCES [dbo].[LogicArray]([Id]),
	CONSTRAINT [FK_Calculations1_Questions] FOREIGN KEY ([Calculations1]) REFERENCES [dbo].[Calculations]([Id]),
	CONSTRAINT [FK_Calculations2_Questions] FOREIGN KEY ([Calculations2]) REFERENCES [dbo].[Calculations]([Id]),
	CONSTRAINT [FK_Calculations3_Questions] FOREIGN KEY ([Calculations3]) REFERENCES [dbo].[Calculations]([Id]),
	CONSTRAINT [FK_Calculations4_Questions] FOREIGN KEY ([Calculations4]) REFERENCES [dbo].[Calculations]([Id]),
	CONSTRAINT [FK_GeneralKnowledge1_Questions] FOREIGN KEY ([GeneralKnowledge1]) REFERENCES [dbo].[GeneralKnowledge]([Id]),
	CONSTRAINT [FK_GeneralKnowledge2_Questions] FOREIGN KEY ([GeneralKnowledge2]) REFERENCES [dbo].[GeneralKnowledge]([Id]),
	CONSTRAINT [FK_GeneralKnowledge3_Questions] FOREIGN KEY ([GeneralKnowledge3]) REFERENCES [dbo].[GeneralKnowledge]([Id]),
	CONSTRAINT [FK_GeneralKnowledge4_Questions] FOREIGN KEY ([GeneralKnowledge4]) REFERENCES [dbo].[GeneralKnowledge]([Id]),
)

