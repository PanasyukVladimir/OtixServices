using Money.Domain.Entities.AccountAggregate;
using Money.Domain.Entities.CategoryAggregate;
using Money.Domain.Entities.TransactionAggregate;
using Money.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Tests.MoneyDBTests
{
    public static class MoneyDBInitializer
    {
        public static void Initialize(MoneyContext context)
        {
            context.Users.AddRange(
            new User
            {
                Id = "1",
                UserName = "admin",
                PasswordHash = "admin123",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                Categories = new List<Category>
                {
                    new Category()
                    {
                        Id = 1,
                        Name = "Category1",
                        CategoryCurrency = CategoryCurrencyEnum.UAH,
                        Balance = 0,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = "1",
                        DefaultTransactions = new List<DefaultTransaction>
                        {
                            new DefaultTransaction()
                            {
                                Id = 1,
                                Amount = 50,
                                Nodes = "DefaultTransaction1",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1, 
                                CategoryId = 1
                            },
                            new DefaultTransaction()
                            {
                                Id = 2,
                                Amount = 60,
                                Nodes = "DefaultTransaction2",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                CategoryId = 1
                            }
                        },
                        Subcategories = new List<Subcategory>
                        {
                            new Subcategory()
                            {
                                Id = 1,
                                Name = "Subcategory1",
                                Description = "Subcategory1",
                                CategoryId = 1
                            },
                            new Subcategory()
                            {
                                Id = 2,
                                Name = "Subcategory2",
                                Description = "Subcategory2",
                                CategoryId = 1
                            },
                            new Subcategory()
                            {
                                Id = 3,
                                Name = "Subcategory3",
                                Description = "Subcategory3",
                                CategoryId = 1
                            }
                        }
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Category2",
                        CategoryCurrency = CategoryCurrencyEnum.UAH,
                        Balance = 80000,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = "1",
                        DefaultTransactions = new List<DefaultTransaction>
                        {
                            new DefaultTransaction()
                            {
                                Id = 3,
                                Amount = 500,
                                Nodes = "DefaultTransaction3",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                CategoryId = 2
                            },
                            new DefaultTransaction()
                            {
                                Id = 4,
                                Amount = 600,
                                Nodes = "DefaultTransaction4",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                CategoryId = 2
                            }
                        },
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Category3",
                        CategoryCurrency = CategoryCurrencyEnum.UAH,
                        Balance = 6000,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = "1",
                        DefaultTransactions = new List<DefaultTransaction>
                        {
                            new DefaultTransaction()
                            {
                                Id = 5,
                                Amount = 5000,
                                Nodes = "DefaultTransaction5",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                CategoryId = 3
                            },
                            new DefaultTransaction()
                            {
                                Id = 6,
                                Amount = 60,
                                Nodes = "DefaultTransaction6",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                CategoryId = 3
                            }
                        }
                    }
                    
                },
                RegularAccounts = new List<RegularAccount>()
                {
                    new RegularAccount()
                    {
                        Id = 1,
                        Name = "RegularAccount1",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 5000,
                        TypeRegularAccount = TypeRegularAccountEnum.Card,
                        UserId = "1",
                        RegularAccountTransactions = new List<RegularAccountTransaction>()
                        {
                            new RegularAccountTransaction()
                            {
                                Id = 1,
                                Amount = 500,
                                Nodes = "RegularAccountTransaction1",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 2,
                                RegularAccountId = 1
                            }
                        }
                    },
                    new RegularAccount()
                    {
                        Id = 2,
                        Name = "RegularAccount2",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 50000,
                        TypeRegularAccount = TypeRegularAccountEnum.Cash,
                        UserId = "1",
                        RegularAccountTransactions = new List<RegularAccountTransaction>()
                        {
                            new RegularAccountTransaction()
                            {
                                Id = 2,
                                Amount = 5000,
                                Nodes = "RegularAccountTransaction2",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                RegularAccountId = 2
                            }
                        }
                    }
                },
                SavingAccounts = new List<SavingAccount>()
                {
                    new SavingAccount()
                    {
                        Id = 1,
                        Name = "SavingAccount1",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 5000,
                        GoalSavingBalance = 50000000,
                        UserId = "1",
                        SavingAccountTransactions = new List<SavingAccountTransaction>()
                        {
                            new SavingAccountTransaction()
                            {
                                Id = 1,
                                Amount = 5000,
                                Nodes = "SavingAccountTransaction1",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                SavingAccountId = 1
                            }
                        }
                    },
                    new SavingAccount()
                    {
                        Id = 2,
                        Name = "SavingAccount2",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 500,
                        GoalSavingBalance = 5000,
                        UserId = "1",
                        SavingAccountTransactions = new List<SavingAccountTransaction>()
                        {
                            new SavingAccountTransaction()
                            {
                                Id = 2,
                                Amount = 500,
                                Nodes = "SavingAccountTransaction2",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                SavingAccountId = 2
                            }
                        }
                    }
                },
                DebtAccounts = new List<DebtAccount>()
                {
                    new DebtAccount()
                    {
                        Id = 1,
                        Name = "DebtAccount1",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 500,
                        UserId = "1",
                        DebtAccountTransactions = new List<DebtAccountTransaction>()
                        {
                            new DebtAccountTransaction()
                            {
                                Id = 1,
                                Amount = 500,
                                Nodes = "DebtAccountTransaction1",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                DebtAccountId = 1
                            }
                        }
                    },
                    new DebtAccount()
                    {
                        Id = 2,
                        Name = "DebtAccount2",
                        AccountCurrency = AccountCurrencyEnum.UAH,
                        Balance = 500,
                        UserId = "1",
                        DebtAccountTransactions = new List<DebtAccountTransaction>()
                        {
                            new DebtAccountTransaction()
                            {
                                Id = 2,
                                Amount = 500,
                                Nodes = "DebtAccountTransaction2",
                                Date = DateTime.Now,
                                AccountProvideTransactionId = 1,
                                DebtAccountId = 2
                            }
                        }
                    }
                }
            },
            new User
            {
                Id = "2",
                UserName = "user1",
                PasswordHash = "user123",
                Email = "user1@gmail.com",
                EmailConfirmed = true
            },
            new User
            {
                Id = "3",
                UserName = "user2",
                PasswordHash = "user1234",
                Email = "user2@gmail.com",
                EmailConfirmed = true
            });

            context.SaveChanges();
        }
    }
}
