CREATE OR ALTER PROCEDURE AppRecords.ItemCategorySummary
AS
SELECT IC.ItemCategoryID, IC.[Name], IC.[Description],U.Username AS OwningUser,
COALESCE(AVG(I.UnitPrice), 0) AS AverageCost, COALESCE(AVG(I.BaseWeight), 0) AS AverageWeight,
COALESCE(SUM(I.UnitPrice), 0) AS TotalCost, COALESCE(SUM(I.BaseWeight), 0) AS TotalWeight
FROM AppRecords.ItemCategory IC LEFT JOIN AppRecords.ItemSubcategory ISC ON
IC.ItemCategoryID = ISC.ItemCategoryID LEFT JOIN AppRecords.Item I ON
I.ItemID = ISC.ItemID LEFT JOIN AppRecords.[User] U ON
U.UserID = IC.OwningUserID
GROUP BY IC.ItemCategoryID, IC.[Name], IC.[Description], IC.OwningUserID,
	IC.CreatedOn, U.Username;
GO