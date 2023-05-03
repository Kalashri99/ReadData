﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using datafromexceltryingon3tables;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230425062849_AllTablesAdded")]
    partial class AllTablesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("datafromexceltryingon3tables.Models.Aging", b =>
                {
                    b.Property<int>("AgingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgingId"));

                    b.Property<int?>("GrandTotal")
                        .HasColumnType("int");

                    b.Property<string>("NotDue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnappliedReceiptsReconcialiationPending")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_030Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_120180Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_180Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_3060Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_6090Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_90120Days")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgingId");

                    b.ToTable("Agings");
                });

            modelBuilder.Entity("datafromexceltryingon3tables.Models.ArPOC", b =>
                {
                    b.Property<int>("ArPOCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArPOCId"));

                    b.Property<string>("PocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArPOCId");

                    b.ToTable("ArPocs");
                });

            modelBuilder.Entity("datafromexceltryingon3tables.Models.MasterTable", b =>
                {
                    b.Property<int>("MasterTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterTableId"));

                    b.Property<int?>("AgingId")
                        .HasColumnType("int");

                    b.Property<int?>("ArPOCId")
                        .HasColumnType("int");

                    b.HasKey("MasterTableId");

                    b.HasIndex("AgingId");

                    b.HasIndex("ArPOCId");

                    b.ToTable("MasterTables");
                });

            modelBuilder.Entity("datafromexceltryingon3tables.Models.MasterTable", b =>
                {
                    b.HasOne("datafromexceltryingon3tables.Models.Aging", "aging")
                        .WithMany("MasterTables")
                        .HasForeignKey("AgingId");

                    b.HasOne("datafromexceltryingon3tables.Models.ArPOC", "ArPoc")
                        .WithMany("MasterTables")
                        .HasForeignKey("ArPOCId");

                    b.Navigation("ArPoc");

                    b.Navigation("aging");
                });

            modelBuilder.Entity("datafromexceltryingon3tables.Models.Aging", b =>
                {
                    b.Navigation("MasterTables");
                });

            modelBuilder.Entity("datafromexceltryingon3tables.Models.ArPOC", b =>
                {
                    b.Navigation("MasterTables");
                });
#pragma warning restore 612, 618
        }
    }
}
