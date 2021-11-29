using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;
using Newtonsoft.Json;
using System.Web.Http.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CreateCategory : Controller {

        public CreateCategory(IItemCategoryRepo ics) {
            ICs = ics;
        }
        public IItemCategoryRepo ICs { get; set; }

        // GET: api/<controller>


        [HttpGet("{json}")]
        public ItemCategory CreateCategoryGet(string json) {
            dynamic ic = JsonConvert.DeserializeObject<dynamic>(json);
            return ICs.CreateItemCategory(ic.OwningUserID, ic.Name.ToString());
        }

        


    }
}
