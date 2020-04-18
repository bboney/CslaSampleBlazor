﻿--region [dbo].[spsoSalesOrderTypeUpdate]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Text Templates
-- Template:       CRUDTenantStoredProcedures.tt
-- Procedure Name: [dbo].[spsoSalesOrderTypeUpdate]
-- Date Generated: Friday, March 27, 2020
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[spsoSalesOrderTypeUpdate]
		@SalesOrderTypeKey int,
		@ModifiedByUserKey int,
		@Name nvarchar(200),
		@SalesOrderTypeId nvarchar(50),
		@SalesOrderTypeValue smallint,
		@LastChanged timestamp,
		@NewLastChanged timestamp OUTPUT
AS

SET NOCOUNT ON

UPDATE [dbo].[tsoSalesOrderType] SET
		[ModifiedByUserKey] = @ModifiedByUserKey,
		ModifiedOnDate = getdate(),
		[Name] = @Name,
		[SalesOrderTypeId] = @SalesOrderTypeId,
		[SalesOrderTypeValue] = @SalesOrderTypeValue
WHERE
	[tsoSalesOrderType].[SalesOrderTypeKey] = @SalesOrderTypeKey
AND	
	[tsoSalesOrderType].[LastChanged] = @LastChanged

IF	@@ROWCOUNT = 0	
	BEGIN
		RAISERROR('Row has been edited by another user.  Your changes will be lost.',16,1)
	END
	
SELECT 
	@NewLastChanged = LastChanged
FROM 
	[dbo].[tsoSalesOrderType]
WHERE 	
	[tsoSalesOrderType].[SalesOrderTypeKey] = @SalesOrderTypeKey

--endregion

GO	