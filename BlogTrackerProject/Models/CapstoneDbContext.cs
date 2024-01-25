using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogTrackerProject.Models
{
    public partial class CapstoneDbContext : DbContext
    {
        public CapstoneDbContext()
        {
        }

        public CapstoneDbContext(DbContextOptions<CapstoneDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;
        public virtual DbSet<Bloginfo> Bloginfos { get; set; } = null!;
        public virtual DbSet<Employeeinfo> Employeeinfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:capstonedb.database.windows.net,1433;Initial Catalog=CapstoneDb;Persist Security Info=False;User ID=onkar;Password=ManishPavan@333;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdminInfo");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Bloginfo>(entity =>
            {
                entity.HasKey(e => e.Blogid)
                    .HasName("PK__Bloginfo__543EF2A8F7BCF6D6");

                entity.ToTable("Bloginfo");

                entity.Property(e => e.Blogid).ValueGeneratedNever();

                entity.Property(e => e.Blogurl).HasMaxLength(50);

                entity.Property(e => e.DateOfCreation).HasColumnType("datetime");

                entity.Property(e => e.Empemail)
                    .HasMaxLength(50)
                    .HasColumnName("empemail");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.EmpemailNavigation)
                    .WithMany(p => p.Bloginfos)
                    .HasForeignKey(d => d.Empemail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Bloginfo__empema__5FB337D6");
            });

            modelBuilder.Entity<Employeeinfo>(entity =>
            {
                entity.HasKey(e => e.Emailid)
                    .HasName("PK__employee__8734520AC106B242");

                entity.ToTable("employeeinfo");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .HasColumnName("emailid");

                entity.Property(e => e.Doj)
                    .HasColumnType("datetime")
                    .HasColumnName("DOJ");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Passcode).HasColumnName("passcode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
