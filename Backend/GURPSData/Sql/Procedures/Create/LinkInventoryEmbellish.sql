CREATE OR ALTER PROCEDURE GeneratedItems.LinkInventoryEmbellishment
	@CreatedEmbellishmentID INT,
	@InventoryID INT
AS

INSERT GeneratedItems.EmbellishmentRef(CreatedEmbellishmentID,InventoryID)
VALUES(@CreatedEmbellishmentID,@InventoryID);
GO