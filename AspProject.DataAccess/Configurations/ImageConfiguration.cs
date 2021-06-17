using AspProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired();
            builder.HasMany(x => x.Posts).WithOne(x => x.Image).HasForeignKey(x => x.ImageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
