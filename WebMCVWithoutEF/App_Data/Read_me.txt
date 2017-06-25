CREATE TABLE [dbo].[Product] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (50)    NULL,
    [price]       DECIMAL (18, 2) NULL,
    [count]       INT             NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

