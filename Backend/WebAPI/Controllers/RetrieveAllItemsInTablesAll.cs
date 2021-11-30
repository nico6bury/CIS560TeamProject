using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class RetrieveAllItemsInTablesAll : Controller {

        public RetrieveAllItemsInTablesAll(IItemRepo items, IItemCategoryRepo cat, IUserRepo users) {
            Items = items;
            Categories = cat;
            Users = users;
        }
        public IItemRepo Items { get; set; }

        public IItemCategoryRepo Categories { get; set; }

        public IUserRepo Users { get; set; }

        // GET: api/<controller>


        [HttpGet("{json}")]
        public List<NewTableWithItems> RetrieveAllItemsInTablesGet(string json) {
            //NewUserIdOb userId = JsonConvert.DeserializeObject<NewUserIdOb>(json);
            List<NewTableWithItems> toReturn = new List<NewTableWithItems>();
            try {
                IReadOnlyList<ItemCategory> cats = Categories.RetrieveAllItemCategories();
                foreach (ItemCategory i in cats) {
                    IReadOnlyList<User> user = Users.RetrieveUserForID(i.OwningUserID);
                    string uname = user[0].Username;
                    toReturn.Add(new NewTableWithItems(i.ItemCategoryID, i.Name, Items.RetrieveItemsForCategoryID(i.ItemCategoryID), uname));
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return toReturn;
        }



    }//end class

    //public class NewTableWithItems {
    //    public NewTableWithItems(int tableId, string tName, IReadOnlyList<Item> d, string un) {
    //        TableId = tableId;
    //        TableName = tName;
    //        Data = d;
    //        UserName = un;
    //    }

    //    public int TableId { get; set; }

    //    public string TableName { get; set; }

    //    public IReadOnlyList<Item> Data { get; set; }

    //    public string UserName { get; set; }
    //}

    //public class NewUserIdOb {
    //    public NewUserIdOb(int uid) {
    //        UserId = uid;
    //    }
    //    public int UserId { get; set; }
    //}
}
