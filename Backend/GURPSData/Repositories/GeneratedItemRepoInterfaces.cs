/*
 * Author: Nicholas Sixbury
 * File: GeneratedItemRepoInterfaces.cs
 * Interfaces: IInventoryRepo, ICreatedEmbellishmentRepo, ICreatedEnchantmentRepo,
 * IEmbellishmentRefRepo, IEnchantmentRefRepo
 * Purpose: To provide a single, well documented file to hold all the interfaces for
 * repository classes for stuff in the GeneratedItems schema in the database.
 */

using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Repositories {
    /// <summary>
    /// Interface for repositories handling InventoryItem information.
    /// </summary>
    public interface IInventoryRepo {
        IReadOnlyList<InventoryItem> RetrieveAllInventory();

        IReadOnlyList<InventoryItem> RetrieveInventoryForUser(int userID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForEnchantment(int createdEnchantmentID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForEmbellishment(int createdEmbellishmentID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForUserAndEnchantment(int userID,
            int createdEnchantmentID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForUserAndEmbellishment(int userID,
            int createdEmbellishmentID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForUserEnchantmentEmbellishment(int userID,
            int createdEnchantmentID, int createdEmbellishmentID);

        IReadOnlyList<InventoryItem> RetrieveInventoryForID(int inventoryID);

        InventoryItem CreateInventoryItem(int owningUserID, string name, string description,
            string generatingCategoryName, int quantity, int unitPrice, int baseWeight);

        void SaveInventoryItem(int inventoryID, int owningUserID, string name, string description,
            string generatingTableName, int quantity, int unitPrice,
            int baseWeight, string weightType);
    }//emd interface IInventoryRepo
    /// <summary>
    /// Interface for repositories handling CreatedEmbellishment information.
    /// </summary>
    public interface ICreatedEmbellishmentRepo {
        IReadOnlyList<CreatedEmbellishment> RetrieveAllCreatedEmbellishments();

        IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForUser(int userID);

        IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForID(
            int createdEmbellishmentID);

        CreatedEmbellishment CreateInventoryEmbellishment(string name, string description,
            string generatingCategoryName, decimal costFactor, decimal weightFactor);

        void SaveCreatedEmbellishment(int createdEmbellishmentID, string name, string description,
            string generatingCategoryName, decimal costFactor, decimal weightFactor);
    }//end interface ICreatedEmbellishmentRepo
    /// <summary>
    /// Interface for repositories handling CreatedEnchantment information.
    /// </summary>
    public interface ICreatedEnchantmentRepo {
        IReadOnlyList<CreatedEnchantment> RetrieveAllCreatedEnchantments();

        IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForUser(int userID);

        IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForID(int createdEnchantmentID);

        CreatedEnchantment CreateInventoryEnchantment(string name, string description,
            string generatingCategoryName, int cost, decimal weightFactor,
            string powerReserveType, int powerReserveAmount);

        void SaveCreatedEnchantment(int createdEnchantmentID, string name, string description,
            string generatingCategoryName, int cost, decimal weightFactor,
            string powerReserveType, int powerReserveAmount);
    }//end interface ICreatedEnchantmentRepo
    /// <summary>
    /// Interface for repositories handling EmbellishmentRef information.
    /// </summary>
    public interface IEmbellishmentRefRepo {
        IReadOnlyList<EmbellishmentRef> RetrieveAllEmbellishmentRefs();

        IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForEmbellishmentAndItem(
            int createdEmbellishmentID, int inventoryID);

        IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForUser(int userID);

        IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForItem(int inventoryID);

        EmbellishmentRef LinkInventoryEmbellishment(int createdEmbellishmentID, int inventoryID);

        void DeleteEmbellishmentRef(int createdEmbellishmentID, int inventoryID);
    }//end interface IEmbellishmentRefRepo
    /// <summary>
    /// Interface for repositories handling EnchantmentRef information.
    /// </summary>
    public interface IEnchantmentRefRepo {
        IReadOnlyList<EnchantmentRef> RetrieveAllEnchantmentRefs();

        IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForEnchantmentAndItem(
            int createdEnchantmentID, int inventoryID);

        IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForUser(int userID);

        IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForItem(int inventoryID);

        EnchantmentRef LinkInventoryEnchantment(int createdEnchantmentID, int inventoryID);

        void DeleteEnchantmentRef(int createdEnchantmentID, int inventoryID);
    }//end interface IEnchantmentRefRepo
}//end namespace
