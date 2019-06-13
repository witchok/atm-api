using System;
using System.Collections.Generic;
using System.Text;
using ATMBankDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ATMBankDAL.Data.DataInitialization;

namespace ATMBankDAL.Data
{
    public class ATMBankContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardOwner> CardOwners { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; } 

        internal ATMBankContext() { }

        public ATMBankContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ATMBankCotextFactory.CONNECTION_STRING;
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId
                    .QueryClientEvaluationWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Card>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Cards)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BankTransaction>()
                .HasOne(e => e.SenderCard)
                .WithMany(e => e.SentTransactions);


            modelBuilder.Entity<BankTransaction>()
                .HasOne(e => e.RecipientCard)
                .WithMany(e => e.ReceivedTransactions)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasIndex(e => e.Number)
                .IsUnique(true);

        }
        public string GetTableName(Type type)
        {
            return Model.FindEntityType(type).SqlServer().TableName;
        }
    }
}
