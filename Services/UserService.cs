using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using blogAPI.Models;
using blogAPI.Models.DTO;
using blogAPI.Services.Context;
using CODE.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;

namespace blogAPI.Services;

public class UserService : ControllerBase
{
    private readonly DataContext _context;
    private object newUser;

    public string? Salt { get; private set; }

    public UserService(DataContext context)
    {
        _context = context;
    }




    //we need a helper method to check if the username is already taken, this will return a boolean if the username is taken or not
    public bool DoesUserExist(string username)
    {
        //check tables to see if username exists, if it does return true, if not return false
        return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
    }
    public bool AddUser(CreateAccountDTO userToAdd)
    {
        bool result = false;
        if (userToAdd.Username != null && userToAdd.Password != null && !DoesUserExist(userToAdd.Username))
        {
            UserModel newUser = new UserModel();

            var HashedPassword = HashPassword(userToAdd.Password);

            newUser.Id = userToAdd.Id;
            newUser.Username = userToAdd.Username;

            newUser.Salt = HashedPassword.Salt;
            newUser.Hash = HashedPassword.Hash;
            _context.Add(newUser);

            result = _context.SaveChanges() != 0;
        }
         return result;
     }
       




        public PasswordDTO HashPassword(string? password)
    {
        PasswordDTO newHashedPassword = new PasswordDTO();

        byte[] SaltBytes = new byte[64];
        var provider = RandomNumberGenerator.Create();
        provider.GetNonZeroBytes(SaltBytes);

        var Salt = Convert.ToBase64String(SaltBytes);


        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA512);
        var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        newHashedPassword.Salt = Salt;
        newHashedPassword.Hash = Hash;
        return newHashedPassword;
    }

    public bool VerifyUserPassword(string? password, string? storedHash, string? storedSalt)
    {
        if (storedSalt == null)
        {
            return false;
        }
        var SaltBytes = Convert.FromBase64String(storedSalt);

        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA512);
        var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        return newHash == storedHash;
    }

    internal IEnumerable<UserModel> GetAllUsers()
    {
        return _context.UserInfo;
    }
    
   public IActionResult Login(LoginDTO User)
    {
        IActionResult result = Unauthorized();
        if (DoesUserExist(User.Username))
        {
           
           //create a secret key used to sign the jtw token
           //this should be stored securely (not hard coded in production)
           var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSuperSuperSuperDuperSecureKey@123"));
           var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
           
           var tokenOptions = new JwtSecurityToken(
               issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
           );

           //convert the token to a string and return it
              var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


             result = Ok(new { Token = tokenString });
        }
        //return either the token (if user exists) or an unauthorized message
        return result;
    }

    internal UserIdDTO GetUserIdDTOByUsername(string username)
    {
        throw new NotImplementedException();
    }
}







