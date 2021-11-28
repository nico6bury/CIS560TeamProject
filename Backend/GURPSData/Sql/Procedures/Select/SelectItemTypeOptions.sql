CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllItemTypeOptions
AS
SELECT ITO.ItemTypeOptionID,ITO.[Name],ITO.ItemSubCategoryID,ITO.RelativeChance,
ITO.PriceChange,ITO.WeightChange,ITO.DescriptionAddition
FROM AppRecords.ItemTypeOption ITO WHERE ITO.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemTypeOptionsForItemSubcategoryID
	@ItemSubcategoryID INT
AS
SELECT ITO.ItemTypeOptionID,ITO.[Name],ITO.ItemSubCategoryID,ITO.RelativeChance,
ITO.PriceChange,ITO.WeightChange,ITO.DescriptionAddition
FROM AppRecords.ItemTypeOption ITO WHERE ITO.IsActive = 1 AND ITO.ItemSubCategoryID = @ItemSubcategoryID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveItemTypeOptionsForID
	@ItemTypeOptionID INT
AS
SELECT ITO.ItemTypeOptionID,ITO.[Name],ITO.ItemSubCategoryID,ITO.RelativeChance,
ITO.PriceChange,ITO.WeightChange,ITO.DescriptionAddition
FROM AppRecords.ItemTypeOption ITO WHERE ITO.IsActive = 1 AND ITO.ItemTypeOptionID = @ItemTypeOptionID;
GO