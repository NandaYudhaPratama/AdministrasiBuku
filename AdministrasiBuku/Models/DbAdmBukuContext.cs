using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdministrasiBuku.Models
{
    /// <summary>
    /// Db Models
    /// </summary>
    public partial class DbAdmBukuContext : DbContext
    {
        public DbAdmBukuContext()
        {
        }

        /// <summary>
        /// Akses data buku dan petugas
        /// </summary>
        /// <param name="options"></param>
        public DbAdmBukuContext(DbContextOptions<DbAdmBukuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buku> Buku { get; set; }
        public virtual DbSet<Petugas> Petugas { get; set; }

        /// <summary>
        /// hasil setelah migrasi database
        /// </summary>
        /// <param name="modelBuilder">method ini akan terbentuk secara otomatis setelah melakukan migrasi database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.JudulBuku)
                    .HasColumnName("Judul_Buku")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Penerbit)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Pengarang)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TahunTerbit)
                    .HasColumnName("Tahun_Terbit")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Petugas>(entity =>
            {
                entity.HasKey(e => e.IdPetugas);

                entity.Property(e => e.IdPetugas).HasColumnName("ID_Petugas");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
