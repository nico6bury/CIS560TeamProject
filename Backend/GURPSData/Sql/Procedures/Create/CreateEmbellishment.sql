CREATE OR ALTER PROCEDURE AppRecords.CreateEmbellishment
	@EmbellishmentCategoryID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@CostFactor DECIMAL(5,2),
	@WeightFactor DECIMAL(5,2),
	@RelativeChance INT,
	@EmbellishmentID INT OUTPUT
AS

INSERT AppRecords.Embellishment(EmbellishmentCategoryID, [Name], RelativeChance, [Description], CostFactor, WeightFactor, RelativeChance)
VALUES(@EmbellishmentCategoryID,@Name,@Description,@CostFactor,@WeightFactor,@RelativeChance);

SET @EmbellishmentID = SCOPE_IDENTITY();
GO