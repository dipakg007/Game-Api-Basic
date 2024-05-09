﻿// <auto-generated />
using System;
using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20240509042104_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("GameStore.Api.Entities.Genre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Fighting"
                        },
                        new
                        {
                            id = 2,
                            name = "Roleplaying"
                        },
                        new
                        {
                            id = 3,
                            name = "Sports"
                        },
                        new
                        {
                            id = 4,
                            name = "Racing"
                        },
                        new
                        {
                            id = 5,
                            name = "Kids and Family"
                        });
                });

            modelBuilder.Entity("GameStore.Api.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("genreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("releaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("genreId");

                    b.ToTable("games");
                });

            modelBuilder.Entity("GameStore.Api.Game", b =>
                {
                    b.HasOne("GameStore.Api.Entities.Genre", "genre")
                        .WithMany()
                        .HasForeignKey("genreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genre");
                });
#pragma warning restore 612, 618
        }
    }
}
