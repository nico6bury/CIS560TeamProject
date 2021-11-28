CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllEnchantments
AS
SELECT E.EnchantmentID,E.EnchantmentCategoryID,E.[Name],E.[Description],E.[Cost],
E.WeightFactor,E.RelativeChance,E.PowerReserveType,E.PowerReserveAmount,E.CreatedOn
FROM AppRecords.Enchantment E
WHERE E.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEnchantmentsForUser
	@UserID INT
AS
SELECT E.EnchantmentID,E.EnchantmentCategoryID,E.[Name],E.[Description],E.[Cost],
E.WeightFactor,E.RelativeChance,E.PowerReserveType,E.PowerReserveAmount,E.CreatedOn
FROM AppRecords.Enchantment E INNER JOIN AppRecords.EnchantmentCategory EC ON
E.EnchantmentCategoryID = EC.EnchantmentCategoryID
WHERE E.IsActive = 1 AND EC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEnchantmentsForCategory
	@EnchantmentCategoryID INT
AS
SELECT E.EnchantmentID,E.EnchantmentCategoryID,E.[Name],E.[Description],E.[Cost],
E.WeightFactor,E.RelativeChance,E.PowerReserveType,E.PowerReserveAmount,E.CreatedOn
FROM AppRecords.Enchantment E
WHERE E.IsActive = 1 AND E.EnchantmentCategoryID = @EnchantmentCategoryID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEnchantmentsForID
	@EnchantmentID INT
AS
SELECT E.EnchantmentID,E.EnchantmentCategoryID,E.[Name],E.[Description],E.[Cost],
E.WeightFactor,E.RelativeChance,E.PowerReserveType,E.PowerReserveAmount,E.CreatedOn
FROM AppRecords.Enchantment E
WHERE E.IsActive = 1 AND E.EnchantmentID = @EnchantmentID;
GO
