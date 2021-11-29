using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;
using Newtonsoft.Json;
using GURPSData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class RandomItemController : Controller {

        public RandomItemController(IItemRepo itemrepo) {
            Is = itemrepo;
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public List<Item> Get(string id) {
            NewItemGenerator ic = JsonConvert.DeserializeObject<NewItemGenerator>(id);
            List<Item> toReturn = new List<Item>();
            try {
                IList<int> list = Statics.GenerateRandomItemsForUser(Is, INs, ICs, ic.NumItems, ic.TypeGenerate, ic.UserId).Item2;
                toReturn = new List<Item>();
                foreach (int i in list) {
                    toReturn.Add(Is.RetrieveItemsForID(i)[0]);
                }
            }//end try
            catch (Exception e) {
                Console.WriteLine(e);
            }
            
            return (toReturn);
        }

        public IItemCategoryRepo ICs { get; set; } = new ItemCategoryRepo();
        public IItemRepo Is { get; set; } = new ItemRepo();
        public IInventoryRepo INs { get; set; } = new InventoryRepo();


    }

    class NewItemGenerator {
        public NewItemGenerator(uint ni, int uid, int typegen) {
            NumItems = ni;
            UserId = uid;
            TypeGenerate = typegen;
        }
        public uint NumItems { get; set; }
        public int UserId { get; set; }

        public int TypeGenerate{get;set;}
    }

}
