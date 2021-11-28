CREATE OR ALTER PROCEDURE AppRecords.SaveItem
	@ItemID INT,
	@Name NVARCHAR(128),
	@UnitPrice INT,
	@Description NVARCHAR(256),
	@BaseWeight INT,
	@WeightType NVARCHAR(32),
	@QuantityMin INT,
	@QuantityMax INT,
	@RelativeChance INT
AS

MERGE AppRecords.Item I
USING (
	VALUES(@ItemID,@Name,@UnitPrice,@BaseWeight,@WeightType,
	@QuantityMin,@QuantityMax,@Description,@RelativeChance)
	) CTE(ItemID,[Name],UnitPrice,BaseWeight,WeightType,
	QuantityMin,QuantityMax,[Description],RelativeChance)
	ON I.ItemID = CTE.ItemID
WHEN MATCHED THEN
	UPDATE
	SET
		[Name] = CTE.[Name],
		UnitPrice = CTE.UnitPrice,
		[Description] = CTE.[Description],
		BaseWeight = CTE.BaseWeight,
		WeightType = CTE.WeightType,
		QuantityMin = CTE.QuantityMin,
		QuantityMax = CTE.QuantityMax,
		RelativeChance = CTE.RelativeChance
WHEN NOT MATCHED THEN
	INSERT(ItemID,[Name],UnitPrice,BaseWeight,WeightType,
	QuantityMin,QuantityMax,[Description],RelativeChance)
	VALUES(@ItemID,@Name,@UnitPrice,@BaseWeight,@WeightType,
	@QuantityMin,@QuantityMax,@Description,@RelativeChance);
GO