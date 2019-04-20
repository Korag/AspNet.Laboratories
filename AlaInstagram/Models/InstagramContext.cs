﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.Models
{
    public class InstagramContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagTechnical> PostTag { get; set; }

        public InstagramContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Database = Instagram; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}