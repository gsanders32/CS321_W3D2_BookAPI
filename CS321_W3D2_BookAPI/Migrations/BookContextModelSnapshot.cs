﻿// <auto-generated />
using System;
using CS321_W3D2_BookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS321_W3D2_BookAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("CS321_W3D2_BookAPI.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stephen",
                            LastName = "King"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1975, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hugh",
                            LastName = "Howey"
                        });
                });

            modelBuilder.Entity("CS321_W3D2_BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Title = "It"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Title = "The Outsider"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Title = "Wool"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Title = "Shift"
                        });
                });

            modelBuilder.Entity("CS321_W3D2_BookAPI.Models.Book", b =>
                {
                    b.HasOne("CS321_W3D2_BookAPI.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
