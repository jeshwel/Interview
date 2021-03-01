﻿// <auto-generated />
using System;
using FullStackDevExercise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStackDevExercise.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210225200529_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("FullStackDevExercise.Data.Entities.Owner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.HasKey("id");

                    b.ToTable("owners");
                });

            modelBuilder.Entity("FullStackDevExercise.Data.Entities.Pet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("owner_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("type")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("owner_id");

                    b.ToTable("pets");
                });

            modelBuilder.Entity("FullStackDevExercise.Data.Entities.Pet", b =>
                {
                    b.HasOne("FullStackDevExercise.Data.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("owner_id");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
