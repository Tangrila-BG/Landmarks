﻿using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{

    using System.Data.Entity.ModelConfiguration;

    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("Users");
            Property(u => u.Name).IsRequired().HasMaxLength(20);
        }
    }
}
