using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Domain.Entities;


namespace SocialMedia.Infrastructure.Context.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(777);

            builder.Property(p => p.CreatedAt)
                .HasColumnType("timestamp(3)")
                .HasDefaultValueSql("NOW()") 
                .IsRequired();


            builder.Property(p => p.RepostCount)
                .IsRequired();

            builder.Property(p => p.IsRepost)
                .IsRequired();

            builder.Property(p => p.OriginalPostId)
                .IsRequired(false);

            builder.Property(p => p.AuthorUserId)
               .IsRequired();         

            builder.HasOne(p => p.User)
                 .WithMany(u => u.Posts)
                 .HasForeignKey(p => p.AuthorUserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.OriginalPost)
                .WithMany()
                .HasForeignKey(p => p.OriginalPostId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
