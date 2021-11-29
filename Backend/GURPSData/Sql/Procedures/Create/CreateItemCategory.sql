CREATE OR ALTER PROCEDURE AppRecords.CreateItemCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@ItemCategoryID INT OUTPUT,
	@IsDefault BIT OUTPUT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT AppRecords.ItemCategory(OwningUserID, [Name], [Description])
VALUES(@OwningUserID,@Name,@Description);

SET @ItemCategoryID = SCOPE_IDENTITY();
SET @IsDefault = 0;
SET @CreatedOn = (SELECT IC.CreatedOn FROM AppRecords.ItemCategory IC WHERE IC.ItemCategoryID = @ItemCategoryID);
GO