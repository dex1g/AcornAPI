using Microsoft.EntityFrameworkCore;
using Acorn.BL.Models;

namespace Acorn.DAL
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BotOrder> BotOrders { get; set; }
        public virtual DbSet<Bot> Bots { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<FreshAccount> FreshAccounts { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<ReadyAccount> ReadyAccounts { get; set; }

        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Acorn.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.BotId);

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)");

                entity.HasOne(d => d.Bot)
                    .WithOne(p => p.Accounts)
                    .HasForeignKey<Account>(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BotOrder>(entity =>
            {
                entity.HasKey(e => e.BotId);

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)");

                entity.HasOne(d => d.Bot)
                    .WithOne(p => p.BotOrder)
                    .HasForeignKey<BotOrder>(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Bot>(entity =>
            {
                entity.HasKey(e => e.BotId);

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasColumnType("VARCHAR(16)");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.BotId);

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aiconfig)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'follow'");

                entity.Property(e => e.Champion1)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'sivir'");

                entity.Property(e => e.Champion2)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'missfortune'");

                entity.Property(e => e.Champion3)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'ashe'");

                entity.Property(e => e.Champion4)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'lux'");

                entity.Property(e => e.Champion5)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'annie'");

                entity.Property(e => e.OverwriteConfig)
                    .IsRequired()
                    .HasColumnType("BIT(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)")
                    .HasDefaultValueSql("'C:/Riot Games/League of Legends/'");

                entity.Property(e => e.Queuetype)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'intro_bot'");

                entity.HasOne(d => d.Bot)
                    .WithOne(p => p.Config)
                    .HasForeignKey<Config>(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FreshAccount>(entity =>
            {
                entity.HasKey(e => e.FreshAccId);

                entity.Property(e => e.FreshAccId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId).ValueGeneratedNever();

                entity.Property(e => e.BotId).HasColumnType("INT(3)");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.HasOne(d => d.Bot)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReadyAccount>(entity =>
            {
                entity.HasKey(e => e.ReadyAccId);

                entity.Property(e => e.ReadyAccId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)");
            });
        }
    }
}