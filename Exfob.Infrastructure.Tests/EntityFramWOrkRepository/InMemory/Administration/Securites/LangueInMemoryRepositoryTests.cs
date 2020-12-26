using Exfob.Core.Interfaces.Repository;
using Exfob.Infrastructure.Repository;
using Exfob.Infrastructure.Tests.Fixtures;
using Exfob.Models.Administration;
using Exfob.Models.Fakes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Exfob.Infrastructure.Tests.EntityFramWOrkRepository.InMemory.Administration.Securites
{
    public class LangueInMemoryRepositoryTests : IClassFixture<SqliteInMemoryGestionBoisContextTest>
    {
        private IGenericRepository<Langue> _repository;
        GestionBoisDataTestesFakes fakeDatas = new GestionBoisDataTestesFakes();
        public SqliteInMemoryGestionBoisContextTest Fixtures { get; }
        public LangueInMemoryRepositoryTests(SqliteInMemoryGestionBoisContextTest fixture) => Fixtures = fixture;

        [Fact]
        public async Task AddAsync_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);


                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                var result = await _repository.AddAsync(entite, saveChanges: true);

                //Assert
                Assert.NotNull(result);
                Assert.NotNull(await _repository.GetByIdAsync(entite.LangueID));
                Assert.Contains(entite, await _repository.GetAllAsync());
            }

        }

        [Fact]
        public async Task AddAsync_ThrowDbUpdateException_When_Code_Duplicated()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);

                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                await _repository.AddAsync(entite, saveChanges: true);
                entite.LangueID = 200;
                entite.Libelle = "Libelle122222";

                //Assert
                var exception = await Assert.ThrowsAsync<DbUpdateException>(() => _repository.AddAsync(entite, saveChanges: true));
                var innerException = Assert.IsType<SqliteException>(exception.InnerException);
                Assert.Contains("Langue.Code", innerException.Message);

            }

        }

        [Fact]
        public async Task AddAsync_ThrowDbUpdateException_When_Libelle_Duplicated()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);

                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                await _repository.AddAsync(entite, saveChanges: true);
                entite.LangueID = 200;
                entite.Code = "code555";

                //Assert
                var exception = await Assert.ThrowsAsync<DbUpdateException>(() => _repository.AddAsync(entite, saveChanges: true));
                var innerException = Assert.IsType<SqliteException>(exception.InnerException);
                Assert.Contains("Langue.Libelle", innerException.Message);

            }

        }

        [Fact]
        public async Task AddAsync_FromSqlRawAsync_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;
            var query = "SELECT * FROM Langue Where LangueID = {0}";

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);
                object[] _params = { 10 };

                var rep = await _repository.FromSqlRawAsync(query, _params);
                // var ee =   rep.FirstOrDefaultAsync;
                Assert.Null(await rep.FirstOrDefaultAsync());

                //Act

            }

        }

        [Fact]
        public async Task AddAsync_FromSqlInterpolated_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;
            FormattableString formatStringquery = $"SELECT * FROM Langue Where LangueID = {entite.LangueID}";

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);
                object[] _params = { 10 };

                var rep = await _repository.FromSqlAsync(formatStringquery);

                Assert.Null(await rep.FirstOrDefaultAsync());

                //Act

            }

        }

        [Fact]
        public async Task AddAsync_FromSqlRawAsync2_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;
            var p1 = new SqliteParameter("@LangueID", entite.LangueID);
            // var p11 = new SqlParameter("@LangueID", entite.LangueID);
            var query = $"SELECT * FROM Langue Where LangueID =@LangueID ";

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);
                object[] _params = { p1 };

                var rep = await _repository.FromSqlRawAsync(query, _params);
                // var ee =   rep.FirstOrDefaultAsync;
                Assert.Null(await rep.FirstOrDefaultAsync());

                var query2 = "SELECT * FROM Langue";
                var reponse2 = await _repository.FromSqlRawAsync(query2, null);
                var liste = await reponse2.ToListAsync();


                //Act
                var commandText = "INSERT INTO Langue(Code,Libelle) VALUES (@Code, @Libelle)";
                var paramCode = new SqliteParameter("@Code", "amd");
                var paramLibelle = new SqliteParameter("@Libelle", "amd");
                object[] _insertParams = { paramCode, paramLibelle };
                var queryId = await _repository.ExecuteCommandsync(commandText, _insertParams);
                Assert.True(queryId > 0);

                var query22 = "SELECT * FROM Langue";
                var reponse22 = await _repository.FromSqlRawAsync(query22, null);
                var liste2 = await reponse22.ToListAsync();
            }

        }

        [Fact]
        public async Task UpdateAsync_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);


                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                var result = await _repository.AddAsync(entite, saveChanges: true);

                var entityToUpdate = await _repository.GetByIdAsync(entite.LangueID);
                entityToUpdate.Code = "zzz";
                entityToUpdate.Libelle = "dddd";

                await _repository.UpdateAsync(entityToUpdate, saveChanges: true);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(entityToUpdate, await _repository.GetByIdAsync(entite.LangueID));
                Assert.Contains(entityToUpdate, await _repository.GetAllAsync());
            }

        }

        [Fact]
        public async Task UpdateAsync_ThrowDbUpdateException_When_Code_Duplicate_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            var entite2 = fakeDatas.GetLangue();
            entite.LangueID = 0;
            entite2.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);


                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                await _repository.AddAsync(entite, saveChanges: true);

                await _repository.AddAsync(entite2, saveChanges: true);

                var entityToUpdate = await _repository.GetByIdAsync(entite.LangueID);
                entityToUpdate.Code = entite2.Code;

                //Assert
                await Assert.ThrowsAsync<DbUpdateException>(() => _repository.UpdateAsync(entityToUpdate, saveChanges: true));
            }

        }

        [Fact]
        public async Task UpdateAsync_ThrowDbUpdateException_When_Libelle_Duplicate_Should_Return_object()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            var entite2 = fakeDatas.GetLangue();
            entite.LangueID = 0;
            entite2.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);


                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                //Act
                await _repository.AddAsync(entite, saveChanges: true);

                await _repository.AddAsync(entite2, saveChanges: true);

                var entityToUpdate = await _repository.GetByIdAsync(entite.LangueID);
                entityToUpdate.Libelle = entite2.Libelle;

                //Assert
                await Assert.ThrowsAsync<DbUpdateException>(() => _repository.UpdateAsync(entityToUpdate, saveChanges: true));
            }

        }

        [Fact]
        public async Task DeleteAsync_By_ID_Should_return_Success()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);

                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                await _repository.AddAsync(entite, saveChanges: true);
                //Act
                await _repository.DeleteAsync(entite.LangueID, saveChanges: true);


                //Assert
                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

            }

        }

        [Fact]
        public async Task DeleteAsync_BY_Object_Should_return_Success()
        {
            //Arrang
            var entite = fakeDatas.GetLangue();
            entite.LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);

                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

                await _repository.AddAsync(entite, saveChanges: true);
                //Act
                await _repository.DeleteAsync(entite, saveChanges: true);


                //Assert
                Assert.Null(await _repository.GetByIdAsync(entite.LangueID));

            }
        }

        [Fact]
        public async Task DeleteAsync_ThrwDbUpdateException_When_NoDatafound_Should_return_Success()
        {
            //Arrang
            int LangueID = 0;

            using (GestionBoisContext context = Fixtures.CreateContext())
            {
                _repository = new GenericRepository<Langue>(context);

                Assert.Null(await _repository.GetByIdAsync(LangueID));

                //Act

                //Assert
                await Assert.ThrowsAsync<DbUpdateException>(() => _repository.DeleteAsync(LangueID, saveChanges: true));
            }
        }



    }
}
