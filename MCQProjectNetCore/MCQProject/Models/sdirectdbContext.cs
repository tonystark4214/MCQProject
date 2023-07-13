using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MCQProject.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mcqproject110723> Mcqproject110723s { get; set; } = null!;
        public virtual DbSet<McqprojectUser110723> McqprojectUser110723s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;UID=sdirectdb;PWD=sdirectdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mcqproject110723>(entity =>
            {
                entity.ToTable("MCQProject110723");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.Option1)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Question).IsUnicode(false);
            });

            modelBuilder.Entity<McqprojectUser110723>(entity =>
            {
                entity.ToTable("MCQProjectUser110723");

                entity.Property(e => e.Qattempted).HasColumnName("QAttempted");

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
