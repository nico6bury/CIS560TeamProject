CREATE OR ALTER PROCEDURE AppRecords.CreateEnchantmentCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@RelativeChance INT,
	@EnchantmentCategoryID INT OUTPUT
AS

INSERT AppRecords.EnchantmentCategory(OwningUserID,[Name],[Description],RelativeChance)
VALUES(@OwningUserID,@Name,@Description,@RelativeChance);

SET @EnchantmentCategoryID = SCOPE_IDENTITY();
GO