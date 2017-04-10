using DeltaDucks.Data.Configuration;
using DeltaDucks.Models;

namespace DeltaDucks.Data
{
    using System.Data.Entity;

    public class DeltaDucksContext : DbContext
    {
        public DeltaDucksContext()
            : base("name=DeltaDucksContext")
        {
            Database.SetInitializer(new SeedData());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Landmark> Landmarks { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Location> Locations { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new LandmarkConfig());
        }

    }
}