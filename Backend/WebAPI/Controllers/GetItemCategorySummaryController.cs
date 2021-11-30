using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;
using Newtonsoft.Json;
using GURPSData.DataDelegates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class GetItemCategorySummary : Controller {

        public GetItemCategorySummary(ReportRepos summ) {
            Summary = summ;
        }
        public ReportRepos Summary;

        // GET: api/<controller>


        [HttpGet]
        public List<ItemCategorySummaryRemake> RetrieveCategorySummaryGet() {
            //NewCategoryIdOb catId = JsonConvert.DeserializeObject<NewCategoryIdOb>(json);
            IReadOnlyList<ItemCategorySummary> toReturn = Summary.GetItemCategorySummary();
            //Console.WriteLine(toReturn[0].Name + "\n\n\n");
            List<ItemCategorySummaryRemake> toActReturn = new List<ItemCategorySummaryRemake>();
            foreach(ItemCategorySummary i in toReturn) {
                toActReturn.Add(new ItemCategorySummaryRemake(i.Name, i.Description, i.OwningUser, i.AverageCost, i.AverageWeight, i.TotalCost, i.TotalWeight));
            }


            return toActReturn;
        }


    }//end class


    public class ItemCategorySummaryRemake {
        public ItemCategorySummaryRemake(string name, string desc, string ou, int avcos, int avweig, int totcos, int totweg) {
            Name = name;
            Description = desc;
            OwningUser = ou;
            AverageCost = avcos;
            AverageWeight = avweig;
            TotalCost = totcos;
            TotalWeight = totweg;
        }

        public string Name { get; set; }

        public string Description { get; set; }
        public string OwningUser { get; set; }
        public  int AverageCost { get; set; }
        public  int AverageWeight { get; set; }
        public int TotalCost { get; set; }
        public int TotalWeight { get; set; }
    }



    public class NewCategoryIdOb {
        public NewCategoryIdOb(int catid) {
            CategoryId = catid;
        }

        public int CategoryId { get; set; }
    }


}
