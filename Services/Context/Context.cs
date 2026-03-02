using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace blogAPI.Services.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BlogItemModel> BlogItems { get; set; }
    }
}