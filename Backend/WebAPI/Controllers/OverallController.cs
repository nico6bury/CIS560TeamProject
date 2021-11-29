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

        //[HttpGet]
        //public List<string> GetSomething() {
        //    List<string> gs = new List<string>();
        //    gs.Add("hello");
        //    gs.Add("there");
        //    return gs;
        //}

        [HttpPost]
        public IReadOnlyList<User> RetrieveAllUsers([FromBody] string item) {
            return Users.RetrieveAllUsers();
        }

        
    }
}
