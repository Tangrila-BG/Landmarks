using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    using System.Data.Entity.ModelConfiguration;


    public class UserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public const int MegaBytePictureMaxLength = 2097152;

        public UserConfig()
        {
            ToTable("Users");
            Property(u => u.UserName).IsRequired().HasMaxLength(20);
            Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            Property(u => u.LastName).IsRequired().HasMaxLength(50);
            Property(u => u.Email).IsRequired();
            Property(u => u.UserPhoto).HasMaxLength(MegaBytePictureMaxLength);

            this.HasMany(u => u.Comments)
                .WithRequired(c => c.Author)
                .WillCascadeOnDelete(true);

            this.HasMany(u => u.Notifications)
                .WithRequired(n => n.User)
                .HasForeignKey(un => un.UserId);
        }
    }
}
