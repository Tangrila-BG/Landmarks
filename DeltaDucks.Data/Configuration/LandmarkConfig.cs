using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            Property(l => l.Points).IsRequired();
            Property(l => l.Code).IsRequired().IsFixedLength().HasMaxLength(5);
            Property(l => l.Description).HasMaxLength(500);
            Property(l => l.Information).HasMaxLength(5000);
            HasRequired(x => x.Location);
            HasMany(x => x.Comments)
                .WithRequired(x => x.Landmark)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Pictures)
                .WithRequired(x => x.Landmark)
                .WillCascadeOnDelete(true);

            Property(t => t.Number).HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Number") { IsUnique = true }));

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
