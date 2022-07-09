using Microsoft.EntityFrameworkCore;
using Money.Domain.Entities;
using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF
{
    public class MoneyContext : DbContext
    {
        public MoneyContext()
        {
            Database.EnsureCreated();
        }

        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options)
        {

            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<DebtAccount> DebtAccounts { get; set; }
        public DbSet<RegularAccount> RegularAccounts { get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<DebtAccountTransaction> DebtAccountTransactions { get; set; }
        public DbSet<DefaultTransaction> DefaultTransactions { get; set; }
        public DbSet<RegularAccountTransaction> RegularAccountTransactions { get; set; }
        public DbSet<SavingAccountTransaction> SavingAccountTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoneyDB;Trusted_Connection=True;");
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), new[] { RelationalEventId.CommandExecuted });
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region INDEX
            //modelBuilder.Entity<User>().HasIndex(u => new { u.Login, u.Email });
            //modelBuilder.Entity<DebtAccount>().HasIndex(u => u.UserId);
            //modelBuilder.Entity<RegularAccount>().HasIndex(u => u.UserId);
            //modelBuilder.Entity<SavingAccount>().HasIndex(u => u.UserId);
            //modelBuilder.Entity<Category>().HasIndex(u => u.UserId);
            //modelBuilder.Entity<Subcategory>().HasIndex(u => u.CategoryId);
            //modelBuilder.Entity<DebtAccountTransaction>().HasIndex(u => u.DebtAccountId);
            //modelBuilder.Entity<DefaultTransaction>().HasIndex(u => u.CategoryId);
            //modelBuilder.Entity<RegularAccountTransaction>().HasIndex(u => u.RegularAccountId);
            //modelBuilder.Entity<SavingAccountTransaction>().HasIndex(u => u.SavingAccountId);
            #endregion

            //modelBuilder.Entity<User>().Property(u => u.IsEmailConfirmed).HasDefaultValue(0);

            #region HasDefaultValueSql
            //modelBuilder.Entity<DebtAccountTransaction>().Property(u => u.Date).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<DefaultTransaction>().Property(u => u.Date).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<RegularAccountTransaction>().Property(u => u.Date).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<SavingAccountTransaction>().Property(u => u.Date).HasDefaultValueSql("GETDATE()");
            #endregion

            #region Required
            //modelBuilder.Entity<User>().Property(b => b.Login).IsRequired();
            //modelBuilder.Entity<User>().Property(b => b.Email).IsRequired();
            #endregion

            #region HasMaxLength
            //modelBuilder.Entity<User>().Property(b => b.Login).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(b => b.Email).HasMaxLength(50);
            //modelBuilder.Entity<User>().Property(b => b.Name).HasMaxLength(50);
            #endregion
        }
    }
}
