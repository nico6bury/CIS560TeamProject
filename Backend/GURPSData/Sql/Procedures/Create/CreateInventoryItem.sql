CREATE OR ALTER PROCEDURE GeneratedItems.CreateInventoryItem
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingCategoryName NVARCHAR(128),
	@Quantity INT,
	@UnitPrice INT,
	@BaseWeight INT,
	@WeightType NVARCHAR(32),
	@InventoryItemID INT OUTPUT
AS

INSERT GeneratedItems.InventoryItem(OwningUserID,[Name],[Description],GeneratingTableName,Quantity,UnitPrice,BaseWeight,WeightType)
VALUES(@OwningUserID,@Name,@Description,@GeneratingCategoryName,@Quantity,@UnitPrice,@BaseWeight,@WeightType);

SET @InventoryItemID = SCOPE_IDENTITY();
GO