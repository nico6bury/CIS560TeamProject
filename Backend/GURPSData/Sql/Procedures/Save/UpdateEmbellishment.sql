CREATE OR ALTER PROCEDURE AppRecords.SaveEmbellishment
	@EmbellishmentID INT,
	@EmbellishmentCategoryID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@CostFactor DECIMAL(5,2),
	@WeightFactor DECIMAL(5,2),
	@RelativeChance INT
AS

MERGE AppRecords.Embellishment E
USING (
	VALUES(@EmbellishmentID,@EmbellishmentCategoryID,@Name,@Description,
	@CostFactor,@WeightFactor,@RelativeChance)
	) CTE(EmbellishmentID,EmbellishmentCategoryID,[Name],[Description],
	CostFactor,WeightFactor,RelativeChance)
	ON E.EmbellishmentID = CTE.EmbellishmentID
WHEN MATCHED THEN
	UPDATE
	SET
		EmbellishmentCategoryID = CTE.EmbellishmentCategoryID,
		[Name] = CTE.[Name],
		[Description] = CTE.[Description],
		CostFactor = CTE.CostFactor,
		WeightFactor = CTE.WeightFactor,
		RelativeChance = CTE.RelativeChance
WHEN NOT MATCHED THEN
	INSERT(EmbellishmentID,EmbellishmentCategoryID,[Name],[Description],
	CostFactor,WeightFactor,RelativeChance)
	VALUES(@EmbellishmentID,@EmbellishmentCategoryID,@Name,@Description,
	@CostFactor,@WeightFactor,@RelativeChance);
GO