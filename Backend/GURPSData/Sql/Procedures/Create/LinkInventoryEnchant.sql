CREATE OR ALTER PROCEDURE GeneratedItems.LinkInventoryEnchant
	@CreatedEnchantmentID INT,
	@InventoryID INT
AS

INSERT GeneratedItems.EnchantmentRef(CreatedEnchantmentID,InventoryID)
VALUES(@CreatedEnchantmentID,@InventoryID);
GO