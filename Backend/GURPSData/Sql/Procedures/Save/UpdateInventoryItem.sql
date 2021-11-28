CREATE OR ALTER PROCEDURE GeneratedItems.SaveInventoryItem
	@InventoryID INT,
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingTableName NVARCHAR(128),
	@Quantity INT,
	@UnitPrice INT,
	@BaseWeight INT,
	@WeightType NVARCHAR(32)
AS

MERGE GeneratedItems.InventoryItem II
USING (
	VALUES(@InventoryID,@OwningUserID,@Name,@Description,
	@GeneratingTableName,@Quantity,@UnitPrice,@BaseWeight,@WeightType)
	) CTE(InventoryID,OwningUserID,[Name],[Description],
	GeneratingTableName,Quantity,UnitPrice,BaseWeight,WeightType)
	ON II.InventoryID = CTE.InventoryID
WHEN MATCHED THEN
	UPDATE
	SET
		OwningUserID = CTE.OwningUserID,
		[Name] = CTE.[Name],
		[Description] = CTE.[Description],
		GeneratingTableName = CTE.GeneratingTableName,
		Quantity = CTE.Quantity,
		UnitPrice = CTE.UnitPrice,
		BaseWeight = CTE.BaseWeight,
		WeightType = CTE.WeightType
WHEN NOT MATCHED THEN
	INSERT(InventoryID,OwningUserID,[Name],[Description],
	GeneratingTableName,Quantity,UnitPrice,BaseWeight,WeightType)
	VALUES(@InventoryID,@OwningUserID,@Name,@Description,
	@GeneratingTableName,@Quantity,@UnitPrice,@BaseWeight,@WeightType);
GO