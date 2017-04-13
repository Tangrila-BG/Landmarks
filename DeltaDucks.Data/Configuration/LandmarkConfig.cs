using System.Data.Entity.ModelConfiguration;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    public class LandmarkConfig : EntityTypeConfiguration<Landmark>
    {

        public LandmarkConfig()
        {
            ToTable("Landmarks");
            Property(l => l.Name).IsRequired().HasMaxLength(100);
            Property(l => l.Description).HasMaxLength(500);
            Property(l => l.Information).HasMaxLength(5000);

            this.HasMany(l => l.UsersVisited)
                .WithMany(u => u.VisitedLandmarks)
                .Map(conf =>
                {
                    conf.ToTable("UsersVisitedLandmarks");
                    conf.MapLeftKey("LandmarkId");
                    conf.MapRightKey("UserVisitedId");
                });
        }
    }
}
