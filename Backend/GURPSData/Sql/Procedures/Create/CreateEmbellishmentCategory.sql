CREATE OR ALTER PROCEDURE AppRecords.CreateEmbellishmentCategory
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@RelativeChance INT,
	@EmbellishmentCategoryID INT OUTPUT
AS

INSERT AppRecords.EmbellishmentCategory(OwningUserID,[Name], [Description], RelativeChance)
VALUES(@OwningUserID,@Name,@Description,@RelativeChance);

SET @EmbellishmentCategoryID = SCOPE_IDENTITY();
GO