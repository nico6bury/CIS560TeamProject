CREATE OR ALTER PROCEDURE AppRecords.SaveEnchantment
	@EnchantmentID INT,
	@EnchantmentCategoryID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@Cost INT,
	@WeightFactor DECIMAL(5,2),
	@RelativeChance INT,
	@PowerReserveType NVARCHAR(64),
	@PowerReserveAmount INT
AS

MERGE AppRecords.Enchantment E
USING (
	VALUES(@EnchantmentID,@EnchantmentCategoryID,@Name,@Description,@Cost,
	@WeightFactor,@RelativeChance,@PowerReserveType,@PowerReserveAmount)
	) CTE(EnchantmentID,EnchantmentCategoryID,[Name],[Description],Cost,
	WeightFactor,RelativeChance,PowerReserveType,PowerReserveAmount)
	ON E.EnchantmentID = CTE.EnchantmentID
WHEN MATCHED THEN
	UPDATE
	SET
		EnchantmentCategoryID = CTE.EnchantmentCategoryID,
		[Name] = CTE.[Name],
		[Description] = CTE.[Description],
		Cost = CTE.Cost,
		WeightFactor = CTE.WeightFactor,
		RelativeChance = CTE.RelativeChance,
		PowerReserveType = CTE.PowerReserveType,
		PowerReserveAmount = CTE.PowerReserveAmount
WHEN NOT MATCHED THEN
	INSERT(EnchantmentID,EnchantmentCategoryID,[Name],[Description],Cost,
	WeightFactor,RelativeChance,PowerReserveType,PowerReserveAmount)
	VALUES(@EnchantmentID,@EnchantmentCategoryID,@Name,@Description,@Cost,
	@WeightFactor,@RelativeChance,@PowerReserveType,@PowerReserveAmount);
GO