using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace blogAPI.Services;

public class UserService 
{
    private readonly Context _context;
    internal bool AddUser(CreateAccountDTO userToAdd)
    {
        throw new NotImplementedException();
    }
}
