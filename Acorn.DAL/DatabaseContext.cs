using Acorn.BL.Enums;
using Acorn.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bot> Bots { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<FreshAccount> FreshAccounts { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<ReadyAccount> ReadyAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlHasEnum<AiConfig>();
            modelBuilder.ForNpgsqlHasEnum<BotOrder>();
            modelBuilder.ForNpgsqlHasEnum<QueueType>();
            modelBuilder.ForNpgsqlHasEnum<Region>();

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("accounts_pkey");

                entity.ToTable("accounts");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasDefaultValueSql("nextval('account_seq'::regclass)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'1970-01-01'::date");

                entity.Property(e => e.BotId).HasColumnName("bot_id");

                entity.Property(e => e.ExpPercentage).HasColumnName("exp_percentage");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region");

                entity.HasOne(d => d.Bot)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts_bot_id_fkey");
            });

            modelBuilder.Entity<Bot>(entity =>
            {
                entity.HasKey(e => e.BotId)
                    .HasName("BOTS_pkey");

                entity.ToTable("bots");

                entity.Property(e => e.BotId)
                    .HasColumnName("bot_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BotOrder)
                    .IsRequired()
                    .HasColumnName("bot_order")
                    .HasDefaultValueSql("'start'::bot_orders");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.BotId)
                    .HasName("configs_pkey");

                entity.ToTable("configs");

                entity.Property(e => e.AiConfig)
                    .IsRequired()
                    .HasColumnName("ai_config")
                    .HasDefaultValueSql("'follow'::ai_configs");

                entity.Property(e => e.BotId)
                    .HasColumnName("bot_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CloseBrowser)
                    .IsRequired()
                    .HasColumnName("close_browser")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.NoActionTimeout)
                    .HasColumnName("no_action_timeout")
                    .HasDefaultValueSql("300");

                entity.Property(e => e.OverwriteConfig)
                    .IsRequired()
                    .HasColumnName("overwrite_config")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'C:/Riot Games/League of Legends/'::character varying");

                entity.Property(e => e.QueueType)
                    .IsRequired()
                    .HasColumnName("queue_type")
                    .HasDefaultValueSql("'intro'::queue_types");

                entity.HasOne(d => d.Bot)
                    .WithOne(p => p.Config)
                    .HasForeignKey<Config>(d => d.BotId)
                    .HasConstraintName("configs_bot_id_fkey");
            });

            modelBuilder.Entity<FreshAccount>(entity =>
            {
                entity.HasKey(e => e.FreshAccountId)
                    .HasName("fresh_accounts_pkey");

                entity.ToTable("fresh_accounts");

                entity.Property(e => e.FreshAccountId)
                    .HasColumnName("fresh_account_id")
                    .HasDefaultValueSql("nextval('fresh_acc_seq'::regclass)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("logs_pkey");

                entity.ToTable("logs");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasDefaultValueSql("nextval('log_id_seq'::regclass)");

                entity.Property(e => e.BotId).HasColumnName("bot_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Bot)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.BotId)
                    .HasConstraintName("logs_bot_id_fkey");
            });

            modelBuilder.Entity<ReadyAccount>(entity =>
            {
                entity.HasKey(e => e.ReadyAccountId)
                    .HasName("ready_accounts_pkey");

                entity.ToTable("ready_accounts");

                entity.Property(e => e.ReadyAccountId)
                    .HasColumnName("ready_account_id")
                    .HasDefaultValueSql("nextval('ready_acc_seq'::regclass)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('user_seq'::regclass)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("password_salt");
            });

            modelBuilder.HasSequence("account_seq")
                .HasMax(9999)
                .IsCyclic();

            modelBuilder.HasSequence("fresh_acc_seq")
                .HasMax(9999)
                .IsCyclic();

            modelBuilder.HasSequence("log_id_seq").IsCyclic();

            modelBuilder.HasSequence("ready_acc_seq")
                .HasMax(9999)
                .IsCyclic();

            modelBuilder.HasSequence("user_seq")
                .IsCyclic();
        }
    }
}
