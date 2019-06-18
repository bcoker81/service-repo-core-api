using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace service_repo_api.Domain
{
    public partial class ServiceRepositoryContext : DbContext
    {
        public ServiceRepositoryContext()
        {
        }

        public ServiceRepositoryContext(DbContextOptions<ServiceRepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<ErrorLogs> ErrorLogs { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentDescription).HasMaxLength(300);

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FkServiceId).HasColumnName("FK_Service_Id");

                entity.HasOne(d => d.FkService)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkServiceId)
                    .HasConstraintName("FK_Comments_Services");
            });

            modelBuilder.Entity<ErrorLogs>(entity =>
            {
                entity.HasKey(e => e.ErrorId);

                entity.Property(e => e.Arguments).HasMaxLength(100);

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ErrorCode).HasMaxLength(200);

                entity.Property(e => e.ErrorMessage).HasMaxLength(500);

                entity.Property(e => e.FkServiceId).HasColumnName("FK_Service_Id");

                entity.HasOne(d => d.FkService)
                    .WithMany(p => p.ErrorLogs)
                    .HasForeignKey(d => d.FkServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ErrorLogs_Services");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.CreateBy).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Documentation).HasMaxLength(150);

                entity.Property(e => e.EndpointAddress).HasMaxLength(150);

                entity.Property(e => e.ModifyBy).HasMaxLength(150);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Platform).HasMaxLength(100);

                entity.Property(e => e.Protocol).HasMaxLength(50);

                entity.Property(e => e.SecurityNotes).HasMaxLength(500);

                entity.Property(e => e.SecurityType).HasMaxLength(50);

                entity.Property(e => e.ServerEnvironment).HasMaxLength(30);

                entity.Property(e => e.ServiceCode).HasMaxLength(20);

                entity.Property(e => e.ServiceDescription).HasMaxLength(500);

                entity.Property(e => e.TeamResponsible).HasMaxLength(30);
            });
        }
    }
}
