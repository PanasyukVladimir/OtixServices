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
                Id = 1,
                Login = "admin",
                Password = "admin123",
                Name = "OTIX",
                Email = "admin@gmail.com",
                IsEmailConfirmed = true,
                Categories = new List<Category>
                {
                    new Category()
                    {
                        Id = 1,
                        Name = "Category1",
                        CategoryCurrency = CategoryCurrencyEnum.UAH,
                        Description = "Category1",
                        Balance = 0,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = 1,
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
                        Description = "Category2",
                        Balance = 80000,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = 1,
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
                        Description = "Category3",
                        Balance = 6000,
                        TypeCategory = TypeCategoryEnum.Expenses,
                        UserId = 1,
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
                        Description = "RegularAccount1",
                        Balance = 5000,
                        CreditLimit = 0,
                        TypeRegularAccount = TypeRegularAccountEnum.Card,
                        UserId = 1,
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
                        Description = "RegularAccount2",
                        Balance = 50000,
                        CreditLimit = 0,
                        TypeRegularAccount = TypeRegularAccountEnum.Cash,
                        UserId = 1,
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
                        Description = "SavingAccount1",
                        Balance = 5000,
                        GoalSavingBalance = 50000000,
                        UserId = 1,
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
                        Description = "SavingAccount2",
                        Balance = 500,
                        GoalSavingBalance = 5000,
                        UserId = 1,
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
                        Description = "DebtAccount1",
                        Balance = 500,
                        UserId = 1,
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
                        Description = "DebtAccount2",
                        Balance = 500,
                        UserId = 1,
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
                Id = 2,
                Login = "user1",
                Password = "user123",
                Name = "USER1",
                Email = "user1@gmail.com",
                IsEmailConfirmed = true
            },
            new User
            {
                Id = 3,
                Login = "user2",
                Password = "user1234",
                Name = "USER2",
                Email = "user2@gmail.com",
                IsEmailConfirmed = true
            });

            context.SaveChanges();
        }
    }
}
