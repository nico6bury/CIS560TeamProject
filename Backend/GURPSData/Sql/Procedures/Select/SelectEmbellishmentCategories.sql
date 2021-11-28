CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllEmbellishmentCategories
AS
SELECT EC.EmbellishmentCategoryID, EC.OwningUserID, EC.[Name],
EC.[Description], EC.RelativeChance, EC.CreatedOn
FROM AppRecords.EmbellishmentCategory EC WHERE EC.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEmbellishmentCategoriesForUser
	@UserID INT
AS
SELECT EC.EmbellishmentCategoryID, EC.OwningUserID, EC.[Name],
EC.[Description], EC.RelativeChance, EC.CreatedOn
FROM AppRecords.EmbellishmentCategory EC WHERE EC.IsActive = 1 AND EC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEmbellishmentCategoriesForID
	@EmbellishmentCategoryID INT
AS
SELECT EC.EmbellishmentCategoryID, EC.OwningUserID, EC.[Name],
EC.[Description], EC.RelativeChance, EC.CreatedOn
FROM AppRecords.EmbellishmentCategory EC
WHERE EC.IsActive = 1 AND EC.EmbellishmentCategoryID = @EmbellishmentCategoryID;
GO