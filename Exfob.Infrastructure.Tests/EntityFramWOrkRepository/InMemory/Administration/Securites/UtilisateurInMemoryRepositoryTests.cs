using Exfob.Core.Interfaces.Repository;
using Exfob.Infrastructure.Repository;
using Exfob.Models.Fakes;
using Exfob.Infrastructure.Tests.Fixtures;
using Exfob.Models.Administration;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Exfob.Core.Interfaces.Administrations.Securites;
using System.IO;
using Microsoft.Data.SqlClient;
using Exfob.Infrastructure.Repository.Administrations.Securites;

namespace Exfob.Infrastructure.Tests.EntityFramWOrkRepository.InMemory.Administration.Securites
{
    public class UtilisateurInMemoryRepositoryTests : IClassFixture<SqliteInMemoryGestionBoisContextTest>
    {
        private IGenericRepository<Utilisateur> _repository;
        private UtilisateurRepository _repository1;
        public SqliteInMemoryGestionBoisContextTest Fixture { get; }
        GestionBoisDataTestesFakes fakeDatas = new GestionBoisDataTestesFakes();
        public UtilisateurInMemoryRepositoryTests(SqliteInMemoryGestionBoisContextTest fixture) => Fixture = fixture;


        [Fact]
        public async Task GetAllAsync_Should_Return_List()
        {
            //Arrang
            int expected = 1;
            _repository1 = new UtilisateurRepository(Fixture._connection);

            //using (var context = Fixture.CreateContext())
            // {
            //  _repository = new GenericRepository<Utilisateur>(context);

            //Arrange

            var result = await _repository1.GetAllAsync();

            //Assert
            Assert.True(result.Any());
            Assert.Equal(expected, result.ToList().Count);
            Assert.Null(result.First().Profil);
            Assert.Null(result.First().Langue);
            Assert.Null(result.First().SiteOperation);
            // }
        }

        [Fact]
        public void GetAllIncluding_Should_Return_List_With_Includes()
        {
            //Arrang
            int expected = 1;
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = _repository.GetAllIncluding(x => x.Profil, x => x.Langue, x => x.SiteOperation);

                //Assert
                Assert.True(result.Any());
                Assert.Equal(expected, result.ToList().Count);
                Assert.NotNull(result.First().Profil);
                Assert.NotNull(result.First().Langue);
                Assert.NotNull(result.First().SiteOperation);
            }
        }



        [Fact]
        public void GetAllMatched_Should_Return_List_BySiteOps()
        {
            //Arrang
            int SiteOperationID = 1;
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = _repository.GetAllMatched(x => x.SiteOperationID == SiteOperationID);

                //Assert

                Assert.True(result.Any());
            }
        }

        [Fact]
        public void GetAllMatched_Should_Return_Empty_List_BySiteOps()
        {
            //Arrang
            int SiteOperationID = 100;
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = _repository.GetAllMatched(x => x.SiteOperationID == SiteOperationID);

                //Assert
                Assert.False(result.Any());
            }
        }

        [Fact]
        public async Task FindAllAsync_Should_Return_List_BySiteOps()
        {
            //Arrang
            int SiteOperationID = 10;
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = await _repository.FindAllAsync(x => x.SiteOperationID == SiteOperationID);

                //Assert
                Assert.False(result.Any());
            }
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_null_Utilisateur()
        {
            //Arrang
            int utilisateurID = 10;

            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = await _repository.GetByIdAsync(utilisateurID);

                //Assert

                Assert.Null(result);
            }

        }

        [Fact]
        public async Task AddAsync_Should_Return_success_Utilisateur()
        {
            //Arrang
            var user1 = new Utilisateur
            {
                UtilisateurID = 0,
                LangueID = 1,
                ProfilID = 1,
                SiteOperationID = 1,
                LoginUtilisateur = "LoginUtilisateur123",
                MotPasseHash = "MotPasseHash23",
                SelMotdePasse = "SelMotdePasse563",
                Email = "teste@yahoo.fr",
                CreerPar = "dd",
                Matricule = "Matricule123",
                Nom = "Nom123",
                Fonction = "Fonction123",
                EstActif = true,
            };
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = await _repository.AddAsync(user1, saveChanges: true);

                //Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_success_Utilisateur()
        {
            //Arrang
            var user1 = fakeDatas.GetUtilisateur();
            user1.Nom = "Nom233337";
            user1.LoginUtilisateur = "LoginUtilisateur233337";
            user1.MotPasseHash = "MotPasseHash233337";
            user1.SelMotdePasse = "SelMotdePasse233337";
            user1.Email = "Email233337";
            user1.Matricule = "Matricule233337";

            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = await _repository.AddAsync(user1, saveChanges: true);

                //Assert
                Assert.NotNull(result);
            }

            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                var user = await _repository.GetByIdAsync(user1.UtilisateurID);

                user.Email = "xx@g.com";
                user.Matricule = "Matxx";

                // Act
                await _repository.UpdateAsync(user, saveChanges: true);

                var actual = await _repository.GetByIdAsync(user1.UtilisateurID);

                //Assert
                Assert.Equal(user.Email, actual.Email);
                Assert.Equal(user.Matricule, actual.Matricule);
            }
        }

        [Fact]
        public async Task UpdateAsync_ById_Should_Return_success_Utilisateur()
        {
            //Arrang
            int userid = 1;
            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);


                var user = await _repository.GetByIdAsync(userid);

                // Act
                await _repository.UpdateAsync(user, userid, saveChanges: true);

                //Assert
            }
        }



        [Fact]
        public async Task DeleteAsync_Should_Return_success_Utilisateur()
        {
            //Arrang
            int userid = 1;



            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                var user = await _repository.GetByIdAsync(userid);

                // Act
                await _repository.DeleteAsync(user, saveChanges: true);

                //Assert
            }
        }

        [Fact]
        public async Task DeleteAsync_ById_Should_Return_success_Utilisateur()
        {
            //Arrang
            var user1 = fakeDatas.GetUtilisateur();
            user1.Nom = "Nom23333";
            user1.LoginUtilisateur = "LoginUtilisateur23333";
            user1.MotPasseHash = "MotPasseHash23333";
            user1.SelMotdePasse = "SelMotdePasse23333";
            user1.Email = "Email23333";
            user1.Matricule = "Matricule23333";

            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                var result = await _repository.AddAsync(user1, saveChanges: true);

                //Assert
                Assert.NotNull(result);
            }

            using (var context = Fixture.CreateContext())
            {
                _repository = new GenericRepository<Utilisateur>(context);

                // Act
                await _repository.DeleteAsync(user1.UtilisateurID, saveChanges: true);

                //Assert
                Assert.Null(await _repository.GetByIdAsync(user1.UtilisateurID));
            }
        }
    }

    public class UtilisateurInMemoryLoginRepositoryTests : IClassFixture<SqliteInMemoryGestionBoisContextTest>
    {
        private IUtilisateurRepository _repository;
        public UtilisateurInMemoryLoginRepositoryTests()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");
            var Connectiongg = new SqlConnection(@"server=tcp:exfob.database.windows.net,1433;Initial Catalog=GBRWBD061915;Persist Security Info=False;User ID=exfobuser;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            Connectiongg.Open();
            _repository = new UtilisateurRepository(Connectiongg);
        }


        [Fact]
        public async Task LogginAsync_WIth_AuthorizedSitedShould_Return_Object()
        {

            //act
            var result = await _repository.GetLoggin("admin.admin", "sa.admin");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("admin.admin", result.LoginUtilisateur);
            Assert.NotNull(result.Profile);
            Assert.NotNull(result.Profile.Droits);
            Assert.NotNull(result.Langue);
            Assert.NotNull(result.SiteOperation);
            Assert.NotNull(result.SiteOperation.Societe);
            Assert.NotNull(result.SiteOperationsAuthorises);

        }

        [Fact(Skip = "non pris en compte")]
        public async Task LoginAsync_WithoutSithAuth_Should_Return_Object()
        {

            //act
            var result = await _repository.GetLoggin("serges.abaze", "alltech.admin");

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Profile);
            Assert.NotNull(result.Profile.Droits);
            Assert.NotNull(result.Langue);
            Assert.NotNull(result.SiteOperation);
            Assert.NotNull(result.SiteOperation.Societe);
            Assert.Null(result.SiteOperationsAuthorises);

        }

        [Fact(Skip = "non pris en compte")]
        public async Task LoginAsync_Error_Should_Return_Null()
        {

            //act
            var result = await _repository.GetLoggin("serges", "alltech");

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Profile);
            Assert.NotNull(result.Profile.Droits);
            Assert.NotNull(result.Langue);
            Assert.NotNull(result.SiteOperation);
            Assert.NotNull(result.SiteOperation.Societe);
            Assert.Null(result.SiteOperationsAuthorises);

        }

    }
}
