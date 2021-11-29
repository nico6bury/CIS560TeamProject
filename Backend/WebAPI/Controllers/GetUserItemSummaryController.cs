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
    public class GetUserItemSummary : Controller {

        public GetUserItemSummary(ReportRepos summ) {
            Summary = summ;
        }
        public ReportRepos Summary;

        // GET: api/<controller>


        [HttpGet("{json}")]
        public UserItemSummary RetrieveCategorySummaryGet(string json) {
            NewUserIdOb userId = JsonConvert.DeserializeObject<NewUserIdOb>(json);
            IReadOnlyList<UserItemSummary> toNotReturn = Summary.GetUserItemSummary();
            UserItemSummary toReturn = new UserItemSummary();
            foreach(UserItemSummary i in toNotReturn) {
                if(i.UserID == userId.UserId) {
                    toReturn = i;
                }
            }
            return toReturn;
        }



    }//end class


}
