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
    public class CreateItem : Controller {

        public CreateItem(IItemRepo items) {
            Items = items;
        }
        public IItemRepo Items { get; set; }

        // GET: api/<controller>


        [HttpGet("json")]
        public Item CreateItemGet(string json) {
            dynamic i = JsonConvert.DeserializeObject<dynamic>(json);
            return Items.CreateItem(i.CategoryId, i.Name, i.UnitPrice, i.BaseWeight, i.WeightType, i.QuantityMin, i.QuantityMax, i.Description, i.RelativeChance);
        }



    }
}
