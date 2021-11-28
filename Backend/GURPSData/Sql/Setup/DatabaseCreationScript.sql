-- drop all the procedures we might have lying around
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveAllCreatedEmbellishments;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveCreatedEmbellishmentsForUser;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveCreatedEmbellishmentsForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllUsers;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveUserForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveUserForUsername;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllItemTypeOptions;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemTypeOptionsForItemSubcategoryID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemTypeOptionsForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllItemSubcategories;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemSubcategoriesForItemID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemSubcategoriesForItemCategoryID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemSubcategoriesForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllItems;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemsForName;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemsForCategoryID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemsForUserID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemsForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllItemCategories;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemCategoriesForUserID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveDefaultItemCategories;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveItemCategoriesForID;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveAllInventory;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForUser;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForEnchantment;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForEmbellishment;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForUserAndEnchantment;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForUserAndEmbellishment;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForUserEnchantmentEmbellishment;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveInventoryForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllEnchantments;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEnchantmentsForUser;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEnchantmentsForCategory;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEnchantmentsForID;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveAllEnchantmentRefs;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEnchantmentRefsForEnchantmentAndItem;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEnchantmentRefsForUser;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEnchantmentRefsForItem;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllEnchantmentCategories;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEnchantmentCategoriesForUser;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEnchantmentCategoriesForID;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllEmbellishments;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEmbellishmentsForCategory;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEmbellishmentsForUser;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEmbellishmentsForID;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveAllEmbellishmentRefs;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEmbellishmentRefsForEmbellishmentAndItem;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEmbellishmentRefsForUser;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveEmbellishmentRefsForItem;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveAllEmbellishmentCategories;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEmbellishmentCategoriesForUser;
DROP PROCEDURE IF EXISTS AppRecords.RetrieveEmbellishmentCategoriesForID;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveAllCreatedEnchantments;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveCreatedEnchantmentsForUser;
DROP PROCEDURE IF EXISTS GeneratedItems.RetrieveCreatedEnchantmentsForID;
DROP PROCEDURE IF EXISTS AppRecords.CreateEnchantment;
DROP PROCEDURE IF EXISTS AppRecords.CreateEmbellishmentCategory;
DROP PROCEDURE IF EXISTS AppRecords.CreateEmbellishment;
DROP PROCEDURE IF EXISTS GeneratedItems.LinkInventoryEnchant;
DROP PROCEDURE IF EXISTS GeneratedItems.LinkInventoryEmbellishment;
DROP PROCEDURE IF EXISTS AppRecords.CreateUser;
DROP PROCEDURE IF EXISTS AppRecords.CreateItemCategory;
DROP PROCEDURE IF EXISTS AppRecords.CreateItem;
DROP PROCEDURE IF EXISTS GeneratedItems.CreateInventoryItem;
DROP PROCEDURE IF EXISTS GeneratedItems.CreateInventoryEnchantment;
DROP PROCEDURE IF EXISTS GeneratedItems.CreateInventoryEmbellishment;
DROP PROCEDURE IF EXISTS AppRecords.CreateEnchantmentCategory;
DROP PROCEDURE IF EXISTS AppRecords.ItemEnhancementSummary;
DROP PROCEDURE IF EXISTS AppRecords.ItemCategorySummary;
DROP PROCEDURE IF EXISTS AppRecords.UserItemSummary;
DROP PROCEDURE IF EXISTS GeneratedItems.UserInventorySummary

-- drop all the tables
DROP TABLE IF EXISTS AppRecords.ItemTypeOption;
DROP TABLE IF EXISTS AppRecords.ItemSubcategory;
DROP TABLE IF EXISTS AppRecords.Item;
DROP TABLE IF EXISTS AppRecords.ItemCategory;
DROP TABLE IF EXISTS AppRecords.Embellishment;
DROP TABLE IF EXISTS AppRecords.EmbellishmentCategory;
DROP TABLE IF EXISTS AppRecords.Enchantment;
DROP TABLE IF EXISTS AppRecords.EnchantmentCategory;
DROP TABLE IF EXISTS GeneratedItems.EnchantmentRef;
DROP TABLE IF EXISTS GeneratedItems.EmbellishmentRef;
DROP TABLE IF EXISTS GeneratedItems.CreatedEnchantment;
DROP TABLE IF EXISTS GeneratedItems.CreatedEmbellishment;
DROP TABLE IF EXISTS GeneratedItems.InventoryItem;
DROP TABLE IF EXISTS AppRecords.[User];

-- drop the schemas?
DROP SCHEMA IF EXISTS GeneratedItems;
DROP SCHEMA IF EXISTS AppRecords;

-- recreate the schemas
EXEC('CREATE SCHEMA AppRecords');
EXEC('CREATE SCHEMA GeneratedItems');

-- make tables in AppRecords
CREATE TABLE AppRecords.[User](
	UserID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_User_UserID PRIMARY KEY,
	Username NVARCHAR(64) NOT NULL
		CONSTRAINT UK_User_Username UNIQUE,
	[Password] NVARCHAR(128) NOT NULL,
	IsAdmin BIT NOT NULL
		CONSTRAINT DF_User_IsAdmin DEFAULT(0),
	JoinedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_User_JoinedOn DEFAULT(SYSDATETIME())
)
CREATE TABLE AppRecords.ItemCategory(
	ItemCategoryID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_ItemCategory_ID PRIMARY KEY,
	OwningUserID INT NOT NULL
		CONSTRAINT FK_ItemCategory_UserID
		REFERENCES AppRecords.[User](UserID),
	[Name] NVARCHAR(128) NOT NULL
		CONSTRAINT UK_ItemCategory_Name UNIQUE,
	[Description] NVARCHAR(256) NOT NULL,
	IsDefault BIT NOT NULL
		CONSTRAINT DF_ItemCategory_IsDefault DEFAULT(0),
	IsActive BIT NOT NULL
		CONSTRAINT DF_ItemCategory_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_ItemCategory_CreatedOn DEFAULT(SYSDATETIME())
)
CREATE TABLE AppRecords.Item(
	ItemID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Item_ID PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL,
	UnitPrice INT NOT NULL,
	BaseWeight INT NOT NULL,
	WeightType NVARCHAR(32) NOT NULL,
	QuantityMin INT NOT NULL
		CONSTRAINT DF_Item_QuantityMin DEFAULT(1),
	QuantityMax INT NOT NULL
		CONSTRAINT DF_Item_QuantityMax DEFAULT(1),
	[Description] NVARCHAR(256) NOT NULL,
	RelativeChance INT NOT NULL
		CONSTRAINT DF_Item_RelativeChance DEFAULT(10),
	IsActive BIT NOT NULL
		CONSTRAINT DF_Item_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_Item_CreatedOn DEFAULT(SYSDATETIME())
)
CREATE TABLE AppRecords.ItemSubcategory(
	ItemSubcategoryID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_ItemSubcategory_ID PRIMARY KEY,
	ItemCategoryID INT NOT NULL
		CONSTRAINT FK_ItemSubcategory_ItemCategoryID
		REFERENCES AppRecords.ItemCategory(ItemCategoryID),
	ItemID INT NOT NULL
		CONSTRAINT FK_ItemSubcategory_ItemID
		REFERENCES AppRecords.Item(ItemID),
	[Name] NVARCHAR(128) NOT NULL,
	IsActive BIT NOT NULL
		CONSTRAINT DF_ItemSubcategory_IsActive DEFAULT(1)
)
CREATE TABLE AppRecords.ItemTypeOption(
	ItemTypeOptionID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_ItemTypeOption_ID PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL,
	ItemSubCategoryID INT NOT NULL
		CONSTRAINT FK_ItemTypeOption_ItemSubCategoryID
		REFERENCES AppRecords.ItemSubcategory(ItemSubcategoryID),
	RelativeChance INT NOT NULL
		CONSTRAINT DF_ItemTypeOption_RelativeChance DEFAULT(10),
	PriceChange INT NOT NULL
		CONSTRAINT DF_ItemTypeOption_PriceChange DEFAULT(0),
	WeightChange INT NOT NULL
		CONSTRAINT DF_ItemTypeOption_WeightChange DEFAULT(0),
	DescriptionAddition NVARCHAR(128) NOT NULL,
	IsActive BIT NOT NULL
		CONSTRAINT DF_ItemTypeOption_IsActive DEFAULT(1)
)
CREATE TABLE AppRecords.EmbellishmentCategory(
	EmbellishmentCategoryID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_EmbellishmentCategory_ID PRIMARY KEY,
	OwningUserID INT NOT NULL
		CONSTRAINT FK_EmbellishmentCategory_UserID
		REFERENCES AppRecords.[User](UserID),
	[Name] NVARCHAR(128) NOT NULL,
	RelativeChance INT NOT NULL
		CONSTRAINT DF_EmbellishmentCategory_RelativeChance DEFAULT(10),
	[Description] NVARCHAR(256) NOT NULL,
	IsActive BIT NOT NULL
		CONSTRAINT DF_EmbellishmentCategory_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_EmbellishmentCategory_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT UK_EmbellishemntCategory_UserID_Name UNIQUE(OwningUserID, [Name])
)
CREATE TABLE AppRecords.Embellishment(
	EmbellishmentID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Embellishment_ID PRIMARY KEY,
	EmbellishmentCategoryID INT NOT NULL
		CONSTRAINT FK_Embellishment_EmbellishmentCategoryID
		REFERENCES AppRecords.EmbellishmentCategory(EmbellishmentCategoryID),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	CostFactor DECIMAL(5,2) NOT NULL,
	WeightFactor DECIMAL(5,2) NOT NULL,
	RelativeChance INT NOT NULL
		CONSTRAINT DF_Embellishment_RelativeChance DEFAULT(10),
	IsActive BIT NOT NULL
		CONSTRAINT DF_Embellishment_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_Embellishment_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT UK_Embellishment_EmbellishmentCategoryID_Name UNIQUE(EmbellishmentCategoryID, [Name])
)
CREATE TABLE AppRecords.EnchantmentCategory(
	EnchantmentCategoryID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_EnchantmentCategory_ID PRIMARY KEY,
	OwningUserID INT NOT NULL
		CONSTRAINT FK_EnchantmentCategory_UserID
		REFERENCES AppRecords.[User](UserID),
	[Name] NVARCHAR(128) NOT NULL,
	RelativeChance INT NOT NULL
		CONSTRAINT DF_EnchantmentCategory_RelativeChance DEFAULT(10),
	[Description] NVARCHAR(256) NOT NULL,
	IsActive BIT NOT NULL
		CONSTRAINT DF_EnchantmentCategory_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_EnchantmentCategory_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT UK_EnchantmentCategory_UserID_Name UNIQUE(OwningUserID, [Name])
)
CREATE TABLE AppRecords.Enchantment(
	EnchantmentID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Enchantment_ID PRIMARY KEY,
	EnchantmentCategoryID INT NOT NULL
		CONSTRAINT FK_Enchantment_EnchantmentCategoryID
		REFERENCES AppRecords.EnchantmentCategory(EnchantmentCategoryID),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	Cost INT NOT NULL,
	WeightFactor DECIMAL(5,2) NOT NULL,
	RelativeChance INT NOT NULL
		CONSTRAINT DF_Enchantment_RelativeChance DEFAULT(10),
	PowerReserveType NVARCHAR(64)
		CONSTRAINT DF_Enchantment_PowerReserveType DEFAULT(NULL),
	PowerReserveAmount INT NOT NULL
		CONSTRAINT DF_Enchantment_PowerReserveAmount DEFAULT(0),
	IsActive BIT NOT NULL
		CONSTRAINT DF_Enchantment_IsActive DEFAULT(1),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_Enchantment_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT UK_Enchantment_EnchantmentCategoryID_Name UNIQUE(EnchantmentCategoryID, [Name])
)

-- make tables in GeneratedItems
CREATE TABLE GeneratedItems.InventoryItem(
	InventoryID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_InventoryItem_ID PRIMARY KEY,
	OwningUserID INT NOT NULL
		CONSTRAINT FK_InventoryItem_UserID
		REFERENCES AppRecords.[User](UserID),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	GeneratingTableName NVARCHAR(128) NOT NULL,
	Quantity INT NOT NULL
		CONSTRAINT DF_InventoryItem_Quantity DEFAULT(1),
	UnitPrice INT NOT NULL,
	BaseWeight INT NOT NULL,
	WeightType NVARCHAR(32) NOT NULL,
	IsActive BIT NOT NULL
		CONSTRAINT DF_InventoryItem_IsActive DEFAULT(1),
	GeneratedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_InventoryItem_GeneratedOn DEFAULT(SYSDATETIME()),
	EditedOn DATETIMEOFFSET
		CONSTRAINT DF_InventoryItem_EditedOn DEFAULT(NULL)
)
CREATE TABLE GeneratedItems.CreatedEnchantment(
	CreatedEnchantmentID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_CreatedEnchantment_ID PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	GeneratingCategoryName NVARCHAR(128) NOT NULL,
	Cost INT NOT NULL,
	WeightFactor DECIMAL(5,2) NOT NULL,
	PowerReserveType NVARCHAR(64),
	PowerReserveAmount INT NOT NULL
)
CREATE TABLE GeneratedItems.CreatedEmbellishment(
	CreatedEmbellishmentID INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_CreatedEmbellishment_ID PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	GeneratingCategoryName NVARCHAR(128) NOT NULL,
	CostFactor DECIMAL(5,2) NOT NULL,
	WeightFactor DECIMAL(5,2) NOT NULL,
)
CREATE TABLE GeneratedItems.EnchantmentRef(
	CreatedEnchantmentID INT NOT NULL
		CONSTRAINT FK_EnchantmentRef_CreatedEnchantmentID
		REFERENCES GeneratedItems.CreatedEnchantment(CreatedEnchantmentID),
	InventoryID INT NOT NULL
		CONSTRAINT FK_EnchantmentRef_InventoryID
		REFERENCES GeneratedItems.InventoryItem(InventoryID),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_EnchantmentRef_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT PK_EnchantmentRef_CreatedEnchantmentID_InventoryID PRIMARY KEY(CreatedEnchantmentID, InventoryID)
)
CREATE TABLE GeneratedItems.EmbellishmentRef(
	CreatedEmbellishmentID INT NOT NULL
		CONSTRAINT FK_EmbellishmentRef_CreatedEmbellishmentID
		REFERENCES GeneratedItems.CreatedEmbellishment(CreatedEmbellishmentID),
	InventoryID INT NOT NULL
		CONSTRAINT FK_EmbellishmentRef_InventoryID
		REFERENCES GeneratedItems.InventoryItem(InventoryID),
	CreatedOn DATETIMEOFFSET NOT NULL
		CONSTRAINT DF_EmbellishmentRef_CreatedOn DEFAULT(SYSDATETIME()),
	CONSTRAINT PK_EmbellishmentRef_CreatedEmbellishmentID_InventoryID PRIMARY KEY(CreatedEmbellishmentID, InventoryID)
)