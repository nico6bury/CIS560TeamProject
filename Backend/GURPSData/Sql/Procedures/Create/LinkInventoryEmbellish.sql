CREATE OR ALTER PROCEDURE GeneratedItems.LinkInventoryEmbellishment
	@CreatedEmbellishmentID INT,
	@InventoryID INT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT GeneratedItems.EmbellishmentRef(CreatedEmbellishmentID,InventoryID)
VALUES(@CreatedEmbellishmentID,@InventoryID);

SET @CreatedOn = (SELECT ER.CreatedOn FROM GeneratedItems.EmbellishmentRef ER
WHERE ER.CreatedEmbellishmentID = @CreatedEmbellishmentID AND ER.InventoryID = @InventoryID);
GO