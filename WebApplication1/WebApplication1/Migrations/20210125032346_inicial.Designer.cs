﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210125032346_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WebApplication1.Models.Gender", b =>
                {
                    b.Property<int>("idGender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idGender");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("WebApplication1.Models.ImagePost", b =>
                {
                    b.Property<int>("idImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("idImage");

                    b.ToTable("ImagePost");
                });

            modelBuilder.Entity("WebApplication1.Models.ListFriend", b =>
                {
                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<int>("idFriend")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("idUser", "idFriend");

                    b.ToTable("ListFriend");
                });

            modelBuilder.Entity("WebApplication1.Models.Notification", b =>
                {
                    b.Property<int>("idNotification")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("idPost")
                        .HasColumnType("int");

                    b.Property<int>("idType")
                        .HasColumnType("int");

                    b.Property<string>("idUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRead")
                        .HasColumnType("bit");

                    b.HasKey("idNotification");

                    b.HasIndex("idPost");

                    b.HasIndex("idType");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("WebApplication1.Models.Post", b =>
                {
                    b.Property<int>("idPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("idTypePost")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("idPost");

                    b.HasIndex("idTypePost");

                    b.HasIndex("idUser");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("WebApplication1.Models.TypeOfNotification", b =>
                {
                    b.Property<int>("idType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("message")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("idType");

                    b.ToTable("TypeOfNotifications");
                });

            modelBuilder.Entity("WebApplication1.Models.TypeOfPost", b =>
                {
                    b.Property<int>("idTypeOfPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("typePost")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTypeOfPost");

                    b.ToTable("TypeOfPost");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("idUSer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("birthday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("idGenter")
                        .HasColumnType("int");

                    b.Property<bool>("isVerificate")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("lastSession")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("idUSer");

                    b.HasIndex("idGenter");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Notification", b =>
                {
                    b.HasOne("WebApplication1.Models.Post", "post")
                        .WithMany()
                        .HasForeignKey("idPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.TypeOfNotification", "typeOfNotification")
                        .WithMany()
                        .HasForeignKey("idType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("typeOfNotification");
                });

            modelBuilder.Entity("WebApplication1.Models.Post", b =>
                {
                    b.HasOne("WebApplication1.Models.TypeOfPost", "typeOfPost")
                        .WithMany()
                        .HasForeignKey("idTypePost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeOfPost");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.HasOne("WebApplication1.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("idGenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gender");
                });
#pragma warning restore 612, 618
        }
    }
}
