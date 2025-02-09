using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Infrastructure.Context.Mappings
{
    public class RepostHistoryMap : IEntityTypeConfiguration<RepostHistory>
    {
        public void Configure(EntityTypeBuilder<RepostHistory> builder)
        {

            builder.HasKey(p => new { p.UserId, p.PostId });

            builder.Property(p => p.RepostDate)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.PostId)
                .IsRequired();
           
            builder.HasOne<User>()
                .WithMany()  
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
           
            builder.HasOne<Post>()
                .WithMany()  
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
