CREATE OR ALTER PROCEDURE GeneratedItems.CreateInventoryEmbellishment
	@Name NVARCHAR(128),
	@Description NVARCHAR(256),
	@GeneratingCategoryName NVARCHAR(128),
	@CostFactor DECIMAL(5,2),
	@WeightFactor DECIMAL(5,2),
	@CreatedEmbellishmentID INT OUTPUT
AS

INSERT GeneratedItems.CreatedEmbellishment([Name],[Description],GeneratingCategoryName,CostFactor,WeightFactor)
VALUES(@Name,@Description,@GeneratingCategoryName,@CostFactor,@WeightFactor);

SET @CreatedEmbellishmentID = SCOPE_IDENTITY();
GO