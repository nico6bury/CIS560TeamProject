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
        public UserItemSummaryRemake RetrieveCategorySummaryGet(string json) {
            NewUserIdOb userId = JsonConvert.DeserializeObject<NewUserIdOb>(json);
            IReadOnlyList<UserItemSummary> toNotReturn = Summary.GetUserItemSummary();
            UserItemSummary toReturn = new UserItemSummary();
            foreach (UserItemSummary i in toNotReturn) {
                if (i.UserID == userId.UserId) {
                    toReturn = i;
                }
            }
            UserItemSummaryRemake toActReturn = new UserItemSummaryRemake(toReturn.UserID, toReturn.Username, toReturn.TablesCreated, toReturn.ItemsCreated, toReturn.TablesUsed, toReturn.ItemsGenerated, toReturn.JoinedOn);
            return toActReturn;
        }



    }//end class


    public class UserItemSummaryRemake {
        public UserItemSummaryRemake(int userID, string username,
            int tablesCreated, int itemsCreated, int tablesUsed,
            int itemsGenerated, DateTime joinedOn) {
            UserId = userID;
            Username = username;
            TablesCreated = tablesCreated;
           ItemsCreated = itemsCreated;
            TablesUsed = tablesUsed;
            ItemsGenerated = itemsGenerated;
            JoinedOn = joinedOn;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public int TablesCreated { get; set; }
        public int ItemsCreated { get; set; }
        public int TablesUsed { get; set; }
        public int ItemsGenerated { get; set; }
        public DateTime JoinedOn { get; set; }
    }


}
