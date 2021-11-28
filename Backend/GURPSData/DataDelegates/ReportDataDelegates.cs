using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace GURPSData.DataDelegates {
    public struct UserItemSummary {
        public readonly int UserID;
        public readonly string Username;
        public readonly int TablesCreated;
        public readonly int ItemsCreated;
        public readonly int TablesUsed;
        public readonly int ItemsGenerated;
        public readonly DateTime JoinedOn;
        public UserItemSummary(int userID, string username,
            int tablesCreated, int itemsCreated, int tablesUsed,
            int itemsGenerated, DateTime joinedOn) {
            this.UserID = userID;
            this.Username = username;
            this.TablesCreated = tablesCreated;
            this.ItemsCreated = itemsCreated;
            this.TablesUsed = tablesUsed;
            this.ItemsGenerated = itemsGenerated;
            this.JoinedOn = joinedOn;
        }//end constructor
    }//end UserItemSummary struct
    internal class UserItemSummaryDataDelegate
        : DataReaderDelegate<IReadOnlyList<UserItemSummary>> {
        public UserItemSummaryDataDelegate() :
            base("AppRecords.UserItemSummary") { }
        public override IReadOnlyList<UserItemSummary> Translate(
            SqlCommand command, IDataRowReader reader) {
            var report = new List<UserItemSummary>();
            while (reader.Read()) {
                report.Add(new UserItemSummary(
                    reader.GetInt32("UserID"),
                    reader.GetString("Username"),
                    reader.GetInt32("TablesCreated"),
                    reader.GetInt32("ItemsCreated"),
                    reader.GetInt32("TablesUsed"),
                    reader.GetInt32("ItemsGenerated"),
                    reader.GetDateTimeOffset("JoinedOn").DateTime
                    ));
            }//end looping while we still have stuff to read
            return report;
        }//end Translate(command, reader)
    }//end class UserItemSummaryDataDelegate

    public struct ItemCategorySummary {
        public readonly int ItemCategoryID;
        public readonly string Name;
        public readonly string Description;
        public readonly string OwningUser;
        public readonly int AverageCost;
        public readonly int AverageWeight;
        public readonly int TotalCost;
        public readonly int TotalWeight;
        public ItemCategorySummary(int itemCategoryID,
            string name, string description, string owningUser,
            int averageCost, int averageWeight, int totalCost,
            int totalWeight) {
            this.ItemCategoryID = itemCategoryID;
            this.Name = name;
            this.Description = description;
            this.OwningUser = owningUser;
            this.AverageCost = averageCost;
            this.AverageWeight = averageWeight;
            this.TotalCost = totalCost;
            this.TotalWeight = totalWeight;
        }//end constructor
    }//end struct ItemCategorySummary
    internal class ItemCategorySummaryDataDelegate
        : DataReaderDelegate<IReadOnlyList<ItemCategorySummary>> {
        public ItemCategorySummaryDataDelegate() :
            base("AppRecords.ItemCategorySummary") { }
        public override IReadOnlyList<ItemCategorySummary> Translate(
            SqlCommand command, IDataRowReader reader) {
            var report = new List<ItemCategorySummary>();
            while (reader.Read()) {
                report.Add(new ItemCategorySummary(
                    reader.GetInt32("ItemCategoryID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetString("OwningUser"),
                    reader.GetInt32("AverageCost"),
                    reader.GetInt32("AverageWeight"),
                    reader.GetInt32("TotalCost"),
                    reader.GetInt32("TotalWeight")
                    ));
            }//end looping while we still have stuff to read
            return report;
        }//end Tranlsate(command, reader)
    }//end class ItemCategorySummaryDataDelegate

    public struct ItemEnhancementSummary {
        public readonly int ItemID;
        public readonly string ItemName;
        public readonly int EnchantmentID;
        public readonly string EnchantmentName;
        public readonly int EmbellishmentID;
        public readonly string EmbellishmentName;
        public readonly decimal Cost;
        public readonly decimal Weight;
        public ItemEnhancementSummary(int itemID, string itemName,
            int enchantmentID, string enchantmentName,
            int embellishmentID, string embellishmentName,
            decimal cost, decimal weight) {
            this.ItemID = itemID;
            this.ItemName = itemName;
            this.EnchantmentID = enchantmentID;
            this.EnchantmentName = enchantmentName;
            this.EmbellishmentID = embellishmentID;
            this.EmbellishmentName = embellishmentName;
            this.Cost = cost;
            this.Weight = weight;
        }//end constructor
    }//end struct ItemEnhancementSummary
    internal class ItemEnhancementSummaryDataDelegate :
        DataReaderDelegate<IReadOnlyList<ItemEnhancementSummary>> {
        public readonly int ItemCategoryID;
        public readonly int EnchantmentCategoryID;
        public readonly int EmbellishmentCategoryID;
        public ItemEnhancementSummaryDataDelegate(int itemCategoryID,
            int enchantmentCategoryID, int embellishmentCategoryID) :
            base("AppRecords.ItemEnhancementSummary") {
            this.ItemCategoryID = itemCategoryID;
            this.EnchantmentCategoryID = enchantmentCategoryID;
            this.EmbellishmentCategoryID = embellishmentCategoryID;
        }//end constructor
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // add this field as a parameter to the command
                command.Parameters.AddWithValue(field.Name,
                    field.GetValue(this));
            }//end looping over fields of this class.
        }//end PrepareCommand(command)
        public override IReadOnlyList<ItemEnhancementSummary> Translate(
            SqlCommand command, IDataRowReader reader) {
            var report = new List<ItemEnhancementSummary>();
            while (reader.Read()) {
                report.Add(new ItemEnhancementSummary(
                    reader.GetInt32("ItemID"),
                    reader.GetString("ItemName"),
                    reader.GetInt32("EnchantmentID"),
                    reader.GetString("EnchantmentName"),
                    reader.GetInt32("EmbellishmentID"),
                    reader.GetString("EmbellishmentName"),
                    reader.GetValue<decimal>("Cost"),
                    reader.GetValue<decimal>("Weight")
                    ));
            }//end looping while we still have stuff to read
            return report;
        }//end Translate(command, reader)
    }//end class ItemEnhancementSummaryDataDelegate

    public struct UserInventorySummary {
        public readonly string Name;
        public readonly string GeneratingTableName;
        public readonly DateTime EarliestGeneration;
        public readonly DateTime LatestGeneration;
        public readonly int UnitPrice;
        public readonly int BaseWeight;
        public readonly int NumberGenerated;
        public UserInventorySummary(string name,
            string generatingTableName, DateTime earliestGeneration,
            DateTime latestGeneration, int unitPrice, int baseWeight,
            int numberGenerated) {
            this.Name = name;
            this.GeneratingTableName = generatingTableName;
            this.EarliestGeneration = earliestGeneration;
            this.LatestGeneration = latestGeneration;
            this.UnitPrice = unitPrice;
            this.BaseWeight = baseWeight;
            this.NumberGenerated = numberGenerated;
        }//end constructor
    }//end struct UserInventorySummary
    internal class UserInventorySummaryDataDelegate :
        DataReaderDelegate<IReadOnlyList<UserInventorySummary>> {
        public readonly int UserID;
        public UserInventorySummaryDataDelegate(int userID) :
            base("GeneratedItems.UserInventorySummary")
            { this.UserID = userID; }
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // add this field as a parameter to the command
                command.Parameters.AddWithValue(field.Name,
                    field.GetValue(this));
            }//end looping over fields of this class.
        }//end PrepareCommand(command)
        public override IReadOnlyList<UserInventorySummary> Translate(
            SqlCommand command, IDataRowReader reader) {
            var report = new List<UserInventorySummary>();
            while (reader.Read()) {
                report.Add(new UserInventorySummary(
                    reader.GetString("Name"),
                    reader.GetString("GeneratingTableName"),
                    reader.GetDateTimeOffset("EarliestGeneration").DateTime,
                    reader.GetDateTimeOffset("LatestGeneration").DateTime,
                    reader.GetInt32("UnitPrice"),
                    reader.GetInt32("BaseWeight"),
                    reader.GetInt32("NumberGenerated")
                    ));
            }//end looping while we still have stuff to read
            return report;
        }//end Translate(command, reader)
    }//end class UserInventorySummaryDataDelegate
}//end namespace
