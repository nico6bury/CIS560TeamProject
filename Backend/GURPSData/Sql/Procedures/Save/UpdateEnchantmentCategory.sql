CREATE OR ALTER PROCEDURE AppRecords.SaveEnchantmentCategory
	@EnchantmentCategoryID INT,
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@RelativeChance INT,
	@Description NVARCHAR(256)
AS

MERGE AppRecords.EnchantmentCategory EC
USING (
	VALUES(@EnchantmentCategoryID,@OwningUserID,@Name,
	@RelativeChance,@Description)
	) CTE(EnchantmentCategoryID,OwningUserID,[Name],
	RelativeChance,[Description])
	ON EC.EnchantmentCategoryID = CTE.EnchantmentCategoryID
WHEN MATCHED THEN
	UPDATE
	SET
		OwningUserID = CTE.OwningUserID,
		[Name] = CTE.[Name],
		RelativeChance = CTE.RelativeChance,
		[Description] = CTE.[Description]
WHEN NOT MATCHED THEN
	INSERT(EnchantmentCategoryID,OwningUserID,[Name],
	RelativeChance,[Description])
	VALUES(@EnchantmentCategoryID,@OwningUserID,@Name,
	@RelativeChance,@Description);
GO