CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveAllCreatedEmbellishments
AS
SELECT CE.CreatedEmbellishmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.CostFactor,CE.WeightFactor
FROM GeneratedItems.CreatedEmbellishment CE;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveCreatedEmbellishmentsForUser
	@UserID INT
AS
SELECT DISTINCT CE.CreatedEmbellishmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.CostFactor,CE.WeightFactor
FROM GeneratedItems.CreatedEmbellishment CE INNER JOIN GeneratedItems.EmbellishmentRef ER ON
CE.CreatedEmbellishmentID = ER.CreatedEmbellishmentID LEFT JOIN GeneratedItems.InventoryItem II ON
ER.InventoryID = II.InventoryID
WHERE II.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveCreatedEmbellishmentsForID
	@CreatedEmbellishmentID INT
AS
SELECT CE.CreatedEmbellishmentID,CE.[Name],CE.[Description],CE.GeneratingCategoryName,
CE.CostFactor,CE.WeightFactor
FROM GeneratedItems.CreatedEmbellishment CE
WHERE CE.CreatedEmbellishmentID = @CreatedEmbellishmentID;
GO
