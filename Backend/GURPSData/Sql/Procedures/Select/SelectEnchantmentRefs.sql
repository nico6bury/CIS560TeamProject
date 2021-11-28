CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveAllEnchantmentRefs
AS
SELECT ER.CreatedEnchantmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EnchantmentRef ER;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEnchantmentRefsForEnchantmentAndItem
	@CreatedEnchantment INT,
	@InventoryID INT
AS
SELECT ER.CreatedEnchantmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EnchantmentRef ER
WHERE ER.CreatedEnchantmentID = @CreatedEnchantment AND ER.InventoryID = @InventoryID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEnchantmentRefsForUser
	@UserID INT
AS
SELECT DISTINCT ER.CreatedEnchantmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EnchantmentRef ER INNER JOIN GeneratedItems.InventoryItem II ON
ER.InventoryID = II.InventoryID
WHERE II.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveEnchantmentRefsForItem
	@InventoryID INT
AS
SELECT ER.CreatedEnchantmentID,ER.InventoryID,ER.CreatedOn
FROM GeneratedItems.EnchantmentRef ER
WHERE ER.InventoryID = @InventoryID;
GO
