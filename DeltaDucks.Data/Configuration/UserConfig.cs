using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{

    using System.Data.Entity.ModelConfiguration;

    public class UserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfig()
        {
            // TODO:  to table ? 
            Property(u => u.UserName).IsRequired().HasMaxLength(20);
        }
    }
}
