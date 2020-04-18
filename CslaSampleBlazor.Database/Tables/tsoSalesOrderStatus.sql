CREATE TABLE [dbo].[tsoSalesOrderStatus]
(
	[SalesOrderStatusKey]	INT				NOT NULL	IDENTITY,
	[CreatedByUserKey]		INT				NULL,
    [CreatedOnDate]			DATETIME		NULL,
	[LastChanged]			ROWVERSION		NULL,
	[ModifiedByUserKey]		INT				NULL,
    [ModifiedOnDate]		DATETIME		NULL,
	[Name]					NVARCHAR(200)	NOT NULL,
	[SalesOrderStatusId]	NVARCHAR(50)	NOT NULL,
	[SalesOrderStatusValue]	SMALLINT		NOT NULL, 
    CONSTRAINT [PK_tsoSalesOrderStatus] PRIMARY KEY ([SalesOrderStatusKey]), 
)

GO

CREATE UNIQUE INDEX [IX_tsoSalesOrderStatus_SalesOrderStatusId] ON [dbo].[tsoSalesOrderStatus] ([SalesOrderStatusId])
