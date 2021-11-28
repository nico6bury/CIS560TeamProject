using DataAccess;
using GURPSData.DataDelegates;
using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Repositories {
    public class ReportRepos {
        private readonly SqlCommandExecutor executor;
        public ReportRepos(string connectionString)
            { executor = new SqlCommandExecutor(connectionString); }

        /// <summary>
        /// For each user, show number of tables they’ve created,
        /// number of items they’ve created, number of categories
        /// generated from, number of items generated, and the day
        /// they joined.
        /// </summary>
        /// <returns>int UserID,string Username,int TablesCreated,
        /// int ItemsCreated,int TablesUsed,int ItemsGenerated,
        /// DateTime JoinedOn</returns>
        public IReadOnlyList<UserItemSummary> GetUserItemSummary() {
            var d = new UserItemSummaryDataDelegate();
            return executor.ExecuteReader(d);
        }//end GetUserItemSummary()

        /// <summary>
        /// Statistics information for every ItemCategory, including
        /// the creating user, number of items in the table, average
        /// cost and weight of items in the table, total cost and
        /// weight of all items in the table, createdOn date, sorted
        /// by least recent creation.
        /// </summary>
        /// <returns>int ItemCategoryID, string Name,
        /// string Description, string OwningUser,
        /// int AverageCost, int AverageWeight,
        /// int TotalCost, int TotalWeight</returns>
        public IReadOnlyList<ItemCategorySummary> GetItemCategorySummary() {
            var d = new ItemCategorySummaryDataDelegate();
            return executor.ExecuteReader(d);
        }//end GetItemCategorySummary()

        /// <summary>
        /// For all items in a particular table, show each combination
        /// of variations of single embellishments and enchantments from
        /// selected embellishment and enchantment categories, including
        /// a final cost and weight for each item, also including
        /// category of each item, embellishment, and enchantment in
        /// the row they belong in.
        /// </summary>
        /// <param name="itemCategoryID">The ID number of the item table
        /// to generate a report on.</param>
        /// <param name="enchantmentCategoryID">The ID number of the
        /// enchantment table to pull enchantments from.</param>
        /// <param name="embellishmentCategoryID">The ID number of the
        /// embellishment table to pull embellishments from.</param>
        /// <returns>int ItemID, string ItemName,
        /// int EnchantmentID, string EnchantmentName,
        /// int EmbellishmentID, string EmbellishmentName,
        /// decimal Cost, decimal Weight</returns>
        public IReadOnlyList<ItemEnhancementSummary> GetItemEnhancementSummary(
            int itemCategoryID, int enchantmentCategoryID,
            int embellishmentCategoryID) {
            var d = new ItemEnhancementSummaryDataDelegate(itemCategoryID,
                enchantmentCategoryID, embellishmentCategoryID);
            return executor.ExecuteReader(d);
        }//end GetItemEnhancementSummary(itemCategoryID,enchantmentCategoryID,embellishmentCategoryID)

        /// <summary>
        /// List all items that have been generated for a particular
        /// user, including information on most and least recent
        /// generation date, cost and weight of each item, the
        /// category each item is from, the name of the item, and
        /// number of users which have generated them. Items are
        /// ordered descending by the number of users who have that
        /// item in their inventory.
        /// </summary>
        /// <param name="userID">The ID number of the user to
        /// generate a report on (ie, will pull from their
        /// inventory).</param>
        /// <returns>string Name, string GeneratingTableName,
        /// DateTime EarliestGeneration, DateTime LatestGeneration,
        /// int UnitPrice, int BaseWeight, int NumberGenerated</returns>
        public IReadOnlyList<UserInventorySummary> GetUserInventorySummary(
            int userID) {
            var d = new UserInventorySummaryDataDelegate(userID);
            return executor.ExecuteReader(d);
        }//end GetUserInventorySummary(userID)
    }//end class Repos
}//end namespace
