using System;
using System.Runtime.CompilerServices;
using Acorn.BL.Helpers;
using Microsoft.EntityFrameworkCore;
using Acorn.BL.Models;

namespace Acorn.DAL
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
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
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever()
                    .IsRequired();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("'login'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)")
                    .HasDefaultValueSql("'password'");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)")
                    .HasConversion(v => v.ToString(),
                        v => (Regions)Enum.Parse(typeof(Regions), v));

                entity.Property(e => e.Level)
                    .HasColumnType("INT(3)")
                    .IsRequired()
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExpPercentage)
                    .HasColumnType("INT(3)")
                    .IsRequired()
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");

                entity.HasOne(d => d.Bot)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Bot>(entity =>
            {
                entity.HasKey(e => e.BotId);

                entity.Property(e => e.BotId)
                    .HasColumnType("INT(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)")
                    .HasConversion(v => v.ToString(),
                        v => (BotOrders)Enum.Parse(typeof(BotOrders), v))
                    .HasDefaultValueSql("'STOP'");
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

                entity.Property(e => e.OverwriteConfig)
                    .IsRequired()
                    .HasColumnType("BIT(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CloseBrowser)
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

                entity.Property(e => e.NoActionTimeout)
                    .IsRequired()
                    .HasColumnType("INT(6)")
                    .HasDefaultValueSql("600");

                entity.HasOne(d => d.Bot)
                    .WithOne(p => p.Config)
                    .HasForeignKey<Config>(d => d.BotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<FreshAccount>(entity =>
            {
                entity.HasKey(e => e.FreshAccId);

                entity.Property(e => e.FreshAccId).ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)")
                    .HasConversion(v => v.ToString(),
                        v => (Regions)Enum.Parse(typeof(Regions), v));

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");
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
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReadyAccount>(entity =>
            {
                entity.HasKey(e => e.ReadyAccId);

                entity.Property(e => e.ReadyAccId).ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(25)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)")
                    .HasConversion(v => v.ToString(),
                        v => (Regions)Enum.Parse(typeof(Regions), v));

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("'1970-01-01'");
            });
        }
    }
}