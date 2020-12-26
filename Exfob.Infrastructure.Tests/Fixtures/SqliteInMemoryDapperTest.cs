using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Tests.Fixtures
{
   public  class SqliteInMemoryDapperTest : GestionBoisContextTests, IDisposable
    {
        private readonly DbConnection _connection;
        public SqliteInMemoryDapperTest()
             : base(
                new DbContextOptionsBuilder<GestionBoisContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options)
        {
            Connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }
        public  DbConnection Connection { get; }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
