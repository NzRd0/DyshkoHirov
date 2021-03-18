﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prodject_ПРІС.Data;

namespace Prodject_ПРІС.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210318075742_test_sql")]
    partial class test_sql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prodject_ПРІС.Data.ClassRoom", b =>
                {
                    b.Property<int>("idCr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCr")
                        .HasColumnType("datetime2");

                    b.Property<string>("nameCr")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("idCr");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Prodject_ПРІС.Data.Student", b =>
                {
                    b.Property<int>("idst")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdCr")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthadateSt")
                        .HasColumnType("datetime2");

                    b.Property<string>("nameSt")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("idst");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
