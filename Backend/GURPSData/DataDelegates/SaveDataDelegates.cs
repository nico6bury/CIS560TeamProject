using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace GURPSData.DataDelegates {
    internal class SaveUserDataDelegate : DataDelegate {
        public readonly int UserID;
        public readonly string Username;
        public readonly string Password;
        public SaveUserDataDelegate(int userID,
            string username, string password) :
            base("AppRecords.SaveUser") {
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
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
    }//end class SaveUserDataDelegate

    internal class SaveItemCategoryDataDelegate : DataDelegate {
        public readonly int ItemCategoryID;
        public readonly int OwningUserID;
        public readonly string Name;
        public readonly string Description;
        public SaveItemCategoryDataDelegate(int itemCategoryID,
            int owningUserID, string name, string description)
            : base("AppRecords.SaveItemCategory") {
            this.ItemCategoryID = itemCategoryID;
            this.OwningUserID = owningUserID;
            this.Name = name; this.Description = description;
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
    }//end class SaveItemCategoryDataDelegate

    internal class SaveItemDataDelegate : DataDelegate {
        public readonly int ItemID;
        public readonly string Name;
        public readonly int UnitPrice;
        public readonly string Description;
        public readonly int BaseWeight;
        public readonly string WeightType;
        public readonly int QuantityMin;
        public readonly int QuantityMax;
        public readonly int RelativeChance;
        public SaveItemDataDelegate(int itemID, string name,
            int unitPrice, string description, int baseWeight,
            string weightType, int quantityMin, int quantityMax,
            int relativeChance) : base("AppRecords.SaveItem") {
            this.ItemID = itemID;
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Description = description;
            this.BaseWeight = baseWeight;
            this.WeightType = weightType;
            this.QuantityMin = quantityMin;
            this.QuantityMax = quantityMax;
            this.RelativeChance = relativeChance;
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
    }//end class SaveItemDataDelegate

    internal class SaveEmbellishmentCategoryDataDelegate
        : DataDelegate {
        public readonly int EmbellishmentCategoryID;
        public readonly int OwningUserID;
        public readonly string Name;
        public readonly int RelativeChance;
        public readonly string Description;
        public SaveEmbellishmentCategoryDataDelegate(
            int embellishmentCategoryID, int owningUserID,
            string name, int relativeChance, string description)
            : base("AppRecords.SaveEmbellishmentCategory") {
            this.EmbellishmentCategoryID = embellishmentCategoryID;
            this.OwningUserID = owningUserID;
            this.Name = name;
            this.RelativeChance = relativeChance;
            this.Description = description;
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
    }//end class SaveEmbellishmentCategoryDataDelegate

    internal class SaveEmbellishmentDataDelegate : DataDelegate {
        public readonly int EmbellishmentID;
        public readonly int EmbellishmentCategoryID;
        public readonly string Name;
        public readonly string Description;
        public readonly decimal CostFactor;
        public readonly decimal WeightFactor;
        public readonly int RelativeChance;
        public SaveEmbellishmentDataDelegate(int embellishmentID,
            int embellishmentCategoryID, string name, string description,
            decimal costFactor, decimal weightFactor, int relativeChance)
            : base("AppRecords.SaveEmbellishment") {
            this.EmbellishmentID = embellishmentID;
            this.EmbellishmentCategoryID = embellishmentCategoryID;
            this.Name = name;
            this.Description = description;
            this.CostFactor = costFactor;
            this.WeightFactor = weightFactor;
            this.RelativeChance = relativeChance;
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
    }//end class SaveEmbellishmentDataDelegate

    internal class SaveEnchantmentCategoryDataDelegate : DataDelegate {
        public readonly int EnchantingCategoryID;
        public readonly int OwningUserID;
        public readonly string Name;
        public readonly int RelativeChance;
        public readonly string Description;
        public SaveEnchantmentCategoryDataDelegate(
            int enchantingCategoryID, int owningUserID, string name,
            int relativeChance, string description) :
            base("AppRecords.SaveEnchantmentCategory") {
            this.EnchantingCategoryID = enchantingCategoryID;
            this.OwningUserID = owningUserID;
            this.Name = name;
            this.RelativeChance = relativeChance;
            this.Description = description;
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
    }//end class SaveEnchantmentCategoryDataDelegate

    internal class SaveEnchantmentDataDelegate : DataDelegate {
        public readonly int EnchantmentID;
        public readonly int EnchantmentCategoryID;
        public readonly string Name;
        public readonly string Description;
        public readonly int Cost;
        public readonly decimal WeightFactor;
        public readonly int RelativeChance;
        public readonly string PowerReserveType;
        public readonly int PowerReserveAmount;
        public SaveEnchantmentDataDelegate(int enchantmentID,
            int enchantmentCategoryID, string name, string description,
            int cost, decimal weightFactor, int relativeChance,
            string powerReserveType, int powerReserveAmount) :
            base("AppRecords.SaveEnchantment") {
            this.EnchantmentID = enchantmentID;
            this.EnchantmentCategoryID = enchantmentCategoryID;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.WeightFactor = weightFactor;
            this.RelativeChance = relativeChance;
            this.PowerReserveType = powerReserveType;
            this.PowerReserveAmount = powerReserveAmount;
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
    }//end class SaveEnchantmentDataDelegate

    internal class SaveInventoryItemDataDelegate : DataDelegate {
        public readonly int InventoryID;
        public readonly int OwningUserID;
        public readonly string Name;
        public readonly string Description;
        public readonly string GeneratingTableName;
        public readonly int Quantity;
        public readonly int UnitPrice;
        public readonly int BaseWeight;
        public readonly string WeightType;
        public SaveInventoryItemDataDelegate(int inventoryID,
            int owningUserID, string name, string description,
            string generatingTableName, int quantity, int unitPrice,
            int baseWeight, string weightType) :
            base("GeneratedItems.SaveInventoryItem") {
            this.InventoryID = inventoryID;
            this.OwningUserID = owningUserID;
            this.Name = name;
            this.Description = description;
            this.GeneratingTableName = generatingTableName;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.BaseWeight = baseWeight;
            this.WeightType = weightType;
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
    }//end class SaveInventoryItemDataDelegate

    internal class SaveCreatedEmbellishmentDataDelegate : DataDelegate {
        public readonly int CreatedEmbellishmentID;
        public readonly string Name;
        public readonly string Description;
        public readonly string GeneratingCategoryName;
        public readonly decimal CostFactor;
        public readonly decimal WeightFactor;
        public SaveCreatedEmbellishmentDataDelegate(
            int createdEmbellishmentID, string name, string description,
            string generatingCategoryName, decimal costFactor,
            decimal weightFactor) :
            base("GeneratedItems.SaveCreatedEmbellishment") {
            this.CreatedEmbellishmentID = createdEmbellishmentID;
            this.Name = name; this.Description = description;
            this.GeneratingCategoryName = generatingCategoryName;
            this.CostFactor = costFactor;
            this.WeightFactor = weightFactor;
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
    }//end class SaveCreatedEmbellishmentDataDelegate

    internal class SaveCreatedEnchantmentDataDelegate : DataDelegate {
        public readonly int CreatedEnchantmentID;
        public readonly string Name;
        public readonly string Description;
        public readonly string GeneratingCategoryName;
        public readonly int Cost;
        public readonly decimal WeightFactor;
        public readonly string PowerReserveType;
        public readonly int PowerReserveAmount;
        public SaveCreatedEnchantmentDataDelegate(
            int createdEnchantmentID, string name, string description,
            string generatingCategoryName, int cost,
            decimal weightFactor, string powerReserveType,
            int powerReserveAmount) :
            base("GeneratedItems.SaveCreatedEnchantment") {
            this.CreatedEnchantmentID = createdEnchantmentID;
            this.Name = name; this.Description = description;
            this.GeneratingCategoryName = generatingCategoryName;
            this.Cost = cost; this.WeightFactor = weightFactor;
            this.PowerReserveType = powerReserveType;
            this.PowerReserveAmount = powerReserveAmount;
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
    }//end class SaveCreatedEnchantmentDataDelegate
}//end namespace
