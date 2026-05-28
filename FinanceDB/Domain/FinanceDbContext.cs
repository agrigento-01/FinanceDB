using System;
using System.Collections.Generic;
using FinanceDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceDB.Domain;

public partial class FinanceDbContext : DbContext
{
    public FinanceDbContext()
    {
    }

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fund> Funds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\FinanceDB;Database=FinanceDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AddShares).HasColumnName("Add_shares");
            entity.Property(e => e.AddTotal).HasColumnName("Add_Total");
            entity.Property(e => e.AddYrDiv).HasColumnName("Add_Yr_Div");
            entity.Property(e => e.Desc).HasMaxLength(50);
            entity.Property(e => e.DistYield).HasColumnName("Dist_Yield");
            entity.Property(e => e.DivFreq)
                .HasMaxLength(50)
                .HasColumnName("Div_Freq");
            entity.Property(e => e.ExpRatio).HasColumnName("Exp_Ratio");
            entity.Property(e => e.Fund1)
                .HasMaxLength(50)
                .HasColumnName("Fund");
            entity.Property(e => e.PerDiv).HasColumnName("Per_div");
            entity.Property(e => e.PerShare).HasColumnName("Per_Share");
            entity.Property(e => e.TRatDiff).HasColumnName("T_Rat_Diff");
            entity.Property(e => e.TRatio).HasColumnName("T_Ratio");
            entity.Property(e => e.TotYrDiv).HasColumnName("Tot_Yr_Div");
            entity.Property(e => e.YrDividend).HasColumnName("Yr_dividend");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
