/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[User] ([Username],[Password],[FirstName],[LastName],[DateCreated],[Email],[Playing],[ImageUrl])
VALUES ('admin','admin','Admin','Admin',GETDATE(),'admin@admin.com',0,null)

/*word definition dummy*/
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')
INSERT INTO [dbo].[WordDefinition] ([CorrectAnswer],[WrongAnswer1],[WrongAnswer2],[WrongAnswer3],[Word])
VALUES ('Neka Ga','Ovako','Sta cu','Ne mogu','Smisljam')