using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories.AppRecordRepoInterfaces;
using GURPSData.Models.AppRecordClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class OverallController : Controller {

        public OverallController(IUserRepo users) {
            Users = users;
        }
        public IUserRepo Users { get; set; }

        // GET: api/<controller>


        [HttpGet]
        public IReadOnlyList<User> RetrieveAllUsers() {
            return Users.RetrieveAllUsers();
        }

        [HttpPost]
        public IReadOnlyList<User> RetrieveAllUsers() {
            return Users.RetrieveAllUsers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        
    }
}
