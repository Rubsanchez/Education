﻿// <auto-generated />
using System;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Education.Persistence.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    partial class EducationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Education.Domain.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("baf3797d-f077-4fb8-a61c-9944d445d21a"),
                            CreationDate = new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1890),
                            Description = "C# basic course",
                            Price = 56m,
                            PublishDate = new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1938),
                            Title = "From noob to pro C#"
                        },
                        new
                        {
                            CourseId = new Guid("4e85f75d-b3aa-43a2-a223-c1b3191996a9"),
                            CreationDate = new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1948),
                            Description = "Java course",
                            Price = 25m,
                            PublishDate = new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1951),
                            Title = "Java Spring Master"
                        },
                        new
                        {
                            CourseId = new Guid("6131a1ba-7f23-430d-88e3-f89a82df7357"),
                            CreationDate = new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1970),
                            Description = ".NET Core Unit test course",
                            Price = 1000m,
                            PublishDate = new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1973),
                            Title = ".NET Core Master Unit Test"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
