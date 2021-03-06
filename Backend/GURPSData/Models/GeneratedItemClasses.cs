/*
 * Author: Nicholas Sixbury
 * File: GeneratedItemsClasses.cs
 * IncludedClasses: InventoryItem, 
 * Purpose: To provide a single, well documented file hich holds all of the classes within the
 * AppRecords schema in the database used by this application. Each class represents a single table
 * in the schema.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Models {
    /// <summary>
    /// A class representing the InventoryItem table in the GeneratedItems schema. Holds information
    /// about an instance of items generated by a user, including the quantity of items in that
    /// instance.
    /// </summary>
    public class InventoryItem {
        /// <summary>
        /// The ID number corresponding to this inventory item.
        /// </summary>
        public int InventoryID { get; }
        /// <summary>
        /// The ID number of the user account who owns this item.
        /// </summary>
        public int OwningUserID { get; }
        /// <summary>
        /// The name of this item.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description of this item.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The name of the table which generated this item.
        /// </summary>
        public string GeneratingTableName { get; }
        /// <summary>
        /// The quantity of this item in this particular instance.
        /// </summary>
        public int Quantity { get; }
        /// <summary>
        /// The base unit price for one of these items, without taking enchantments or
        /// embellishments into account.
        /// </summary>
        public int UnitPrice { get; }
        /// <summary>
        /// The base weight of one of these items, without taking enchantments or
        /// embellishments into account.
        /// </summary>
        public int BaseWeight { get; }
        /// <summary>
        /// The "Weight Type" for this item. If the BaseWeight
        /// is in ounces, then this should be ounces or oz. If
        /// the BaseWeight is in gallons, then this should be
        /// gallons or gal.
        /// </summary>
        public string WeightType { get; }
        /// <summary>
        /// The date and time that this item was generated on.
        /// </summary>
        public DateTime GeneratedOn { get; }
        /// <summary>
        /// The date and time that this item was last edited on. If this item
        /// has never been edited, then this should be null.
        /// </summary>
        public DateTime EditedOn { get; }

        /// <summary>
        /// Constructs the InventoryItem class.
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingTableName"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="baseWeight"></param>
        /// <param name="weightType"></param>
        /// <param name="generatedOn"></param>
        /// <param name="editedOn"></param>
        public InventoryItem(int inventoryID, int owningUserID, string name, string description,
            string generatingTableName, int quantity, int unitPrice, int baseWeight,
            string weightType, DateTime generatedOn, DateTime editedOn) {
            this.InventoryID = inventoryID; this.OwningUserID = owningUserID; this.Name = name;
            this.Description = description; this.GeneratingTableName = generatingTableName;
            this.Quantity = quantity; this.UnitPrice = unitPrice; this.BaseWeight = baseWeight;
            this.WeightType = weightType; this.GeneratedOn = generatedOn; this.EditedOn = editedOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with InventoryID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>InventoryID of this object.</returns>
        public override int GetHashCode() {
            return InventoryID;
        }//end GetHashCode()
    }//end class InventoryItem
    /// <summary>
    /// A class representing the CreatedEnchantment table in the GeneratedItems schema. Holds
    /// information about a particular enchantment that has been generated by the user at some
    /// point. Generally there will only be one instance of a particular enchantment, as one
    /// instance can link to any number of items through EnchantmentRefs.
    /// </summary>
    public class CreatedEnchantment {
        /// <summary>
        /// The ID number that corresponds to this particular enchantment instance.
        /// </summary>
        public int CreatedEnchantmentID { get; }
        /// <summary>
        /// The name of this enchantment.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description for this enchantment.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The name of the enchantment category that this enchantment came from.
        /// </summary>
        public string GeneratingCategoryName { get; }
        /// <summary>
        /// The cost of this enchantment.
        /// </summary>
        public int Cost { get; }
        /// <summary>
        /// The weight factor of this enchantment.
        /// </summary>
        public decimal WeightFactor { get; }
        /// <summary>
        /// The type of power reserve this enchantment holds. Examples of power reserves include
        /// Normal, Exclusive, OneCollege, Dedicated, Regenerating, and Rechargeable.
        /// </summary>
        public string PowerReserveType { get; }
        /// <summary>
        /// The amount of power held by the power reserve in this object. This should be the max
        /// amount, and if this item has no power reserve, then this should be zero.
        /// </summary>
        public int PowerReserveAmount { get; }

        /// <summary>
        /// Constructs the CreatedEnchantment class.
        /// </summary>
        /// <param name="createdEnchantmentID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingCategoryName"></param>
        /// <param name="cost"></param>
        /// <param name="weightFactor"></param>
        /// <param name="powerReserveType"></param>
        /// <param name="powerReserveAmount"></param>
        public CreatedEnchantment(int createdEnchantmentID, string name, string description,
            string generatingCategoryName, int cost, decimal weightFactor,
            string powerReserveType, int powerReserveAmount) {
            this.CreatedEnchantmentID = createdEnchantmentID; this.Name = name;
            this.Description = description; this.GeneratingCategoryName = generatingCategoryName;
            this.Cost = cost; this.WeightFactor = weightFactor;
            this.PowerReserveType = powerReserveType; this.PowerReserveAmount = powerReserveAmount;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with CreatedEnchantmentID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>CreatedEnchantmentID of this object.</returns>
        public override int GetHashCode() {
            return CreatedEnchantmentID;
        }//end GetHashCode()
    }//enc class CreatedEnchantment
    /// <summary>
    /// A class representing the CreatedEmbellishment table in the GeneratedItems schema. Holds
    /// information about a particular embellishment that has been generated by the user at some
    /// point. Generally there will only be one instance of a particular embellishment, as one
    /// instance can link to any number of items through EmbellishmentRefs.
    /// </summary>
    public class CreatedEmbellishment {
        /// <summary>
        /// The ID number that corresponds to this particular instance of a particular
        /// embellishment that has been generated.
        /// </summary>
        public int CreatedEmbellishmentID { get; }
        /// <summary>
        /// The name of this embellishment.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description for this embellishment.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// THe name of the embellishment category that this generated embellishment came from.
        /// </summary>
        public string GeneratingCategoryName { get; }
        /// <summary>
        /// The Cost Factor (CF) of this item, applied to the item which this enchantment is
        /// applied to.
        /// </summary>
        public decimal CostFactor { get; }
        /// <summary>
        /// The Weight Factor for this item, applied to the item which this embellishment is
        /// applied to.
        /// </summary>
        public decimal WeightFactor { get; }

        /// <summary>
        /// Constructs the CreatedEmbellishment class.
        /// </summary>
        /// <param name="createdEmbellishmentID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="generatingCategoryName"></param>
        /// <param name="costFactor"></param>
        /// <param name="weightFactor"></param>
        public CreatedEmbellishment(int createdEmbellishmentID, string name, string description,
            string generatingCategoryName, decimal costFactor, decimal weightFactor) {
            this.CreatedEmbellishmentID = createdEmbellishmentID; this.Name = name;
            this.Description = description; this.GeneratingCategoryName = generatingCategoryName;
            this.CostFactor = costFactor; this.WeightFactor = weightFactor;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with CreatedEmbellishmentID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>CreatedEmbellishmentID of this object.</returns>
        public override int GetHashCode() {
            return CreatedEmbellishmentID;
        }//end GetHashCode()
    }//end class CreatedEmbellishment
    /// <summary>
    /// A class representing the EnchantmentRef table in the GeneratedItems schema. This class
    /// represents a reference from an item that has been generated, to an enchantment that has
    /// been created, indicating that that item is enchanted with the given enchantment.
    /// </summary>
    public class EnchantmentRef {
        /// <summary>
        /// The ID number of the generated enchantment instance that this Ref is linking to.
        /// </summary>
        public int CreatedEnchantmentID { get; }
        /// <summary>
        /// The ID number of the generated item instance that this Ref is linking to.
        /// </summary>
        public int InventoryID { get; }
        /// <summary>
        /// The date and time when this reference was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the EnchantmentRef class.
        /// </summary>
        /// <param name="createdEnchantmentID"></param>
        /// <param name="inventoryID"></param>
        /// <param name="createdOn"></param>
        public EnchantmentRef(int createdEnchantmentID, int inventoryID, DateTime createdOn) {
            this.CreatedEnchantmentID = createdEnchantmentID;
            this.InventoryID = inventoryID; this.CreatedOn = createdOn;
        }//end constructor
    }//end class EnchantmentRef
    /// <summary>
    /// A class representing the EmbellishmentRef table in the GeneratedItems schema. This class
    /// represents a reference from an item that has been generated, to an embellishment that has
    /// been created, indicating that that item is embellished with the given embellishment.
    /// </summary>
    public class EmbellishmentRef {
        /// <summary>
        /// The ID number of the generated embellishment instance that this Ref is linking to.
        /// </summary>
        public int CreatedEmbellishmentID { get; }
        /// <summary>
        /// The ID number of the generated item instance that this Ref is linking to.
        /// </summary>
        public int InventoryID { get; }
        /// <summary>
        /// The date and time when this reference was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the EmbellishmentRef class.
        /// </summary>
        /// <param name="createdEmbellishmentID"></param>
        /// <param name="inventoryID"></param>
        /// <param name="createdOn"></param>
        public EmbellishmentRef(int createdEmbellishmentID, int inventoryID, DateTime createdOn) {
            this.CreatedEmbellishmentID = createdEmbellishmentID;
            this.InventoryID = inventoryID; this.CreatedOn = createdOn;
        }//end constructor
    }//end class EmbellishmentRef
}//end namespace
