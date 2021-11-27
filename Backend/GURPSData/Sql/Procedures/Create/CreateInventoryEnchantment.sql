CREATE OR ALTER PROCEDURE GeneratedItems.CreateInventoryEnchantment
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingCategoryName NVARCHAR(128),
	@Cost INT,
	@WeightFactor DECIMAL(5,2),
	@PowerReserveType NVARCHAR(64),
	@PowerReserveAmount INT,
	@CreatedEnchantmentID INT OUTPUT
AS

INSERT GeneratedItems.CreatedEnchantment([Name],[Description],GeneratingCategoryName,[Cost],WeightFactor,PowerReserveType,PowerReserveAmount)
VALUES(@Name,@Description,@GeneratingCategoryName,@Cost,@WeightFactor,@PowerReserveType,@PowerReserveAmount);

SET @CreatedEnchantmentID = SCOPE_IDENTITY();
GO