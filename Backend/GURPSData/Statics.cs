using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using GURPSData.Repositories;
using GURPSData.Models;

namespace GURPSData {
    public static class Statics {
        public static string BuildConnectionString() {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb["Data Source"] = "mssql.cs.ksu.edu";
            scsb["User ID"] = "nico6bury";
            scsb["Password"] = "D@t4B4s3:-)";

            return scsb.ConnectionString;
        }//end BuildConnectionString()

        /// <summary>
        /// Random number generation for ChooseChanceItem
        /// </summary>
        private static Random R = new Random();

        /// <summary>
        /// Generally Assumes that objects passed will have a public property
        /// named "RelativeChance". If a passed object doesn't have a public
        /// property named "RelativeChance", then its relative chance will
        /// be assumed to be 1. If "RelativeChance" isn't of type int, then
        /// if will be set to 1 as well. Input is sterilized a little bit as well,
        /// so negative numbers will be converted to positive opposites.
        /// </summary>
        /// <param name="objects">The list of objects to choose from.</param>
        /// <returns>A tuple with two values. The first value is the index in
        /// <seealso cref="objects"/> which was chosen. The second value is
        /// a reference to the object at that index itself. If, for some reason,
        /// (and this really should never happen), the operation fails in a
        /// way that goes undetected by the method and throws no error, then
        /// the return will be (-2, null)</returns>
        public static (int, object) ChooseChanceItem(IList<object> objects) {
            // a little bit of error handling
            if (objects.Count < 1)
                throw new ArgumentException("The parameter, objects, must have elements " +
                    $"in it, but instead it has a count of {objects.Count}");
            
            // setup parallel list to objects of relative chances
            int[] relChance = new int[objects.Count];
            for(int i = 0; i < relChance.Length; i++) {
                PropertyInfo rel = objects[i].GetType().GetProperty("RelativeChance");
                relChance[i] = rel == null || rel.PropertyType != typeof(int) ?
                    1 : Math.Abs((int)rel.GetValue(objects[i]));
            }//end looping over objects in objects

            // setup parallel list to objects of various chance thresholds
            (int, int)[] thresholds = new (int, int)[relChance.Length];
            thresholds[0] = (0, relChance[0]);
            for (int i = 1; i < thresholds.Length; i++) {
                thresholds[i] = (thresholds[i - 1].Item2,
                    thresholds[i - 1].Item2 + relChance[i]);
            }//end looping over each chance in relative chances

            // actually generate a random number, from 0 to last num in thresholds
            int chosen = R.Next(0, thresholds[thresholds.Length - 1].Item2 + 1);

            // actually figure out which item was chosen, and return our result
            for(int i = 0; i < thresholds.Length; i++) {
                if(chosen > thresholds[i].Item1 && chosen <= thresholds[i].Item2) {
                    return (i, objects[i]);
                }//end if we've found a match
            }//end looping to try and find answer

            // base case of sorts just in case something fails somehow
            return (-1, null);
        }//end ChooseChanceItem(objects)

        /// <summary>
        /// Randomly selects items from the selected pool of available items,
        /// creates summary statistics about those items, and then adds
        /// inventory versions to the database.
        /// </summary>
        /// <param name="itemRepo">The ItemRepo object we should use to access
        /// item records in the database.</param>
        /// <param name="inventoryRepo">The InventoryRepo object we should use
        /// to access inventory records in the database.</param>
        /// <param name="itemCategoryRepo">The ItemCategoryRepo object that we
        /// should use to access item category records in the database</param>
        /// <param name="numItems">The number of items to generate.</param>
        /// <param name="itemCategoryID">The ID of the Item Category table to pull
        /// items from. This parameter also has special values. If this is set
        /// to -1, then we'll pull from all item categories owned by the user.
        /// If this is -2, then we'll allow ourselves to pull from any category
        /// at all.</param>
        /// <param name="userID">The user who is generating items. GeneratedItems will
        /// be placed in their inventory automatically.</param>
        /// <returns>This method returns a relatively complicated tuple. Here's
        /// an explanation of each part: <para />
        /// Item1: Set of names of each item generated. <para />
        /// Item2: List of itemIDs from items generated from. <para />
        /// Item3: List of inventoryIDs of items generated. <para />
        /// Item4: Total cost of all items generated. This takes quantity
        /// for individual items into account.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <remarks>Exception explanation:<para />
        /// ArgumentException: Generated when <paramref name="itemCategoryID"/> is either
        /// 0 or less than -2.<para />
        /// InvalidOperationException: Generated when the pool of available items
        /// (base on <paramref name="itemCategoryID"/>) is filtered to the point
        /// that there are no items for us to pick from. Ie, we look for items in
        /// a particular category, and there's nothing there, or something similar.</remarks>
        public static (ISet<string>, IList<int>, IList<int>, int)
            GenerateRandomItemsForUser(IItemRepo itemRepo, IInventoryRepo inventoryRepo,
            IItemCategoryRepo itemCategoryRepo,
            uint numItems, int itemCategoryID, int userID) {
            // setup some variables to get returned
            ISet<string> itemNames = new HashSet<string>();
            IList<int> itemIDs = new List<int>();
            IList<int> inventoryIDs = new List<int>();
            int totalCost = 0;

            IList<Item> generationPool = new List<Item>();
            // get a list of the items we're allowed to generated from
            if(itemCategoryID < -2 || itemCategoryID == 0) {
                throw new ArgumentException("Sorry, but it seems you entered {itemCategoryID} " +
                    "for {nameof(itemCategoryID)} in the {nameof(GeneratedRandomItemsForUser)} method in the " +
                    "{nameof(Statics)} class. This value should be -2, -1, or a value 1 or highter.");
            }//end if we have a problem with itemCategory
            else if(itemCategoryID == -2) {
                generationPool = (IList<Item>)itemRepo.RetrieveAllItems();
            }//end if we're doing all categories
            else if(itemCategoryID == -1) {
                generationPool = (IList<Item>)itemRepo.RetrieveItemsForUserID(userID);
            }//end if we're doing all of {userID}'s categories
            else {
                generationPool = (IList<Item>)itemRepo.RetrieveItemsForCategoryID(itemCategoryID);
            }//end else we're just doing one category

            // make sure we actually have stuff to generate
            if(generationPool.Count <= 0) {
                throw new InvalidOperationException("Sorry, but following method " +
                    "protocol has resulted in an item pool without any items in it. " +
                    "As such, we can't generate anything.");
            }//end if there are no items to generate

            // create version of generation bool with objects
            IList<object> genericGenPool = new List<object>();
            foreach(Item item in generationPool) {
                genericGenPool.Add((object)item);
            }//end looping over generation pool

            // do stuff for each generation
            for(int i = 0; i < numItems; i++) {
                var resTup = ChooseChanceItem(genericGenPool);
                if(resTup.Item2 != null) {
                    Item gend = resTup.Item2 as Item;

                    // add what we can to our outputs
                    itemNames.Add(gend.Name);
                    itemIDs.Add(gend.ItemID);

                    int gennedQuantity = R.Next(gend.QuantityMin, gend.QuantityMax + 1);

                    totalCost += (gennedQuantity * gend.UnitPrice);

                    // following chunk slightly broken/wrong for some inputs, I know
                    IReadOnlyList<ItemCategory> ecfrrfrid = itemCategoryRepo
                        .RetrieveItemCategoriesForID(itemCategoryID);
                    string catName = "MissingCategoryName";
                    if (ecfrrfrid.Count > 0) catName = ecfrrfrid[0].Name;

                    // add item(s) to inventory of user
                    InventoryItem invIt = inventoryRepo.CreateInventoryItem(userID, gend.Name, gend.Description,
                        catName,
                        gennedQuantity, gend.UnitPrice, gend.BaseWeight, gend.WeightType);

                    inventoryIDs.Add(invIt.InventoryID);
                }//end if we didn't generate something {null}
            }//end looping {numItems} times

            return (itemNames, itemIDs, inventoryIDs, totalCost);
        }//end GenerateRandomItemsForUser(itemRepo,inventoryRepo,numItems,itemCategoryID,userID)
    }//end class
}//end namespace
