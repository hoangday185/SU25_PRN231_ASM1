using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace QuitSmoking.Repositories.HoangNV.Models;

public partial class Su25Prn231Se1723G5Context : DbContext
{
    public Su25Prn231Se1723G5Context()
    {
    }

    public Su25Prn231Se1723G5Context(DbContextOptions<Su25Prn231Se1723G5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CreatePlanQuitSmokingHoangNv> CreatePlanQuitSmokingHoangNvs { get; set; }

    public virtual DbSet<PlanQuitMethodHoangNv> PlanQuitMethodHoangNvs { get; set; }

    public virtual DbSet<QuitMethodHoangNv> QuitMethodHoangNvs { get; set; }

    public virtual DbSet<RecordProcessHoangNv> RecordProcessHoangNvs { get; set; }

    public virtual DbSet<UserAccountHoangNv> UserAccountHoangNvs { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnection"];
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreatePlanQuitSmokingHoangNv>(entity =>
        {
            entity.HasKey(e => e.CreatePlanQuitSmokingHoangNvid).HasName("PK__CreatePl__A14E2B74E29D5897");

            entity.ToTable("CreatePlanQuitSmokingHoangNV");

            entity.Property(e => e.CreatePlanQuitSmokingHoangNvid).HasColumnName("CreatePlanQuitSmokingHoangNVID");
            entity.Property(e => e.CreationDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MotivationReason).HasColumnType("text");
            entity.Property(e => e.PlanTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SelectedApproach)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserAccountHoangNvid).HasColumnName("UserAccountHoangNVID");

            entity.HasOne(d => d.UserAccountHoangNv).WithMany(p => p.CreatePlanQuitSmokingHoangNvs)
                .HasForeignKey(d => d.UserAccountHoangNvid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreatePlanQuitSmokingHoangNV_UserAccountHoangNV");
        });

        modelBuilder.Entity<PlanQuitMethodHoangNv>(entity =>
        {
            entity.HasKey(e => e.PlanQuitMethodHoangNvid).HasName("PK__PlanQuit__6077F8A22D31134F");

            entity.ToTable("PlanQuitMethodHoangNV");

            entity.Property(e => e.PlanQuitMethodHoangNvid).HasColumnName("PlanQuitMethodHoangNVID");
            entity.Property(e => e.CreatePlanQuitSmokingHoangNvid).HasColumnName("CreatePlanQuitSmokingHoangNVID");
            entity.Property(e => e.CreationDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QuitMethodHoangNvid).HasColumnName("QuitMethodHoangNVID");
            entity.Property(e => e.UserNotes).HasColumnType("text");

            entity.HasOne(d => d.CreatePlanQuitSmokingHoangNv).WithMany(p => p.PlanQuitMethodHoangNvs)
                .HasForeignKey(d => d.CreatePlanQuitSmokingHoangNvid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanQuitMethodHoangNV_CreatePlanQuitSmokingHoangNV");

            entity.HasOne(d => d.QuitMethodHoangNv).WithMany(p => p.PlanQuitMethodHoangNvs)
                .HasForeignKey(d => d.QuitMethodHoangNvid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanQuitMethodHoangNV_QuitMethodHoangNV");
        });

        modelBuilder.Entity<QuitMethodHoangNv>(entity =>
        {
            entity.HasKey(e => e.QuitMethodHoangNvid).HasName("PK__QuitMeth__F52378B8FFC95EBB");

            entity.ToTable("QuitMethodHoangNV");

            entity.Property(e => e.QuitMethodHoangNvid).HasColumnName("QuitMethodHoangNVID");
            entity.Property(e => e.CreationDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPopular).HasDefaultValue(false);
            entity.Property(e => e.MethodDescription).HasColumnType("text");
            entity.Property(e => e.MethodName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RequiresCounseling).HasDefaultValue(false);
            entity.Property(e => e.RequiresMedical).HasDefaultValue(false);
        });

        modelBuilder.Entity<RecordProcessHoangNv>(entity =>
        {
            entity.HasKey(e => e.RecordProcessHoangNvid).HasName("PK__RecordPr__26CAFFF6B9066069");

            entity.ToTable("RecordProcessHoangNV");

            entity.Property(e => e.RecordProcessHoangNvid).HasColumnName("RecordProcessHoangNVID");
            entity.Property(e => e.CreatePlanQuitSmokingHoangNvid).HasColumnName("CreatePlanQuitSmokingHoangNVID");
            entity.Property(e => e.CreationDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DailyNotes).HasColumnType("text");
            entity.Property(e => e.DailySavings).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.IsGoalAchieved).HasDefaultValue(false);
            entity.Property(e => e.TriggerSituations).HasColumnType("text");

            entity.HasOne(d => d.CreatePlanQuitSmokingHoangNv).WithMany(p => p.RecordProcessHoangNvs)
                .HasForeignKey(d => d.CreatePlanQuitSmokingHoangNvid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecordProcessHoangNV_CreatePlanQuitSmokingHoangNV");
        });

        modelBuilder.Entity<UserAccountHoangNv>(entity =>
        {
            entity.ToTable("UserAccountHoangNV");

            entity.Property(e => e.UserAccountHoangNvid).HasColumnName("UserAccountHoangNVID");
            entity.Property(e => e.ApplicationCode).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EmployeeCode).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RequestCode).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
