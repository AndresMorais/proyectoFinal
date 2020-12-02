﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyecto_comunidad_it.Models;

namespace proyecto_comunidad_it.Migrations
{
    [DbContext(typeof(legislacionContext))]
    [Migration("20201202232855_LegislacionPropiedadEnlace")]
    partial class LegislacionPropiedadEnlace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("proyecto_comunidad_it.Models.Legislacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Enlace")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Objeto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Origen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("legislacion");
                });
#pragma warning restore 612, 618
        }
    }
}
