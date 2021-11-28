using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Repositories {
    /// <summary>
    /// Holds methods for manipulating User
    /// table in AppRecords schema of database.
    /// </summary>
    public class UserRepo : IUserRepo {
        public User CreateUser(string username, string password) {
            throw new NotImplementedException();
        }//end CreateUser(username, password)

        public IReadOnlyList<User> RetrieveAllUsers() {
            throw new NotImplementedException();
        }//end RetrieveAllUsers()

        public IReadOnlyList<User> RetrieveUserForID(int userID) {
            throw new NotImplementedException();
        }//end RetrieveUserForID(userID)

        public IReadOnlyList<User> RetrieveUserForUsername(string username) {
            throw new NotImplementedException();
        }//end RetrieveUserForUsername(username)

        public void SaveUser(int userID, string username, string password) {
            throw new NotImplementedException();
        }//end SaveUser(userID, username, password)
    }//end class UserRepo
    /// <summary>
    /// Holds methods for manipulating ItemCategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemCategoryRepo : IItemCategoryRepo {
        public ItemCategory CreateItemCategory(int owningUserID, string name) {
            throw new NotImplementedException();
        }//end CreateItemCategory(owningUserID, name)

        public IReadOnlyList<ItemCategory> RetrieveAllItemCategories() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }//end SaveItemCategory(itemCategoryID, owningUserID, name, description)
    }//end class ItemCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Item
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemRepo : IItemRepo {
        public Item CreateItem(int itemCategoryID, string name, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, string description, int relativeChance) {
            throw new NotImplementedException();
        }//end CreateItem(int itemCategoryID, string name, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, string description, int relativeChance)

        public IReadOnlyList<Item> RetrieveAllItems() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }//end SaveItem(int itemID, string name, string description, int unitPrice, int baseWeight, string weightType, int quantityMin, int quantityMax, int relativeChance)
    }//end class ItemRepo
    /// <summary>
    /// Holds methods for manipulating ItemSubcategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class ItemSubcategoryRepo : IItemSubcategoryRepo {
        public IReadOnlyList<ItemSubcategory> RetrieveAllItemSubcategories() {
            throw new NotImplementedException();
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
        public IReadOnlyList<ItemTypeOption> RetrieveAllItemTypeOptions() {
            throw new NotImplementedException();
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
        public EmbellishmentCategory CreateEmbellishmentCategory(int owningUserID, string name, string description, int relativeChance) {
            throw new NotImplementedException();
        }//end CreateEmbellishmentCategory(int owningUserID, string name, string description, int relativeChance)

        public IReadOnlyList<EmbellishmentCategory> RetrieveAllEmbellishmentCategories() {
            throw new NotImplementedException();
        }//end RetrieveAllEmbellishmentCategories()

        public IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForID(int embellishmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentCategoriesForID(int embellishmentCategoryID)

        public IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentCategoriesForUser(int userID)

        public void SaveEmbellishmentCategory(int embellishmentCategoryID, int owningUserID, string name, string description, int relativeChance) {
            throw new NotImplementedException();
        }//end SaveEmbellishmentCategory(int embellishmentCategoryID, int owningUserID, string name, string description, int relativeChance)
    }//end class EmbellishmentCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Embellishment
    /// table in AppRecords schema of database.
    /// </summary>
    public class EmbellishmentRepo : IEmbellishmentRepo {
        public Embellishment CreateEmbellishment(int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance) {
            throw new NotImplementedException();
        }//end CreateEmbellishment(int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance)

        public IReadOnlyList<Embellishment> RetrieveAllEmbellishments() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }//end SaveEmbellishment(int embellishmentID, int embellishmentCategoryID, string name, string description, decimal costFactor, decimal weightFactor, int relativeChance)
    }//end class EmbellishmentRepo
    /// <summary>
    /// Holds methods for manipulating EnchantmentCategory
    /// table in AppRecords schema of database.
    /// </summary>
    public class EnchantmentCategoryRepo : IEnchantmentCategoryRepo {
        public EnchantmentCategory CreateEnchantmentCategory(int owningUserID, string name, string description, int relativeChance) {
            throw new NotImplementedException();
        }//end CreateEnchantmentCategory(int owningUserID, string name, string description, int relativeChance)

        public IReadOnlyList<EnchantmentCategory> RetrieveAllEnchantmentCategories() {
            throw new NotImplementedException();
        }//end RetrieveAllEnchantmentCategories()

        public IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForID(int enchantmentCategoryID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentCategoriesForID(int enchantmentCategoryID)

        public IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentCategoriesForUser(int userID)

        public void SaveEnchantmentCategory(int enchantmentCategoryID, int owningUserID, string name, string description, int relativeChance) {
            throw new NotImplementedException();
        }//end SaveEnchantmentCategory(int enchantmentCategoryID, int owningUserID, string name, string description, int relativeChance)
    }//end class EnchantmentCategoryRepo
    /// <summary>
    /// Holds methods for manipulating Enchantment
    /// table in AppRecords schema of database.
    /// </summary>
    public class EnchantmentRepo : IEnchantmentRepo {
        public Enchantment CreateEnchantment(int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount) {
            throw new NotImplementedException();
        }//end CreateEnchantment(int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount)

        public IReadOnlyList<Enchantment> RetrieveAllEnchantments() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }//end SaveEnchantment(int enchantmentID, int enchantmentCategoryID, string name, string description, int cost, decimal weightFactor, int relativeChance, string powerReserveType, int powerReserveAmount)
    }//end class EnchantmentRepo
}//end namespace