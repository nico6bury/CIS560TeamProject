/*
 * Author: Nicholas Sixbury
 * File: RetrievalDataDelegates.cs
 * Classes: All the data delegates for retrieving data from the database. Good
 * for reading data from both the AppRecords and GeneratedItems schemas.
 * Purpose: To provide a single file with all the retrieval data delegates.
 */

using DataAccess;
using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GURPSData.DataDelegates {
    public class RetrieveAllUsersDataDelegate : DataReaderDelegate<IReadOnlyList<User>> {
        public RetrieveAllUsersDataDelegate() : base("AppRecords.RetrieveAllUsers") { }

        public override IReadOnlyList<User> Translate(SqlCommand command, IDataRowReader reader) {
            var users = new List<User>();
            while (reader.Read()) {
                users.Add(new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Username"),
                    reader.GetString("Password"),
                    reader.GetValue<bool>("IsAdmin")
                    
                    ));
                //reader.GetDateTimeOffset("JoinedOn").DateTime
            }//end looping while we have stuff to read
            return users;
        }//end Translate(command,reader)
    }//end class RetrieveAllUsersDataDelegate
    public class RetrieveUserForIDDataDelegate : DataReaderDelegate<IReadOnlyList<User>> {
        private readonly int UserID;
        public RetrieveUserForIDDataDelegate(int userID)
            : base("AppRecords.RetrieveUserForID")
            { this.UserID = userID; }
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("UserID", UserID);
        }//end PrepareCommand(command)
        public override IReadOnlyList<User> Translate(SqlCommand command, IDataRowReader reader) {
            var users = new List<User>();
            while (reader.Read()) {
                users.Add(new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Username"),
                    reader.GetString("Password"),
                    reader.GetValue<bool>("IsAdmin")
                    ));
                //,
                //reader.GetDateTimeOffset("JoinedOn").DateTime
            }//end looping while we have stuff to read
            return users;
        }//end Translate(command,reader)
    }//end class RetrieveUserForIDDataDelegate
    public class RetrieveUserForUsernameDataDelegate : DataReaderDelegate<IReadOnlyList<User>> {
        private readonly string Username;
        public RetrieveUserForUsernameDataDelegate(string username)
            : base("AppRecords.RetrieveUserForUsername")
            { this.Username = username; }
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            //command.Parameters.AddWithValue("Username", Username);
            var p = command.Parameters.Add("Username", System.Data.SqlDbType.NVarChar);
            p.Value = Username;
        }//end PrepareCommand(command)
        public override IReadOnlyList<User> Translate(SqlCommand command, IDataRowReader reader) {
            var users = new List<User>();
            while (reader.Read()) {
                users.Add(new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Username"),
                    reader.GetString("Password"),
                    reader.GetValue<bool>("IsAdmin")
                    
                    ));
                //reader.GetDateTimeOffset("JoinedOn").DateTime
            }//end looping while we have stuff to read
            return users;
        }//end Translate(command,reader)
    }//end class RetrieveUserForUsernameDataDelegate

    public class RetrieveAllItemCategoriesDateDelegate : DataReaderDelegate<IReadOnlyList<ItemCategory>> {
        public RetrieveAllItemCategoriesDateDelegate()
            : base("AppRecords.RetrieveAllItemCategories") { }
        public override IReadOnlyList<ItemCategory> Translate(SqlCommand command, IDataRowReader reader) {
            var categories = new List<ItemCategory>();
            while (reader.Read()) {
                categories.Add(new ItemCategory(
                    reader.GetInt32("ItemCategoryID"),
                    reader.GetInt32("OwningUserID"),
                    reader.GetString("Name"),
                    reader.GetValue<bool>("IsDefault"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we have stuff to read
            return categories;
        }//end Translate(command, reader)
    }//end class RetrieveAllItemCategoriesDateDelegate

    public class RetrieveAllItemsDataDelegate : DataReaderDelegate<IReadOnlyList<Item>> {
        public RetrieveAllItemsDataDelegate()
            : base("AppRecords.RetrieveAllItems") { }
        public override IReadOnlyList<Item> Translate(SqlCommand command, IDataRowReader reader) {
            var items = new List<Item>();
            while (reader.Read()) {
                items.Add(new Item(
                    reader.GetInt32("ItemID"),
                    reader.GetString("Name"),
                    reader.GetInt32("UnitPrice"),
                    reader.GetInt32("BaseWeight"),
                    reader.GetString("WeightType"),
                    reader.GetInt32("QuantityMin"),
                    reader.GetInt32("QuantityMax"),
                    reader.GetString("Description"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime)
                    );
            }//end looping while we have stuff to read
            return items;
        }//end Translate(command, reader)
    }//end class RetrieveAllItemsDataDelegate

    public class RetrieveAllItemSubcategoriesDataDelegate
        : DataReaderDelegate<IReadOnlyList<ItemSubcategory>> {
        public RetrieveAllItemSubcategoriesDataDelegate() :
            base("AppRecords.RetrieveAllItemSubcategories") { }
        public override IReadOnlyList<ItemSubcategory> Translate(SqlCommand command,
            IDataRowReader reader) {
            var subCats = new List<ItemSubcategory>();
            while (reader.Read()) {
                subCats.Add(new ItemSubcategory(
                    reader.GetInt32("ItemSubCategoryID"),
                    reader.GetInt32("ItemCategoryID"),
                    reader.GetInt32("ItemID"),
                    reader.GetString("Name")
                    ));
            }//end looping while we have stuff to read
            return subCats;
        }//end Translate(command, reader)
    }//end class RetrieveAllItemSubcategoriesDataDelegate

    public class RetrieveAllItemTypeOptionsDataDelegate
        : DataReaderDelegate<IReadOnlyList<ItemTypeOption>> {
        public RetrieveAllItemTypeOptionsDataDelegate() :
            base("AppRecords.RetrieveAllItemTypeOptions") { }
        public override IReadOnlyList<ItemTypeOption> Translate(SqlCommand command,
            IDataRowReader reader) {
            var itos = new List<ItemTypeOption>();
            while (reader.Read()) {
                itos.Add(new ItemTypeOption(
                    reader.GetInt32("ItemTypeOptionID"),
                    reader.GetString("Name"),
                    reader.GetInt32("ItemSubcategoryID"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetInt32("PriceChange"),
                    reader.GetInt32("WeightChange"),
                    reader.GetString("DescriptionAddition")
                    ));
            }//end looping while we have stuff to read
            return itos;
        }//end Translate(command, reader)
    }//end class RetrieveAllItemTypeOptionsDataDelegate

    public class RetrieveAllEmbellishmentCategoriesDataDelegate
        : DataReaderDelegate<IReadOnlyList<EmbellishmentCategory>> {
        public RetrieveAllEmbellishmentCategoriesDataDelegate() :
            base("AppRecords.RetrieveAllEmbellishmentCategories") { }
        public override IReadOnlyList<EmbellishmentCategory> Translate(SqlCommand command,
            IDataRowReader reader) {
            var ecs = new List<EmbellishmentCategory>();
            while (reader.Read()) {
                ecs.Add(new EmbellishmentCategory(
                    reader.GetInt32("EmbellishmentCategoryID"),
                    reader.GetInt32("OwningUserID"),
                    reader.GetString("Name"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetString("Description"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we have stuff to read
            return ecs;
        }//end Translate(command, reader)
    }//end class RetrieveAllEmbellishmentCategoriesDataDelegate

    public class RetrieveAllEmbellishmentsDataDelegate
        : DataReaderDelegate<IReadOnlyList<Embellishment>> {
        public RetrieveAllEmbellishmentsDataDelegate() :
            base("AppRecords.RetrieveAllEmbellishments") { }
        public override IReadOnlyList<Embellishment> Translate(SqlCommand command,
            IDataRowReader reader) {
            var embells = new List<Embellishment>();
            while (reader.Read()) {
                embells.Add(new Embellishment(
                    reader.GetInt32("EmbellishmentID"),
                    reader.GetInt32("EmbellishmentCategoryID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetValue<decimal>("CostFactor"),
                    reader.GetValue<decimal>("WeightFactor"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we have stuff to read
            return embells;
        }//end Translate(command, reader)
    }//end class RetrieveAllEmbellishmentsDataDelegate

    public class RetrieveAllEnchantmentCategoriesDataDelegate
        : DataReaderDelegate<IReadOnlyList<EnchantmentCategory>> {
        public RetrieveAllEnchantmentCategoriesDataDelegate() :
            base("AppRecords.RetrieveAllEnchantmentCategories") { }
        public override IReadOnlyList<EnchantmentCategory> Translate(SqlCommand command,
            IDataRowReader reader) {
            var encCats = new List<EnchantmentCategory>();
            while (reader.Read()) {
                encCats.Add(new EnchantmentCategory(
                    reader.GetInt32("EnchantmentCategoryID"),
                    reader.GetInt32("OwningUserID"),
                    reader.GetString("Name"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetString("Description"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we have stuff to read
            return encCats;
        }//end Translate(command, reader)
    }//end class RetrieveAllEnchantmentCategoriesDataDelegate

    public class RetrieveAllEnchantmentsDataDelegate
        : DataReaderDelegate<IReadOnlyList<Enchantment>> {
        public RetrieveAllEnchantmentsDataDelegate() :
            base("AppRecords.RetrieveAllEnchantments") { }
        public override IReadOnlyList<Enchantment> Translate(SqlCommand command,
            IDataRowReader reader) {
            var encs = new List<Enchantment>();
            while (reader.Read()) {
                encs.Add(new Enchantment(
                    reader.GetInt32("EnchantmentID"),
                    reader.GetInt32("EnchantmentCategoryID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetInt32("Cost"),
                    reader.GetValue<decimal>("WeightFactor"),
                    reader.GetInt32("RelativeChance"),
                    reader.GetString("PowerReserveType"),
                    reader.GetInt32("PowerReserveAmount"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we have stuff to read
            return encs;
        }//end Translate(command,reader)
    }//end class RetrieveAllEnchantmentsDataDelegate

    public class RetrieveAllInventoryDataDelegate
        : DataReaderDelegate<IReadOnlyList<InventoryItem>> {
        public RetrieveAllInventoryDataDelegate() :
            base("GeneratedItems.RetrieveAllInventory") { }
        public override IReadOnlyList<InventoryItem> Translate(
            SqlCommand command, IDataRowReader reader) {
            var i = new List<InventoryItem>();
            while (reader.Read()) {
                i.Add(new InventoryItem(
                    reader.GetInt32("InventoryID"),
                    reader.GetInt32("OwningUserID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetString("GeneratingTableName"),
                    reader.GetInt32("Quantity"),
                    reader.GetInt32("UnitPrice"),
                    reader.GetInt32("BaseWeight"),
                    reader.GetString("WeightType"),
                    reader.GetDateTimeOffset("GeneratedOn").DateTime,
                    reader.GetDateTimeOffset("EditedOn").DateTime
                    ));
            }//end looping while we still have stuff to read
            return i;
        }//end Translate(command, reader)
    }//end class RetrieveAllInventoryDataDelegate

    public class RetrieveAllCreatedEmbellishmentsDataDelegate
        : DataReaderDelegate<IReadOnlyList<CreatedEmbellishment>> {
        public RetrieveAllCreatedEmbellishmentsDataDelegate() :
            base("GeneratedItems.RetrieveAllCreatedEmbellishments") { }
        public override IReadOnlyList<CreatedEmbellishment> Translate(
            SqlCommand command, IDataRowReader reader) {
            var cms = new List<CreatedEmbellishment>();
            while (reader.Read()) {
                cms.Add(new CreatedEmbellishment(
                    reader.GetInt32("CreatedEmbellishmentID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetString("GeneratingCategoryName"),
                    reader.GetValue<decimal>("CostFactor"),
                    reader.GetValue<decimal>("WeightFactor")
                    ));
            }//end looping while we still have stuff to read
            return cms;
        }//end Translate(command, reader)
    }//end class RetrieveAllCreatedEmbellishmentsDataDelegate

    public class RetrieveAllCreatedEnchantmentsDataDelegate
        : DataReaderDelegate<IReadOnlyList<CreatedEnchantment>> {
        public RetrieveAllCreatedEnchantmentsDataDelegate() :
            base("GeneratedItems.RetrieveAllCreatedEnchantments") { }
        public override IReadOnlyList<CreatedEnchantment> Translate(
            SqlCommand command, IDataRowReader reader) {
            var cns = new List<CreatedEnchantment>();
            while (reader.Read()) {
                cns.Add(new CreatedEnchantment(
                    reader.GetInt32("CreatedEnchantmentID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetString("GeneratingCategoryName"),
                    reader.GetInt32("Cost"),
                    reader.GetValue<decimal>("WeightFactor"),
                    reader.GetString("PowerReserveType"),
                    reader.GetInt32("PowerReserveAmount")
                    ));
            }//end looping while we still have stuff to read
            return cns;
        }//end Translate(command, reader)
    }//end class RetrieveAllCreatedEnchantmentsDataDelegate

    public class RetrieveAllEmbellishmentRefsDataDelegate
        : DataReaderDelegate<IReadOnlyList<EmbellishmentRef>> {
        public RetrieveAllEmbellishmentRefsDataDelegate() :
            base("GeneratedItems.RetrieveAllEmbellishmentRefs") {}
        public override IReadOnlyList<EmbellishmentRef> Translate(
            SqlCommand command, IDataRowReader reader) {
            var emrs = new List<EmbellishmentRef>();
            while (reader.Read()) {
                emrs.Add(new EmbellishmentRef(
                    reader.GetInt32("CreatedEmbellishmentID"),
                    reader.GetInt32("InventoryID"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we still have stuff to read
            return emrs;
        }//end Translate(command, reader)
    }//end class RetrieveAllEmbellishmentRefsDataDelegate

    public class RetrieveAllEnchantmentRefsDataDelegate
        : DataReaderDelegate<IReadOnlyList<EnchantmentRef>> {
        public RetrieveAllEnchantmentRefsDataDelegate() :
            base("GeneratedItems.RetrieveAllEnchantmentRefs") { }
        public override IReadOnlyList<EnchantmentRef> Translate(
            SqlCommand command, IDataRowReader reader) {
            var enrs = new List<EnchantmentRef>();
            while (reader.Read()) {
                enrs.Add(new EnchantmentRef(
                    reader.GetInt32("CreatedEnchantmentID"),
                    reader.GetInt32("InventoryID"),
                    reader.GetDateTimeOffset("CreatedOn").DateTime
                    ));
            }//end looping while we still have stuff to read
            return enrs;
        }//end Translate(command, reader)
    }//end class RetrieveAllEnchantmentRefsDataDelegate
}//end namespace
