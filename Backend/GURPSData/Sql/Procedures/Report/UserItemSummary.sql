CREATE OR ALTER PROCEDURE AppRecords.UserItemSummary
AS
SELECT U.UserID, U.Username, COUNT(DISTINCT IC.ItemCategoryID) AS TablesCreated,
COUNT(DISTINCT I.ItemID) AS ItemsCreated, COUNT(DISTINCT II.GeneratingTableName) AS TablesUsed,
COUNT(II.InventoryID) AS ItemsGenerated, U.JoinedOn
FROM AppRecords.[User] U LEFT JOIN AppRecords.ItemCategory IC ON
U.UserID = IC.OwningUserID LEFT JOIN AppRecords.ItemSubcategory ISC ON
ISC.ItemCategoryID = IC.ItemCategoryID LEFT JOIN AppRecords.Item I ON
ISC.ItemID = I.ItemID LEFT JOIN GeneratedItems.InventoryItem II ON
II.OwningUserID = U.UserID
GROUP BY U.UserID, U.Username, U.JoinedOn
GO