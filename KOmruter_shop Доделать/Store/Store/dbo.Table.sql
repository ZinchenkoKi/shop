CREATE TABLE [dbo].[Products] (
    [Id]       INT          NOT NULL IDENTITY,
    [Name]     VARCHAR (50) NULL,
    [Price]    INT          NULL,
    [Quantity] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

