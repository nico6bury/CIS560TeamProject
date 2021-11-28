using DataAccess;
using GURPSData.DataDelegates;
using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GURPSData.Repositories {
    /// <summary>
    /// Holds methods for manipulating InventoryItem
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class InventoryRepo : IInventoryRepo {
        private readonly SqlCommandExecutor executor;
        public InventoryRepo(string connectionString) {
            executor = new SqlCommandExecutor(connectionString);
        }//end constructor

        public InventoryItem CreateInventoryItem(int owningUserID, string name, string description, string generatingCategoryName, int quantity, int unitPrice, int baseWeight, string weightType) {
            var d = new CreateInventoryItemDataDelegate(owningUserID, name, description, generatingCategoryName, quantity, unitPrice, baseWeight, weightType);
            return executor.ExecuteNonQuery(d);
        }//end CreateInventoryItem(int owningUserID, string name, string description, string generatingCategoryName, int quantity, int unitPrice, int baseWeight)

        public IReadOnlyList<InventoryItem> RetrieveAllInventory() {
            var d = new RetrieveAllInventoryDataDelegate();
            return executor.ExecuteReader(d);
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
            var d = new SaveInventoryItemDataDelegate(inventoryID, owningUserID, name, description, generatingTableName, quantity, unitPrice, baseWeight, weightType);
            executor.ExecuteNonQuery(d);
        }//end SaveInventoryItem(int inventoryID, int owningUserID, string name, string description, string generatingTableName, int quantity, int unitPrice, int baseWeight, string weightType)
    }//end class InventoryRepo
    /// <summary>
    /// Holds methods for manipulating CreatedEmbellishment
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class CreatedEmbellishmentRepo : ICreatedEmbellishmentRepo {
        private readonly SqlCommandExecutor executor;
        public CreatedEmbellishmentRepo(string connectionString) {
            executor = new SqlCommandExecutor(connectionString);
        }//end constructor

        public CreatedEmbellishment CreateInventoryEmbellishment(string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor) {
            var d = new CreateInventoryEmbellishmentDataDelegate(name, description, generatingCategoryName, costFactor, weightFactor);
            return executor.ExecuteNonQuery(d);
        }//end CreateInventoryEmbellishment(string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor)

        public IReadOnlyList<CreatedEmbellishment> RetrieveAllCreatedEmbellishments() {
            var d = new RetrieveAllCreatedEmbellishmentsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllCreatedEmbellishments()

        public IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForID(int createdEmbellishmentID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEmbellishmentsForID(int createdEmbellishmentID)

        public IReadOnlyList<CreatedEmbellishment> RetrieveCreatedEmbellishmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEmbellishmentsForUser(int userID)

        public void SaveCreatedEmbellishment(int createdEmbellishmentID, string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor) {
            var d = new SaveCreatedEmbellishmentDataDelegate(createdEmbellishmentID, name, description, generatingCategoryName, costFactor, weightFactor);
            executor.ExecuteNonQuery(d);
        }//end SaveCreatedEmbellishment(int createdEmbellishmentID, string name, string description, string generatingCategoryName, decimal costFactor, decimal weightFactor)
    }//end class CreatedEmbellishmentRepo
    /// <summary>
    /// Holds methods for manipulating CreatedEnchantment
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class CreatedEnchantmentRepo : ICreatedEnchantmentRepo {
        private readonly SqlCommandExecutor executor;
        public CreatedEnchantmentRepo(string connectionString) {
            executor = new SqlCommandExecutor(connectionString);
        }//end constructor
        
        public CreatedEnchantment CreateInventoryEnchantment(string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount) {
            var d = new CreateInventoryEnchantmentDataDelegate(name, description, generatingCategoryName, cost, weightFactor, powerReserveType, powerReserveAmount);
            return executor.ExecuteNonQuery(d);
        }//end CreateInventoryEnchantment(string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount)

        public IReadOnlyList<CreatedEnchantment> RetrieveAllCreatedEnchantments() {
            var d = new RetrieveAllCreatedEnchantmentsDataDelegate();
            return executor.ExecuteReader(d);
        }//end RetrieveAllCreatedEnchantments()

        public IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForID(int createdEnchantmentID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEnchantmentsForID(int createdEnchantmentID)

        public IReadOnlyList<CreatedEnchantment> RetrieveCreatedEnchantmentsForUser(int userID) {
            throw new NotImplementedException();
        }//end RetrieveCreatedEnchantmentsForUser(int userID)

        public void SaveCreatedEnchantment(int createdEnchantmentID, string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount) {
            var d = new SaveCreatedEnchantmentDataDelegate(createdEnchantmentID, name, description, generatingCategoryName, cost, weightFactor, powerReserveType, powerReserveAmount);
            executor.ExecuteNonQuery(d);
        }//end SaveCreatedEnchantment(int createdEnchantmentID, string name, string description, string generatingCategoryName, int cost, decimal weightFactor, string powerReserveType, int powerReserveAmount)
    }//end class CreatedEnchantmentRepo
    /// <summary>
    /// Holds methods for manipulating EmbellishmentRef
    /// table in GeneratedItems schema of database.
    /// </summary>
    public class EmbellishmentRefRepo : IEmbellishmentRefRepo {
        private readonly SqlCommandExecutor executor;
        public EmbellishmentRefRepo(string connectionString) {
            executor = new SqlCommandExecutor(connectionString);
        }//end constructor

        public void DeleteEmbellishmentRef(int createdEmbellishmentID, int inventoryID) {
            var d = new DeleteEmbellishmentRefDataDelegate(createdEmbellishmentID, inventoryID);
            executor.ExecuteNonQuery(d);
        }//end DeleteEmbellishmentRef(int createdEmbellishmentID, int inventoryID)

        public EmbellishmentRef LinkInventoryEmbellishment(int createdEmbellishmentID, int inventoryID) {
            var d = new LinkInventoryEmbellishmentDataDelegate(createdEmbellishmentID, inventoryID);
            return executor.ExecuteNonQuery(d);
        }//end LinkInventoryEmbellishment(int createdEmbellishmentID, int inventoryID)

        public IReadOnlyList<EmbellishmentRef> RetrieveAllEmbellishmentRefs() {
            var d = new RetrieveAllEmbellishmentRefsDataDelegate();
            return executor.ExecuteReader(d);
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
        private readonly SqlCommandExecutor executor;
        public EnchantmentRefRepo(string connectionString) {
            executor = new SqlCommandExecutor(connectionString);
        }//end constructor

        public void DeleteEnchantmentRef(int createdEnchantmentID, int inventoryID) {
            var d = new DeleteEnchantmentRefDataDelegate(createdEnchantmentID, inventoryID);
            executor.ExecuteNonQuery(d);
        }//end DeleteEnchantmentRef(int createdEnchantmentID, int inventoryID)

        public EnchantmentRef LinkInventoryEnchantment(int createdEnchantmentID, int inventoryID) {
            var d = new LinkInventoryEnchantmentDataDelegate(createdEnchantmentID, inventoryID);
            return executor.ExecuteNonQuery(d);
        }//end LinkInventoryEnchantment(int createdEnchantmentID, int inventoryID)

        public IReadOnlyList<EnchantmentRef> RetrieveAllEnchantmentRefs() {
            var d = new RetrieveAllEnchantmentRefsDataDelegate();
            return executor.ExecuteReader(d);
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
