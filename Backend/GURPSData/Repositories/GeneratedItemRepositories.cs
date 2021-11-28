using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Repositories {
    /// <summary>
    /// Holds methods for manipulating InventoryItem
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class InventoryRepo : IInventoryRepo {
        public InventoryItem CreateInventoryItem(int owningUserID, string name, string description, string generatingCategoryName, int quantity, int unitPrice, int baseWeight) {
            throw new NotImplementedException();
        }//end CreateInventoryItem(int owningUserID, string name, string description, string generatingCategoryName, int quantity, int unitPrice, int baseWeight)

        public IReadOnlyList<InventoryItem> RetrieveAllInventory() {
            throw new NotImplementedException();
        }//end RetrieveAllInventory()

        public IReadOnlyList<InventoryItem> RetrieveInventoryForEmbellishment(int createdEmbellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForEmbellishment(int createdEmbellishmentID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForEnchantment(int createdEnchantmentID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForEnchantment(int createdEnchantmentID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForID(int inventoryID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForID(int inventoryID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForUser(int userID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForUserAndEmbellishment(int userID, int createdEmbellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForUserAndEmbellishment(int userID, int createdEmbellishmentID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForUserAndEnchantment(int userID, int createdEnchantmentID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForUserAndEnchantment(int userID, int createdEnchantmentID)

        public IReadOnlyList<InventoryItem> RetrieveInventoryForUserEnchantmentEmbellishment(int userID, int createdEnchantmentID, int createdEmbellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveInventoryForUserEnchantmentEmbellishment(int userID, int createdEnchantmentID, int createdEmbellishmentID)

        public void SaveInventoryItem(int inventoryID, int owningUserID, string name, string description, string generatingTableName, int quantity, int unitPrice, int baseWeight, string weightType) {
            throw new NotImplementedException();
        }//end SaveInventoryItem(int inventoryID, int owningUserID, string name, string description, string generatingTableName, int quantity, int unitPrice, int baseWeight, string weightType)
    }//end class InventoryRepo
    /// <summary>
    /// Holds methods for manipulating CreatedEmbellishment
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class CreatedEmbellishmentRepo : ICreatedEmbellishmentRepo {
        public CreatedEmbellishment CreateInventoryEmbellishment(string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor) {
            throw new NotImplementedException();
        }//end CreateInventoryEmbellishment(string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor)

        public IReadOnlyList<CreatedEmbellishment> RetrieveAllCreatedEmbellishments() {
            throw new NotImplementedException();
        }//end RetrieveAllCreatedEmbellishments()

        public IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForID(int createdEmbellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEmbellishmentsForID(int createdEmbellishmentID)

        public IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEmbellishmentsForUser(int userID)

        public void SaveCreatedEmbellishment(int createdEmbellishmentID, string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor) {
            throw new NotImplementedException();
        }//end SaveCreatedEmbellishment(int createdEmbellishmentID, string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor)
    }//end class CreatedEmbellishmentRepo
    /// <summary>
    /// Holds methods for manipulating CreatedEnchantment
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class CreatedEnchantmentRepo : ICreatedEnchantmentRepo {
        public CreatedEnchantment CreateInventoryEnchantment(string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount) {
            throw new NotImplementedException();
        }//end CreateInventoryEnchantment(string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount)

        public IReadOnlyList<CreatedEnchantment> RetrieveAllCreatedEnchantments() {
            throw new NotImplementedException();
        }//end RetrieveAllCreatedEnchantments()

        public IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForID(int createdEnchantmentID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEnchantmentsForID(int createdEnchantmentID)

        public IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEnchantmentsForUser(int userID)

        public void SaveCreatedEnchantment(int createdEnchantmentID, string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount) {
            throw new NotImplementedException();
        }//end SaveCreatedEnchantment(int createdEnchantmentID, string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount)
    }//end class CreatedEnchantmentRepo
    /// <summary>
    /// Holds methods for manipulating EmbellishmentRef
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class EmbellishmentRefRepo : IEmbellishmentRefRepo {
        public void DeleteEmbellishmentRef(int createdEmbellishmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end DeleteEmbellishmentRef(int createdEmbellishmentID, int inventoryID)

        public EmbellishmentRef LinkInventoryEmbellishment(int createdEmbellishmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end LinkInventoryEmbellishment(int createdEmbellishmentID, int inventoryID)

        public IReadOnlyList<EmbellishmentRef> RetrieveAllEmbellishmentRefs() {
            throw new NotImplementedException();
        }//end RetrieveAllEmbellishmentRefs()

        public IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForEmbellishmentAndItem(int createdEmbellishmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentRefsForEmbellishmentAndItem(int createdEmbellishmentID, int inventoryID)

        public IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForItem(int inventoryID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentRefsForItem(int inventoryID)

        public IReadOnlyList<EmbellishmentRef> RetrieveEmbellishmentRefsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEmbellishmentRefsForUser(int userID)
    }//end class EmbellishmentRefRepo
    /// <summary>
    /// Holds methods for manipulating EnchantmentRef
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class EnchantmentRefRepo : IEnchantmentRefRepo {
        public void DeleteEnchantmentRef(int createdEnchantmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end DeleteEnchantmentRef(int createdEnchantmentID, int inventoryID)

        public EnchantmentRef LinkInventoryEnchantment(int createdEnchantmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end LinkInventoryEnchantment(int createdEnchantmentID, int inventoryID)

        public IReadOnlyList<EnchantmentRef> RetrieveAllEnchantmentRefs() {
            throw new NotImplementedException();
        }//end RetrieveAllEnchantmentRefs()

        public IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForEnchantmentAndItem(int createdEnchantmentID, int inventoryID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentRefsForEnchantmentAndItem(int createdEnchantmentID, int inventoryID)

        public IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForItem(int inventoryID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentRefsForItem(int inventoryID)

        public IReadOnlyList<EnchantmentRef> RetrieveEnchantmentRefsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveEnchantmentRefsForUser(int userID)
    }//end class EnchantmentRefRepo
}//end namespace
