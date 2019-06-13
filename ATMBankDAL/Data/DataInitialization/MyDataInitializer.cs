using ATMBankDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StringEncoding;

namespace ATMBankDAL.Data.DataInitialization
{
    public static class MyDataInitializer
    {
        public static void InitializeData(ATMBankContext context)
        {

            var owners = new List<CardOwner>
            {
                new CardOwner{FirstName = "Eric", LastName = "Cartman"},
                new CardOwner{FirstName = "Kyle", LastName = "Broflofskiy"},
                new CardOwner{FirstName = "Kenny", LastName = "Mackormick"},
                new CardOwner{FirstName = "Stan", LastName = "Marsh"},
            };
            context.CardOwners.AddRange(owners);
            context.SaveChanges();

            var cards = new List<Card>
            {
                new Card {Number = "0000222233334444",
                    Balance =431.21M,
                    EncodedPin = "0000".EncodeForUTF8(),
                    Owner=owners[0]
                },
                new Card {Number = "2222555533334444",
                    Balance =51232.51M,
                    EncodedPin = "1111".EncodeForUTF8(),
                    Owner=owners[1]
                },
                new Card {Number = "3333222233334444",
                    Balance = 0.21M,
                    EncodedPin = "3333".EncodeForUTF8(),
                    Owner=owners[2]
                },
                new Card {Number = "4444222233334444",
                    Balance = 21.21M,
                    EncodedPin = "4444".EncodeForUTF8(),
                    Owner=owners[3]
                },
                new Card {Number = "5555222233334444",
                    Balance =123.23M,
                    EncodedPin = "5555".EncodeForUTF8(),
                    Owner=owners[0]
                },
                new Card {Number = "6666222233334444",
                    Balance =31.41M,
                    EncodedPin = "6666".EncodeForUTF8(),
                    Owner=owners[1]
                },
                new Card {Number = "7777222233334444",
                    Balance = 312.21M,
                    EncodedPin = "7777".EncodeForUTF8(),
                    Owner=owners[2]
                },
                new Card {Number = "8888222233334444",
                    Balance =441.22M,
                    EncodedPin = "8888".EncodeForUTF8(),
                    Owner=owners[3]
                }
            };
            context.Cards.AddRange(cards);
            context.SaveChanges();

            var transactions = new List<BankTransaction>
            {
                new BankTransaction{
                    Amount = 30.12M,
                    ExecutionDate = new DateTime(2019, 3, 28, 1 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[0],
                    RecipientCard = cards[1]
                },
                new BankTransaction{
                    Amount = 1233.12M,
                    ExecutionDate = new DateTime(2019, 3, 24, 2 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[0],
                    RecipientCard = cards[2]
                    
                },
                new BankTransaction{
                    Amount = 1.14M,
                    ExecutionDate = new DateTime(2019, 6, 1, 3 ,20 ,1),
                    IsSuccesful = false,
                    SenderCard = cards[0],
                    RecipientCard = cards[2]

                },
                new BankTransaction{
                    Amount = 41.65M,
                    ExecutionDate = new DateTime(2018, 4, 28, 4 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[1],
                    RecipientCard = cards[0]

                },
                new BankTransaction{
                    Amount = 141.12M,
                    ExecutionDate = new DateTime(2019, 6, 21, 5 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[1],
                    RecipientCard = cards[2]

                },
                new BankTransaction{
                    Amount = 10.12M,
                    ExecutionDate = new DateTime(2019,4, 11, 6 ,20 ,1),
                    IsSuccesful = false,
                    SenderCard = cards[2],
                    RecipientCard = cards[3]

                },
                new BankTransaction{
                    Amount = 20.12M,
                    ExecutionDate = new DateTime(2019, 3, 14, 7 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[2],
                    RecipientCard = cards[0]

                },
                new BankTransaction{
                    Amount = 51.14M,
                    ExecutionDate = new DateTime(2019, 3, 18, 8 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[3],
                    RecipientCard = cards[2]
                },
                new BankTransaction{
                    Amount = 3.12M,
                    ExecutionDate = new DateTime(2019, 1, 8, 9 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[3],
                    RecipientCard = cards[2]
                },
                new BankTransaction{
                    Amount = 40.40M,
                    ExecutionDate = new DateTime(2019, 5, 17, 10 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[1],
                    RecipientCard = cards[3]

                },
                new BankTransaction{
                    Amount = 41.2M,
                    ExecutionDate = new DateTime(2019, 2, 5, 11 ,20 ,1),
                    IsSuccesful = true,
                    SenderCard = cards[3],
                    RecipientCard = cards[0]
                },
            };
            context.BankTransactions.AddRange(transactions);
            context.SaveChanges();

        }

        public static void RecreateDatabase(ATMBankContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        public static void ClearData(ATMBankContext context)
        {
            ExecuteDeleteSql(context, "BankTransaction");
            ExecuteDeleteSql(context, "Card");
            ExecuteDeleteSql(context, "CardOwner");
            ResetIdentity(context);
        }

        private static void ExecuteDeleteSql(ATMBankContext context, string tableName)
        {
            //With 2.0, must separate string interpolation if not passing in params
            var rawSqlString = $"Delete from dbo.{tableName}";
            context.Database.ExecuteSqlCommand(rawSqlString);
        }
        private static void ResetIdentity(ATMBankContext context)
        {
            var tables = new[] { "BankTransaction", "Card", "CardOwner"};
            foreach (var itm in tables)
            {
                //With 2.0, must separate string interpolation if not passing in params
                var rawSqlString = $"DBCC CHECKIDENT (\"dbo.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(rawSqlString);
            }
        }

    }
}
