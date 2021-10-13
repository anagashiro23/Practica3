using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Play.Data
{
    public class AppDbContext : DbContext

    {


        public DbSet<Nintendo> Nintendo { get; set; } //Llama al modelo (Person) 


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {



        }

    }
}
