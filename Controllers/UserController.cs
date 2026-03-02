using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models.DTO;
using blogAPI.Services;
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
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            return _data.AddUser(userToAdd);
        }

    }
}