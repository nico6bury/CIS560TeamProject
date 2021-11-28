CREATE OR ALTER PROCEDURE AppRecords.SaveEmbellishmentCategory
	@EmbellishmentCategoryID INT,
	@OwningUserID INT,
	@Name NVARCHAR(128),
	@RelativeChance INT,
	@Description NVARCHAR(256)
AS

MERGE AppRecords.EmbellishmentCategory EC
USING(
	VALUES(@EmbellishmentCategoryID,@OwningUserID,@Name,@RelativeChance,@Description)
	) CTE(EmbellishmentCategoryID,OwningUserID,[Name],RelativeChance,[Description])
	ON EC.EmbellishmentCategoryID = CTE.EmbellishmentCategoryID
WHEN MATCHED THEN
	UPDATE
	SET
		OwningUserID = CTE.OwningUserID,
		[Name] = CTE.[Name],
		RelativeChance = CTE.RelativeChance,
		[Description] = CTE.[Description]
WHEN NOT MATCHED THEN
	INSERT(EmbellishmentCategoryID,OwningUserID,[Name],RelativeChance,[Description])
	VALUES(@EmbellishmentCategoryID,@OwningUserID,@Name,@RelativeChance,@Description);
GO