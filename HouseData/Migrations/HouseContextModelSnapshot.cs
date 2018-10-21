﻿// <auto-generated />
using System;
using HouseData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseData.Migrations
{
    [DbContext(typeof(HouseContext))]
    partial class HouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("HouseData.Models.Counter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FactoryNumber");

                    b.Property<DateTime>("VerificationTimeOver");

                    b.HasKey("Id");

                    b.ToTable("Counters");
                });

            modelBuilder.Entity("HouseData.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int?>("CounterId");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CounterId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HouseData.Models.Indication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CounterId");

                    b.Property<int>("CurrentIndication");

                    b.Property<DateTime>("FillingTime");

                    b.Property<int>("PreviousIndication");

                    b.HasKey("Id");

                    b.HasIndex("CounterId");

                    b.ToTable("Indications");
                });

            modelBuilder.Entity("HouseData.Models.House", b =>
                {
                    b.HasOne("HouseData.Models.Counter", "Counter")
                        .WithMany()
                        .HasForeignKey("CounterId");
                });

            modelBuilder.Entity("HouseData.Models.Indication", b =>
                {
                    b.HasOne("HouseData.Models.Counter")
                        .WithMany("Indications")
                        .HasForeignKey("CounterId");
                });
#pragma warning restore 612, 618
        }
    }
}
