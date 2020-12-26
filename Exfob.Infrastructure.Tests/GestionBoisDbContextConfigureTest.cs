using Exfob.Models.Administration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Tests
{
    public class GestionBoisDbContextConfigureTest: IDisposable
    {
        private readonly DbContextOptions<GestionBoisContext> ContextOptions;
        protected GestionBoisContext _context { get; }


        public GestionBoisDbContextConfigureTest()
        {
            ContextOptions = new DbContextOptionsBuilder<GestionBoisContext>()
               .UseSqlite("Filename=Test.db")
               .Options;
            _context = new GestionBoisContext(ContextOptions);
           
           // SeedAsync() ; 
        }

        private  void  SeedAsync()
        {
           using (var context = new GestionBoisContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Profils.Add(new Profil { ProfilID = 1, Libelle = "Fr" });
                    context.Langues.Add(new Langue { LangueID = 1, Code = "", Libelle = "" });
            
                    context.NatureSites.Add(new NatureSite { NatureSiteID = 1, Code = "st", Libelle = "site" });
                    context.Groupes.Add(new Groupe { GroupeID = 1, Code = "st", Libelle = "site" });
                    context.Sieges.Add(new Siege { SiegeID = 1, Code = "st", Libelle = "site", GroupeID = 1, Adresse = "Adresse2365" });
                    context.Societes.Add(new Societe
                {
                    SocieteID = 1,
                    SiegeID = 1,
                    NumIdentite = "NumIdentite123",
                    Code = "st",
                    Libelle = "site",
                    Description = "",
                    Adresse = "",
                    BoitePostale = ""
                });
                    context.Pays.Add(new Pays { PaysID = 1, SocieteID = 1, CodePays = "", CodePostal = "st", NomPays = "site" });
                    context.SiteOperations.Add(new SiteOperation
                {
                    SiteOperationID = 1,
                    NatureSiteID = 1,
                    PaysID = 1,
                    SiegeID = 1,
                    SocieteID = 1,
                    Libelle = "Libelle123",
                    Code = "Code222",
                    Adresse = "Adresse222",
                    Activite = true,

                });

                var user1 = new Utilisateur
                {
                    UtilisateurID = 1,
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
                 context.Utilisateurs.AddRange(user1);
                 context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
