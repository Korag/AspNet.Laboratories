using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zajecia4.Models
{
    public class ConferenceContext : DbContext
    {
        public DbSet<ConferenceUser> ConferenceUsers { get; set; }

        public ConferenceContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Database = Conference; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
