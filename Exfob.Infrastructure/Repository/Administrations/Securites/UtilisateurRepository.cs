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
            string query = "SELECT * FROM [Utilisateur] WHERE SiteOperationID=@SiteOperationID";
            return await this.GetDataAsync(query, parameters);
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
 select * from #TMP_SITEAUTH
SELECT SiegeID,GroupeID,Code,Libelle FROM Siege
	   WHERE SiegeID  =(select top(1) SiegeID  from #TMP_SITEOPS);
 	  
";
            if(user != null)
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
            //var entity = dataset.ReadSingle<Utilisateur>();
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
                    Profile = Mappprofile(_profile, _droits),
                    Langue = MapppLangue(_langue),
                    SiteOperation = MapppSiteOperation(_siteops, _societe),
                    SiteOperationsAuthoriser = MapppSiteAuthorizer(_siteauths, _profleauthzs)
                };

            }


            return model;

        }

        private ProfileLoginModel Mappprofile(Profil entity, IEnumerable<Droit> entities)
        {
            ProfileLoginModel model = null;
            //var entity = dataset.ReadSingle<Profil>();
            if (entity != null)
            {
                model = new ProfileLoginModel
                {
                    ProfilID = entity.ProfilID,
                    Libelle = entity.Libelle,
                    Droits = MapppDroits(entities)
                };

            }
            return model;
        }

        private List<DroitsLoginModel> MapppDroits(IEnumerable<Droit> entity)
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
                    Suppression = x.Suppression
                }));
            }
            return model;
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
            IEnumerable<ProfileAuthorizerLoginModel> profiles)
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
                    Profile = profiles.FirstOrDefault(y => y.ProfilAutoriseID == x.ProfilAutoriseID)
                }));
            }
            return models;
        }
        #endregion

    }
}
