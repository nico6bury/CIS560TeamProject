CREATE OR ALTER PROCEDURE AppRecords.CreateItem
	@ItemCategoryID INT,
	@Name NVARCHAR(128),
	@UnitPrice INT,
	@BaseWeight INT,
	@WeightType NVARCHAR(32),
	@QuantityMin INT,
	@QuantityMax INT,
	@Description NVARCHAR(256),
	@RelativeChance INT,
	@ItemID INT OUTPUT
AS

INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description],RelativeChance)
VALUES(@Name,@UnitPrice,@BaseWeight,@WeightType,@QuantityMin,@QuantityMax,@Description,@RelativeChance);

SET @ItemID = SCOPE_IDENTITY();

INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name])
VALUES(@ItemCategoryID,@ItemID,N'NULL');
GO