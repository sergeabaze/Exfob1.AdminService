using Microsoft.EntityFrameworkCore;

namespace Exfob.Infrastructure.Tests.Fixtures
{
    public  class SqliteIGestionBoisFixture : GestionBoisDbContextConfigureTest
    {
        public SqliteIGestionBoisFixture()
            :base(
                 new DbContextOptionsBuilder<GestionBoisContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {

        }
        // => options.UseSqlite("Data Source=sqlitedemo.db");
    }
}
