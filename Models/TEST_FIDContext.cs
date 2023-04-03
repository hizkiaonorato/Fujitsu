using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fujitsu.Models
{
    public partial class TEST_FIDContext : DbContext
    {
        public TEST_FIDContext()
        {
        }

        public TEST_FIDContext(DbContextOptions<TEST_FIDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbMCity> TbMCity { get; set; }
        public virtual DbSet<TbMSupplier> TbMSupplier { get; set; }
        public virtual DbSet<TbROrderH> TbROrderH { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbMCity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_M_CITY");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbMSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierCode)
                    .HasName("PK_TB_M_SUPPLIER_SUPPLIER_CODE");

                entity.ToTable("TB_M_SUPPLIER");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("SUPPLIER_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("PROVINCE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasColumnName("SUPPLIER_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbROrderH>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK_TB_R_ORDER_H_ORDER_NO");

                entity.ToTable("TB_R_ORDER_H");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("ORDER_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("ORDER_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("SUPPLIER_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
