CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveAllEmbellishmentRefs
AS
SELECT ER.CreatedEmbellishmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EmbellishmentRef ER;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEmbellishmentRefsForEmbellishmentAndItem
	@CreatedEmbellishment INT,
	@InventoryID INT
AS
SELECT ER.CreatedEmbellishmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EmbellishmentRef ER
WHERE ER.CreatedEmbellishmentID = @CreatedEmbellishment AND ER.InventoryID = @InventoryID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEmbellishmentRefsForUser
	@UserID INT
AS
SELECT DISTINCT ER.CreatedEmbellishmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EmbellishmentRef ER INNER JOIN GeneratedItems.InventoryItem II ON
ER.InventoryID = II.InventoryID
WHERE II.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEmbellishmentRefsForItem
	@InventoryID INT
AS
SELECT ER.CreatedEmbellishmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EmbellishmentRef ER
WHERE ER.InventoryID = @InventoryID;
GO
