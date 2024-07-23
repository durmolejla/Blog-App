using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blog2.Models;

public partial class DbBlogContext : DbContext
{
    public DbBlogContext()
    {
    }

    public DbBlogContext(DbContextOptions<DbBlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KorisnikObjaveView> KorisnikObjaveViews { get; set; }

    public virtual DbSet<TblKomentari> TblKomentaris { get; set; }

    public virtual DbSet<TblKorisnik> TblKorisniks { get; set; }

    public virtual DbSet<TblLajkovi> TblLajkovis { get; set; }

    public virtual DbSet<TblObjave> TblObjaves { get; set; }

    public virtual DbSet<TblPregledi> TblPregledis { get; set; }

    public virtual DbSet<VObjave> VObjaves { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-J0TKU41\\SQLEXPRESS01;Database=dbBlog;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KorisnikObjaveView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("korisnik_objave_view");

            entity.Property(e => e.Naslov).HasColumnName("naslov");
            entity.Property(e => e.Sadrzaj).HasColumnName("sadrzaj");
            entity.Property(e => e.Slika)
                .HasMaxLength(50)
                .HasColumnName("slika");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TblKomentari>(entity =>
        {
            entity.HasKey(e => e.IdKomentara);

            entity.ToTable("tbl_Komentari");

            entity.Property(e => e.IdKomentara).HasColumnName("id_komentara");
            entity.Property(e => e.IdKorisnika).HasColumnName("id_korisnika");
            entity.Property(e => e.IdObjave).HasColumnName("id_objave");
            entity.Property(e => e.Sadrzaj).HasColumnName("sadrzaj");
        });

        modelBuilder.Entity<TblKorisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnika);

            entity.ToTable("tbl_Korisnik");

            entity.Property(e => e.IdKorisnika).HasColumnName("id_korisnika");
            entity.Property(e => e.DatumRodjena)
                .HasColumnType("date")
                .HasColumnName("datum_rodjena");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .HasColumnName("ime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .HasColumnName("prezime");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TblLajkovi>(entity =>
        {
            entity.HasKey(e => e.IdLike).HasName("PK_tbl_lajkovi");

            entity.ToTable("tbl_Lajkovi");

            entity.Property(e => e.IdLike).HasColumnName("id_like");
            entity.Property(e => e.IdKorisnika).HasColumnName("id_korisnika");
            entity.Property(e => e.IdObjave).HasColumnName("id_objave");

            entity.HasOne(d => d.IdObjaveNavigation).WithMany(p => p.TblLajkovis)
                .HasForeignKey(d => d.IdObjave)
                .HasConstraintName("FK_tbl_lajkovi_tbl_objave");
        });

        modelBuilder.Entity<TblObjave>(entity =>
        {
            entity.HasKey(e => e.IdObjave).HasName("PK_tbl_objave");

            entity.ToTable("tbl_Objave");

            entity.Property(e => e.IdObjave).HasColumnName("id_objave");
            entity.Property(e => e.IdKorisnika).HasColumnName("id_korisnika");
            entity.Property(e => e.Naslov).HasColumnName("naslov");
            entity.Property(e => e.Sadrzaj).HasColumnName("sadrzaj");
            entity.Property(e => e.Slika).HasColumnName("slika");
        });

        modelBuilder.Entity<TblPregledi>(entity =>
        {
            entity.HasKey(e => e.IdPregleda);

            entity.ToTable("tbl_Pregledi");

            entity.Property(e => e.IdPregleda).HasColumnName("id_pregleda");
            entity.Property(e => e.IdObjave).HasColumnName("id_objave");

            entity.HasOne(d => d.IdObjaveNavigation).WithMany(p => p.TblPregledis)
                .HasForeignKey(d => d.IdObjave)
                .HasConstraintName("FK_tbl_Pregledi_tbl_objave");
        });

        modelBuilder.Entity<VObjave>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vObjave");

            entity.Property(e => e.Naslov).HasColumnName("naslov");
            entity.Property(e => e.Sadrzaj).HasColumnName("sadrzaj");
            entity.Property(e => e.Slika)
                .HasMaxLength(50)
                .HasColumnName("slika");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
