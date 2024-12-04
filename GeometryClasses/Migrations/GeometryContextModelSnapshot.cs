﻿// <auto-generated />
using System;
using GeometryClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeometryClasses.Migrations
{
    [DbContext(typeof(GeometryContext))]
    partial class GeometryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeometryClasses.GeometryClasses.Square", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Edge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("figureColour")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Squares");
                });

            modelBuilder.Entity("GeometryClasses.Point", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("PolygonID")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PolygonID");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("GeometryClasses.Polygon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("figureColour")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Polygons");
                });

            modelBuilder.Entity("GeometryClasses.Rectangle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int?>("figureColour")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rectangles");
                });

            modelBuilder.Entity("GeometryClasses.Point", b =>
                {
                    b.HasOne("GeometryClasses.Polygon", null)
                        .WithMany("Points")
                        .HasForeignKey("PolygonID");
                });

            modelBuilder.Entity("GeometryClasses.Polygon", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
