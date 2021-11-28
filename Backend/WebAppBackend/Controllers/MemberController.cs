using Member.Data.Interface;
using Member.Data.Models;
using Member.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MemberApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {
        private IMembers members { get; set; }

        public MemberController(IMembers newMembers) {
            members = newMembers;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Members>> GetAllMembers() {
            return members.GetAllMember();
        }

        [HttpGet("{id}", Name ="GetMembers")]
        public IActionResult GetById(string id) {
            var item = members.Find(id);
            if (item == null) { return NotFound(); }
            return new ObjectResult(item);
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Members>> GetAllMembers() {
        //    return members.GetAllMember();
        //}
        //[HttpGet]
        //public ActionResult<Members> GetMemberById(int id) {
        //    return members.GetMember(id);
        //}
    }
}