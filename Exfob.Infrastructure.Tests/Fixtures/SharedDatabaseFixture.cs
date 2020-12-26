using Exfob.Models.Administration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Exfob.Infrastructure.Tests.Fixtures
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=gbwebdbTeste;ConnectRetryCount=0");
           // Connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=|DataDirectory|\gbwebteste.mdf");
            //Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\Data\MyDB1.mdf
            Seed();

            Connection.Open();
        }

        public DbConnection Connection { get; }
        public GestionBoisContext Contexte { get; set; }

        public GestionBoisContext CreateContext(DbTransaction transaction = null)
        {

            var sqlServerDboptions = new DbContextOptionsBuilder<GestionBoisContext>(
                ).UseSqlServer(Connection)
                .Options;

            Contexte = new GestionBoisContext(sqlServerDboptions);

            if (transaction != null)
            {
                Contexte.Database.UseTransaction(transaction);
            }

            return Contexte;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.Profils.Add(new Profil { Libelle = "Fr" });
                        context.Langues.Add(new Langue { Code = "", Libelle = "" });
                        context.NatureSites.Add(new NatureSite { Code = "st", Libelle = "site" });
                        context.Groupes.Add(new Groupe { Code = "st", Libelle = "site" });
                        context.Sieges.Add(new Siege { Code = "st", Libelle = "site", GroupeID = 1, Adresse = "Adresse2365" });
                        context.Societes.Add(new Societe
                        {

                            SiegeID = 1,
                            NumIdentite = "NumIdentite123",
                            Code = "st",
                            Libelle = "site",
                            Description = "",
                            Adresse = "",
                            BoitePostale = ""
                        });
                        context.SaveChanges();

                        context.Pays.Add(new Pays { SocieteID = 1, CodePays = "", CodePostal = "st", NomPays = "site" });
                        context.SiteOperations.Add(new SiteOperation
                        {

                            NatureSiteID = 1,
                            PaysID = 1,
                            SiegeID = 1,
                            SocieteID = 1,
                            Libelle = "Libelle123",
                            Code = "Code222",
                            Adresse = "Adresse222",
                            Activite = true,

                        });

                        context.SaveChanges();

                        var user1 = new Utilisateur
                        {

                            LangueID = 1,
                            ProfilID = 1,
                            SiteOperationID = 1,
                            LoginUtilisateur = "Teste",
                            MotPasseHash = "eee",
                            SelMotdePasse = "",
                            Email = "xxx@yahoo.fr",
                            CreerPar = "dd",
                            Matricule = "Matricule123",
                            Nom = "Nom123",
                            Fonction = "Fonction123",
                            EstActif = true,


                        };
                        //  if (!context.Utilisateurs.Any())
                        context.Utilisateurs.AddRange(user1);



                        context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }


        // public void Dispose() => Connection.Dispose();
        public void Dispose() => Contexte.Dispose();

    }
}
