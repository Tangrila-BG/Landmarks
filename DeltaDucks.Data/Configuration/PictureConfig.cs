using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    class PictureConfig : EntityTypeConfiguration<Picture>
    {
        public const int MegaBytePictureMaxLength = 2097152;

        public PictureConfig()
        {
            ToTable("Pictures");
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.ImageData).IsRequired().HasMaxLength(MegaBytePictureMaxLength);
        }
    }
}
