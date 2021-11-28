CREATE OR ALTER PROCEDURE AppRecords.ItemEnhancementSummary
	@ItemCategoryID INT,
	@EnchantmentCategoryID INT,
	@EmbellishmentCategoryID INT
AS
SELECT I.ItemID, I.[Name] AS ItemName, EN.EnchantmentID, EN.[Name] AS EnchantmentName,
EM.EmbellishmentID, EM.[Name] AS EmbellishmentName,
((I.UnitPrice * (1 + EM.CostFactor)) + EN.Cost) AS Cost,
(I.BaseWeight * (1 + EM.WeightFactor + EN.WeightFactor)) AS [Weight]
FROM AppRecords.Item I INNER JOIN AppRecords.ItemSubcategory ISC ON
I.ItemID = ISC.ItemID INNER JOIN AppRecords.ItemCategory IC ON
ISC.ItemSubcategoryID = IC.ItemCategoryID INNER JOIN AppRecords.Enchantment EN ON
EN.EnchantmentCategoryID = @EnchantmentCategoryID INNER JOIN AppRecords.Embellishment EM
ON EM.EmbellishmentCategoryID = @EmbellishmentCategoryID
WHERE IC.ItemCategoryID = @ItemCategoryID;
GO