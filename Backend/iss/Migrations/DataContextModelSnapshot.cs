﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iss.Data;

namespace iss.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookModelUserModel", b =>
                {
                    b.Property<int>("BookBorrowedByUsersUserId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowedBooksBookId")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowedByUsersUserId", "BorrowedBooksBookId");

                    b.HasIndex("BorrowedBooksBookId");

                    b.ToTable("BookModelUserModel");
                });

            modelBuilder.Entity("iss.Models.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookCode")
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvaible")
                        .HasColumnType("bit");

                    b.Property<int?>("LibraryModelLibraryId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("LibraryModelLibraryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("iss.Models.LibraryModel", b =>
                {
                    b.Property<int>("LibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReturnPoint")
                        .HasColumnType("bit");

                    b.HasKey("LibraryId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("iss.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("BookModelUserModel", b =>
                {
                    b.HasOne("iss.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("BookBorrowedByUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iss.Models.BookModel", null)
                        .WithMany()
                        .HasForeignKey("BorrowedBooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("iss.Models.BookModel", b =>
                {
                    b.HasOne("iss.Models.LibraryModel", null)
                        .WithMany("AvailableBooks")
                        .HasForeignKey("LibraryModelLibraryId");
                });

            modelBuilder.Entity("iss.Models.LibraryModel", b =>
                {
                    b.Navigation("AvailableBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
