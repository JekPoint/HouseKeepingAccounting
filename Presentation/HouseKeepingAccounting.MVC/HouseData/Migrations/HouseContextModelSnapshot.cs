﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HouseKeepingAccounting.MVC.HouseData.Migrations
{
    [DbContext(typeof(HouseContext))]
    partial class HouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("HouseKeepingAccounting.HouseData.Models.Counter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FactoryNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VerificationTimeOver")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Counters");
                });

            modelBuilder.Entity("HouseKeepingAccounting.HouseData.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CounterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CounterId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HouseKeepingAccounting.HouseData.Models.Indication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CounterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentIndication")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FillingTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PreviousIndication")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CounterId");

                    b.ToTable("Indications");
                });

            modelBuilder.Entity("HouseKeepingAccounting.HouseData.Models.House", b =>
                {
                    b.HasOne("HouseKeepingAccounting.HouseData.Models.Counter", "Counter")
                        .WithMany()
                        .HasForeignKey("CounterId");
                });

            modelBuilder.Entity("HouseKeepingAccounting.HouseData.Models.Indication", b =>
                {
                    b.HasOne("HouseKeepingAccounting.HouseData.Models.Counter", null)
                        .WithMany("Indications")
                        .HasForeignKey("CounterId");
                });
#pragma warning restore 612, 618
        }
    }
}
