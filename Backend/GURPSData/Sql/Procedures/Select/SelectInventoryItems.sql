CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveAllInventory
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II
WHERE II.IsActive = 1;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForUser
	@UserID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II
WHERE II.IsActive = 1 AND II.OwningUserID = @UserID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForEnchantment
	@CreatedEnchantmentID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EnchantmentRef ER
ON II.InventoryID = ER.InventoryID
WHERE II.IsActive = 1 AND ER.CreatedEnchantmentID = @CreatedEnchantmentID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForEmbellishment
	@CreatedEmbellishmentID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EmbellishmentRef ER
ON II.InventoryID = ER.InventoryID
WHERE II.IsActive = 1 AND ER.CreatedEmbellishmentID = @CreatedEmbellishmentID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForUserAndEnchantment
	@UserID INT,
	@CreatedEnchantmentID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EnchantmentRef ER ON
II.InventoryID = ER.InventoryID
WHERE II.IsActive = 1 AND II.OwningUserID = @UserID AND ER.CreatedEnchantmentID = @CreatedEnchantmentID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForUserAndEmbellishment
	@UserID INT,
	@CreatedEmbellishmentID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EmbellishmentRef ER ON
II.InventoryID = ER.InventoryID
WHERE II.IsActive = 1 AND II.OwningUserID = @UserID AND ER.CreatedEmbellishmentID = @CreatedEmbellishmentID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForUserEnchantmentEmbellishment
	@UserID INT,
	@CreatedEnchantmentID INT,
	@CreatedEmbellishmentID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II INNER JOIN GeneratedItems.EmbellishmentRef EMR ON
II.InventoryID = EMR.InventoryID INNER JOIN GeneratedItems.EnchantmentRef ENR ON
II.InventoryID = ENR.InventoryID
WHERE II.IsActive = 1 AND II.OwningUserID = @UserID AND
EMR.CreatedEmbellishmentID = @CreatedEmbellishmentID AND
ENR.CreatedEnchantmentID = @CreatedEnchantmentID;
GO

CREATE OR ALTER PROCEDURE GeneratedItems.RetrieveInventoryForID
	@InventoryID INT
AS
SELECT II.InventoryID,II.OwningUserID,II.[Name],II.[Description],
II.GeneratingTableName,II.Quantity,II.UnitPrice,II.BaseWeight,
II.WeightType,II.GeneratedOn,II.EditedOn
FROM GeneratedItems.InventoryItem II
WHERE II.IsActive = 1 AND II.InventoryID = @InventoryID;
GO