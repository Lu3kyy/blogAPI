using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;
using blogAPI.Models.DTO;
using blogAPI.Services;
using CODE.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }

        // Function to add our user type of CreateAccountDTO call userToadd, this will return a boolean if the user was added or not
        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            return _data.AddUser(userToAdd);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }






        [HttpGet("GetUserByUsername")]
        public UserIdDTO GetUserDTOUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
           return _data.Login(User);
            
        }


        [HttpDelete("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete)
        {
           return _data.DeleteUser(userToDelete);
        }



        //update user, this will take in a user model and update the user with the same id as the user model, this will return a boolean if the user was updated or not
        public bool UpdateUser(int Id, string username)
        {
            return _data.UpdateUser(Id, username);
        }

    }
}