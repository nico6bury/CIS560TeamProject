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
    public class CreateUserController : Controller {

        public CreateUserController(IUserRepo users) {
            Users = users;
        }
        public IUserRepo Users { get; set; }

        // GET: api/<controller>


        [HttpGet("{username},{password}")]
        public User CreateUser(string username, string password) {
            return Users.CreateUser(username, password);
        }

        [HttpPost]
        public User CreateUserPost([FromBody] string username, [FromBody] string password) {
            return Users.CreateUser(username, password);
        }


    }
}
