using System.Data.Entity.ModelConfiguration;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            ToTable("Comments");
            Property(c => c.Text).IsRequired().HasMaxLength(300);
        }
    }
}
