CREATE OR ALTER PROCEDURE GeneratedItems.DeleteEnchantmentRef
	@CreatedEnchantmentID INT,
	@InventoryID INT
AS

DELETE GeneratedItems.EnchantmentRef
WHERE InventoryID = @InventoryID AND
CreatedEnchantmentID = @CreatedEnchantmentID;
GO