using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIS.DAL.DataModel
{
    public partial class PIS_DbContext : DbContext
    {
        public PIS_DbContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public PIS_DbContext(DbContextOptions<PIS_DbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<PisUsersDrupcic> PisUsersDrupcic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PisUsersDrupcic>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__PIS_USER__F3BEEBFF367B8209");

                entity.ToTable("PIS_USERS_DRUPCIC");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.Oib)
                    .HasColumnName("OIB")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserAddress)
                    .HasColumnName("USER_ADDRESS")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserApproved).HasColumnName("USER_APPROVED");

                entity.Property(e => e.UserBanned).HasColumnName("USER_BANNED");

                entity.Property(e => e.UserCountry)
                    .HasColumnName("USER_COUNTRY")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("USER_EMAIL")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserFax)
                    .HasColumnName("USER_FAX")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserImage)
                    .HasColumnName("USER_IMAGE")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserLevel).HasColumnName("USER_LEVEL");

                entity.Property(e => e.UserLoginName)
                    .HasColumnName("USER_LOGIN_NAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserSurname)
                    .HasColumnName("USER_SURNAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserTel)
                    .HasColumnName("USER_TEL")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
