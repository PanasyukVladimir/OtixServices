using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Money.EF.Tests.MoneyDBTests
{
    public class MoneyDBTestBase : IDisposable
    {
        protected readonly MoneyContext _context;

        public MoneyDBTestBase()
        {
            var options = new DbContextOptionsBuilder<MoneyContext>()
                .UseInMemoryDatabase(databaseName: "MoneyDBTest")
                .Options;

            _context = new MoneyContext(options);

            _context.Database.EnsureCreated();

            MoneyDBInitializer.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
