using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    class TownConfig : EntityTypeConfiguration<Town>
    {
        public TownConfig()
        {
            ToTable("Towns");
            Property(t => t.Name).IsRequired().HasMaxLength(50);
        }
    }
}
