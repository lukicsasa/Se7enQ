﻿CREATE TABLE [dbo].[LogicArray]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Array] NVARCHAR(MAX) NOT NULL, 
    [CorrectNumber] INT NOT NULL, 
    [WrongNumber1] INT NOT NULL, 
    [WrongNumber2] INT NOT NULL, 
    [WrongNumber3] INT NOT NULL
)
