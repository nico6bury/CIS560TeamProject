/*
 * Author: Nicholas Sixbury
 * File: AppRecordRepoInterfaces.cs
 * Interfaces: IUserRepo,IItemCategoryRepo,IItemRepo,IItemSubcategoryRepo,
 * IItemTypeOptionRepo,IEmbellishmentCategoryRepo,IEmbellishmentRepo,
 * IEnchantmentCategoryRepo,IEnchantmentRepo
 * Purpose: To provide a single, well documented file for all the repository interfaces
 * for stuff from the AppRecords schema in the database.
 */

using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Repositories {
    /// <summary>
    /// Interface for repositories handling User information.
    /// </summary>
    public interface IUserRepo {
        
        IReadOnlyList<User> RetrieveAllUsers();

        IReadOnlyList<User> RetrieveUserForID(int userID);

        IReadOnlyList<User> RetrieveUserForUsername(string username);

        User CreateUser(string username, string password);

        void SaveUser(int userID, string username, string password);
    }//end interface IUserRepo
    /// <summary>
    /// Interface for repositories handling ItemCategory information.
    /// </summary>
    public interface IItemCategoryRepo {
        
        IReadOnlyList<ItemCategory> RetrieveAllItemCategories();

        IReadOnlyList<ItemCategory> RetrieveItemCategoriesForUserID(int userID);

        IReadOnlyList<ItemCategory> RetrieveItemCategoriesForID(int itemCatgoryID);

        IReadOnlyList<ItemCategory> RetrieveDefaultItemCategories();

        ItemCategory CreateItemCategory(int owningUserID, string name, string description);

        void SaveItemCategory(int itemCategoryID, int owningUserID, string name, string description);
    }//end interface IItemCategoryRepo
    /// <summary>
    /// Interface for repositories handling Item information.
    /// </summary>
    public interface IItemRepo {
        
        IReadOnlyList<Item> RetrieveAllItems();
        
        IReadOnlyList<Item> RetrieveItemsForName(string name);
        
        IReadOnlyList<Item> RetrieveItemsForCategoryID(int categoryID);

        IReadOnlyList<Item> RetrieveItemsForUserID(int userID);

        IReadOnlyList<Item> RetrieveItemsForID(int itemID);

        Item CreateItem(int itemCategoryID, string name, int unitPrice, int baseWeight,
            string weightType, int quantityMin, int quantityMax, string description,
            int relativeChance);

        void SaveItem(int itemID, string name, string description, int unitPrice,
            int baseWeight, string weightType, int quantityMin, int quantityMax,
            int relativeChance);
    }//end interface IItemRepo
    /// <summary>
    /// Interface for repositories handling ItemSubcategory information.
    /// </summary>
    public interface IItemSubcategoryRepo {
        
        IReadOnlyList<ItemSubcategory> RetrieveAllItemSubcategories();

        IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForItemID(int itemID);

        IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForItemCategoryID(int itemCategoryID);

        IReadOnlyList<ItemSubcategory> RetrieveItemSubcategoriesForID(int itemSubcategoryID);


    }//end interface IItemSubcategoryRepo
    /// <summary>
    /// Interface for repositories handling ItemTypeOption information.
    /// </summary>
    public interface IItemTypeOptionRepo {
        
        IReadOnlyList<ItemTypeOption> RetrieveAllItemTypeOptions();

        IReadOnlyList<ItemTypeOption> RetrieveItemTypeOptionsForItemSubcategoryID(int itemSubcategoryID);

        IReadOnlyList<ItemTypeOption> RetrieveItemTypeOptionsForID(int itemTypeOptionID);

    }//end interface IItemTypeOptionReop
    /// <summary>
    /// Interface for repositories handling EmbellishmentCategory information.
    /// </summary>
    public interface IEmbellishmentCategoryRepo {
        
        IReadOnlyList<EmbellishmentCategory> RetrieveAllEmbellishmentCategories();

        IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForUser(int userID);

        IReadOnlyList<EmbellishmentCategory> RetrieveEmbellishmentCategoriesForID(
            int embellishmentCategoryID);

        EmbellishmentCategory CreateEmbellishmentCategory(int owningUserID, string name,
            string description, int relativeChance);

        void SaveEmbellishmentCategory(int embellishmentCategoryID, int owningUserID,
            string name, string description, int relativeChance);
    }//end interface IEmbellishmentCategoryRepo
    /// <summary>
    /// Interface for repositories handling Embellishment information.
    /// </summary>
    public interface IEmbellishmentRepo {
        
        IReadOnlyList<Embellishment> RetrieveAllEmbellishments();

        IReadOnlyList<Embellishment> RetrieveEmbellishmentsForCategory(int embellishmentCategoryID);

        IReadOnlyList<Embellishment> RetrieveEmbellishmentsForUser(int userID);

        IReadOnlyList<Embellishment> RetrieveEmbellishmentsForID(int embellishmentID);

        Embellishment CreateEmbellishment(int embellishmentCategoryID, string name,
            string description, decimal costFactor, decimal weightFactor, int relativeChance);

        void SaveEmbellishment(int embellishmentID, int embellishmentCategoryID,
            string name, string description, decimal costFactor, decimal weightFactor,
            int relativeChance);
    }//end interface IEmbellishmentRepo
    /// <summary>
    /// Interface for repositories handling EnchantmentCategory information.
    /// </summary>
    public interface IEnchantmentCategoryRepo {
        
        IReadOnlyList<EnchantmentCategory> RetrieveAllEnchantmentCategories();

        IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForUser(int userID);

        IReadOnlyList<EnchantmentCategory> RetrieveEnchantmentCategoriesForID(
            int enchantmentCategoryID);

        EnchantmentCategory CreateEnchantmentCategory(int owningUserID, string name,
            string description, int relativeChance);

        void SaveEnchantmentCategory(int enchantmentCategoryID, int owningUserID,
            string name, string description, int relativeChance);
    }//end interface IEnchantmentCategoryRepo
    /// <summary>
    /// Interface for repositories handling Enchantment information.
    /// </summary>
    public interface IEnchantmentRepo {
        
        IReadOnlyList<Enchantment> RetrieveAllEnchantments();

        IReadOnlyList<Enchantment> RetrieveEnchantmentsForUser(int userID);

        IReadOnlyList<Enchantment> RetrieveEnchantmentsForCategory(int enchantmentCategoryID);

        IReadOnlyList<Enchantment> RetrieveEnchantmentsForID(int enchantmentID);

        Enchantment CreateEnchantment(int enchantmentCategoryID, string name, string description,
            int cost, decimal weightFactor, int relativeChance, string powerReserveType,
            int powerReserveAmount);

        void SaveEnchantment(int enchantmentID, int enchantmentCategoryID,
            string name, string description, int cost, decimal weightFactor,
            int relativeChance, string powerReserveType, int powerReserveAmount);
    }//end interface IEnchantmentRepo
}//end namespace
