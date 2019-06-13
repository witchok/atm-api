﻿// <auto-generated />
using System;
using ATMBankDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATMBankDAL.Data.Migrations
{
    [DbContext(typeof(ATMBankContext))]
    partial class ATMBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATMBankDAL.Models.BankTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExecutionDate");

                    b.Property<bool>("IsSuccesful");

                    b.Property<int>("RecipientCardId");

                    b.Property<int>("SenderCardId");

                    b.HasKey("Id");

                    b.HasIndex("RecipientCardId");

                    b.HasIndex("SenderCardId");

                    b.ToTable("BankTransaction");
                });

            modelBuilder.Entity("ATMBankDAL.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasMaxLength(50);

                    b.Property<string>("EncodedPin")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("ATMBankDAL.Models.CardOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CardOwner");
                });

            modelBuilder.Entity("ATMBankDAL.Models.BankTransaction", b =>
                {
                    b.HasOne("ATMBankDAL.Models.Card", "RecipientCard")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("RecipientCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ATMBankDAL.Models.Card", "SenderCard")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMBankDAL.Models.Card", b =>
                {
                    b.HasOne("ATMBankDAL.Models.CardOwner", "Owner")
                        .WithMany("Cards")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
