﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210702184651_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("API.Entities.ColPhoto", b =>
                {
                    b.Property<int>("ColPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdminUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ColUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HsStudentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainCol")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainHs")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColPhotoId");

                    b.HasIndex("ColUserId");

                    b.ToTable("ColPhotos");
                });

            modelBuilder.Entity("API.Entities.ColUser", b =>
                {
                    b.Property<int>("ColUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ColUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColUserId");

                    b.ToTable("ColUsers");
                });

            modelBuilder.Entity("API.Entities.CollegeMajor", b =>
                {
                    b.Property<int>("CollegeNum")
                        .HasColumnType("int");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.HasKey("CollegeNum", "MajorId");

                    b.HasIndex("MajorId");

                    b.ToTable("CollegeMajors");
                });

            modelBuilder.Entity("API.Entities.FactFeature", b =>
                {
                    b.Property<int>("FactId")
                        .HasColumnType("int");

                    b.Property<int>("CollegeNum")
                        .HasColumnType("int");

                    b.Property<string>("FactBullet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FactId");

                    b.HasIndex("CollegeNum");

                    b.ToTable("FactFeatures");
                });

            modelBuilder.Entity("API.Entities.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<int>("MajorCatId")
                        .HasColumnType("int");

                    b.Property<string>("MajorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MajorId");

                    b.HasIndex("MajorCatId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("API.Entities.MajorCat", b =>
                {
                    b.Property<int>("MajorCatId")
                        .HasColumnType("int");

                    b.Property<string>("MajorCatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MajorCatId");

                    b.ToTable("MajorCats");
                });

            modelBuilder.Entity("API.Entities.ColPhoto", b =>
                {
                    b.HasOne("API.Entities.ColUser", "ColUser")
                        .WithMany("ColPhotos")
                        .HasForeignKey("ColUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColUser");
                });

            modelBuilder.Entity("API.Entities.CollegeMajor", b =>
                {
                    b.HasOne("API.Entities.ColUser", "ColUser")
                        .WithMany("CollegeMajors")
                        .HasForeignKey("CollegeNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Major", "Major")
                        .WithMany("CollegeMajors")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColUser");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("API.Entities.FactFeature", b =>
                {
                    b.HasOne("API.Entities.ColUser", "ColUser")
                        .WithMany("FactFeatures")
                        .HasForeignKey("CollegeNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColUser");
                });

            modelBuilder.Entity("API.Entities.Major", b =>
                {
                    b.HasOne("API.Entities.MajorCat", "MajorCat")
                        .WithMany("Majors")
                        .HasForeignKey("MajorCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MajorCat");
                });

            modelBuilder.Entity("API.Entities.ColUser", b =>
                {
                    b.Navigation("CollegeMajors");

                    b.Navigation("ColPhotos");

                    b.Navigation("FactFeatures");
                });

            modelBuilder.Entity("API.Entities.Major", b =>
                {
                    b.Navigation("CollegeMajors");
                });

            modelBuilder.Entity("API.Entities.MajorCat", b =>
                {
                    b.Navigation("Majors");
                });
#pragma warning restore 612, 618
        }
    }
}
