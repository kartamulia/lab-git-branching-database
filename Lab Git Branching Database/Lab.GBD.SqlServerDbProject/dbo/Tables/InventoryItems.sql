CREATE TABLE [dbo].[InventoryItems] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (MAX)  NULL,
    [UnitOfMeasurementId] INT             NOT NULL,
    [UnitPrice]           DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InventoryItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InventoryItems_UnitOfMeasurements_UnitOfMeasurementId] FOREIGN KEY ([UnitOfMeasurementId]) REFERENCES [dbo].[UnitOfMeasurements] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_InventoryItems_UnitOfMeasurementId]
    ON [dbo].[InventoryItems]([UnitOfMeasurementId] ASC);

