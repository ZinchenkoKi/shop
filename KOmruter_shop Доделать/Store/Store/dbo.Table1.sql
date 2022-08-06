CREATE TABLE [dbo].[Pokupateli]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [Surname] VARCHAR(50) NULL, 
    [Patronymic] VARCHAR(50) NULL, 
    [Born_date] DATE NULL, 
    [Adress] VARCHAR(50) NULL
)
