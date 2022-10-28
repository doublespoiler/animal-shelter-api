﻿// <auto-generated />
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace animalshelterapi.Migrations
{
    [DbContext(typeof(AnimalShelterContext))]
    [Migration("20221028214012_AddBranch")]
    partial class AddBranch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelterApi.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsFixed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 6,
                            BranchId = 1,
                            Breed = "pit bull mix",
                            Color = "White",
                            IsFixed = true,
                            Name = "Titan",
                            Sex = "male",
                            Species = "canine"
                        },
                        new
                        {
                            Id = 2,
                            Age = 3,
                            BranchId = 1,
                            Breed = "pit bull mix",
                            Color = "brown",
                            IsFixed = true,
                            Name = "Milo",
                            Sex = "male",
                            Species = "canine"
                        },
                        new
                        {
                            Id = 3,
                            Age = 4,
                            BranchId = 2,
                            Breed = "Shepherd Mix",
                            Color = "Black",
                            IsFixed = true,
                            Name = "Korra",
                            Sex = "female",
                            Species = "canine"
                        },
                        new
                        {
                            Id = 4,
                            Age = 1,
                            BranchId = 2,
                            Breed = "american shorthair",
                            Color = "black",
                            IsFixed = true,
                            Name = "Sid",
                            Sex = "male",
                            Species = "feline"
                        },
                        new
                        {
                            Id = 5,
                            Age = 1,
                            BranchId = 1,
                            Breed = "mixed",
                            Color = "tabby",
                            IsFixed = true,
                            Name = "Maeve",
                            Sex = "female",
                            Species = "feline"
                        });
                });

            modelBuilder.Entity("AnimalShelterApi.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1800 S. Milton Road, Flagstaff, AZ 86001",
                            Name = "Flagstaff Humane Society"
                        },
                        new
                        {
                            Id = 2,
                            Address = "2990 Andy Devine Ave, Kingman, AZ, 86401",
                            Name = "Kingman Human Society"
                        });
                });

            modelBuilder.Entity("AnimalShelterApi.Models.Animal", b =>
                {
                    b.HasOne("AnimalShelterApi.Models.Branch", "branch")
                        .WithMany("Animals")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");
                });

            modelBuilder.Entity("AnimalShelterApi.Models.Branch", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
