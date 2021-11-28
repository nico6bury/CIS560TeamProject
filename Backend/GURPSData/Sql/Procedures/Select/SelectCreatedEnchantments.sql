CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveAllCreatedEnchantments
AS
SELECT CE.CreatedEnchantmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.[Cost],CE.WeightFactor,CE.PowerReserveType,CE.PowerReserveAmount
FROM GeneratedItems.CreatedEnchantment CE;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveCreatedEnchantmentsForUser
	@UserID INT
AS
SELECT DISTINCT CE.CreatedEnchantmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.[Cost],CE.WeightFactor,CE.PowerReserveType,CE.PowerReserveAmount
FROM GeneratedItems.CreatedEnchantment CE INNER JOIN GeneratedItems.EnchantmentRef ER ON
CE.CreatedEnchantmentID = ER.CreatedEnchantmentID LEFT JOIN GeneratedItems.InventoryItem II ON
ER.InventoryID = II.InventoryID
WHERE II.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveCreatedEnchantmentsForID
	@CreatedEnchantmentID INT
AS
SELECT CE.CreatedEnchantmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.[Cost],CE.WeightFactor,CE.PowerReserveType,CE.PowerReserveAmount
FROM GeneratedItems.CreatedEnchantment CE
WHERE CE.CreatedEnchantmentID = @CreatedEnchantmentID;
GO
