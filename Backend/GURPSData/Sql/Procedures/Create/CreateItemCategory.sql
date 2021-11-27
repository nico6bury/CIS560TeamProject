CREATE OR ALTER PROCEDURE AppRecords.CreateItemCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@ItemCategoryID INT OUTPUT,
	@IsDefault BIT OUTPUT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT AppRecords.ItemCategory(OwningUserID, [Name])
VALUES(@OwningUserID,@Name);

SET @ItemCategoryID = SCOPE_IDENTITY();
SET @IsDefault = 0;
SET @CreatedOn = (SELECT IC.CreatedOn FROM AppRecords.ItemCategory IC WHERE IC.ItemCategoryID = @ItemCategoryID);
GO