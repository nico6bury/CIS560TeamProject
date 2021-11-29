/*
 * Author: Nicholas Sixbury
 * File: CreationDataDelegates.cs
 * Classes: CreateUserDataDelegate,CreateItemCategoryDataDelegate,CreateItemDataDelegate,
 * CreateEmbellishmentCategoryDataDelegate,CreateEmbellishmentDataDelegate,
 * CreateEnchantmentCategoryDataDelegate,CreateEnchantmentDataDelegate,
 * CreateInventoryItemDataDelegate,CreateInventoryEmbellishmentDataDelegate,
 * CreateInventoryEnchantmentDataDelegate,LinkInventoryEmbellishmentDataDelegate,
 * LinkInventoryEnchantmentDataDelegate
 * Purpose: To provide a single, well documented file with all the data delegates for
 * creating entries in the database.
 * Note: The comments describing the fields for all this classes have been copied over from
 * the corresponding classes in GURPSData.Models without editing. As such, there might be
 * inconsistencies.
 */

using DataAccess;
using GURPSData.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GURPSData.DataDelegates {
    /// <summary>
    /// Data delegate for creating User in database.
    /// </summary>
    internal class CreateUserDataDelegate : NonQueryDataDelegate<User> {
        /// <summary>
        /// The username of this particular user. Used to log in.
        /// </summary>
        public string Username;
        /// <summary>
        /// THe password of this particular user account. Used to log in.
        /// </summary>
        public readonly string Password;

        /// <summary>
        /// Constructs the CreateUserDataDelegate class.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public CreateUserDataDelegate(string username, string password)
            : base("AppRecords.CreateUser") {
            this.Username = username; this.Password = password;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach(FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if(field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if(field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if(field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if(field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if(field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("UserID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("IsAdmin", SqlDbType.Bit);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("JoinedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type User.</returns>
        public override User Translate(SqlCommand command) {
            int UserID = (int)command.Parameters["UserID"].Value;
            bool IsAdmin = (bool)command.Parameters["IsAdmin"].Value;
            //DateTime JoinedOn = (DateTime)command.Parameters["JoinedOn"].Value;
            return new User(UserID,Username,Password,IsAdmin);
        }//end Translate(command)
    }//end class CreateUserDataDelegate
    /// <summary>
    /// Data delegate for creating ItemCategory in database.
    /// </summary>
    internal class CreateItemCategoryDataDelegate : NonQueryDataDelegate<ItemCategory> {
        /// <summary>
        /// The User ID of the user which owns this category of items.
        /// </summary>
        public readonly int OwningUserID;
        /// <summary>
        /// The name of this category of items.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A Description of this category of items.
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Constructs the CreateItemCategoryDataDelegate class.
        /// </summary>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public CreateItemCategoryDataDelegate(int owningUserID, string name, string description)
            : base("AppRecords.CreateItemCategory") {
            this.OwningUserID = owningUserID; this.Name = name; this.Description = description;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("ItemCategoryID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("IsDefault", SqlDbType.Bit);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type ItemCategory.</returns>
        public override ItemCategory Translate(SqlCommand command) {
            int ItemCategoryID = (int)command.Parameters["ItemCategoryID"].Value;
            bool IsDefault = (bool)command.Parameters["IsDefault"].Value;
            DateTime CreatedOn = ((DateTimeOffset)command.Parameters["CreatedOn"].Value).DateTime;
            return new ItemCategory(ItemCategoryID,OwningUserID,Name,IsDefault,CreatedOn);
        }//end Translate(command)
    }//end class CreateItemCategoryDataDelegate
    /// <summary>
    /// Data delegate for creating Item in database.
    /// </summary>
    internal class CreateItemDataDelegate : NonQueryDataDelegate<Item> {
        /// <summary>
        /// The ID number of the ItemCategory table that this item goes in.
        /// </summary>
        public readonly int ItemCategoryID;
        /// <summary>
        /// The name of this item.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// The base price of a single item like this.
        /// </summary>
        public readonly int UnitPrice;
        /// <summary>
        /// The base weight for a single item like this.
        /// </summary>
        public readonly int BaseWeight;
        /// <summary>
        /// The "Weight Type" for this item. If the BaseWeight
        /// is in ounces, then this should be ounces or oz. If
        /// the BaseWeight is in gallons, then this should be
        /// gallons or gal.
        /// </summary>
        public readonly string WeightType;
        /// <summary>
        /// The minimum quantity you might find in one generation of this item.
        /// </summary>
        public readonly int QuantityMin;
        /// <summary>
        /// The maximum quantity you might find in one generation of this item.
        /// </summary>
        public readonly int QuantityMax;
        /// <summary>
        /// A description of what this item is, or information about it. Might
        /// very well be blank for a lot of items.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// The relative chance that this item will be generated instead of another
        /// item in the same categpry.
        /// </summary>
        public readonly int RelativeChance;

        /// <summary>
        /// Constructs the CreateItemDataDelegate class.
        /// </summary>
        /// <param name="itemCategoryID"></param>
        /// <param name="name"></param>
        /// <param name="unitPrice"></param>
        /// <param name="baseWeight"></param>
        /// <param name="weightType"></param>
        /// <param name="quantityMin"></param>
        /// <param name="quantityMax"></param>
        /// <param name="description"></param>
        /// <param name="relativeChance"></param>
        public CreateItemDataDelegate(int itemCategoryID, string name, int unitPrice, int baseWeight,
            string weightType, int quantityMin, int quantityMax, string description, int relativeChance)
            : base("AppRecords.CreateItem") {
            this.ItemCategoryID = itemCategoryID;
            this.Name = name; this.UnitPrice = unitPrice; this.BaseWeight = baseWeight;
            this.WeightType = weightType; this.QuantityMin = quantityMin; this.QuantityMax = quantityMax;
            this.Description = description; this.RelativeChance = relativeChance;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("ItemID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type Item.</returns>
        public override Item Translate(SqlCommand command) {
            int ItemID = (int)command.Parameters["ItemID"].Value;
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new Item(ItemID, Name, UnitPrice, BaseWeight, WeightType, QuantityMin,
                QuantityMax, Description, RelativeChance, CreatedOn); ;
        }//end Translate(command)
    }//end class CreateItemDataDelegate
    /// <summary>
    /// Data delegate for creating EmbellishmentCategory in database.
    /// </summary>
    internal class CreateEmbellishmentCategoryDataDelegate : NonQueryDataDelegate<EmbellishmentCategory> {
        /// <summary>
        /// The user ID of the user account which owns this category of embellishments.
        /// </summary>
        public readonly int OwningUserID;
        /// <summary>
        /// The name of this category of embellishments.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// The relative chance that this category of embellishments will be chosen as
        /// opposed to any other category of embellishments.
        /// </summary>
        public readonly int RelativeChance;
        /// <summary>
        /// A description of this category of embellishments.
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Constructs the CreateEmbellishmentCategoryDataDelegate class.
        /// </summary>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="relativeChance"></param>
        /// <param name="description"></param>
        public CreateEmbellishmentCategoryDataDelegate(int owningUserID,
            string name, int relativeChance, string description) :
            base("AppRecords.CreateEmbellishmentCategory") {
            this.OwningUserID = owningUserID; this.Name = name;
            this.RelativeChance = relativeChance; this.Description = description;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("EmbellishmentCategoryID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type EmbellishmentCategory.</returns>
        public override EmbellishmentCategory Translate(SqlCommand command) {
            int EmbellishmentCategoryID = (int)command.Parameters["EmbellishmentCategoryID"].Value;
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new EmbellishmentCategory(EmbellishmentCategoryID, OwningUserID, Name,
                RelativeChance, Description, CreatedOn); ;
        }//end Translate(command)
    }//end class CreateEmbellishmentCategoryDataDelegate
    /// <summary>
    /// Data delegate for creating Embellishment in database.
    /// </summary>
    internal class CreateEmbellishmentDataDelegate : NonQueryDataDelegate<Embellishment> {
        /// <summary>
        /// The ID of the category of embellishments that this embellishment belongs to.
        /// </summary>
        public readonly int EmbellishmentCategoryID;
        /// <summary>
        /// The name of this embellishment.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A description of this embellishment.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// The cost factor (CF) of this embellishment, applied to the cost of the item
        /// that this embellishment is applied to.
        /// </summary>
        public readonly decimal CostFactor;
        /// <summary>
        /// The weigt factor of this embellishment, applied to the weight of the item
        /// that this embellishment is applied to.
        /// </summary>
        public readonly decimal WeightFactor;
        /// <summary>
        /// The relative chance that this embellishment is chosen as opposed to any other
        /// embellishment in the same category.
        /// </summary>
        public readonly int RelativeChance;

        /// <summary>
        /// Constructs the CreateEmbellishmentDataDelegate class.
        /// </summary>
        /// <param name="embellishmentCategoryID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="costFactor"></param>
        /// <param name="weightFactor"></param>
        /// <param name="relativeChance"></param>
        public CreateEmbellishmentDataDelegate(int embellishmentCategoryID,
            string name, string description, decimal costFactor, decimal weightFactor,
            int relativeChance) : base("AppRecords.CreateEmbellishment") {
            this.EmbellishmentCategoryID = embellishmentCategoryID; this.Name = name;
            this.Description = description; this.CostFactor = costFactor;
            this.WeightFactor = weightFactor;
            this.RelativeChance = relativeChance;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("EmbellishmentID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type Embellishment.</returns>
        public override Embellishment Translate(SqlCommand command) {
            int EmbellishmentID = (int)command.Parameters["EmbellishmentID"].Value;
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new Embellishment(EmbellishmentID, EmbellishmentCategoryID, Name,
                Description, CostFactor, WeightFactor, RelativeChance, CreatedOn); ;
        }//end Translate(command)
    }//end class CreateEmbellishmentDataDelegate
    /// <summary>
    /// Data delegate for creating EnchantmentCategory in database.
    /// </summary>
    internal class CreateEnchantmentCategoryDataDelegate : NonQueryDataDelegate<EnchantmentCategory> {
        /// <summary>
        /// The ID number of the User account which owns this category of enchantments.
        /// </summary>
        public readonly int OwningUserID;
        /// <summary>
        /// The name of this enchantment category.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// The relative chance that this enchantment category will be chosen as opposed
        /// to any other enchantment category.
        /// </summary>
        public readonly int RelativeChance;
        /// <summary>
        /// A description of this enchantment category.
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Constructs the CreateEnchantmentCategoryDataDelegate class.
        /// </summary>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="relativeChance"></param>
        /// <param name="description"></param>
        public CreateEnchantmentCategoryDataDelegate(int owningUserID,
            string name, int relativeChance, string description)
            : base("AppRecords.CreateEnchantmentCategory") {
            this.OwningUserID = owningUserID; this.Name = name;
            this.Description = description; this.RelativeChance = relativeChance;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("EnchantmentCategoryID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type EnchantmentCategory.</returns>
        public override EnchantmentCategory Translate(SqlCommand command) {
            int EnchantmentCategoryID = (int)command.Parameters["EnchantmentCategoryID"].Value;
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new EnchantmentCategory(EnchantmentCategoryID,OwningUserID,Name,
                RelativeChance,Description,CreatedOn);
        }//end Translate(command)
    }//end class CreateEnchantmentCategoryDataDelegate
    /// <summary>
    /// Data delegate for creating Enchantment in database.
    /// </summary>
    internal class CreateEnchantmentDataDelegate : NonQueryDataDelegate<Enchantment> {
        /// <summary>
        /// The ID number of the enchantment category that this enchantment belongs to.
        /// </summary>
        public readonly int EnchantmentCategoryID;
        /// <summary>
        /// The name of this enchantment.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A description of this enchantment.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// The cost of this enchantment.
        /// </summary>
        public readonly int Cost;
        /// <summary>
        /// The weigt factor of this enchantment, applied to the BaseWeight of whatever item
        /// this enchantment is applied to.
        /// </summary>
        public readonly decimal WeightFactor;
        /// <summary>
        /// THe relative chance that this enchantment will be chosen as opposed to any other
        /// enchantment in the same category.
        /// </summary>
        public readonly int RelativeChance;
        /// <summary>
        /// The type of power reserve this enchantment holds. Examples of power reserves include
        /// Normal, Exclusive, OneCollege, Dedicated, Regenerating, and Rechargeable.
        /// </summary>
        public readonly string PowerReserveType;
        /// <summary>
        /// The amount of energy held by the power reserve. If there's no power reserve, this
        /// could be 0.
        /// </summary>
        public readonly int PowerReserveAmount;

        /// <summary>
        /// Constructs the CreateEnchantmentDataDelegate class;
        /// </summary>
        /// <param name="enchantmentCategoryID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="weightFactor"></param>
        /// <param name="relativeChance"></param>
        /// <param name="powerReserveType"></param>
        /// <param name="powerReserveAmount"></param>
        public CreateEnchantmentDataDelegate(int enchantmentCategoryID, string name,
            string description, int cost, decimal weightFactor, int relativeChance,
            string powerReserveType, int powerReserveAmount)
            : base("AppRecords.CreateEnchantment") {
            this.EnchantmentCategoryID = enchantmentCategoryID;
            this.Name = name; this.Description = description; this.Cost = cost;
            this.WeightFactor = weightFactor; this.RelativeChance = relativeChance;
            this.PowerReserveType = powerReserveType; this.PowerReserveAmount = powerReserveAmount;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("EnchantmentID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type Enchantment.</returns>
        public override Enchantment Translate(SqlCommand command) {
            int EnchantmentID = (int)command.Parameters["EnchantmentID"].Value;
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new Enchantment(EnchantmentID,EnchantmentCategoryID,Name,Description,
                Cost,WeightFactor,RelativeChance,PowerReserveType,PowerReserveAmount,CreatedOn);
        }//end Translate(command)
    }//end class CreateEnchantmentDataDelegate
    /// <summary>
    /// Data delegate for creating InventoryItem in database.
    /// </summary>
    internal class CreateInventoryItemDataDelegate : NonQueryDataDelegate<InventoryItem> {
        /// <summary>
        /// The ID number of the user account who owns this item.
        /// </summary>
        public readonly int OwningUserID;
        /// <summary>
        /// The name of this item.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A description of this item.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// The name of the table which generated this item.
        /// </summary>
        public readonly string GeneratingCategoryName;
        /// <summary>
        /// The quantity of this item in this particular instance.
        /// </summary>
        public readonly int Quantity;
        /// <summary>
        /// The base unit price for one of these items, without taking enchantments or
        /// embellishments into account.
        /// </summary>
        public readonly int UnitPrice;
        /// <summary>
        /// The base weight of one of these items, without taking enchantments or
        /// embellishments into account.
        /// </summary>
        public readonly int BaseWeight;
        /// <summary>
        /// The "Weight Type" for this item. If the BaseWeight
        /// is in ounces, then this should be ounces or oz. If
        /// the BaseWeight is in gallons, then this should be
        /// gallons or gal.
        /// </summary>
        public readonly string WeightType;

        /// <summary>
        /// Constructs the CreateInventoryItemDataDelegate class.
        /// </summary>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingCategoryName"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="baseWeight"></param>
        /// <param name="weightType"></param>
        public CreateInventoryItemDataDelegate(int owningUserID, string name, string description,
            string generatingCategoryName, int quantity, int unitPrice, int baseWeight,
            string weightType) : base("GeneratedItems.CreateInventoryItem") {
            this.OwningUserID = owningUserID; this.Name = name;
            this.Description = description; this.GeneratingCategoryName = generatingCategoryName;
            this.Quantity = quantity; this.UnitPrice = unitPrice; this.BaseWeight = baseWeight;
            this.WeightType = weightType;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("InventoryItemID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("GeneratedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
            o = command.Parameters.Add("EditedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type InventoryItem.</returns>
        public override InventoryItem Translate(SqlCommand command) {
            int InventoryID = (int)command.Parameters["InventoryItemID"].Value;
            DateTime GeneratedOn = DateTime.Now;
            DateTime EditedOn = DateTime.Now;
            try {
                GeneratedOn = (DateTime)command.Parameters["GeneratedOn"].Value;
            }
            catch { GeneratedOn = DateTime.Now; }
            try {
                EditedOn = (DateTime)command.Parameters["EditedOn"].Value;
            }
            catch { EditedOn = GeneratedOn; }
            
            return new InventoryItem(InventoryID,OwningUserID,Name,Description,GeneratingCategoryName,
                Quantity,UnitPrice,BaseWeight,WeightType,GeneratedOn,EditedOn);
        }//end Translate(command)
    }//end class CreateInventoryItemDataDelegate
    /// <summary>
    /// Data delegate for creating CreatedEmbellishment in database.
    /// </summary>
    internal class CreateInventoryEmbellishmentDataDelegate : NonQueryDataDelegate<CreatedEmbellishment> {
        /// <summary>
        /// The name of this embellishment.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A description for this embellishment.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// THe name of the embellishment category that this generated embellishment came from.
        /// </summary>
        public readonly string GeneratingCategoryName;
        /// <summary>
        /// The Cost Factor (CF) of this item, applied to the item which this enchantment is
        /// applied to.
        /// </summary>
        public readonly decimal CostFactor;
        /// <summary>
        /// The Weight Factor for this item, applied to the item which this embellishment is
        /// applied to.
        /// </summary>
        public readonly decimal WeightFactor;

        /// <summary>
        /// Constructs the CreateInventoryEmbellishmentDataDelegate class.
        /// </summary>
        /// <param name="createdEmbellishmentID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingCategoryName"></param>
        /// <param name="costFactor"></param>
        /// <param name="weightFactor"></param>
        public CreateInventoryEmbellishmentDataDelegate(string name, string description,
            string generatingCategoryName, decimal costFactor, decimal weightFactor)
            : base("GeneratedItems.CreateInventoryEmbellishment") {
            this.Name = name; this.Description = description;
            this.GeneratingCategoryName = generatingCategoryName;
            this.CostFactor = costFactor; this.WeightFactor = weightFactor;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("CreatedEmbellishmentID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type CreatedEmbellishment.</returns>
        public override CreatedEmbellishment Translate(SqlCommand command) {
            int CreatedEmbellishmentID = (int)command.Parameters["CreatedEmbellishmentID"].Value;
            return new CreatedEmbellishment(CreatedEmbellishmentID,Name,Description,
                GeneratingCategoryName,CostFactor,WeightFactor);
        }//end Translate(command)
    }//end class CreateInventoryEmbellishmentDataDelegate
    /// <summary>
    /// Data delegate for creating CreatedEnchantment in database.
    /// </summary>
    internal class CreateInventoryEnchantmentDataDelegate : NonQueryDataDelegate<CreatedEnchantment> {
        /// <summary>
        /// The name of this enchantment.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// A description for this enchantment.
        /// </summary>
        public readonly string Description;
        /// <summary>
        /// The name of the enchantment category that this enchantment came from.
        /// </summary>
        public readonly string GeneratingCategoryName;
        /// <summary>
        /// The cost of this enchantment.
        /// </summary>
        public readonly int Cost;
        /// <summary>
        /// The weight factor of this enchantment.
        /// </summary>
        public readonly decimal WeightFactor;
        /// <summary>
        /// The type of power reserve this enchantment holds. Examples of power reserves include
        /// Normal, Exclusive, OneCollege, Dedicated, Regenerating, and Rechargeable.
        /// </summary>
        public readonly string PowerReserveType;
        /// <summary>
        /// The amount of power held by the power reserve in this object. This should be the max
        /// amount, and if this item has no power reserve, then this should be zero.
        /// </summary>
        public readonly int PowerReserveAmount;

        /// <summary>
        /// Constructs the CreateInventoryEnchantmentDataDelegate class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingCategoryName"></param>
        /// <param name="cost"></param>
        /// <param name="weightFactor"></param>
        /// <param name="powerReserveType"></param>
        /// <param name="powerReserveAmount"></param>
        public CreateInventoryEnchantmentDataDelegate(string name, string description,
            string generatingCategoryName, int cost, decimal weightFactor,
            string powerReserveType, int powerReserveAmount)
            : base("GeneratedItems.CreateInventoryEnchantment") {
            this.Name = name; this.Description = description;
            this.GeneratingCategoryName = generatingCategoryName;
            this.Cost = cost; this.WeightFactor = weightFactor;
            this.PowerReserveType = powerReserveType; this.PowerReserveAmount = powerReserveAmount;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("CreatedEnchantmentID", SqlDbType.Int);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type CreatedEnchantment.</returns>
        public override CreatedEnchantment Translate(SqlCommand command) {
            int CreatedEnchantmentID = (int)command.Parameters["CreatedEnchantmentID"].Value;
            return new CreatedEnchantment(CreatedEnchantmentID, Name, Description, GeneratingCategoryName,
                Cost, WeightFactor, PowerReserveType, PowerReserveAmount);
        }//end Translate(command)
    }//end class CreateInventoryEnchantmentDataDelegate
    /// <summary>
    /// Data delegate for creating EmbellishmentRef in database.
    /// </summary>
    internal class LinkInventoryEmbellishmentDataDelegate : NonQueryDataDelegate<EmbellishmentRef> {
        /// <summary>
        /// The ID number of the generated embellishment instance that this Ref is linking to.
        /// </summary>
        public readonly int CreatedEmbellishmentID;
        /// <summary>
        /// The ID number of the generated item instance that this Ref is linking to.
        /// </summary>
        public readonly int InventoryID;

        /// <summary>
        /// Constructs the LinkInventoryEmbellishmentDataDelegate class.
        /// </summary>
        /// <param name="createdEmbellishmentID"></param>
        /// <param name="inventoryID"></param>
        public LinkInventoryEmbellishmentDataDelegate(int createdEmbellishmentID, int inventoryID)
            : base("GeneratedItems.LinkInventoryEmbellishment") {
            this.CreatedEmbellishmentID = createdEmbellishmentID;
            this.InventoryID = inventoryID;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of type EmbellishmentRef.</returns>
        public override EmbellishmentRef Translate(SqlCommand command) {
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new EmbellishmentRef(CreatedEmbellishmentID,InventoryID,CreatedOn);
        }//end Translate(command)
    }//end class LinkInventoryEmbellishmentDataDelegate
    /// <summary>
    /// Data delegate for creating EnchantmentRef in database.
    /// </summary>
    internal class LinkInventoryEnchantmentDataDelegate : NonQueryDataDelegate<EnchantmentRef> {
        /// <summary>
        /// The ID number of the generated enchantment instance that this Ref is linking to.
        /// </summary>
        public readonly int CreatedEnchantmentID;
        /// <summary>
        /// The ID number of the generated item instance that this Ref is linking to.
        /// </summary>
        public readonly int InventoryID;

        /// <summary>
        /// Constructs the LinkInventoryEnchantmentDataDelegate class.
        /// </summary>
        /// <param name="createdEnchantmentID"></param>
        /// <param name="inventoryID"></param>
        /// <param name="createdOn"></param>
        public LinkInventoryEnchantmentDataDelegate(int createdEnchantmentID, int inventoryID)
            : base("GeneratedItems.LinkInventoryEnchantment") {
            this.CreatedEnchantmentID = createdEnchantmentID;
            this.InventoryID = inventoryID;
        }//end constructor

        /// <summary>
        /// Prepares command by calling base class with properties from constructor.
        /// </summary>
        /// <param name="command">Command to be prepared.</param>
        public override void PrepareCommand(SqlCommand command) {
            // do whatever the base class says we need to do
            base.PrepareCommand(command);

            // just handle doing all the cookie-cutter stuff for each field with reflection
            foreach (FieldInfo field in this.GetType().GetFields()) {
                // figure out what type we need for the database
                SqlDbType dbType = SqlDbType.Int;
                if (field.FieldType == typeof(int)) {
                    dbType = SqlDbType.Int;
                }//end if type is int
                else if (field.FieldType == typeof(bool)) {
                    dbType = SqlDbType.Bit;
                }//end if type is bool
                else if (field.FieldType == typeof(DateTime)) {
                    dbType = SqlDbType.DateTimeOffset;
                }//end if type if DateTime
                else if (field.FieldType == typeof(decimal)) {
                    dbType = SqlDbType.Decimal;
                }//end if type if decimal
                else if (field.FieldType == typeof(string)) {
                    dbType = SqlDbType.NVarChar;
                }//end if type is string

                // add this field as a parameter to the command
                var p = command.Parameters.Add(field.Name, dbType);
                p.Value = field.GetValue(this);
            }//end looping over fields of this class.

            // add class specific parameter(s)
            var o = command.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset);
            o.Direction = ParameterDirection.Output;
        }//end PrepareCommand(command)

        /// <summary>
        /// Translates data in the delegate to the appropriate class.
        /// </summary>
        /// <param name="command">The command used to get certain properties.</param>
        /// <returns>Object of EnchantmentRef User.</returns>
        public override EnchantmentRef Translate(SqlCommand command) {
            DateTime CreatedOn = (DateTime)command.Parameters["CreatedOn"].Value;
            return new EnchantmentRef(CreatedEnchantmentID,InventoryID,CreatedOn);
        }//end Translate(command)
    }//end class LinkInventoryEnchantmentDataDelegate
}//end namespace