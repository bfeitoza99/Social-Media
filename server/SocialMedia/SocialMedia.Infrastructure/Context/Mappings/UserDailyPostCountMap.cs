using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;


namespace SocialMedia.Infrastructure.Context.Mappings
{
    public class UserDailyPostCountMap : IEntityTypeConfiguration<UserDailyPostCount>
    {
        public void Configure(EntityTypeBuilder<UserDailyPostCount> builder)
        {            

            builder.Property(u => u.PostCount)
                .IsRequired();

            builder.Property(u => u.ReferenceDate)
                .IsRequired();

            builder.Property(p => p.UserId)
               .IsRequired();      

            builder.HasKey(p => new { p.UserId, p.ReferenceDate });
        }
    }

}