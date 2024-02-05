using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStudent
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Curse { get; set; }

        public int FacultetId { get; set; }
        public Facultet Facultet { get; set; }
    }

    public class Facultet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student>? Students { get; set; }

        public Proffesor Proffesor { get; set; }

    }

    public class Proffesor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int? FacultetId { get; set; }
        public Facultet? Facultet { get; set; }
    }

    public class CoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Facultet> Facultetes { get; set; }
        public DbSet<Proffesor> Proffesors { get; set; }

        public CoolContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(st =>
            {
                st.Property(s => s.Name).IsRequired().HasMaxLength(100);
                st.Property(s => s.Age).IsRequired().HasDefaultValueSql("18");
                st.Property(s => s.Curse).IsRequired().HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Student>().ToTable(t => t.HasCheckConstraint("CK_MaxMinAge", "age between 18 and 40"));
            modelBuilder.Entity<Student>().ToTable(t => t.HasCheckConstraint("CK_MaxMinCurse", "Curse between 1 and 5"));

            modelBuilder.Entity<Proffesor>(st =>
            {
                st.Property(s => s.Name).IsRequired().HasMaxLength(100);
                st.Property(s => s.Age).IsRequired().HasDefaultValueSql("18");
            });

            modelBuilder.Entity<Proffesor>().ToTable(t => t.HasCheckConstraint("CK_MaxMinAge", "age between 18 and 80"));

            modelBuilder.Entity<Facultet>(st =>
            {
                st.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
