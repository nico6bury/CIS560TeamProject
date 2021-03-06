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
    public class RetrieveDefaultItemCategories : Controller {

        public RetrieveDefaultItemCategories(IItemCategoryRepo ics) {
            ICs = ics;
        }
        public IItemCategoryRepo ICs { get; set; }

        // GET: api/<controller>


        [HttpGet]
        public IReadOnlyList<ItemCategory> RetrieveDefaultItemCategoriesGet() {
            return ICs.RetrieveDefaultItemCategories();
        }

        [HttpPost]
        public IReadOnlyList<ItemCategory> RetrieveDefaultItemCategoriesPost([FromBody] string item) {
            return ICs.RetrieveDefaultItemCategories();
        }


    }
}
