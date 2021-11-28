CREATE OR ALTER PROCEDURE GeneratedItems.SaveCreatedEnchantment
	@CreatedEnchantmentID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingCategoryName NVARCHAR(128),
	@Cost INT,
	@WeightFactor DECIMAL(5,2),
	@PowerReserveType NVARCHAR(64),
	@PowerReserveAmount INT
AS

MERGE GeneratedItems.CreatedEnchantment CE
USING (
	VALUES(@CreatedEnchantmentID,@Name,@Description,@GeneratingCategoryName,
	@Cost,@WeightFactor,@PowerReserveType,@PowerReserveAmount)
	) CTE(CreatedEnchantmentID,[Name],[Description],GeneratingCategoryName,
	Cost,WeightFactor,PowerReserveType,PowerReserveAmount)
	ON CE.CreatedEnchantmentID = CTE.CreatedEnchantmentID
WHEN MATCHED THEN
	UPDATE
	SET
		[Name] = CTE.[Name],
		[Description] = CTE.[Description],
		GeneratingCategoryName = CTE.GeneratingCategoryName,
		Cost = CTE.Cost,
		WeightFactor = CTE.WeightFactor,
		PowerReserveType = CTE.PowerReserveType,
		PowerReserveAmount = CTE.PowerReserveAmount
WHEN NOT MATCHED THEN
	INSERT(CreatedEnchantmentID,[Name],[Description],GeneratingCategoryName,
	Cost,WeightFactor,PowerReserveType,PowerReserveAmount)
	VALUES(@CreatedEnchantmentID,@Name,@Description,@GeneratingCategoryName,
	@Cost,@WeightFactor,@PowerReserveType,@PowerReserveAmount);
GO