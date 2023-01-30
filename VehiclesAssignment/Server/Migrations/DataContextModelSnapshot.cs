﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehiclesAssignment.Server.Data;

#nullable disable

namespace VehiclesAssignment.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehiclesAssignment.Shared.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abreviation = "ALFA",
                            Name = "Alfa Romeo"
                        },
                        new
                        {
                            Id = 2,
                            Abreviation = "CHEV",
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 3,
                            Abreviation = "HYUN",
                            Name = "Hyundai"
                        });
                });

            modelBuilder.Entity("VehiclesAssignment.Shared.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeID");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abreviation = "ALFA",
                            MakeID = 1,
                            Name = "031 Spider Roadsters"
                        },
                        new
                        {
                            Id = 2,
                            Abreviation = "CHEV",
                            MakeID = 2,
                            Name = "002 Impala/Caprice Belair"
                        },
                        new
                        {
                            Id = 3,
                            Abreviation = "HYUN",
                            MakeID = 3,
                            Name = "036 Accent GT"
                        });
                });

            modelBuilder.Entity("VehiclesAssignment.Shared.VehicleModel", b =>
                {
                    b.HasOne("VehiclesAssignment.Shared.VehicleMake", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("VehiclesAssignment.Shared.VehicleMake", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
