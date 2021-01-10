using Dapper;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Exfob.Infrastructure.Repository.Administrations.Securites
{
    public class UtilisateurRepository : GenericDapperRepository<Utilisateur>, IUtilisateurRepository
    {
        private IDbConnection _connection;

        #region Constructor
        public UtilisateurRepository(DbConnection context)
           : base(context)
        {
            _connection = context;
        }
        #endregion

        #region Public Methods

        public async Task<Utilisateur> GetById(int Id)
        {
            string query = "SELECT * FROM Utilisateur WHERE UtilisateurID = @id";

            var queries = @"SELECT * FROM Profil WHERE ProfilID=@ProfilID ;
SELECT * FROM Langue WHERE LangueID =@LangueID 
SELECT * FROM SiteOperation WHERE SiteOperationID =@SiteOperationID;
";
            // var user = await this.GetById(Id);
            var result = await this.GetDataAsync(query, new { id = Id });
            var user = result.FirstOrDefault();
            if (user != null)
            {
                var param = new DynamicParameters();
                param.Add("@ProfilID", user.ProfilID);
                param.Add("@LangueID", user.LangueID);
                param.Add("@SiteOperationID", user.SiteOperationID);
                var dataset = await this.GetAllMultiAsync(queries, param);

                var _profile = dataset.ReadSingle<Profil>();
                if (_profile != null)
                {
                    user.Profil = _profile;
                }
                var _langue = dataset.ReadSingle<Langue>();
                if (_langue != null)
                {
                    user.Langue = _langue;
                }
                var _siteops = dataset.ReadSingle<SiteOperation>();
                if (_siteops != null)
                {
                    user.SiteOperation = _siteops;
                }

            }
            return user;
        }

        public async Task<UtilisateurEdit> GetEditById(int Id, int societeId)
        {
            var entitty = new UtilisateurEdit();
            var queries = @"SELECT * FROM [Utilisateur] WHERE UtilisateurID=@Id
SELECT * FROM Profil ;
SELECT * FROM Langue ;
SELECT * FROM SiteOperation WHERE SocieteID =@societeId;
";
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            param.Add("@societeId", societeId);
            var dataset = await this.GetAllMultiAsync(queries, param);
            entitty.Utilisateur = dataset.ReadSingle<Utilisateur>();
            var profiles = dataset.Read<Profil>();
            if (profiles.Any())
            {
                entitty.Profiles = new List<Profil>();
                entitty.Profiles.AddRange(profiles);
            }

            var langues = dataset.Read<Langue>();
            if (langues.Any())
            {
                entitty.Langues = new List<Langue>();
                entitty.Langues.AddRange(langues);
            }
            var siteOps = dataset.Read<SiteOperation>();

            if (siteOps.Any())
            {
                entitty.SiteOperations = siteOps.Select(x => new SiteOperationForListe
                {
                    SiteOperationID = x.SiteOperationID,
                    Code = x.Code,
                    Libelle = x.Libelle
                }).ToList();
            }

            return entitty;
        }

        public async Task<IEnumerable<Utilisateur>> GetListe(int siteOperationid)
        {

            object parameters = new { SiteOperationID = siteOperationid };
            var param = new DynamicParameters();
            param.Add("@SiteOperationID", siteOperationid);

            string query = @"SELECT * FROM [Utilisateur] WHERE SiteOperationID=@SiteOperationID;
SELECT * FROM Profil ;
SELECT * FROM Langue ;
";
            var dataset = await this.GetAllMultiAsync(query, param);
            var users = dataset.Read<Utilisateur>();
            var profiles = dataset.Read<Profil>();
            var langues = dataset.Read<Langue>();
            if (users != null)
            {
                foreach (var user in users)
                {
                    if (user.LangueID.HasValue)
                    {
                        var langue = langues.FirstOrDefault(x => x.LangueID == user.LangueID);
                        if (langue != null)
                            user.Langue = langue;
                    }

                    if (user.ProfilID > 0)
                    {
                        var profile = profiles.FirstOrDefault(x => x.ProfilID == user.ProfilID);
                        user.Profil = profile;
                    }

                }

            }


            return users;
        }

        public async Task<int> Creation(Utilisateur entity)
        {
            entity.DateCreation = DateTime.Now;
            string insQuery = $@"INSERT INTO [Utilisateur]
      ([SiteOperationID]
       ,[ProfilID]
       , [Nom]
       , [LoginUtilisateur]
       , [MotPasseHash]
       , [SelMotdePasse]
       , [Email]
       , [Matricule]
       , [Fonction]
       , [EstActif]
        ,[LangueID]
        ,[DateCreation]
        ,[CreerPar]) 
        VALUES(
      @{nameof(Utilisateur.SiteOperationID)}
      ,@{nameof(Utilisateur.ProfilID)}
      ,@{nameof(Utilisateur.Nom)}
      ,@{nameof(Utilisateur.LoginUtilisateur)}
      ,@{nameof(Utilisateur.MotPasseHash)}
      ,@{nameof(Utilisateur.SelMotdePasse)}
      ,@{nameof(Utilisateur.Email)}
      ,@{nameof(Utilisateur.Matricule)}
      ,@{nameof(Utilisateur.Fonction)}
      ,@{nameof(Utilisateur.EstActif)}
	  ,@{nameof(Utilisateur.LangueID)}
	  ,@{nameof(Utilisateur.DateCreation)}
	  ,@{nameof(Utilisateur.CreerPar)})";

            object inParameters = new
            {
                entity.SiteOperationID,
                entity.ProfilID,
                entity.Nom,
                entity.LoginUtilisateur,
                entity.MotPasseHash,
                entity.SelMotdePasse,
                entity.Email,
                entity.Matricule,
                entity.Fonction,
                entity.EstActif,
                entity.LangueID,
                entity.DateCreation,
                entity.CreerPar
            };
            var id = await this.AddScalarAsync(insQuery, inParameters);
            return id;
        }


        public async Task Update(Utilisateur entity)
        {
            entity.DateMisejour = DateTime.Now;
            string insQuery = $@" UPDATE [Utilisateur] SET
     [SiteOperationID] = @{nameof(Utilisateur.SiteOperationID)},
     [ProfilID] =@{nameof(Utilisateur.ProfilID)},
     [Nom] =@{nameof(Utilisateur.Nom)},
     [LoginUtilisateur] =@{nameof(Utilisateur.LoginUtilisateur)},
     [Email] =@{nameof(Utilisateur.Email)},
     [Matricule] = @{nameof(Utilisateur.Matricule)},
     [Fonction] = @{nameof(Utilisateur.Fonction)},
     [EstActif] = @{nameof(Utilisateur.EstActif)},
	 [LangueID] = @{nameof(Utilisateur.LangueID)},
	 [DateMisejour] = @{nameof(Utilisateur.DateMisejour)},
	 [MiseJourPar] = @{nameof(Utilisateur.MiseJourPar)}
     WHERE UtilisateurID=@{nameof(Utilisateur.UtilisateurID)}
      ";

            object inParameters = new
            {
                entity.UtilisateurID,
                entity.SiteOperationID,
                entity.ProfilID,
                entity.Nom,
                entity.LoginUtilisateur,
                entity.Email,
                entity.Matricule,
                entity.Fonction,
                entity.EstActif,
                entity.LangueID,
                entity.DateMisejour,
                entity.MiseJourPar
            };
            await this.UpdateWithScriptAsync(insQuery, inParameters);

        }

        public async Task UpdatePassWord(int UtilisateurID, string NewPassWord, string MisejourPar)
        {
            string insQuery = $@" UPDATE [Utilisateur] SET
     [MotPasseHash] = @{nameof(Utilisateur.MotPasseHash)},
     [SelMotdePasse] = @{nameof(Utilisateur.SelMotdePasse)},
     [DateMisejour] = @{nameof(Utilisateur.DateMisejour)},
	 [MiseJourPar] = @{nameof(Utilisateur.MiseJourPar)},
     WHERE UtilisateurID=@{nameof(Utilisateur.UtilisateurID)}
      ";

            object inParameters = new
            {
                UtilisateurID,
                MotPasseHash = NewPassWord,
                SelMotdePasse = NewPassWord,
                DateMisejour = DateTime.Now,
                MiseJourPar = MisejourPar
            };
            await this.UpdateWithScriptAsync(insQuery, inParameters);

        }

        public async Task UpdateActivateAccount(int UtilisateurID, bool EstActif, string MisejourPar)
        {
            string insQuery = $@" UPDATE [Utilisateur] SET
     [EstActif] = @{nameof(Utilisateur.EstActif)},
     [DateMisejour] = @{nameof(Utilisateur.DateMisejour)},
	 [MiseJourPar] = @{nameof(Utilisateur.MiseJourPar)},
     WHERE UtilisateurID=@{nameof(Utilisateur.UtilisateurID)}
      ";

            object inParameters = new
            {
                UtilisateurID,
                EstActif = EstActif,
                DateMisejour = DateTime.Now,
                MiseJourPar = MisejourPar
            };
            await this.UpdateWithScriptAsync(insQuery, inParameters);

        }

        public async Task Delete(int id)
        {
            object inParameters = new { UtilisateurID = id };
            await this.RemoveAsync(inParameters);
        }

        public async Task<UtilisateurLoginModel> GetLoggin(string NomUtilisateur, string MotPasse)
        {
            UtilisateurLoginModel entitty = null;
            var queryUser = @"SELECT *  FROM [Utilisateur] 
WHERE LoginUtilisateur=@NomUtilisateur AND SelMotdePasse=@MotPasse AND EstActif = 1";

            var result = await this.GetDataAsync(queryUser, new { NomUtilisateur, MotPasse });
            var user = result.FirstOrDefault();

            var queries = @"SELECT * FROM Profil  WHERE ProfilID=@ProfilID;
SELECT * FROM Langue WHERE LangueID=@LangueID ;
SELECT SiteOperationID,SiegeID,SocieteID,NatureSiteID,Code,Libelle,Adresse INTO #TMP_SITEOPS FROM SiteOperation
	  WHERE SiteOperationID=@SiteOperationID;
 SELECT * from #TMP_SITEOPS;
SELECT SocieteID,Code,Libelle,EstPeriodeCloture FROM Societe
	   WHERE SocieteID  =(select top(1) SocieteID  from #TMP_SITEOPS);
SELECT dr.*,mo.Libelle 
	   FROM Droit dr inner join Module mo
	   On dr.ModuleID =mo.ModuleID 
	   WHERE ProfilID =@ProfilID ;
SELECT sa.SiteAutoriseID,
	  sa.UtilisateurID  ,
	  pfauth.Libelle as ProfileAuthoriser,
	  st.code,
	  st.Libelle,
	  st.Adresse,
	  sa.SiteOperationID,
	  dra.*
	  ,md.Libelle as module
	 INTO #TMP_SITEAUTH
	 FROM SiteAutorise sa inner join ProfilAutorise pfauth
	  ON pfauth.ProfilAutoriseID =sa.ProfilAutoriseID left outer join SiteOperation st
	  ON st .SiteOperationID =sa.SiteOperationID left outer join DroitAutorise dra
	  ON dra.ProfilAutoriseID =sa.ProfilAutoriseID left outer join  Module md
	  ON md.ModuleID =dra.ModuleID 
	  WHERE sa.UtilisateurID=@UtilisateurID;
select distinct SiteAutoriseID,ProfilAutoriseID,ProfileAuthoriser as ProfilAutorise,SiteOperationID,code, Libelle,Adresse from #TMP_SITEAUTH;
select distinct ProfilAutoriseID as ProfilAutoriseID,ProfileAuthoriser as Libelle from #TMP_SITEAUTH;
SELECT * FROM Module;
 select * from #TMP_SITEAUTH;
SELECT SiegeID,GroupeID,Code,Libelle FROM Siege
	   WHERE SiegeID  =(select top(1) SiegeID  from #TMP_SITEOPS);
 	  
";
            if (user != null)
            {
                entitty = new UtilisateurLoginModel();

                var param = new DynamicParameters();
                param.Add("@ProfilID", user.ProfilID);
                param.Add("@LangueID", user.LangueID);
                param.Add("@SiteOperationID", user.SiteOperationID);
                param.Add("@UtilisateurID", user.UtilisateurID);
                var dataset = await this.GetAllMultiAsync(queries, param);
                entitty = MappeUser(dataset, user);
            }
            //UPDATE Utilisateur SET dateconnection=Getdate() Where UtilisateurID =(select top(1) UtilisateurID from #TMP_USER) 

            string updateQuery = $@" UPDATE [Utilisateur] SET
     [dateconnection] = @{nameof(Utilisateur.DateConnection)}
     WHERE UtilisateurID=@{nameof(Utilisateur.UtilisateurID)}
      ";

            object inParameters = new
            {
                entitty.UtilisateurID,
                DateConnection = DateTime.Now,

            };

            await this.UpdateWithScriptAsync(updateQuery, inParameters);
            return entitty;
        }
        #endregion

        #region Private Metods
        private UtilisateurLoginModel MappeUser(GridReader dataset, Utilisateur entity)
        {
            UtilisateurLoginModel model = null;
            var _profile = dataset.ReadSingleOrDefault<Profil>();
            var _langue = dataset.ReadSingle<Langue>();
            var _siteops = dataset.ReadSingle<SiteOperation>();
            var _societe = dataset.ReadSingle<Societe>();
            var _droits = dataset.Read<Droit>();
            var _siteauths = dataset.Read<SiteOperationsAuthorizerLoginModel>();
            var _profleauthzs = dataset.Read<ProfileAuthorizerLoginModel>();
            var _modules = dataset.Read<Module>();
            var _alldatas = dataset.Read<SiteAthurizedAll>();

            if (entity != null)
            {
                model = new UtilisateurLoginModel
                {
                    UtilisateurID = entity.UtilisateurID,
                    Email = entity.Email,
                    EstActif = entity.EstActif,
                    LangueID = entity.LangueID.Value,
                    ProfilID = entity.ProfilID,
                    LoginUtilisateur = entity.LoginUtilisateur,
                    Nom = entity.Nom,
                    SiteOperationID = entity.SiteOperationID.Value,
                    Profile = Mappprofile(_profile, _droits, _modules),
                    Langue = MapppLangue(_langue),
                    SiteOperation = MapppSiteOperation(_siteops, _societe),
                    SiteOperationsAuthorises = MapppSiteAuthorizer(_siteauths, _profleauthzs, _alldatas, _modules)

                };

            }


            return model;

        }

        private ProfileLoginModel Mappprofile(Profil entity, IEnumerable<Droit> entities, IEnumerable<Module> modules)
        {
            ProfileLoginModel model = null;
            //var entity = dataset.ReadSingle<Profil>();
            if (entity != null)
            {
                model = new ProfileLoginModel
                {
                    ProfilID = entity.ProfilID,
                    Libelle = entity.Libelle,
                    Droits = MapppDroits(entities, modules)
                };

            }
            return model;
        }

        private List<DroitsLoginModel> MapppDroits(IEnumerable<Droit> entity, IEnumerable<Module> modules)
        {
            List<DroitsLoginModel> model = null;
            //var entity = dataset.Read<Droit>();
            if (entity.Any())
            {
                model = new List<DroitsLoginModel>();
                model.AddRange(entity.Select(x => new DroitsLoginModel
                {
                    DroitID = x.DroitID,
                    Ecriture = x.Ecriture,
                    Impression = x.Impression,
                    Lecture = x.Lecture,
                    Modifier = x.Modifier,
                    ModuleID = x.ModuleID,
                    ProfilID = x.ProfilID,
                    Suppression = x.Suppression,
                    Module = GetModule(modules, x.ModuleID)
                }));
            }
            return model;
        }

        ModuleLoginModel GetModule(IEnumerable<Module> modules, int ModuleID)
        {
            var module = modules.FirstOrDefault(x => x.ModuleID == ModuleID);
            if (module != null)
            {
                return new ModuleLoginModel { ModuleID = module.ModuleID, Libelle = module.Libelle, ModuleParentID = module.ModuleParentID };
            }
            return null;
        }

        private LangueLoginModel MapppLangue(Langue entity)
        {
            LangueLoginModel model = null;
            //var entity = dataset.ReadSingle<Langue>();
            if (entity != null)
            {
                model = new LangueLoginModel
                {
                    LangueID = entity.LangueID,
                    Libelle = entity.Libelle,
                    Code = entity.Code
                };
            }
            return model;
        }

        private SiteOperationLoginModel MapppSiteOperation(SiteOperation entity, Societe societe)
        {
            SiteOperationLoginModel model = null;
            //var entity = dataset.ReadSingle<SiteOperation>();
            if (entity != null)
            {
                model = new SiteOperationLoginModel
                {
                    SiteOperationID = entity.SiteOperationID,
                    Libelle = entity.Libelle,
                    Code = entity.Code,
                    Adresse = entity.Adresse,
                    NatureSiteID = entity.NatureSiteID,
                    SiegeID = entity.SiegeID,
                    Societe = MapppSociete(societe)
                };
                if (entity.SiegeID != null)
                {
                    //model.Siege = MapppSiege(dataset);
                }
            }
            return model;
        }

        private SocieteLoginModel MapppSociete(Societe entity)
        {
            SocieteLoginModel model = null;
            if (entity != null)
            {
                model = new SocieteLoginModel
                {
                    SocieteID = entity.SocieteID,
                    Libelle = entity.Libelle,
                    Code = entity.Code,
                    EstPeriodeCloture = entity.EstPeriodeCloture,
                    SiegeID = entity.SiegeID
                };
            }
            return model;
        }

        private SiegeLoginModel MapppSiege(GridReader dataset)
        {
            SiegeLoginModel model = null;
            var entity = dataset.ReadSingle<Siege>();
            if (entity != null)
            {
                model = new SiegeLoginModel
                {
                    GroupeID = entity.GroupeID,
                    Libelle = entity.Libelle,
                    Code = entity.Code,
                    SiegeID = entity.SiegeID
                };
            }
            return model;
        }

        private List<SiteOperationsAuthorizerLoginModel> MapppSiteAuthorizer(
            IEnumerable<SiteOperationsAuthorizerLoginModel> entity,
            IEnumerable<ProfileAuthorizerLoginModel> profiles,
             IEnumerable<SiteAthurizedAll> siteauthall,
              IEnumerable<Module> modules
            )
        {
            List<SiteOperationsAuthorizerLoginModel> models = null;
            // var entity = dataset.ReadSingle<Siege>();
            if (entity.Any())
            {
                models = new List<SiteOperationsAuthorizerLoginModel>();
                models.AddRange(entity.Select(x => new SiteOperationsAuthorizerLoginModel
                {
                    SiteAutoriseID = x.SiteAutoriseID,
                    ProfilAutoriseID = x.ProfilAutoriseID,
                    SiteOperationID = x.SiteOperationID,
                    Code = x.Code,
                    Libelle = x.Libelle,
                    Adresse = x.Adresse,
                    Profile = MappProfileAuth(profiles, x.ProfilAutoriseID, siteauthall, modules, x.SiteAutoriseID)

                }));
            }
            return models;
        }

        ProfileAuthorizerLoginModel MappProfileAuth(IEnumerable<ProfileAuthorizerLoginModel> profiles, int ProfilAutoriseID,
            IEnumerable<SiteAthurizedAll> siteauthall,
             IEnumerable<Module> modules, int SiteAutoriseID)
        {
            var profile = profiles.FirstOrDefault(y => y.ProfilAutoriseID == ProfilAutoriseID);
            profile.DroitsAuthoriser = MapppDroitsAuthorizes(siteauthall, modules, SiteAutoriseID);
            return profile;
        }
        //.DroitsAuthoriser= MapppDroitsAuthorizes(siteauthall, modules)
        private List<DroitsAuthorizerLoginModel> MapppDroitsAuthorizes(IEnumerable<SiteAthurizedAll> entity, IEnumerable<Module> modules
            , int SiteAutoriseID)
        {
            List<DroitsAuthorizerLoginModel> model = null;
            if (entity.Any())
            {
                model = new List<DroitsAuthorizerLoginModel>();
                var query = from x in entity
                            where x.SiteAutoriseID == SiteAutoriseID
                            select new DroitsAuthorizerLoginModel
                            {
                                DroitAutoriseID = x.DroitAutoriseID,
                                Ecriture = x.Ecriture,
                                Impression = x.Impression,
                                Lecture = x.Lecture,
                                Modifier = x.Modifier,
                                ModuleID = x.ModuleID,
                                ProfilAutoriseID = x.ProfilAutoriseID,
                                Suppression = x.Suppression,
                                ModuleLibelle = GetModuleAutho(modules, x.ModuleID)
                            };

                model.AddRange(query);
            }
            return model;
        }

        string GetModuleAutho(IEnumerable<Module> modules, int ModuleID)
        {
            var module = modules.FirstOrDefault(x => x.ModuleID == ModuleID);
            if (module != null)
            {
                return module.Libelle ;
            }
            return null;
        }
        #endregion

    }

    public class SiteAthurizedAll
    {
        public int SiteAutoriseID { get; set; }
        public int UtilisateurID { get; set; }
        public string ProfilAutorise { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public int SiteOperationID { get; set; }
        public int DroitAutoriseID { get; set; }

        public int ProfilAutoriseID { get; set; }

        public int ModuleID { get; set; }

        public bool Ecriture { get; set; }

        public bool Lecture { get; set; }

        public bool Modifier { get; set; }

        public bool Suppression { get; set; }

        public bool Impression { get; set; }

        public string Module { get; set; }

    }
}
