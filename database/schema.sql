IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [CustomerName] nvarchar(150) NOT NULL,
    [Address] nvarchar(250) NOT NULL,
    [City] nvarchar(100) NOT NULL,
    [PostCode] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

CREATE TABLE [Items] (
    [Id] int NOT NULL IDENTITY,
    [ItemCode] nvarchar(50) NOT NULL,
    [Description] nvarchar(250) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
);

CREATE TABLE [SalesOrders] (
    [Id] int NOT NULL IDENTITY,
    [OrderNumber] nvarchar(50) NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_SalesOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SalesOrders_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [SalesOrderItems] (
    [Id] int NOT NULL IDENTITY,
    [SalesOrderId] int NOT NULL,
    [ItemId] int NOT NULL,
    [Note] nvarchar(500) NULL,
    [Quantity] decimal(18,2) NOT NULL,
    [TaxRate] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_SalesOrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SalesOrderItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SalesOrderItems_SalesOrders_SalesOrderId] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrders] ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE INDEX [IX_Items_ItemCode] ON [Items] ([ItemCode]);

CREATE INDEX [IX_SalesOrderItems_ItemId] ON [SalesOrderItems] ([ItemId]);

CREATE INDEX [IX_SalesOrderItems_SalesOrderId] ON [SalesOrderItems] ([SalesOrderId]);

CREATE INDEX [IX_SalesOrders_ClientId] ON [SalesOrders] ([ClientId]);

CREATE UNIQUE INDEX [IX_SalesOrders_OrderNumber] ON [SalesOrders] ([OrderNumber]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260704025340_InitialCreate', N'10.0.9');

COMMIT;
GO

