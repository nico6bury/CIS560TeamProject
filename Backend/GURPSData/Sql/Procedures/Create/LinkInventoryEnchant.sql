CREATE OR ALTER PROCEDURE GeneratedItems.LinkInventoryEnchant
	@CreatedEnchantmentID INT,
	@InventoryID INT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT GeneratedItems.EnchantmentRef(CreatedEnchantmentID,InventoryID)
VALUES(@CreatedEnchantmentID,@InventoryID);

SET @CreatedOn = (SELECT ER.CreatedOn FROM GeneratedItems.EnchantmentRef ER
WHERE ER.CreatedEnchantmentID = @CreatedEnchantmentID AND ER.InventoryID = @InventoryID);
GO