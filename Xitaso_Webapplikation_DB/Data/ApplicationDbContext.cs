using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xitaso_Webapplikation.Models;

namespace Xitaso_Webapplikation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet <Projekt> Projekte { get; set; }

        public DbSet<Analyse> Analysen { get; set; }

        
    }
}
