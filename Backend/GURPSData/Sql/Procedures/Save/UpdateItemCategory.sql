CREATE OR ALTER PROCEDURE AppRecords.SaveItemCategory
	@ItemCategoryID INT,
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256)
AS

MERGE AppRecords.ItemCategory IC
USING (
	VALUES(@ItemCategoryID,@OwningUserID,@Name,@Description)
	) CTE(ItemCategoryID,OwningUserID,[Name],[Description])
	ON IC.ItemCategoryID = CTE.ItemCategoryID
WHEN MATCHED THEN
	UPDATE
	SET
		OwningUserID = CTE.OwningUserID,
		[Name] = CTE.[Name],
		[Description] = CTE.[Description]
WHEN NOT MATCHED THEN
	INSERT(OwningUserID,[Name],[Description])
	VALUES(@OwningUserID,@Name,@Description);
GO