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
    public class RetrieveAllItemCategories : Controller {

        public RetrieveAllItemCategories(IItemCategoryRepo ics) {
            ICs = ics;
        }
        public IItemCategoryRepo ICs { get; set; }

        // GET: api/<controller>


        [HttpGet]
        public IReadOnlyList<ItemCategory> RetrieveAllItemCategoriesGet() {
            return ICs.RetrieveAllItemCategories();
        }

        [HttpPost]
        public IReadOnlyList<ItemCategory> RetrieveAllItemCategoriesPost([FromBody] string item) {
            return ICs.RetrieveAllItemCategories();
        }


    }
}
