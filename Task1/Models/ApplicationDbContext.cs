using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    internal class ApplicationDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ChildPerson> ChildPersons { get; set; }
        public DbSet<HealthInsuranceDocument> HealthInsuranceDocuments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost;Database=Task1;User Id=Leonard;Password=test123;");
;
    }
}
