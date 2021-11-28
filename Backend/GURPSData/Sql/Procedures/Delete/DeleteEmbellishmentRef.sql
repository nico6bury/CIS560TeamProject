CREATE OR ALTER PROCEDURE GeneratedItems.DeleteEmbellishmentRef
	@CreatedEmbellishmentID INT,
	@InventoryID INT
AS

DELETE GeneratedItems.EmbellishmentRef
WHERE InventoryID = @InventoryID AND
CreatedEmbellishmentID = @CreatedEmbellishmentID;
GO