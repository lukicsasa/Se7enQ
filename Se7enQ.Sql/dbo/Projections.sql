CREATE TABLE [dbo].[Projections]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [3DImage] NVARCHAR(MAX) NOT NULL, 
    [CorrectProjection] NVARCHAR(MAX) NOT NULL, 
    [WrongProjection1] NVARCHAR(MAX) NOT NULL, 
    [WrongProjection2] NVARCHAR(MAX) NOT NULL, 
    [WrongProjection3] NVARCHAR(MAX) NOT NULL
)
