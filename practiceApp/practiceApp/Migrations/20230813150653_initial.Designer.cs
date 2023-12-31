﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using practiceApp.Data;

#nullable disable

namespace practiceApp.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230813150653_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("practiceApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("mfgDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
