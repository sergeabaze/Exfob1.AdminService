using AutoFixture;
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
    public class SqliteInMemoryGestionBoisContextTest : GestionBoisContextTests, IDisposable
    {
        public  DbConnection _connection;
        public   Fixture _fixture;
        public SqliteInMemoryGestionBoisContextTest()
            : base(
                new DbContextOptionsBuilder<GestionBoisContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
            _fixture = new Fixture();
        }

        public GestionBoisContext CreateContext(DbTransaction transaction = null)
        {

            //var sqlServerDboptions = new DbContextOptionsBuilder<GestionBoisContext>(
            //    ).UseSqlServer(Connection)
            //    .Options;

            var context = new GestionBoisContext(ContextOptions);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
       
    }
}
