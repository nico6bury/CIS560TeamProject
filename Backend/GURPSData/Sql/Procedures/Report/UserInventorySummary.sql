CREATE OR ALTER PROCEDURE GeneratedItems.UserInventorySummary
	@UserID INT
AS

SELECT II.[Name], II.GeneratingTableName, MIN(II.GeneratedOn) AS EarliestGeneration,
MAX(II.GeneratedOn) AS LatestGeneration, II.UnitPrice, II.BaseWeight,
(COUNT(II.InventoryID) * II.Quantity) AS NumberGenerated
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EmbellishmentRef EMR
ON II.InventoryID = EMR.InventoryID INNER JOIN GeneratedItems.EnchantmentRef ENR
ON II.InventoryID = ENR.InventoryID INNER JOIN GeneratedItems.CreatedEmbellishment CEM
ON EMR.CreatedEmbellishmentID = CEM.CreatedEmbellishmentID INNER JOIN
GeneratedItems.CreatedEnchantment ON ENR.CreatedEnchantmentID = ENR.CreatedEnchantmentID
WHERE II.OwningUserID = @UserID
GROUP BY II.[Name], II.GeneratingTableName, II.UnitPrice, II.BaseWeight, II.Quantity;

GO