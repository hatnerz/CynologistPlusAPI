﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.DataBase;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(CynologistPlusContext))]
    [Migration("20231123002657_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthCredentialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthCredentialId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("WebAPI.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Country")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("House")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Street")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("WebAPI.Models.AuthCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("AuthCredentials");
                });

            modelBuilder.Entity("WebAPI.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthCredentialId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AuthCredentialId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebAPI.Models.Cynologist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthCredentialId")
                        .HasColumnType("int");

                    b.Property<int?>("DogTrainingCenterId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AuthCredentialId");

                    b.HasIndex("DogTrainingCenterId");

                    b.ToTable("Cynologists");
                });

            modelBuilder.Entity("WebAPI.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Breed")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("WebAPI.Models.DogSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.HasIndex("SkillId");

                    b.ToTable("DogSkills");
                });

            modelBuilder.Entity("WebAPI.Models.DogSkillsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("datetime");

                    b.Property<double?>("CurrentValue")
                        .HasColumnType("float");

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.Property<double?>("PreviousValue")
                        .HasColumnType("float");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.HasIndex("SkillId");

                    b.ToTable("DogSkillsLogs");
                });

            modelBuilder.Entity("WebAPI.Models.DogTrainingCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("DogTrainingCenters");
                });

            modelBuilder.Entity("WebAPI.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthCredentialId")
                        .HasColumnType("int");

                    b.Property<int?>("DogTrainingCenterId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthCredentialId");

                    b.HasIndex("DogTrainingCenterId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("WebAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DogId")
                        .HasColumnType("int");

                    b.Property<int?>("DogTrainingCenterId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DogId");

                    b.HasIndex("DogTrainingCenterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebAPI.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("MaxValue")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Type")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("WebAPI.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("CynologistId")
                        .HasColumnType("int");

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TrainingType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CynologistId");

                    b.HasIndex("DogId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("WebAPI.Models.Admin", b =>
                {
                    b.HasOne("WebAPI.Models.AuthCredential", "AuthCredential")
                        .WithMany("Admins")
                        .HasForeignKey("AuthCredentialId")
                        .IsRequired();

                    b.Navigation("AuthCredential");
                });

            modelBuilder.Entity("WebAPI.Models.Adress", b =>
                {
                    b.HasOne("WebAPI.Models.DogTrainingCenter", "IdNavigation")
                        .WithOne("Adress")
                        .HasForeignKey("WebAPI.Models.Adress", "Id")
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebAPI.Models.Client", b =>
                {
                    b.HasOne("WebAPI.Models.AuthCredential", "AuthCredential")
                        .WithMany("Clients")
                        .HasForeignKey("AuthCredentialId")
                        .IsRequired();

                    b.Navigation("AuthCredential");
                });

            modelBuilder.Entity("WebAPI.Models.Cynologist", b =>
                {
                    b.HasOne("WebAPI.Models.AuthCredential", "AuthCredential")
                        .WithMany("Cynologists")
                        .HasForeignKey("AuthCredentialId")
                        .IsRequired();

                    b.HasOne("WebAPI.Models.DogTrainingCenter", "DogTrainingCenter")
                        .WithMany("Cynologists")
                        .HasForeignKey("DogTrainingCenterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AuthCredential");

                    b.Navigation("DogTrainingCenter");
                });

            modelBuilder.Entity("WebAPI.Models.DogSkill", b =>
                {
                    b.HasOne("WebAPI.Models.Dog", "Dog")
                        .WithMany("DogSkills")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.Skill", "Skill")
                        .WithMany("DogSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Dog");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebAPI.Models.DogSkillsLog", b =>
                {
                    b.HasOne("WebAPI.Models.Dog", "Dog")
                        .WithMany("DogSkillsLogs")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.Skill", "Skill")
                        .WithMany("DogSkillsLogs")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Dog");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebAPI.Models.Manager", b =>
                {
                    b.HasOne("WebAPI.Models.AuthCredential", "AuthCredential")
                        .WithMany("Managers")
                        .HasForeignKey("AuthCredentialId")
                        .IsRequired();

                    b.HasOne("WebAPI.Models.DogTrainingCenter", "DogTrainingCenter")
                        .WithMany("Managers")
                        .HasForeignKey("DogTrainingCenterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AuthCredential");

                    b.Navigation("DogTrainingCenter");
                });

            modelBuilder.Entity("WebAPI.Models.Order", b =>
                {
                    b.HasOne("WebAPI.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebAPI.Models.Dog", "Dog")
                        .WithMany("Orders")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.DogTrainingCenter", "DogTrainingCenter")
                        .WithMany("Orders")
                        .HasForeignKey("DogTrainingCenterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Client");

                    b.Navigation("Dog");

                    b.Navigation("DogTrainingCenter");
                });

            modelBuilder.Entity("WebAPI.Models.Training", b =>
                {
                    b.HasOne("WebAPI.Models.Cynologist", "Cynologist")
                        .WithMany("Training")
                        .HasForeignKey("CynologistId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebAPI.Models.Dog", "Dog")
                        .WithMany("Training")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Cynologist");

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("WebAPI.Models.AuthCredential", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Clients");

                    b.Navigation("Cynologists");

                    b.Navigation("Managers");
                });

            modelBuilder.Entity("WebAPI.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebAPI.Models.Cynologist", b =>
                {
                    b.Navigation("Training");
                });

            modelBuilder.Entity("WebAPI.Models.Dog", b =>
                {
                    b.Navigation("DogSkills");

                    b.Navigation("DogSkillsLogs");

                    b.Navigation("Orders");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("WebAPI.Models.DogTrainingCenter", b =>
                {
                    b.Navigation("Adress");

                    b.Navigation("Cynologists");

                    b.Navigation("Managers");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebAPI.Models.Skill", b =>
                {
                    b.Navigation("DogSkills");

                    b.Navigation("DogSkillsLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
