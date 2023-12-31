﻿// <auto-generated />
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
    [Migration("20231223121832_ElementTable1")]
    partial class ElementTable1
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
#pragma warning restore 612, 618
        }
    }
}
