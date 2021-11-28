CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllItemCategories
AS
SELECT IC.ItemCategoryID,IC.OwningUserID,IC.[Name],IC.[Description],IC.IsDefault,IC.CreatedOn
FROM AppRecords.ItemCategory IC WHERE IC.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemCategoriesForUserID
	@UserID INT
AS
SELECT IC.ItemCategoryID,IC.OwningUserID,IC.[Name],IC.[Description],IC.IsDefault,IC.CreatedOn
FROM AppRecords.ItemCategory IC WHERE IC.IsActive = 1 AND IC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveDefaultItemCategories
AS
SELECT IC.ItemCategoryID,IC.OwningUserID,IC.[Name],IC.[Description],IC.IsDefault,IC.CreatedOn
FROM AppRecords.ItemCategory IC WHERE IC.IsActive = 1 AND IC.IsDefault = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemCategoriesForID
	@ItemCategoryID INT
AS
SELECT IC.ItemCategoryID,IC.OwningUserID,IC.[Name],IC.[Description],IC.IsDefault,IC.CreatedOn
FROM AppRecords.ItemCategory IC WHERE IC.IsActive = 1 AND IC.ItemCategoryID = @ItemCategoryID;
GO