﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OneValet.DeviceGallery.Infrastructure.Contexts;

#nullable disable

namespace OneValet.DeviceGallery.Infrastructure.Migrations
{
    [DbContext(typeof(DeviceDbContext))]
    partial class DeviceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OneValet.DeviceGallery.Domain.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("IconBase64String")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Devices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeviceTypeId = 1,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = true,
                            Name = "Nokia 7 Plus",
                            TemperatureC = 49.0
                        },
                        new
                        {
                            Id = 2,
                            DeviceTypeId = 2,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "iPad 11",
                            TemperatureC = 67.0
                        },
                        new
                        {
                            Id = 3,
                            DeviceTypeId = 3,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "HP Elitebook",
                            TemperatureC = 72.0
                        },
                        new
                        {
                            Id = 4,
                            DeviceTypeId = 2,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "Samsung Tablet",
                            TemperatureC = 31.0
                        },
                        new
                        {
                            Id = 5,
                            DeviceTypeId = 3,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "DELL 205",
                            TemperatureC = 55.0
                        },
                        new
                        {
                            Id = 6,
                            DeviceTypeId = 1,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "Tecno Spark 6",
                            TemperatureC = 84.0
                        },
                        new
                        {
                            Id = 7,
                            DeviceTypeId = 1,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = true,
                            Name = "iPhone 13 Pro Max",
                            TemperatureC = 50.0
                        },
                        new
                        {
                            Id = 8,
                            DeviceTypeId = 1,
                            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                            IsOnline = false,
                            Name = "Nokia 3310",
                            TemperatureC = 37.0
                        });
                });

            modelBuilder.Entity("OneValet.DeviceGallery.Domain.Entities.DeviceType", b =>
                {
                    b.Property<int>("DeviceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceTypeId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceTypes", (string)null);

                    b.HasData(
                        new
                        {
                            DeviceTypeId = 1,
                            Description = "A pocket-sized device",
                            Name = "Phone"
                        },
                        new
                        {
                            DeviceTypeId = 2,
                            Description = "A palm-sized device",
                            Name = "Tablet"
                        },
                        new
                        {
                            DeviceTypeId = 3,
                            Description = "A personal computer",
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("OneValet.DeviceGallery.Domain.Entities.DeviceUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("Id");

                    b.ToTable("DeviceUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "onevalet@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "One",
                            LastName = "Valet",
                            Password = "sapass123$",
                            UserName = "onevalet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
