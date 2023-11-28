using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataBase;

public partial class CynologistPlusContext : DbContext
{
    public CynologistPlusContext()
    {
    }

    public CynologistPlusContext(DbContextOptions<CynologistPlusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<AuthCredential> AuthCredentials { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Cynologist> Cynologists { get; set; }

    public virtual DbSet<Dog> Dogs { get; set; }

    public virtual DbSet<DogSkill> DogSkills { get; set; }

    public virtual DbSet<DogSkillsLog> DogSkillsLogs { get; set; }

    public virtual DbSet<DogTrainingCenter> DogTrainingCenters { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.AuthCredential).WithMany(p => p.Admins)
                .HasForeignKey(d => d.AuthCredentialId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.City).HasMaxLength(150);
            entity.Property(e => e.Country).HasMaxLength(150);
            entity.Property(e => e.House).HasMaxLength(150);
            entity.Property(e => e.Street).HasMaxLength(150);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Adress)
                .HasForeignKey<Adress>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AuthCredential>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Login).HasMaxLength(64);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.AuthCredential).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AuthCredentialId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Cynologist>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.AuthCredential).WithMany(p => p.Cynologists)
                .HasForeignKey(d => d.AuthCredentialId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DogTrainingCenter).WithMany(p => p.Cynologists)
                .HasForeignKey(d => d.DogTrainingCenterId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Dog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Breed).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Client).WithMany(p => p.Dogs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<DogSkill>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Dog).WithMany(p => p.DogSkills)
                .HasForeignKey(d => d.DogId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Skill).WithMany(p => p.DogSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DogSkillsLog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ChangeDate).HasColumnType("datetime");

            entity.HasOne(d => d.Dog).WithMany(p => p.DogSkillsLogs)
                .HasForeignKey(d => d.DogId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Skill).WithMany(p => p.DogSkillsLogs)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DogTrainingCenter>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.AuthCredential).WithMany(p => p.Managers)
                .HasForeignKey(d => d.AuthCredentialId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DogTrainingCenter).WithMany(p => p.Managers)
                .HasForeignKey(d => d.DogTrainingCenterId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Dog).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DogId);

            entity.HasOne(d => d.DogTrainingCenter).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DogTrainingCenterId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Comment).HasMaxLength(200);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TrainingType).HasMaxLength(50);

            entity.HasOne(d => d.Cynologist).WithMany(p => p.Training)
                .HasForeignKey(d => d.CynologistId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Dog).WithMany(p => p.Training)
                .HasForeignKey(d => d.DogId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
