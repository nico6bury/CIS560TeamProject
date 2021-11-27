CREATE OR ALTER PROCEDURE AppRecords.CreateItemCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@ItemCategoryID INT OUTPUT
AS

INSERT AppRecords.ItemCategory(OwningUserID, [Name])
VALUES(@OwningUserID,@Name);

SET @ItemCategoryID = SCOPE_IDENTITY();
GO