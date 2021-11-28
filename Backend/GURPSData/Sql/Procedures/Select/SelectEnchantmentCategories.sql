CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllEnchantmentCategories
AS
SELECT EC.EnchantmentCategoryID,EC.OwningUserID,EC.[Name],
EC.[Description],EC.CreatedOn
FROM AppRecords.EnchantmentCategory EC
WHERE EC.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEnchantmentCategoriesForUser
	@UserID INT
AS
SELECT EC.EnchantmentCategoryID,EC.OwningUserID,EC.[Name],
EC.[Description],EC.CreatedOn
FROM AppRecords.EnchantmentCategory EC
WHERE EC.IsActive = 1 AND EC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveEnchantmentCategoriesForID
	@EnchantmentCategoryID INT
AS
SELECT EC.EnchantmentCategoryID,EC.OwningUserID,EC.[Name],
EC.[Description],EC.CreatedOn
FROM AppRecords.EnchantmentCategory EC
WHERE EC.IsActive = 1 AND EC.EnchantmentCategoryID = @EnchantmentCategoryID;
GO
