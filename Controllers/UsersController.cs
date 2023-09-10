using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<UserModel> Users = Data.Data.GetUsers(100);

        [HttpGet]
        public List<UserModel> GetUsers()
        {
            return Users.OrderBy(x => x.Id).ToList();
        }
        [HttpGet("{id}")] //by route
        public IActionResult GetById(int id) 
        { 
            var User = Users.Where(u => u.Id == id).FirstOrDefault() ;
            if (User == null)
                return NotFound();
            return Ok(User);
        }
        [HttpGet("GetByQuery")]
        public UserModel GetByIdQuery([FromQuery] int id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }
        [HttpPost]
        public IActionResult AddUser([FromBody]UserModel model) 
        { 
            var User = Users.Where(u=> u.Id == model.Id).FirstOrDefault();
            if (User != null)
                return BadRequest();
            Users.Add(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody]UserModel model) 
        {
            var User = Users.Where(u => u.Id == model.Id).FirstOrDefault();
            if(User == null)
                return BadRequest("There is no user with the entered ID.");
            User.FirstName = model.FirstName;   
            User.LastName = model.LastName;
            User.Address = model.Address;

            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteUser(int id) 
        {
            var User = Users.Where(u => u.Id == id).FirstOrDefault();
            if (User == null)
                return BadRequest("There is no user with the entered ID.");
            Users.Remove(User);
            return Ok();
        }
    }
}
