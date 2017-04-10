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
        }
    }
}
