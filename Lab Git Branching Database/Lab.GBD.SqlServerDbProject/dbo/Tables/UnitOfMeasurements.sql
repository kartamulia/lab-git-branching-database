CREATE TABLE [dbo].[UnitOfMeasurements] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UnitOfMeasurements] PRIMARY KEY CLUSTERED ([Id] ASC)
);

