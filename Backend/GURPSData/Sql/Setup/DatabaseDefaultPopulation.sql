/*
	NOTE: This script is not meant to be re-runnable. It will only insert, not merge.
*/

-- use variable for UserID of Administrator User
DECLARE @AdminID INT = 1;

-- ref variables for later
DECLARE @MRCategoryID INT = 0;
DECLARE @MRItemID INT = 0;
DECLARE @MRSubCat INT = 0;

-- add to ItemCategory
INSERT AppRecords.ItemCategory(OwningUserID,[Name],[Description],IsDefault)
VALUES (@AdminID, N'Spices', N'A collection of different spices.', 1);
SET @MRCategoryID = SCOPE_IDENTITY();

-- variables for spice descriptions
DECLARE @SpiceDesc1 NVARCHAR(256) = N'An ounce of this, ground to a powder and 
	scattered in the users path, will make anyone tracking him by scent have a 
	fit of sneezing (see p. B428). Afterward, the tracker must make a HT roll 
	at -3 or have to stop tracking for an hour while his sense of smell recovers 
	from overload.',
	@SpiceDesc2 NVARCHAR(256) = N'This spice is a well-known aphrodisiac. 
	Consuming an ounce imposes -1 on any rolls to resist Lecherousness and 
	seduction attempts for the next hour.',
	@SpiceDesc3 NVARCHAR(256) = N'If an ounce of this is consumed within an hour 
	before ingesting a poison, the user is at +1 to HT rolls to resist.',
	@SpiceDesc4 NVARCHAR(256) = N'This spice is useful for strengthening the blood 
	and speeding healing. Consuming an ounce a day gives +1 to daily HT rolls to 
	recover lost HP.',
	@SpiceDesc5 NVARCHAR(256) = N'This spice is highly prized, but the consumer of 
	an ounce or more is at -1 to resist any mind-reading or mind-control attempts 
	made in the next hour.',
	@SpiceDesc6 NVARCHAR(256) = N'This spice aids digestion; an ounce acts as a 
	treatment to resist nausea (see p. B428) for an hour.',
	@SpiceDesc7 NVARCHAR(256) = N'This spice balances humors and helps stabilize 
	mood. Consuming an ounce gives +1 to resist sudden outbursts of anger and rage,
	including the Berserk and Bloodlust disadvantages, for an hour.',
	@SpiceDesc8 NVARCHAR(256) = N'This is a very mild stimulant. Anyone who ingests 
	an ounce is at +1 to HT to resist poisons that cause unconsciousness or fatigue 
	damage for the next hour.',
	@SpiceDesc9 NVARCHAR(256) = N'Tossing an ounce of salt gives clerics +1 to cast 
	Turn Zombie and to Will rolls for True Faith to turn zombies.',
	@SpiceDesc10 NVARCHAR(256) = N'This spice has antiseptic properties. Using an 
	ounce of it while dressing wounds gives +1 to First Aid.';
-- add Allspice
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Allspice',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Anise
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Anise',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Annatto
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Annatto',113,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Asafetida
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Asafetida',75,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Cardamom
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Cardamom',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Cassia
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Cassia',75,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Chiles
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Chiles',38,1,N'oz',1,3,@SpiceDesc1); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Cinnamon
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Cinnamon',150,1,N'oz',1,3,@SpiceDesc2); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Clove
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Clove',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Coriander
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Coriander',150,1,N'oz',1,3,@SpiceDesc3); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Cumin
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Cumin',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Dwarven Savory Fungus
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Dwarven Savory Fungus',75,1,N'oz',1,3,@SpiceDesc4); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Elven Pepperbark
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Elven Pepperbark',38,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Faerie Glimmerseek
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Faerie Glimmerseed',270,1,N'oz',1,3,@SpiceDesc5); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Fennel
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Fennel',75,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Fenugreek
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Fenugreek',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Ginger
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Ginger',38,1,N'oz',1,3,@SpiceDesc6); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Halfling Savory
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Halfling Savory',150,1,N'oz',1,3,@SpiceDesc4); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Huajiao (Szechuan Pepper)
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Huajiao (Szechuan Pepper)',150,1,N'oz',1,3,@SpiceDesc1); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Mace
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Mace',225,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Mustard
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Mustard',38,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Nigella
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Nigella',75,1,N'oz',1,3,@SpiceDesc7); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Nutmeg
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Nutmeg',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Onion Seed
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Onion Seed',38,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Orcish Firegrain
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Orchish Firegrain',150,1,N'oz',1,3,@SpiceDesc8); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Pepper
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Pepper',150,1,N'oz',1,3,@SpiceDesc1); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'Pepper');
SET @MRSubCat = SCOPE_IDENTITY();
INSERT AppRecords.ItemTypeOption([Name],ItemSubCategoryID,PriceChange,WeightChange,DescriptionAddition)
VALUES (N'Pepper, Black', @MRSubCat, 0, 0, N''),
	(N'Pepper, White', @MRSubCat, 38, 0, N'');
-- add Poppy Seed
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Poppy Seed',38,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Saffron
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Saffron',300,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Salt
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Salt',15,1,N'oz',1,3,@SpiceDesc9); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'Salt');
SET @MRSubCat = SCOPE_IDENTITY();
INSERT AppRecords.ItemTypeOption([Name],ItemSubCategoryID,PriceChange,WeightChange,DescriptionAddition)
VALUES (N'Salt, Table', @MRSubCat, 0, 0, N''),
	(N'Salt, Black', @MRSubCat, 23, 0, N''),
	(N'Salt, Red', @MRSubCat, 23, 0, N'');
-- add Sumac
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Sumac',38,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Tamarind
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Tamarind',15,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Turmeric
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Turmeric',38,1,N'oz',1,3,@SpiceDesc10); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');
-- add Zeodary
INSERT AppRecords.Item([Name],UnitPrice,BaseWeight,WeightType,QuantityMin,QuantityMax,[Description])
VALUES (N'Zeodary',150,1,N'oz',1,3,N''); SET @MRItemID = SCOPE_IDENTITY();
INSERT AppRecords.ItemSubcategory(ItemCategoryID,ItemID,[Name]) VALUES (@MRCategoryID, @MRItemID, N'NULL');

/* put -- at the beginning of this line to uncomment query below
SELECT I.ItemID, I.[Name], I.UnitPrice, I.[Description], [IS].ItemSubcategoryID, ITO.[Name], ITO.PriceChange, ITO.ItemTypeOptionID
FROM AppRecords.Item I INNER JOIN AppRecords.ItemSubcategory [IS] ON I.ItemID = [IS].ItemID
	INNER JOIN AppRecords.ItemCategory IC ON IC.ItemCategoryID = [IS].ItemCategoryID LEFT JOIN
	AppRecords.ItemTypeOption ITO ON ITO.ItemSubCategoryID = [IS].ItemSubcategoryID;
--*/