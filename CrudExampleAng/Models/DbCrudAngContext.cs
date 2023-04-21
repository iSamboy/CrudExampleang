using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudExampleAng.Models;

public partial class DbCrudAngContext : DbContext
{
    public DbCrudAngContext()
    {
    }

    public DbCrudAngContext(DbContextOptions<DbCrudAngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("PK__Employee__A5D4E15B375A3044");

            entity.ToTable("Employee");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK__Employee__IdOffi__2A4B4B5E");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.IdOffice).HasName("PK__Office__57A12F4F2E726AEE");

            entity.ToTable("Office");

            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OfficeName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
