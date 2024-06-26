﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arq_backend;

#nullable disable

namespace arq_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240606213651_RoleUpdate")]
    partial class RoleUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("arq_backend.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrator",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Teacher",
                            Name = "Teacher"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Student",
                            Name = "Student"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
