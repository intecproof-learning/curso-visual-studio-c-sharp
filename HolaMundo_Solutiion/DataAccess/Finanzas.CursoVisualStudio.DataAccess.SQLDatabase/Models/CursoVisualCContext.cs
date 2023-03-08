﻿using System;
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

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CursoVisualC#;User ID=sa;Password=Admin123;Trusted_Connection=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
