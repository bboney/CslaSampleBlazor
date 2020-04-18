﻿--region [dbo].[spseNavigationInsert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Text Templates
-- Template:       CRUDTenantStoredProcedures.tt
-- Procedure Name: [dbo].[spseNavigationInsert]
-- Date Generated: Wednesday, June 27, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[spseNavigationInsert]
		@CreatedByUserKey int,
		@HasChildren bit = 0,
		@IsPrivilegeRequired bit,
		@Name nvarchar(200),
		@NavigationId nvarchar(50),
		@NavigationType int,
		@ParentNavigationKey int,
		@Sequence int,
		@SpriteCssClass nvarchar(50),
		@Url nvarchar(200),
		@NewNavigationKey int output,
		@NewLastChanged timestamp output
AS

SET NOCOUNT ON

INSERT INTO [dbo].[tseNavigation] (
	[CreatedByUserKey],
	[CreatedOnDate],
	[HasChildren],
	[IsPrivilegeRequired],
	[Name],
	[NavigationId],
	[NavigationType],
	[ParentNavigationKey],
	[Sequence],
	[SpriteCssClass],
	[Url]
) VALUES (
	@CreatedByUserKey,
	getdate(),
	@HasChildren,
	@IsPrivilegeRequired,
	@Name,
	@NavigationId,
	@NavigationType,
	@ParentNavigationKey,
	@Sequence,
	@SpriteCssClass,
	@Url
)

SET @NewNavigationKey = SCOPE_IDENTITY()

SELECT @NewLastChanged = LastChanged
FROM [dbo].[tseNavigation]
WHERE NavigationKey = @NewNavigationKey

--endregion

GO