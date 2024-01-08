﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODO;

#nullable disable

namespace todoMan.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20231227040157_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("TODO.DataItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompletionTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
