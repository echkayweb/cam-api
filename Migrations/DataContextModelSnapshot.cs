﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cam_api.Data;

#nullable disable

namespace cam_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("cam_api.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<int?>("AssetAssignedTo")
                        .HasColumnType("int");

                    b.Property<bool>("AssetAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("AssetModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AssetSerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AssetId");

                    b.HasIndex("AssetAssignedTo");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("cam_api.Models.AssignedAsset", b =>
                {
                    b.Property<int>("AssignedAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignedAssetId"), 1L, 1);

                    b.Property<int?>("AssetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("DateReturned")
                        .HasColumnType("Date");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssignedAssetId");

                    b.HasIndex("AssetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AssignedAssets");
                });

            modelBuilder.Entity("cam_api.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DOJ")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("EOJ")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("cam_api.Models.Asset", b =>
                {
                    b.HasOne("cam_api.Models.Employee", "Employee")
                        .WithMany("Assets")
                        .HasForeignKey("AssetAssignedTo");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("cam_api.Models.AssignedAsset", b =>
                {
                    b.HasOne("cam_api.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId");

                    b.HasOne("cam_api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Asset");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("cam_api.Models.Employee", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
