﻿// <auto-generated />
using System;
using INTUSManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INTUSManagement.API.Migrations
{
    [DbContext(typeof(INTUSManagementAPIContext))]
    [Migration("20231223202940_WindowsAndOrdersTable")]
    partial class WindowsAndOrdersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("INTUSManagement.Model.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElementId"), 1L, 1);

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("ElementId");

                    b.ToTable("Element");
                });

            modelBuilder.Entity("INTUSManagement.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("INTUSManagement.Model.SubElement", b =>
                {
                    b.Property<int>("SubElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubElementId"), 1L, 1);

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<int>("WindowId")
                        .HasColumnType("int");

                    b.HasKey("SubElementId");

                    b.HasIndex("WindowId");

                    b.ToTable("SubElements");
                });

            modelBuilder.Entity("INTUSManagement.Model.Window", b =>
                {
                    b.Property<int>("WindowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WindowId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfWindows")
                        .HasColumnType("int");

                    b.Property<int>("TotalSubElements")
                        .HasColumnType("int");

                    b.HasKey("WindowId");

                    b.HasIndex("OrderId1");

                    b.ToTable("Windows");
                });

            modelBuilder.Entity("INTUSManagement.Model.SubElement", b =>
                {
                    b.HasOne("INTUSManagement.Model.Window", null)
                        .WithMany("SubElements")
                        .HasForeignKey("WindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("INTUSManagement.Model.Window", b =>
                {
                    b.HasOne("INTUSManagement.Model.Order", null)
                        .WithMany("Windows")
                        .HasForeignKey("OrderId1");
                });

            modelBuilder.Entity("INTUSManagement.Model.Order", b =>
                {
                    b.Navigation("Windows");
                });

            modelBuilder.Entity("INTUSManagement.Model.Window", b =>
                {
                    b.Navigation("SubElements");
                });
#pragma warning restore 612, 618
        }
    }
}
