using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestApplication.Models
{
    public partial class TestApplicationContext : DbContext
    {
       /* public TestApplicationContext()
        {
        }*/

        public TestApplicationContext(DbContextOptions<TestApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ManagerTable> ManagerTables { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U2LN7O1;Database=TestApplication;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManagerTable>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PK__ManagerT__3BA2AA81695BD9DB");

                entity.ToTable("ManagerTable");

                entity.HasIndex(e => e.MailId, "MailID_ManagerTable")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "PhoneNumber_ManagerTable")
                    .IsUnique();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MailID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ManagerTables)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagerTable_Roles");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "IX_Roles")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__UserTabl__AF2DBA796A560C30");

                entity.ToTable("UserTable");

                entity.HasIndex(e => e.MailId, "MailID_Table_1")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "PhoneNumber_Table_1")
                    .IsUnique();

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MailID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_ManagerTable");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
