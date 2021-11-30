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
    public class GetUserInventorySummary : Controller {

        public GetUserInventorySummary(ReportRepos summ) {
            Summary = summ;
        }
        public ReportRepos Summary;

        // GET: api/<controller>


        [HttpGet("{json}")]
        public List<UserInventorySummaryRemake> GetUserInventorySummaryGet(string json) {
            NewUserIdOb catId = JsonConvert.DeserializeObject<NewUserIdOb>(json);
            IReadOnlyList<UserInventorySummary> toReturn = Summary.GetUserInventorySummary(catId.UserId);
            //Console.WriteLine(toReturn[0].Name + "\n\n\n");
            List<UserInventorySummaryRemake> toActReturn = new List<UserInventorySummaryRemake>();
            foreach (UserInventorySummary i in toReturn) {
                toActReturn.Add(new UserInventorySummaryRemake(i.Name, i.GeneratingTableName, i.EarliestGeneration, i.LatestGeneration, i.UnitPrice, i.BaseWeight, i.NumberGenerated));
            }


            return toActReturn;
        }
    }//end class


    public class UserInventorySummaryRemake {
        public UserInventorySummaryRemake( string name,
            string generatingTableName, DateTime earliestGeneration,
            DateTime latestGeneration, int unitPrice, int baseWeight,
            int numberGenerated) {
            Name = name;
            GeneratingTableName = generatingTableName;
            EarliestGeneration = earliestGeneration;
            LatestGeneration = latestGeneration;
            UnitPrice = unitPrice;
            BaseWeight = baseWeight;
            NumberGenerated = numberGenerated;
        }

        public string Name { get; set; }
        public string GeneratingTableName { get; set; }
        public DateTime EarliestGeneration { get; set; }
        public DateTime LatestGeneration { get; set; }
        public int UnitPrice { get; set; }
        public int BaseWeight { get; set; }
        int NumberGenerated { get; set; }
        
    }



}
