using Microsoft.EntityFrameworkCore;

namespace AlaInstagram.Models
{
    public class InstagramContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PhotoDetail> PhotoDetails { get; set; }
        public DbSet<PostTagTechnical> PostTagTechnical { get; set; }

        public InstagramContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Database = Instagram; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTagTechnical>().HasKey(x => new { x.PostId, x.TagName });
        }
    }
}
