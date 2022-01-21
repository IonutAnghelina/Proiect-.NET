﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_DAW.Entities;

namespace Proiect_DAW.Migrations
{
    [DbContext(typeof(ProiectContext))]
    [Migration("20220117112100_addedOneToMany")]
    partial class addedOneToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proiect_DAW.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("ShopId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Manager", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Shop", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NoEmployees")
                        .HasColumnType("int");

                    b.Property<string>("OpenningDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Employee", b =>
                {
                    b.HasOne("Proiect_DAW.Entities.Shop", "Shop")
                        .WithMany("Employees")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Shop", b =>
                {
                    b.HasOne("Proiect_DAW.Entities.Manager", "Manager")
                        .WithOne("Shop")
                        .HasForeignKey("Proiect_DAW.Entities.Shop", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Manager", b =>
                {
                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Proiect_DAW.Entities.Shop", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
