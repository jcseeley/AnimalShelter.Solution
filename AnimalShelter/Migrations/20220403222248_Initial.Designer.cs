﻿// <auto-generated />
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter.Migrations
{
    [DbContext(typeof(AnimalShelterContext))]
    [Migration("20220403222248_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Age = 1,
                            Gender = "Male",
                            Name = "Mathias McDog",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 2,
                            Age = 2,
                            Gender = "Female",
                            Name = "Sally Sandwichstealer",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 3,
                            Age = 2,
                            Gender = "Male",
                            Name = "Peter Poopeater",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 4,
                            Age = 3,
                            Gender = "Female",
                            Name = "Samantha Sniffsalot",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 5,
                            Age = 1,
                            Gender = "Female",
                            Name = "Catrina McMeow",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 6,
                            Age = 2,
                            Gender = "Male",
                            Name = "Henry Hiss",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 7,
                            Age = 2,
                            Gender = "Female",
                            Name = "Pamela Pushitoff",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 8,
                            Age = 3,
                            Gender = "Male",
                            Name = "Benjamin Bartholomeow",
                            Type = "Cat"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
