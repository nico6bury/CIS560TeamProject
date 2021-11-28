CREATE OR ALTER PROCEDURE AppRecords.CreateEnchantmentCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@RelativeChance INT,
	@EnchantmentCategoryID INT OUTPUT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT AppRecords.EnchantmentCategory(OwningUserID,[Name],[Description],RelativeChance)
VALUES(@OwningUserID,@Name,@Description,@RelativeChance);

SET @EnchantmentCategoryID = SCOPE_IDENTITY();
SET @CreatedOn = (SELECT EC.CreatedOn FROM AppRecords.EnchantmentCategory EC WHERE EC.CreatedOn = @CreatedOn);
GO