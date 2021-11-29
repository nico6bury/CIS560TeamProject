using DataAccess;
using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GURPSData.DataDelegates;

namespace GURPSData.Repositories {
    /// <summary>
    /// Holds methods for manipulating User
    /// table in AppRecords schema of database.
    /// </summary>
    public class UserRepo : IUserRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public User CreateUser(string username, string password) {
            var d = new CreateUserDataDelegate(username, password);
            return executor.ExecuteNonQuery(d);
        }//end CreateUser(username, password)

        public IReadOnlyList<User> RetrieveAllUsers() {
            var d = new RetrieveAllUsersDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllUsers()

        public IReadOnlyList<User> RetrieveUserForID(int userID) {
            throw new NotImplementedException();
        }//end RetrieveUserForID(userID)

        public IReadOnlyList<User> RetrieveUserForUsername(string username) {
            var d = new RetrieveUserForUsernameDataDelegate(username);
            return executor.ExecuteReader(d);
        }//end RetrieveUserForUsername(username)

        public void SaveUser(int userID, string username, string password) {
            var d = new SaveUserDataDelegate(userID, username, password);
            executor.ExecuteNonQuery(d);
        }//end SaveUser(userID, username, password)
    }//end class UserRepo
    /// <summary>
    /// Holds methods for manipulating ItemCategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemCategoryRepo : IItemCategoryRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public ItemCategory CreateItemCategory(int owningUserID, string name) {
            var d = new CreateItemCategoryDataDelegate(owningUserID, name);
            return executor.ExecuteNonQuery(d);
        }//end CreateItemCategory(owningUserID, name)

        public IReadOnlyList<ItemCategory> RetrieveAllItemCategories() {
            var d = new RetrieveAllItemCategoriesDateDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllItemCategories()

        public IReadOnlyList<ItemCategory> RetrieveDefaultItemCategories() {
            throw new NotImplementedException();
        }//end RetrieveDefaultItemCategories()

        public IReadOnlyList<ItemCategory> RetrieveItemCategoriesForID(int itemCatgoryID) {
            throw new NotImplementedException();
        }//end RetrieveItemCategoriesForID(itemCategoryID)

        public IReadOnlyList<ItemCategory> RetrieveItemCategoriesForUserID(int userID) {
            throw new NotImplementedException();
        }//end RetrieveItemCategoriesForUserID(userID)

        public void SaveItemCategory(int itemCategoryID, int owningUserID, string name, string description) {
            var d = new SaveItemCategoryDataDelegate(itemCategoryID, owningUserID, name, description);
            executor.ExecuteNonQuery(d);
        }//end SaveItemCategory(itemCategoryID, owningUserID, name, description)
    }//end class ItemCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Item
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemRepo : IItemRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public Item CreateItem(int itemCategoryID, string name, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, string description, int relativeChance) {
            var d = new CreateItemDataDelegate(itemCategoryID, name, unitPrice, baseWeight, weightType, quantityMin, quantityMax, description, relativeChance);
            return executor.ExecuteNonQuery(d);
        }//end CreateItem(int itemCategoryID, string name, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, string description, int relativeChance)

        public IReadOnlyList<Item> RetrieveAllItems() {
            var d = new RetrieveAllItemsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllItems()

        public IReadOnlyList<Item> RetrieveItemsForCategoryID(int categoryID) {
            throw new NotImplementedException();
        }//end RetrieveItemsForCategoryID(categoryID)

        public IReadOnlyList<Item> RetrieveItemsForID(int itemID) {
            throw new NotImplementedException();
        }//end RetrieveItemsForID(itemID)

        public IReadOnlyList<Item> RetrieveItemsForName(string name) {
            throw new NotImplementedException();
        }//end RetrieveItemsForName(name)

        public IReadOnlyList<Item> RetrieveItemsForUserID(int userID) {
            throw new NotImplementedException();
        }//end RetrieveItemsForUserID(userID)

        public void SaveItem(int itemID, string name, string description, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, int relativeChance) {
            var d = new SaveItemDataDelegate(itemID, name, unitPrice, description, baseWeight, weightType, quantityMin, quantityMax, relativeChance);
            executor.ExecuteNonQuery(d);
        }//end SaveItem(int itemID, string name, string description, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, int relativeChance)
    }//end class ItemRepo
    /// <summary>
    /// Holds methods for manipulating ItemSubcategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemSubcategoryRepo : IItemSubcategoryRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public IReadOnlyList<ItemSubcategory> RetrieveAllItemSubcategories() {
            var d = new RetrieveAllItemSubcategoriesDataDelegate();
            return executor.ExecuteReader(d);
        }// end RetrieveAllItemSubcategories()

        public IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForID(int itemSubcategoryID) {
            throw new NotImplementedException();
        }//end RetrieveItemSubcategoriesForID(itemSubcategoryID)

        public IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForItemCategoryID(int itemCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveItemSubcategoriesForItemCategoryID(itemCategoryID)

        public IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForItemID(int itemID) {
            throw new NotImplementedException();
        }//end RetrieveItemSubcategoriesForItemID(itemID)
    }//end class ItemSubcategoryRepo
    /// <summary>
    /// Holds methods for manipulating ItemTypeOption
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemTypeOptionRepo : IItemTypeOptionRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public IReadOnlyList<ItemTypeOption> RetrieveAllItemTypeOptions() {
            var d = new RetrieveAllItemTypeOptionsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllItemTypeOptions()

        public IReadOnlyList<ItemTypeOption> RetrieveItemTypeOptionsForID(int itemTypeOptionID) {
            throw new NotImplementedException();
        }//end RetrieveItemTypeOptionsForID(itemTypeOptionID)

        public IReadOnlyList<ItemTypeOption> RetrieveItemTypeOptionsForItemSubcategoryID(int itemSubcategoryID) {
            throw new NotImplementedException();
        }//end RetrieveItemTypeOptionsForItemSubcategoryID(int itemSubcategoryID)
    }//end class ItemTypeOptionRepo
    /// <summary>
    /// Holds methods for manipulating EmbellishmentCategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class EmbellishmentCategoryRepo : IEmbellishmentCategoryRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public EmbellishmentCategory CreateEmbellishmentCategory(int owningUserID, string name, string description, int relativeChance) {
            var d = new CreateEmbellishmentCategoryDataDelegate(owningUserID, name, relativeChance, description);
            return executor.ExecuteNonQuery(d);
        }//end CreateEmbellishmentCategory(int owningUserID, string name, string description, int relativeChance)

        public IReadOnlyList<EmbellishmentCategory> RetrieveAllEmbellishmentCategories() {
            var d = new RetrieveAllEmbellishmentCategoriesDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllEmbellishmentCategories()

        public IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForID(int embellishmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentCategoriesForID(int embellishmentCategoryID)

        public IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentCategoriesForUser(int userID)

        public void SaveEmbellishmentCategory(int embellishmentCategoryID, int owningUserID, string name, string description, int relativeChance) {
            var d = new SaveEmbellishmentCategoryDataDelegate(embellishmentCategoryID, owningUserID, name, relativeChance, description);
            executor.ExecuteNonQuery(d);
        }//end SaveEmbellishmentCategory(int embellishmentCategoryID, int owningUserID, string name, string description, int relativeChance)
    }//end class EmbellishmentCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Embellishment
    /// table in AppRecords schema of database.
    /// </summary>
    public class EmbellishmentRepo : IEmbellishmentRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public Embellishment CreateEmbellishment(int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance) {
            var d = new CreateEmbellishmentDataDelegate(embellishmentCategoryID, name, description, costFactor, weightFactor, relativeChance);
            return executor.ExecuteNonQuery(d);
        }//end CreateEmbellishment(int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance)

        public IReadOnlyList<Embellishment> RetrieveAllEmbellishments() {
            var d = new RetrieveAllEmbellishmentsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllEmbellishments()

        public IReadOnlyList<Embellishment> RetrieveEmbellishmentsForCategory(int embellishmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentsForCategory(int embellishmentCategoryID)

        public IReadOnlyList<Embellishment> RetrieveEmbellishmentsForID(int embellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentsForID(int embellishmentID)

        public IReadOnlyList<Embellishment> RetrieveEmbellishmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentsForUser(int userID)

        public void SaveEmbellishment(int embellishmentID, int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance) {
            var d = new SaveEmbellishmentDataDelegate(embellishmentID, embellishmentCategoryID, name, description, costFactor, weightFactor, relativeChance);
            executor.ExecuteNonQuery(d);
        }//end SaveEmbellishment(int embellishmentID, int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance)
    }//end class EmbellishmentRepo
    /// <summary>
    /// Holds methods for manipulating EnchantmentCategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class EnchantmentCategoryRepo : IEnchantmentCategoryRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public EnchantmentCategory CreateEnchantmentCategory(int owningUserID, string name, string description, int relativeChance) {
            var d = new CreateEnchantmentCategoryDataDelegate(owningUserID, name, relativeChance, description);
            return executor.ExecuteNonQuery(d);
        }//end CreateEnchantmentCategory(int owningUserID, string name, string description, int relativeChance)

        public IReadOnlyList<EnchantmentCategory> RetrieveAllEnchantmentCategories() {
            var d = new RetrieveAllEnchantmentCategoriesDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllEnchantmentCategories()

        public IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForID(int enchantmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentCategoriesForID(int enchantmentCategoryID)

        public IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentCategoriesForUser(int userID)

        public void SaveEnchantmentCategory(int enchantmentCategoryID, int owningUserID, string name, string description, int relativeChance) {
            var d = new SaveEnchantmentCategoryDataDelegate(enchantmentCategoryID,owningUserID,name,relativeChance,description);
            executor.ExecuteNonQuery(d);
        }//end SaveEnchantmentCategory(int enchantmentCategoryID, int owningUserID, string name, string description, int relativeChance)
    }//end class EnchantmentCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Enchantment
    /// table in AppRecords schema of database.
    /// </summary>
    public class EnchantmentRepo : IEnchantmentRepo {
        private readonly SqlCommandExecutor executor = new SqlCommandExecutor(Statics.BuildConnectionString());

        public Enchantment CreateEnchantment(int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount) {
            var d = new CreateEnchantmentDataDelegate(enchantmentCategoryID, name, description, cost, weightFactor, relativeChance, powerReserveType, powerReserveAmount);
            return executor.ExecuteNonQuery(d);
        }//end CreateEnchantment(int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount)

        public IReadOnlyList<Enchantment> RetrieveAllEnchantments() {
            var d = new RetrieveAllEnchantmentsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllEnchantments()

        public IReadOnlyList<Enchantment> RetrieveEnchantmentsForCategory(int enchantmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentsForCategory(int enchantmentCategoryID)

        public IReadOnlyList<Enchantment> RetrieveEnchantmentsForID(int enchantmentID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentsForID(int enchantmentID)

        public IReadOnlyList<Enchantment> RetrieveEnchantmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentsForUser(int userID)

        public void SaveEnchantment(int enchantmentID, int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount) {
            var d = new SaveEnchantmentDataDelegate(enchantmentID, enchantmentCategoryID, name, description, cost, weightFactor, relativeChance, powerReserveType, powerReserveAmount);
            executor.ExecuteNonQuery(d);
        }//end SaveEnchantment(int enchantmentID, int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount)
    }//end class EnchantmentRepo
}//end namespace