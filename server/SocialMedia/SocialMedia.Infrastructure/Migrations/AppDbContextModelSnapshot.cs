﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SocialMedia.Infrastructure.Context;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SocialMedia.Domain.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorNickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(777)
                        .HasColumnType("character varying(777)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRepost")
                        .HasColumnType("boolean");

                    b.Property<int?>("OriginalPostId")
                        .HasColumnType("integer");

                    b.Property<int>("RepostCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorNickname");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("OriginalPostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.RepostHistory", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RepostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("RepostHistories");
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice Johnson",
                            Nickname = "@AliceJohnson",
                            ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Alice"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob Smith",
                            Nickname = "@BobSmith",
                            ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Bob"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Charlie Brown",
                            Nickname = "@CharlieBrown",
                            ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Charlie"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Diana Prince",
                            Nickname = "@DianaPrince",
                            ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Diana"
                        });
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.UserDailyPostCount", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ReferenceDate")
                        .HasColumnType("date");

                    b.Property<int>("PostCount")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ReferenceDate");

                    b.ToTable("UserDailyPostCounts");
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.Post", b =>
                {
                    b.HasOne("SocialMedia.Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorNickname")
                        .HasPrincipalKey("Nickname")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Domain.Entity.Post", "OriginalPost")
                        .WithMany()
                        .HasForeignKey("OriginalPostId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("OriginalPost");
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.RepostHistory", b =>
                {
                    b.HasOne("SocialMedia.Domain.Entity.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialMedia.Domain.Entity.UserDailyPostCount", b =>
                {
                    b.HasOne("SocialMedia.Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
