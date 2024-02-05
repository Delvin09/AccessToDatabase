using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccessToDatabase_Entity;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserWithCompany> UserWithCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;Trust Server Certificate=True");

        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3213E83FEB640BED");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddVal)
                .HasMaxLength(200)
                .HasColumnName("addVal");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");

            entity.HasOne(d => d.Company).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Addresses__compa__6FE99F9F");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3213E83FDE3BC56E");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FD0CA68B2");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__User__companyId__6D0D32F4");
        });

        modelBuilder.Entity<UserWithCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserWithCompany");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .HasColumnName("companyName");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("userName");
        });
        modelBuilder.HasSequence<int>("DecSeq")
            .HasMin(1L)
            .HasMax(9999L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
