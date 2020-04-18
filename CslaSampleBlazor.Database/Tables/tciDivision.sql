CREATE TABLE [dbo].[tciDivision]
(
	[DivisionKey]		INT NOT NULL IDENTITY,
	[CreatedByUserKey]  INT            NULL,
    [CreatedOnDate]     DATETIME       NULL,
	[DivisionId]		NVARCHAR(50) NOT NULL, 
	[DivisionValue]		INT NOT NULL DEFAULT(1),
	[LastChanged]		ROWVERSION NULL,
	[ModifiedByUserKey] INT            NULL,
    [ModifiedOnDate]    DATETIME       NULL,
	[Name]				NVARCHAR(200) NOT NULL, 
    CONSTRAINT [PK_tciDivision] PRIMARY KEY ([DivisionKey]),
)

GO

CREATE UNIQUE INDEX [IX_tciDivision_DivisionId] ON [dbo].[tciDivision] ([DivisionId])
