﻿// <auto-generated />
using System;
using HellowWorld.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HellowWorld.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210205150829_weapon")]
    partial class weapon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("HellowWorld.Models.Charecter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defence")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("charecters");
                });

            modelBuilder.Entity("HellowWorld.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HellowWorld.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CharecterId")
                        .HasColumnType("int");

                    b.Property<string>("Damage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharecterId")
                        .IsUnique();

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("HellowWorld.Models.Charecter", b =>
                {
                    b.HasOne("HellowWorld.Models.User", "Users")
                        .WithMany("charecters")
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HellowWorld.Models.Weapon", b =>
                {
                    b.HasOne("HellowWorld.Models.Charecter", "charecter")
                        .WithOne("Weapons")
                        .HasForeignKey("HellowWorld.Models.Weapon", "CharecterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("charecter");
                });

            modelBuilder.Entity("HellowWorld.Models.Charecter", b =>
                {
                    b.Navigation("Weapons");
                });

            modelBuilder.Entity("HellowWorld.Models.User", b =>
                {
                    b.Navigation("charecters");
                });
#pragma warning restore 612, 618
        }
    }
}
