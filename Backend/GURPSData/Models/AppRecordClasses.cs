/*
 * Author: Nicholas Sixbury
 * File: AppRecordClasses.cs
 * Included Classes: User, ItemCategory, Item, ItemSubcategory, ItemTypeOption,
 * EmbellishmentCategory, Embellishment, EnchantmentCategory, Embellishment
 * Purpose: To provide a single, well documented file which holds all of the classes
 * within the AppRecords schema in the database used by this application. Each class
 * represents a single table in the schema.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GURPSData.Models {
    /// <summary>
    /// A class representing the User table in the AppRecords schema. Holds information about
    /// a single user.
    /// </summary>
    public class User {
        /// <summary>
        /// The UserID of this particular user.
        /// </summary>
        public int UserID { get; }
        /// <summary>
        /// The username of this particular user. Used to log in.
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// THe password of this particular user account. Used to log in.
        /// </summary>
        public string Password { get; }
        /// <summary>
        /// Whether or not this user is an admin. For most users, this will be false.
        /// </summary>
        public bool IsAdmin { get; }
        /// <summary>
        /// The date when this user made their account.
        /// </summary>
        public DateTime JoinedOn { get; }

        /// <summary>
        /// Constructs the User class.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isAdmin"></param>
        /// <param name="joinedOn"></param>
        //public User(int userID, string username, string password, bool isAdmin, DateTime joinedOn) {
        //    this.UserID = userID; this.Username = username; this.Password = password;
        //    this.IsAdmin = isAdmin; this.JoinedOn = joinedOn;
        //}//end constructor

        public User(int userID, string username, string password, bool isAdmin) {
            this.UserID = userID; this.Username = username; this.Password = password;
            this.IsAdmin = isAdmin; this.JoinedOn = DateTime.Now;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with UserID. This should work
        /// as long as objects of type User are only stored in sets with
        /// other objects of exactly type User.
        /// </summary>
        /// <returns>UserID of this object.</returns>
        public override int GetHashCode() {
            return UserID;
        }//end GetHashCode()
    }//end class User
    /// <summary>
    /// A class representing the ItemCategory table in the AppRecords schema. Holds information
    /// about a particular category or group which items might fall under.
    /// </summary>
    public class ItemCategory {
        /// <summary>
        /// The ID number corresponding to this particular category of items.
        /// </summary>
        public int ItemCategoryID { get; }
        /// <summary>
        /// The User ID of the user which owns this category of items.
        /// </summary>
        public int OwningUserID { get; }
        /// <summary>
        /// The name of this category of items.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Whether or not this category is a part of the default set of item categories.
        /// </summary>
        public bool IsDefault { get; }
        /// <summary>
        /// The date and time when this category of items was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the ItemCategory class.
        /// </summary>
        /// <param name="itemCategoryID"></param>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="isDefault"></param>
        /// <param name="createdOn"></param>
        public ItemCategory(int itemCategoryID, int owningUserID, string name,
            bool isDefault, DateTime createdOn) {
            this.ItemCategoryID = itemCategoryID; this.OwningUserID = owningUserID;
            this.Name = name; this.IsDefault = isDefault; this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with ItemCategoryID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>ItemCategoryID of this object.</returns>
        public override int GetHashCode() {
            return ItemCategoryID;
        }//end GetHashCode()
    }//end class ItemCategory
    /// <summary>
    /// A class which represents a single item, along with all the statistical information about
    /// that item.
    /// </summary>
    public class Item {
        /// <summary>
        /// The ID number corresponding to this particular item.
        /// </summary>
        public int ItemID { get; }
        /// <summary>
        /// The name of this item.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The base price of a single item like this.
        /// </summary>
        public int UnitPrice { get; }
        /// <summary>
        /// The base weight for a single item like this.
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
        /// The minimum quantity you might find in one generation of this item.
        /// </summary>
        public int QuantityMin { get; }
        /// <summary>
        /// The maximum quantity you might find in one generation of this item.
        /// </summary>
        public int QuantityMax { get; }
        /// <summary>
        /// A description of what this item is, or information about it. Might
        /// very well be blank for a lot of items.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The relative chance that this item will be generated instead of another
        /// item in the same categpry.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// The date and time that the stats for this item were put together.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the Item class.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="name"></param>
        /// <param name="unitPrice"></param>
        /// <param name="baseWeight"></param>
        /// <param name="weightType"></param>
        /// <param name="quantityMin"></param>
        /// <param name="quantityMax"></param>
        /// <param name="description"></param>
        /// <param name="relativeChance"></param>
        /// <param name="createdOn"></param>
        public Item(int itemID, string name, int unitPrice, int baseWeight, string weightType,
            int quantityMin, int quantityMax, string description, int relativeChance, DateTime createdOn) {
            this.ItemID = itemID; this.Name = name; this.UnitPrice = unitPrice; this.BaseWeight = baseWeight;
            this.WeightType = weightType; this.QuantityMin = quantityMin; this.QuantityMax = quantityMax;
            this.Description = description; this.RelativeChance = relativeChance; this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with ItemID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>ItemID of this object.</returns>
        public override int GetHashCode() {
            return ItemID;
        }//end GetHashCode()
    }//end class Item
    /// <summary>
    /// A linking class of sorts that links the Item, ItemCategory, and ItemTypeOption
    /// classes together. These should usually be one and only one ItemSubcategory for each
    /// item, but it is possible for more to exist. For items with no ItemTypeOptions, the
    /// Name property of the corresponding ItemSubcategory object should be "NULL".
    /// </summary>
    public class ItemSubcategory {
        /// <summary>
        /// The ID that corresponds to this ItemSubcategory.
        /// </summary>
        public int ItemSubcategoryID { get; }
        /// <summary>
        /// The ID of the ItemCategory that this ItemSubcategory belongs to.
        /// </summary>
        public int ItemCategoryID { get; }
        /// <summary>
        /// The ID of the item that this ItemSubcategory belongs to.
        /// </summary>
        public int ItemID { get; }
        /// <summary>
        /// The name of this subcategory. For items which do not have any ItemTypeOption,
        /// this will likely be "NULL".
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructs the ItemSubcategory class.
        /// </summary>
        /// <param name="itemSubcategoryID"></param>
        /// <param name="itemCategory"></param>
        /// <param name="itemID"></param>
        /// <param name="name"></param>
        public ItemSubcategory(int itemSubcategoryID, int itemCategory, int itemID, string name) {
            this.ItemSubcategoryID = itemSubcategoryID; this.ItemCategoryID = itemCategory;
            this.ItemID = itemID; this.Name = name;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with ItemSubcategoryID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>ItemSubcategoryID of this object.</returns>
        public override int GetHashCode() {
            return ItemSubcategoryID;
        }//end GetHashCode()
    }//end class ItemSubcategory
    /// <summary>
    /// This class represents one option of multiple different types of a partular item. For
    /// instance, if you have an Item named "Pepper", you could have variations in the price
    /// of different colors of "Pepper", so "Pepper, (White)" and "Pepper, (Black)" would be
    /// two different ItemTypeOptions with properties to account for changes to price
    /// accordingly.
    /// </summary>
    public class ItemTypeOption {
        /// <summary>
        /// The ID that corresponds to this particular ItemTypeOption.
        /// </summary>
        public int ItemTypeOptionID { get; }
        /// <summary>
        /// The name of this ItemTypeOption. Should be verbose enough to replace
        /// name of corresponding Item.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The ID of the ItemSubcategory object which this object corresponds to.
        /// </summary>
        public int ItemSubcategoryID { get; }
        /// <summary>
        /// The relative chance that this type option should get chosen as opposed to
        /// any other type option with the same ItemSubcategoryID.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// The change in price which is added to the price of the original item.
        /// </summary>
        public int PriceChange { get; }
        /// <summary>
        /// The change in weight which is added to the weight of the original item.
        /// </summary>
        public int WeightChange { get; }
        /// <summary>
        /// The string that should be added onto the description of the original item.
        /// </summary>
        public string DescriptionAddition { get; }

        /// <summary>
        /// Constructs the ItemTypeOption class.
        /// </summary>
        /// <param name="itemTypeOptionID"></param>
        /// <param name="name"></param>
        /// <param name="itemSubcategoryID"></param>
        /// <param name="relativeChance"></param>
        /// <param name="priceChange"></param>
        /// <param name="weightChange"></param>
        /// <param name="descriptionAddition"></param>
        public ItemTypeOption(int itemTypeOptionID, string name, int itemSubcategoryID, int relativeChance,
            int priceChange, int weightChange, string descriptionAddition) {
            this.ItemTypeOptionID = itemTypeOptionID; this.Name = name; this.ItemSubcategoryID = itemSubcategoryID;
            this.RelativeChance = relativeChance; this.PriceChange = priceChange;
            this.WeightChange = weightChange; this.DescriptionAddition = descriptionAddition;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with ItemTypeOptionID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>ItemTypeOptionID of this object.</returns>
        public override int GetHashCode() {
            return ItemTypeOptionID;
        }//end GetHashCode()
    }//end class ItemTypeOption
    /// <summary>
    /// A class representing a category of embellishments.
    /// </summary>
    public class EmbellishmentCategory {
        /// <summary>
        /// The ID that corresponds to this particular category of embellishments.
        /// </summary>
        public int EmbellishmentCategoryID { get; }
        /// <summary>
        /// The user ID of the user account which owns this category of embellishments.
        /// </summary>
        public int OwningUserID { get; }
        /// <summary>
        /// The name of this category of embellishments.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The relative chance that this category of embellishments will be chosen as
        /// opposed to any other category of embellishments.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// A description of this category of embellishments.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The date when this category of embellishments was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the EmbellishmentCategory class.
        /// </summary>
        /// <param name="embellishmentCategoryID"></param>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="relativeChance"></param>
        /// <param name="description"></param>
        /// <param name="createdOn"></param>
        public EmbellishmentCategory(int embellishmentCategoryID, int owningUserID,
            string name, int relativeChance, string description, DateTime createdOn) {
            this.EmbellishmentCategoryID = embellishmentCategoryID;
            this.OwningUserID = owningUserID; this.Name = name;
            this.RelativeChance = relativeChance; this.Description = description;
            this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with EmbellishmentCategoryID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>EmbellishmentCategoryID of this object.</returns>
        public override int GetHashCode() {
            return EmbellishmentCategoryID;
        }//end GetHashCode()
    }//end class EmbellishmentCategory
    /// <summary>
    /// A class representing a particular embellishment that an item might have.
    /// </summary>
    public class Embellishment {
        /// <summary>
        /// The ID number that corresponds to this particular embellishment.
        /// </summary>
        public int EmbellishmentID { get; }
        /// <summary>
        /// The ID of the category of embellishments that this embellishment belongs to.
        /// </summary>
        public int EmbellishmentCategoryID { get; }
        /// <summary>
        /// The name of this embellishment.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description of this embellishment.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The cost factor (CF) of this embellishment, applied to the cost of the item
        /// that this embellishment is applied to.
        /// </summary>
        public decimal CostFactor { get; }
        /// <summary>
        /// The weigt factor of this embellishment, applied to the weight of the item
        /// that this embellishment is applied to.
        /// </summary>
        public decimal WeightFactor { get; }
        /// <summary>
        /// The relative chance that this embellishment is chosen as opposed to any other
        /// embellishment in the same category.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// The date and time that this embellishment was created on.
        /// </summary>
        public DateTime CreatedOn { get; }
        /// <summary>
        /// Constructs the Embellishment class.
        /// </summary>
        /// <param name="embellishmentID"></param>
        /// <param name="embellishmentCategoryID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="costFactor"></param>
        /// <param name="weightFactor"></param>
        /// <param name="relativeChance"></param>
        /// <param name="createdOn"></param>
        public Embellishment(int embellishmentID, int embellishmentCategoryID,
            string name, string description, decimal costFactor, decimal weightFactor,
            int relativeChance, DateTime createdOn) {
            this.EmbellishmentID = embellishmentID;
            this.EmbellishmentCategoryID = embellishmentCategoryID; this.Name = name;
            this.Description = description; this.CostFactor = costFactor;
            this.WeightFactor = weightFactor;
            this.RelativeChance = relativeChance; this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with EmbellishmentID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>EmbellishmentID of this object.</returns>
        public override int GetHashCode() {
            return EmbellishmentID;
        }//end GetHashCode()
    }//end class Embellishment
    /// <summary>
    /// A class representing a category of enchantments.
    /// </summary>
    public class EnchantmentCategory {
        /// <summary>
        /// The ID number which corresponds to this particular category of enchantments.
        /// </summary>
        public int EnchantmentCategoryID { get; }
        /// <summary>
        /// The ID number of the User account which owns this category of enchantments.
        /// </summary>
        public int OwningUserID { get; }
        /// <summary>
        /// The name of this enchantment category.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The relative chance that this enchantment category will be chosen as opposed
        /// to any other enchantment category.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// A description of this enchantment category.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The date and time when this enchantment category was created.
        /// </summary>
        public DateTime CreatedOn { get; }
        
        /// <summary>
        /// Constructs the EnchamtmentCategory class.
        /// </summary>
        /// <param name="enchantmentCategoryID"></param>
        /// <param name="owningUserID"></param>
        /// <param name="name"></param>
        /// <param name="relativeChance"></param>
        /// <param name="description"></param>
        /// <param name="createdOn"></param>
        public EnchantmentCategory(int enchantmentCategoryID, int owningUserID,
            string name, int relativeChance, string description, DateTime createdOn) {
            this.EnchantmentCategoryID = enchantmentCategoryID;
            this.OwningUserID = owningUserID; this.Name = name;
            this.Description = description; this.RelativeChance = relativeChance;
            this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with EnchantmentCategoryID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>EnchantmentCategoryID of this object.</returns>
        public override int GetHashCode() {
            return EnchantmentCategoryID;
        }//end GetHashCode()
    }//end class EnchantmentCategory
    /// <summary>
    /// A class representing a particular enchantment that an item might have.
    /// </summary>
    public class Enchantment {
        /// <summary>
        /// The ID number which corresponds to this particular enchantment.
        /// </summary>
        public int EnchantmentID { get; }
        /// <summary>
        /// The ID number of the enchantment category that this enchantment belongs to.
        /// </summary>
        public int EnchantmentCategoryID { get; }
        /// <summary>
        /// The name of this enchantment.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description of this enchantment.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// The cost of this enchantment.
        /// </summary>
        public int Cost { get; }
        /// <summary>
        /// The weigt factor of this enchantment, applied to the BaseWeight of whatever item
        /// this enchantment is applied to.
        /// </summary>
        public decimal WeightFactor { get; }
        /// <summary>
        /// THe relative chance that this enchantment will be chosen as opposed to any other
        /// enchantment in the same category.
        /// </summary>
        public int RelativeChance { get; }
        /// <summary>
        /// The type of power reserve this enchantment holds. Examples of power reserves include
        /// Normal, Exclusive, OneCollege, Dedicated, Regenerating, and Rechargeable.
        /// </summary>
        public string PowerReserveType { get; }
        /// <summary>
        /// The amount of energy held by the power reserve. If there's no power reserve, this
        /// could be 0.
        /// </summary>
        public int PowerReserveAmount { get; }
        /// <summary>
        /// The date and time that this enchantment was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// Constructs the Enchantment class;
        /// </summary>
        /// <param name="enchantmentID"></param>
        /// <param name="enchantmentCategoryID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="weightFactor"></param>
        /// <param name="relativeChance"></param>
        /// <param name="powerReserveType"></param>
        /// <param name="powerReserveAmount"></param>
        /// <param name="createdOn"></param>
        public Enchantment(int enchantmentID, int enchantmentCategoryID, string name,
            string description, int cost, decimal weightFactor, int relativeChance,
            string powerReserveType, int powerReserveAmount, DateTime createdOn) {
            this.EnchantmentID = enchantmentID; this.EnchantmentCategoryID = enchantmentCategoryID;
            this.Name = name; this.Description = description; this.Cost = cost;
            this.WeightFactor = weightFactor; this.RelativeChance = relativeChance;
            this.PowerReserveType = powerReserveType; this.PowerReserveAmount = powerReserveAmount;
            this.CreatedOn = createdOn;
        }//end constructor

        /// <summary>
        /// Replaces hash code generation with EnchantmentID.
        /// This should work as long as objects of type User are
        /// only stored in sets with other objects of exactly type User.
        /// </summary>
        /// <returns>EnchantmentID of this object.</returns>
        public override int GetHashCode() {
            return EnchantmentID;
        }//end GetHashCode()
    }//end class Enchantment
}//end namespace
