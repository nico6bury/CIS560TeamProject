CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllItemSubcategories
AS
SELECT ISC.ItemSubcategoryID,ISC.ItemCategoryID,ISC.ItemID,ISC.[Name]
FROM AppRecords.ItemSubcategory ISC WHERE ISC.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemSubcategoriesForItemID
	@ItemID INT
AS
SELECT ISC.ItemSubcategoryID,ISC.ItemCategoryID,ISC.ItemID,ISC.[Name]
FROM AppRecords.ItemSubcategory ISC WHERE ISC.IsActive = 1 AND ISC.ItemID = @ItemID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemSubcategoriesForItemCategoryID
	@ItemCategoryID INT
AS
SELECT ISC.ItemSubcategoryID,ISC.ItemCategoryID,ISC.ItemID,ISC.[Name]
FROM AppRecords.ItemSubcategory ISC WHERE ISC.IsActive = 1 AND ISC.ItemCategoryID = @ItemCategoryID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemSubcategoriesForID
	@ItemSubcategoryID INT
AS
SELECT ISC.ItemSubcategoryID,ISC.ItemCategoryID,ISC.ItemID,ISC.[Name]
FROM AppRecords.ItemSubcategory ISC WHERE ISC.IsActive = 1 AND ISC.ItemSubcategoryID = @ItemSubcategoryID;
GO
