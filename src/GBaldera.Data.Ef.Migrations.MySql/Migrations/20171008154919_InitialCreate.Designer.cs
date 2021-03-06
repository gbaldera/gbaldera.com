﻿// <auto-generated />
using GBaldera.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GBaldera.Data.Ef.Migrations.MySql.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20171008154919_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("GBaldera.Data.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("FileName")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
