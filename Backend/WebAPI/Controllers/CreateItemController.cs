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


        [HttpGet("{json}")]
        public Item CreateItemGet(string json) {
            NewItem i = JsonConvert.DeserializeObject<NewItem>(json);
            return Items.CreateItem(i.CategoryId, i.Name, i.UnitPrice, i.BaseWeight, i.WeightType, i.QuantityMin, i.QuantityMax, i.Description, i.RelativeChance);
        }



    }//end class

    class NewItem {
        public NewItem(int catId, string name, int unitPrice, int baseW, string weightT, int quanMin, int quanMax, string desc, int relChance) {
            CategoryId = catId;
            Name = name;
            UnitPrice = unitPrice;
            BaseWeight = baseW;
            WeightType = weightT;
            QuantityMin = quanMin;
            QuantityMax = quanMax;
            Description = Description;
            RelativeChance = relChance;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int BaseWeight { get; set; }
        public string WeightType { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public string Description { get; set; }
        public int RelativeChance { get; set; }
    }
}
