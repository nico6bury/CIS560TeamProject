using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class RetrieveAllItems : Controller {

        public RetrieveAllItems(IItemRepo items) {
            Items = items;
        }
        public IItemRepo Items { get; set; }

        // GET: api/<controller>


        [HttpGet]
        public IReadOnlyList<Item> RetrieveAllItemsGet() {
            return Items.RetrieveAllItems();
        }

        [HttpPost]
        public IReadOnlyList<Item> RetrieveAllItemsPost([FromBody] string username) {
            return Items.RetrieveAllItems();
        }


    }
}
