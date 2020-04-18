CREATE TABLE [dbo].[tsoSalesOrderType]
(
	[SalesOrderTypeKey]		INT				NOT NULL	IDENTITY,
	[CreatedByUserKey]		INT				NULL,
    [CreatedOnDate]			DATETIME		NULL,
	[LastChanged]			ROWVERSION		NULL,
	[ModifiedByUserKey]		INT				NULL,
    [ModifiedOnDate]		DATETIME		NULL,
	[Name]					NVARCHAR(200)	NOT NULL,
	[SalesOrderTypeId]		NVARCHAR(50)	NOT NULL,
	[SalesOrderTypeValue]	SMALLINT		NOT NULL, 
    CONSTRAINT [PK_tsoSalesOrderType] PRIMARY KEY ([SalesOrderTypeKey])
)

GO

CREATE UNIQUE INDEX [IX_tsoSalesOrderType_SalesOrderTypeId] ON [dbo].[tsoSalesOrderType] ([SalesOrderTypeId])
