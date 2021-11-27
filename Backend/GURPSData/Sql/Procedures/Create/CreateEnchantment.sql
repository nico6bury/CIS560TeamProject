CREATE OR ALTER PROCEDURE AppRecords.CreateEnchantment
	@EnchantmentCategoryID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@Cost INT,
	@WeightFactor DECIMAL(5,2),
	@RelativeChance INT,
	@PowerReserveType NVARCHAR(64),
	@PowerReserveAmount INT,
	@EnchantmentID INT OUTPUT
AS

INSERT AppRecords.Enchantment(EnchantmentCategoryID,[Name],[Description],Cost,WeightFactor,RelativeChance,PowerReserveType,PowerReserveAmount)
VALUES(@EnchantmentCategoryID,@Name,@Description,@Cost,@WeightFactor,@RelativeChance,@PowerReserveType,@PowerReserveAmount);

SET @EnchantmentID = SCOPE_IDENTITY();
GO