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

            builder.Property(p => p.AuthorNickname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.RepostCount)
                .IsRequired();

            builder.Property(p => p.IsRepost)
                .IsRequired();

            builder.Property(p => p.OriginalPostId)
                .IsRequired(false);

            builder.Property(p => p.AuthorUserId)
               .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.AuthorUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.AuthorNickname)
                .HasPrincipalKey(u => u.Nickname) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.OriginalPost)
                .WithMany()
                .HasForeignKey(p => p.OriginalPostId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
