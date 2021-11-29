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
    public class RetrieveUserFromUserIdController : Controller {

        public RetrieveUserFromUserIdController(IUserRepo users) {
            Users = users;
        }
        public IUserRepo Users { get; set; }

        // GET: api/<controller>


        [HttpGet("{id}")]
        public IReadOnlyList<User> RetrieveUserForId(int id) {
            return Users.RetrieveUserForID(id);
        }

        [HttpPost]
        public IReadOnlyList<User> RetrieveUserForIdPost([FromBody] int userId) {
            return Users.RetrieveUserForID(userId);
        }


    }
}
