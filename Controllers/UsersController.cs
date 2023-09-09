using Microsoft.AspNetCore.Mvc;
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
        public UserModel GetById(int id) 
        { 
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }
        //[HttpGet]
        //public UserModel GetByIdQuery([FromQuery]int id)
        //{
        //    return Users.Where(u => u.Id == id).FirstOrDefault();
        //}
        [HttpPost]
        public IActionResult AddUser([FromBody]UserModel model) 
        { 
            var User = Users.Where(u=> u.Id == model.Id).FirstOrDefault();
            if (User != null)
                return BadRequest();
            Users.Add(model);
            return Ok();
        }
    }
}
