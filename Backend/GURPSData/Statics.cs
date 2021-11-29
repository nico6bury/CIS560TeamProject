using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;

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
    }//end class
}//end namespace
