CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllItems
AS
SELECT I.ItemID,I.[Name],I.UnitPrice,I.BaseWeight,I.WeightType,I.QuantityMin,I.QuantityMax,
I.[Description],I.RelativeChance,I.CreatedOn
FROM AppRecords.Item I WHERE I.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemsForName
	@Name NVARCHAR(128)
AS
SELECT I.ItemID,I.[Name],I.UnitPrice,I.BaseWeight,I.WeightType,I.QuantityMin,I.QuantityMax,
I.[Description],I.RelativeChance,I.CreatedOn
FROM AppRecords.Item I WHERE I.IsActive = 1 AND I.[Name] = @Name;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemsForCategoryID
	@ItemCategoryID INT
AS
SELECT I.ItemID,I.[Name],I.UnitPrice,I.BaseWeight,I.WeightType,I.QuantityMin,I.QuantityMax,
I.[Description],I.RelativeChance,I.CreatedOn
FROM AppRecords.Item I INNER JOIN AppRecords.ItemSubcategory ISC ON I.ItemID = ISC.ItemID
WHERE I.IsActive = 1 AND ISC.ItemCategoryID = @ItemCategoryID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemsForUserID
	@UserID INT
AS
SELECT I.ItemID,I.[Name],I.UnitPrice,I.BaseWeight,I.WeightType,I.QuantityMin,I.QuantityMax,
I.[Description],I.RelativeChance,I.CreatedOn
FROM AppRecords.Item I INNER JOIN AppRecords.ItemSubcategory ISC ON I.ItemID = ISC.ItemID
INNER JOIN AppRecords.ItemCategory IC ON ISC.ItemCategoryID = IC.ItemCategoryID
WHERE I.IsActive = 1 AND IC.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemsForID
	@ItemID INT
AS
SELECT I.ItemID,I.[Name],I.UnitPrice,I.BaseWeight,I.WeightType,I.QuantityMin,I.QuantityMax,
I.[Description],I.RelativeChance,I.CreatedOn
FROM AppRecords.Item I WHERE I.IsActive = 1 AND I.ItemID = @ItemID;
GO