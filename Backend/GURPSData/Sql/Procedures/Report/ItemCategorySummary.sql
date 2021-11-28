CREATE OR ALTER PROCEDURE AppRecords.ItemCategorySummary
AS
SELECT IC.ItemCategoryID, IC.[Name], IC.[Description],U.Username AS OwningUser,
AVG(I.UnitPrice) AS AverageCost, AVG(I.BaseWeight) AS AverageWeight,
SUM(I.UnitPrice) AS TotalCost, SUM(I.BaseWeight) AS TotalWeight
FROM AppRecords.ItemCategory IC INNER JOIN AppRecords.ItemSubcategory ISC ON
IC.ItemCategoryID = ISC.ItemCategoryID INNER JOIN AppRecords.Item I ON
I.ItemID = ISC.ItemID INNER JOIN AppRecords.[User] U ON
U.UserID = IC.OwningUserID
GROUP BY IC.ItemCategoryID, IC.[Name], IC.[Description], IC.OwningUserID,
	IC.CreatedOn, U.Username;
GO