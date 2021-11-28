CREATE OR ALTER PROCEDURE AppRecords.CreateEmbellishmentCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@RelativeChance INT,
	@EmbellishmentCategoryID INT OUTPUT,
	@CreatedOn DATETIMEOFFSET OUTPUT
AS

INSERT AppRecords.EmbellishmentCategory(OwningUserID,[Name], [Description], RelativeChance)
VALUES(@OwningUserID,@Name,@Description,@RelativeChance);

SET @EmbellishmentCategoryID = SCOPE_IDENTITY();
SET @CreatedOn = (SELECT EC.CreatedOn FROM AppRecords.EmbellishmentCategory EC WHERE EC.CreatedOn = @CreatedOn);
GO