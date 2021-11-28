using DataAccess;
using GURPSData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GURPSData.DataDelegates {
    public class DeleteEmbellishmentRefDataDelegate
        : NonQueryDataDelegate<EmbellishmentRef> {
        private readonly int CreatedEmbellishmentID;
        private readonly int InventoryID;
        public DeleteEmbellishmentRefDataDelegate(
            int createdEmbellishmentID, int inventoryID) :
            base("GeneratedItems.DeleteEmbellishmentRef")
            { this.CreatedEmbellishmentID = createdEmbellishmentID;
            this.InventoryID = inventoryID;
        }//end constructor
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue(
                "CreatedEmbellishmentID", CreatedEmbellishmentID);
            command.Parameters.AddWithValue(
                "InventoryID", InventoryID);
        }//end PrepareCommand(command)
        public override EmbellishmentRef Translate(SqlCommand command) {
            return null;
        }//end Translate(command)
    }//end class DeleteEmbellishmentRefDataDelegate

    public class DeleteEnchantmentRefDataDelegate
        : NonQueryDataDelegate<EnchantmentRef> {
        private readonly int CreatedEnchantmentID;
        private readonly int InventoryID;
        public DeleteEnchantmentRefDataDelegate(
            int createdEnchantmentID, int inventoryID) :
            base("GeneratedItems.DeleteEnchantmentRef") {
            this.CreatedEnchantmentID = createdEnchantmentID;
            this.InventoryID = inventoryID;
        }//end constructor
        public override void PrepareCommand(SqlCommand command) {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue(
                "CreatedEnchantmentID", CreatedEnchantmentID);
            command.Parameters.AddWithValue(
                "InventoryID", InventoryID);
        }//end PrepareCommand(command)
        public override EnchantmentRef Translate(SqlCommand command) {
            return null;
        }//end Translate(command)
    }//end class DeleteEnchantmentRefDataDelegate
}//end namespace
