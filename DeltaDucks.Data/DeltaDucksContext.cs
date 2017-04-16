using DeltaDucks.Data.Configuration;
using DeltaDucks.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeltaDucks.Data
{
    using System.Data.Entity;

    public class DeltaDucksContext : IdentityDbContext<ApplicationUser>
    {
        public DeltaDucksContext()
            : base("name=DeltaDucksContext")
        {
            //Database.SetInitializer(new SeedData());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DeltaDucksContext,Migrations.Configuration>());
        }

        public virtual DbSet<Landmark> Landmarks { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public static DeltaDucksContext Create()
        {
            return new DeltaDucksContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new LandmarkConfig());
            modelBuilder.Configurations.Add(new PictureConfig());
            modelBuilder.Configurations.Add(new TownConfig());
            modelBuilder.Configurations.Add(new CommentConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}