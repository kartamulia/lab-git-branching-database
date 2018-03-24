CREATE TABLE [dbo].[InventoryItems] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX)  NULL,
    [UnitOfMeasure] INT             NOT NULL,
    [UnitPrice]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InventoryItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

