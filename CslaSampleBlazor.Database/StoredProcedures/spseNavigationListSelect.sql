﻿--region [dbo].[spseNavigationListSelect]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Text Templates
-- Template:       CRUDTenantStoredProcedures.tt
-- Procedure Name: [dbo].[spseNavigationListSelect]
-- Date Generated: Wednesday, June 27, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[spseNavigationListSelect]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

SELECT
	[tseNavigation].[NavigationKey],
	[tseNavigation].[CreatedByUserKey],
	CreatedByUser.UserId AS CreatedByUserId,
	[tseNavigation].[CreatedOnDate],
	[tseNavigation].[HasChildren],
	[tseNavigation].[IsPrivilegeRequired],
	[tseNavigation].[LastChanged],
	[tseNavigation].[ModifiedByUserKey],
	ModifiedByUser.UserId AS ModifiedByUserId,
	[tseNavigation].[ModifiedOnDate],
	[tseNavigation].[Name],
	[tseNavigation].[NavigationId],
	[tseNavigation].[NavigationType],
	[tseNavigation].[ParentNavigationKey],
	[tseNavigation].[Sequence],
	[tseNavigation].[SpriteCssClass],
	[tseNavigation].[Url]
FROM
	[dbo].[tseNavigation]
LEFT JOIN
	[dbo].[tseUser] CreatedByUser
ON
	[dbo].[tseNavigation].[CreatedByUserKey] = CreatedByUser.UserKey
LEFT JOIN
	[dbo].[tseUser] ModifiedByUser
ON
	[dbo].[tseNavigation].[ModifiedByUserKey] = ModifiedByUser.UserKey
ORDER BY
	[tseNavigation].[NavigationId]
--endregion

GO