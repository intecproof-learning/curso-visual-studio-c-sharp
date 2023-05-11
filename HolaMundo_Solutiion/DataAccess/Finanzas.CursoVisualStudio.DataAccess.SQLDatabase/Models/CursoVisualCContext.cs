using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

public partial class CursoVisualCContext : DbContext
{
    public CursoVisualCContext()
    {
    }

    public CursoVisualCContext(DbContextOptions<CursoVisualCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserModuleRel> UserModuleRels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:demoacc.database.windows.net,1433;Initial Catalog=CursoVisualC#;Persist Security Info=False;User ID=abrahamcc;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("Module");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.NickName)
                .HasMaxLength(12)
                .HasColumnName("nickName");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UserModuleRel>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdModule });

            entity.ToTable("User_Module_Rel");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdModule).HasColumnName("idModule");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IdModuleNavigation).WithMany(p => p.UserModuleRels)
                .HasForeignKey(d => d.IdModule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Module_Rel_Module");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserModuleRels)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Module_Rel_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
