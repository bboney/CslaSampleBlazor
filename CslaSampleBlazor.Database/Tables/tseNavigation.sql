CREATE TABLE [dbo].[tseNavigation]
(
	[NavigationKey] INT NOT NULL IDENTITY,
	[CreatedByUserKey]  INT            NULL,
    [CreatedOnDate]     DATETIME       NULL,
	[HasChildren]		BIT				NOT NULL DEFAULT (0),
	[IsPrivilegeRequired] BIT NOT NULL DEFAULT(0),
	[LastChanged] ROWVERSION NULL,
	[ModifiedByUserKey] INT            NULL,
    [ModifiedOnDate]    DATETIME       NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[NavigationId] NVARCHAR(50) NOT NULL,
	[NavigationType] INT NOT NULL,
	[ParentNavigationKey] INT NULL,
	[Sequence] INT NOT NULL,
	[SpriteCssClass] NVARCHAR(1024) NULL,
	[Url] NVARCHAR(200) NULL, 
    CONSTRAINT [PK_tseNavigation] PRIMARY KEY ([NavigationKey])
)

GO

CREATE UNIQUE INDEX [IX_tseNavigation_NavigationId] ON [dbo].[tseNavigation] ([NavigationId])
