using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Models
{
    public class UserContext ///: DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public UserContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server database
        //    options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));
        //}

        //public DbSet<Entities.User> Users { get; set; }
    }
}
