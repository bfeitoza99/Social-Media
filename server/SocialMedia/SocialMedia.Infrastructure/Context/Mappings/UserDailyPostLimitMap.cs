using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Context.Mappings
{
    public class UserDailyPostLimitMap : IEntityTypeConfiguration<UserDailyPostLimit>
    {
        public void Configure(EntityTypeBuilder<UserDailyPostLimit> builder)
        {            

            builder.Property(u => u.PostCount)
                .IsRequired();

            builder.Property(u => u.ReferenceDate)
                .IsRequired();

            builder.Property(p => p.UserId)
               .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(p => new { p.UserId, p.ReferenceDate });
        }
    }

}