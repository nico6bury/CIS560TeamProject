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
        public IReadOnlyList<ItemCategorySummary> RetrieveCategorySummaryGet() {
            //NewCategoryIdOb catId = JsonConvert.DeserializeObject<NewCategoryIdOb>(json);
                IReadOnlyList<ItemCategorySummary> toReturn = Summary.GetItemCategorySummary();

            return toReturn;
        }



    }//end class

    public class NewCategoryIdOb {
        public NewCategoryIdOb(int catid) {
            CategoryId = catid;
        }

        public int CategoryId { get; set; }
    }


}
