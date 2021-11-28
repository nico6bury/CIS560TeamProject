CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllEmbellishments
AS
SELECT E.EmbellishmentID,E.EmbellishmentCategoryID,E.[Name],E.[Description],
E.CostFactor,E.WeightFactor,E.RelativeChance,E.CreatedOn
FROM AppRecords.Embellishment E WHERE E.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEmbellishmentsForCategory
	@EmbellishmentCategoryID INT
AS
SELECT E.EmbellishmentID,E.EmbellishmentCategoryID,E.[Name],E.[Description],
E.CostFactor,E.WeightFactor,E.RelativeChance,E.CreatedOn
FROM AppRecords.Embellishment E WHERE E.IsActive = 1 AND E.EmbellishmentCategoryID = @EmbellishmentCategoryID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEmbellishmentsForUser
	@UserID INT
AS
SELECT E.EmbellishmentID,E.EmbellishmentCategoryID,E.[Name],E.[Description],
E.CostFactor,E.WeightFactor,E.RelativeChance,E.CreatedOn
FROM AppRecords.Embellishment E INNER JOIN AppRecords.EmbellishmentCategory EC ON
E.EmbellishmentCategoryID = EC.EmbellishmentCategoryID
WHERE E.IsActive = 1 AND EC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEmbellishmentsForID
	@EmbellishmentID INT
AS
SELECT E.EmbellishmentID,E.EmbellishmentCategoryID,E.[Name],E.[Description],
E.CostFactor,E.WeightFactor,E.RelativeChance,E.CreatedOn
FROM AppRecords.Embellishment E WHERE E.IsActive = 1 AND E.EmbellishmentID = @EmbellishmentID;
GO
