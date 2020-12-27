using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

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
            Contexte = new GestionBoisContext(ContextOptions);
        }
        public  DbConnection Connection { get; }
        public GestionBoisContext Contexte { get; set; }

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
