using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GURPSData.Repositories;
using GURPSData.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//using System.Web.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class CreateUserController : Controller {

        public CreateUserController(IUserRepo users) {
            Users = users;
        }
        public IUserRepo Users { get; set; }

        // GET: api/<controller>


        [HttpGet("{jsonString}")]
        public User CreateUser(string jsonString) {

            User decoded = JsonConvert.DeserializeObject<User>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-mm-dd" });

            return Users.CreateUser(decoded.Username, decoded.Password);
        }

        [HttpPost]
        public User CreateUserPost([FromBody] string username, string password) {
            Console.WriteLine(username);
            return Users.CreateUser(username, password);
        }


    }
}
