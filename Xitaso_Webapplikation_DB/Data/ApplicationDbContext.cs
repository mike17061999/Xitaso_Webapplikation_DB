using Xitaso_Webapplikation_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Xitaso_Webapplikation_DB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Projekt> Projekte { get; set; }
        public DbSet<Analyse> Analysen { get; set; }
        public DbSet<Analysekategorie> Analysekategorien { get; set; }
        public DbSet<Frage> Fragen { get; set; }

    }
}
