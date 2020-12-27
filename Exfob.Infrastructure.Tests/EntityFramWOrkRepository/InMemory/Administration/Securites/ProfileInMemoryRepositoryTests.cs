using Dapper;
using Exfob.Core.Interfaces.Repository;
using Exfob.Infrastructure.Repository;
using Exfob.Models.Fakes;
using Exfob.Infrastructure.Tests.Fixtures;
using Exfob.Models.Administration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Dapper.SqlMapper;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Infrastructure.Repository.Administrations.Securites;

namespace Exfob.Infrastructure.Tests.EntityFramWOrkRepository.InMemory.Administration.Securites
{
    public class ProfileInMemoryRepositoryTests : IClassFixture<SqliteInMemoryDapperTest>
    {

        private IProfileRepository _repository;
        GestionBoisDataTestesFakes fakeDatas;
        public SqliteInMemoryDapperTest Context { get; }
        public ProfileInMemoryRepositoryTests(SqliteInMemoryDapperTest contexte)
        {
            Context = contexte;
            _repository = new ProfileRepository(Context.Contexte);
            fakeDatas = new GestionBoisDataTestesFakes();
        }

        [Fact]
        public async Task AddAsync_Should_Return_List()
        {
            //Arrang
            var entite = fakeDatas.GetProfil();


            // Act
            var id = await _repository.AddAsync(entite);

           // object parameters = new { ProfilID = entite.ProfilID };
            var result2 = await _repository.GetByIdAsync(entite.ProfilID);

            //Assert
            Assert.Equal(entite.Libelle, result2.Libelle);
        }

        [Fact]
        public async Task GetDataAsync_ById_Should_Return_Object()
        {
            //Arrang
            var entite = fakeDatas.GetProfil();
            entite.ProfilID = 0;


            string query = "SELECT * FROM Profil WHERE ProfilID = @id";

            // Act
            var id = await _repository.AddAsync(entite);
            object parameters = new { id = entite.ProfilID };

            var result = await _repository.FromSqlRawAsync(query, parameters);

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task AddAsync_Should_Return_Id()
        {
            //Arrang
            var entite = fakeDatas.GetProfil();
            entite.ProfilID = 0;

            string insQuery = $"INSERT INTO Profil(Libelle) VALUES(@{nameof(Profil.Libelle)})";
            string query = $"SELECT * FROM Profil WHERE ProfilID = @{nameof(Profil.ProfilID)}";
            object inParameters = new { entite.Libelle };

            // Act
            var ProfilID = await _repository.FromSqlRawAsync(insQuery, inParameters);


            object parameters = new { ProfilID };
            var result = await _repository.FromSqlRawAsync(query, parameters);

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task FindAsync_Should_Return_Object()
        {
            //Arrange
            var entite = fakeDatas.GetProfil();

            await _repository.AddAsync(entite);
            object parameters = new { ProfilID = entite.ProfilID };

            var entiteUpdate = await _repository.FindAsync(x => x.ProfilID == entite.ProfilID);
            entiteUpdate.Libelle = "ssssssssss5";
            object pk = new { ProfilID = entiteUpdate.ProfilID };
            // Act
            await _repository.UpdateAsync(entiteUpdate, pk);

            parameters = new { ProfilID = entiteUpdate.ProfilID };

            var result = await _repository.FindAsync(x => x.ProfilID == entite.ProfilID);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetData_ById_Should_Return_Object()
        {
            //Arrang
            object parameters = new { id = 1 };
            string query = "SELECT * FROM Profil WHERE ProfilID = @id";
            // Act
            var result = await  _repository.FromSqlRawAsync(query, parameters);

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void GetAll_Should_Return_List()
        {
            //Arrang
            // Act
            var result = _repository.GetAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void FindA_Should_Return_Object()
        {
            //Arrange
           // object parameters = new { ProfilID = 1 };

            // Act
            var result = _repository.FindAsync(x => x.ProfilID ==1);

            //Assert
            Assert.NotNull(result);
        }

    }

    public class ProfileDapperDatabaeRepositorySToreProcTests
    {
        private readonly IGenericDapperRepository<Profil> _repository;
        public ProfileDapperDatabaeRepositorySToreProcTests()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");
            var Connectiongg = new SqlConnection(@"data source=CA-L7KB0VN2\SQLEXPRESS;initial catalog=GBRWBD061915;integrated security=True;MultipleActiveResultSets=True;Max Pool Size=500;");
            Connectiongg.Open();
            _repository = new GenericDapperRepository<Profil>(Connectiongg);

            // var entite = fakeDatas.GetProfil();

        }

        [Fact(Skip = "non pris en compte")]
        public async Task AddWithStoreProcAsync_Should_Return_Object()
        {
            //Arrange

            var storeProc = "sp_ProfilInsert";
            var storeProcDelete = "sp_ProfilDelete";
            var storeProcById = "sp_ProfilSelectById";
            var storeProcUpdate = "sp_ProfilUpdate";

            string paramReturn = "pn_OutProfilID";
            var param = new DynamicParameters();
            param.Add("@pc_InLibelle", "toto");
            param.Add("@pn_OutProfilID", DbType.Int32, direction: ParameterDirection.Output);

            // Act 1 add
            var profilID = await _repository.AddWithStoreProcAsync(storeProc, param, paramReturn);
            Assert.True(profilID > 0, "Id superieur a zero attendu");
            // object parameters = new { ProfilID = profilID };

            // Act 2 select
            var paramSelectId = new DynamicParameters();
            paramSelectId.Add("@pn_InProfilID", profilID);
            var profile = await _repository.GetByIdStoreProcAsync(storeProcById, paramSelectId);
            Assert.NotNull(profile);
            Assert.Equal(profilID, profile.ProfilID);
            Assert.Equal("toto", profile.Libelle);

            // Act 3 update
            profile.Libelle = "manilala";
            var paramUpdate = new DynamicParameters();
            paramUpdate.Add("@pn_InProfilID", profile.ProfilID);
            paramUpdate.Add("@pc_InLibelle", profile.Libelle);
            var op2 = await _repository.WithStoreProcAsync(storeProcUpdate, paramUpdate);
            Assert.True(op2 > 0);
            // var result = _repository.Find(parameters);

            //act 5 select byid
            var profile1 = await _repository.GetByIdStoreProcAsync(storeProcById, paramSelectId);
            Assert.NotNull(profile1);
            Assert.Equal(profile.Libelle, profile1.Libelle);

            //Act 6 delete
            var paramDelete = new DynamicParameters();
            paramDelete.Add("@pn_InProfilID", profilID);
            await _repository.WithStoreProcAsync(storeProcDelete, paramDelete);

            Assert.Null(await _repository.GetByIdStoreProcAsync(storeProcById, paramSelectId));

        }

        [Fact(Skip = "non pris en compte")]
        public async Task AddWithStoreProcAsync_Delete_Should_Return_Object()
        {
            var storeProcDelete = "sp_ProfilDelete";
            var storeProcById = "sp_ProfilSelectById";
            var profilID = 13;

            var paramDelete = new DynamicParameters();
            paramDelete.Add("@pn_InProfilID", profilID);
            await _repository.WithStoreProcAsync(storeProcDelete, paramDelete);

            var paramSelectId = new DynamicParameters();
            paramSelectId.Add("@pn_InProfilID", profilID);

            Assert.Null(await _repository.GetByIdStoreProcAsync(storeProcById, paramSelectId));

        }

        [Fact(Skip = "non pris en compte")]
        public async Task AddWithStoreProcAsync_QUeryMultiple_Should_Return_Object()
        {
            var param = new DynamicParameters();
            var queries = @"SELECT * FROM Profil where ProfilID= @ProfilID;
                          SELECT *FROM Utilisateur  where ProfilID= @ProfilID;";
            //var paramDelete = new DynamicParameters();
            param.Add("@ProfilID", 1);
            GridReader result = await _repository.GetAllMultiAsync(queries, param);
            Assert.NotNull(result);



            var profiles = result.ReadSingle<Profil>();
            var users = result.Read<Utilisateur>();

            Assert.NotNull(profiles);


        }

    }

}
