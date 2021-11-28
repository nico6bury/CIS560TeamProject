CREATE OR ALTER PROCEDURE AppRecords.UserItemSummary
AS
SELECT U.UserID, U.Username, COUNT(IC.ItemCategoryID) AS TablesCreated,
COUNT(I.ItemID) AS ItemsCreated, COUNT(DISTINCT II.GeneratingTableName) AS TablesUsed,
COUNT(DISTINCT II.InventoryID) AS ItemsGenerated, U.JoinedOn
FROM AppRecords.[User] U INNER JOIN AppRecords.ItemCategory IC ON
U.UserID = IC.OwningUserID INNER JOIN AppRecords.ItemSubcategory ISC ON
ISC.ItemCategoryID = IC.ItemCategoryID INNER JOIN AppRecords.Item I ON
ISC.ItemID = I.ItemID LEFT JOIN GeneratedItems.InventoryItem II ON
II.OwningUserID = U.UserID
GROUP BY U.UserID, U.Username, U.JoinedOn
GO