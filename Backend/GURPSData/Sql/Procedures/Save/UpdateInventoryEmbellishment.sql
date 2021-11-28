CREATE OR ALTER PROCEDURE GeneratedItems.SaveCreatedEmbellishment
	@CreatedEmbellishmentID INT,
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingCategoryName NVARCHAR(128),
	@CostFactor DECIMAL(5,2),
	@WeightFactor DECIMAL(5,2)
AS

MERGE GeneratedItems.CreatedEmbellishment CE
USING (
	VALUES(@CreatedEmbellishmentID,@Name,@Description,
	@GeneratingCategoryName,@CostFactor,@WeightFactor)
	) CTE(CreatedEmbellishmentID,[Name],[Description],
	GeneratingCategoryName,CostFactor,WeightFactor)
	ON CE.CreatedEmbellishmentID = CTE.CreatedEmbellishmentID
WHEN MATCHED THEN
	UPDATE
	SET
		[Name] = CTE.[Name],
		[Description] = CTE.[Description],
		GeneratingCategoryName = CTE.GeneratingCategoryName,
		CostFactor = CTE.CostFactor,
		WeightFactor = CTE.WeightFactor
WHEN NOT MATCHED THEN
	INSERT(CreatedEmbellishmentID,[Name],[Description],
	GeneratingCategoryName,CostFactor,WeightFactor)
	VALUES(@CreatedEmbellishmentID,@Name,@Description,
	@GeneratingCategoryName,@CostFactor,@WeightFactor);
GO