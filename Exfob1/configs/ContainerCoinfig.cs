﻿using AutoMapper;
using Exfob.Core.Interfaces.Administrations;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Interfaces.Repository;
using Exfob.Core.Services.Administration;
<<<<<<< HEAD
using Exfob.Infrastructure.Repository;
=======
using Exfob.Infrastructure.Repository.Administrations;
>>>>>>> fd1d453f89614d20d2c78c3655e235df17810d96
using Exfob.Infrastructure.Repository.Administrations.Securites;
using Exfob.Service.Administration.Securiter;
using Exfob.Service.Traducteurs.Administration.Securiter;
using Exfob1.Controllers.Administration;
using Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.ProfilesMappeur;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.Mappeur;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Exfob1.configs
{
    public static class ContainerCoinfig
    {
        public static void ServiceMapping(this IServiceCollection services)
        {
            services.AddTransient<IUtilisateurTraducteur, UtilisateurTraducteur>();
            services.AddAutoMapper(typeof(LangueMappeur));
            services.AddAutoMapper(typeof(ProfileMappeur));
            services.AddAutoMapper(typeof(UtilisateurMappeur));
            services.AddAutoMapper(typeof(AcconierMappeur));
            services.AddAutoMapper(typeof(AffecterEquipeMappeur));
            services.AddAutoMapper(typeof(BanqueMappeur));
            services.AddAutoMapper(typeof(CategorieBoisMappeur));
            services.AddAutoMapper(typeof(CategorieEssenceMappeur));
            services.AddAutoMapper(typeof(ChantierMappeur));
            services.AddAutoMapper(typeof(ClasseEssenceMappeur));
            services.AddAutoMapper(typeof(ClientMappeur));
            services.AddAutoMapper(typeof(ClientAdresseMappeur));
            services.AddAutoMapper(typeof(ClientConsignataireMappeur));
            services.AddAutoMapper(typeof(ClientContactMappeur));
            services.AddAutoMapper(typeof(CodePlaquetteMappeur));
            services.AddAutoMapper(typeof(CodificationMappeur));
            services.AddAutoMapper(typeof(ComptabiliteMappeur));
            services.AddAutoMapper(typeof(CompteBanqueMappeur));
            services.AddAutoMapper(typeof(CompteProduitMappeur));
            services.AddAutoMapper(typeof(CompteTiersMappeur));
            services.AddAutoMapper(typeof(ConteneurOrigineMappeur));
            services.AddAutoMapper(typeof(ContratFournisseurMappeur));
            services.AddAutoMapper(typeof(DensiteBoisMappeur));
            services.AddAutoMapper(typeof(DestinationMappeur));
            services.AddAutoMapper(typeof(DroitMappeur));
            services.AddAutoMapper(typeof(DroitAutoriseMappeur));
            services.AddAutoMapper(typeof(EquipeMappeur));
            services.AddAutoMapper(typeof(EquipeOperateurMappeur));
            services.AddAutoMapper(typeof(EssenceMappeur));
            services.AddAutoMapper(typeof(FamilleMappeur));
            services.AddAutoMapper(typeof(FournisseurMappeur));
            services.AddAutoMapper(typeof(GroupeMappeur));
            services.AddAutoMapper(typeof(LamelleChoixMappeur));
            services.AddAutoMapper(typeof(LamelleCouleurMappeur));
            services.AddAutoMapper(typeof(LangueMappeur));
            services.AddAutoMapper(typeof(LieuTransitMappeur));
            services.AddAutoMapper(typeof(ListeServiceVenteMappeur));
            services.AddAutoMapper(typeof(LoadingNavireMappeur));
            services.AddAutoMapper(typeof(MaterielMappeur));
            services.AddAutoMapper(typeof(ModeEnvoieMappeur));
            services.AddAutoMapper(typeof(ModePaiementMappeur));
            services.AddAutoMapper(typeof(ModeTransportMappeur));
            services.AddAutoMapper(typeof(ModuleMappeur));
            services.AddAutoMapper(typeof(MotifMappeur));
            services.AddAutoMapper(typeof(MoyenTransportMappeur));
            services.AddAutoMapper(typeof(NatureConteneurMappeur));
            services.AddAutoMapper(typeof(NatureMouvementMappeur));
            services.AddAutoMapper(typeof(NatureParcMappeur));
            services.AddAutoMapper(typeof(NaturePortMappeur));
            services.AddAutoMapper(typeof(NatureSiteMappeur));
            services.AddAutoMapper(typeof(NatureSiteArriveMappeur));
            services.AddAutoMapper(typeof(NavireMappeur)); 
            services.AddAutoMapper(typeof(OperateurMappeur));
            services.AddAutoMapper(typeof(ParcMappeur)); 
            services.AddAutoMapper(typeof(PaysMappeur));
            services.AddAutoMapper(typeof(PeriodeClotureMappeur)); 
            services.AddAutoMapper(typeof(PileGrumeMappeur));
            services.AddAutoMapper(typeof(PortMappeur));
            services.AddAutoMapper(typeof(PortArriveMappeur));
            services.AddAutoMapper(typeof(PortEmbarquementMappeur));
            services.AddAutoMapper(typeof(ProduitMappeur)); 
            services.AddAutoMapper(typeof(ProfilAutoriseMappeur));
            services.AddAutoMapper(typeof(QualiteBoisMappeur));
            services.AddAutoMapper(typeof(QualiteIHCMappeur));
            services.AddAutoMapper(typeof(RedevanceEtatiqueMappeur));
            services.AddAutoMapper(typeof(RotationMappeur));
            services.AddAutoMapper(typeof(SciesMappeur));
            services.AddAutoMapper(typeof(SechoirMappeur));
            services.AddAutoMapper(typeof(SectionAnalytiqueMappeur));
            services.AddAutoMapper(typeof(SepbcMappeur));
            services.AddAutoMapper(typeof(ServiceVenteMappeur));
            services.AddAutoMapper(typeof(SiegeMappeur));
            services.AddAutoMapper(typeof(SiteArriveMappeur));
            services.AddAutoMapper(typeof(SiteAutoriseMappeur));
            services.AddAutoMapper(typeof(SiteOperationMappeur));
            services.AddAutoMapper(typeof(SocieteMappeur));
            services.AddAutoMapper(typeof(SocieteMaritimeMappeur));
            services.AddAutoMapper(typeof(SousFamilleMappeur));
            services.AddAutoMapper(typeof(SousTraitanceMappeur));
            services.AddAutoMapper(typeof(StatutOperationMappeur)); 
            services.AddAutoMapper(typeof(TarifIHCMappeur));
            services.AddAutoMapper(typeof(TerminalPortMappeur));
            services.AddAutoMapper(typeof(TrancheHoraireMappeur));
            services.AddAutoMapper(typeof(TransitaireMappeur));
            services.AddAutoMapper(typeof(TransporteurMappeur));
            services.AddAutoMapper(typeof(TypeClientMappeur));
            services.AddAutoMapper(typeof(TypeEquipeMappeur));
            services.AddAutoMapper(typeof(TypeFactureMappeur));
            services.AddAutoMapper(typeof(TypeFournisseurMappeur));
            services.AddAutoMapper(typeof(TypeLongueurMappeur));
            services.AddAutoMapper(typeof(TypeMaterielMappeur));
            services.AddAutoMapper(typeof(TypeOperateurMappeur));
            services.AddAutoMapper(typeof(TypeoperationControleMappeur));
            services.AddAutoMapper(typeof(VilleMappeur));


            //Repository
            services.AddTransient<ILangueRepository, LangueRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IUtilisateurRepository>(provider => {
                return new UtilisateurRepository(provider.GetRequiredService<SqlConnection>());
            });
            services.AddTransient<IAcconierRepository, AcconierRepository>();
            services.AddTransient<IAffecterEquipeRepository, AffecterEquipeRepository>();
            services.AddTransient<IBanqueRepository, BanqueRepository>();
            services.AddTransient<ICategorieBoisRepository, CategorieBoisRepository>();
            services.AddTransient<ICategorieEssenceRepository, CategorieEssenceRepository>();
            services.AddTransient<IChantierRepository, ChantierRepository>();
            services.AddTransient<IClasseEssenceRepository, ClasseEssenceRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientAdresseRepository, ClientAdresseRepository>();
            services.AddTransient<IClientConsignataireRepository, ClientConsignataireRepository>();
            services.AddTransient<IClientContactRepository, ClientContactRepository>();
            services.AddTransient<ICodePlaquetteRepository, CodePlaquetteRepository>();
            services.AddTransient<ICodificationRepository, CodificationRepository>();
            services.AddTransient<IComptabiliteRepository, ComptabiliteRepository>();
            services.AddTransient<ICompteBanqueRepository, CompteBanqueRepository>();
            services.AddTransient<ICompteProduitRepository, CompteProduitRepository>();
            services.AddTransient<ICompteTiersRepository, CompteTiersRepository>();
            services.AddTransient<IConteneurOrigineRepository, ConteneurOrigineRepository>();
            services.AddTransient<IContratFournisseurRepository, ContratFournisseurRepository>();
            services.AddTransient<IDensiteBoisRepository, DensiteBoisRepository>();
            services.AddTransient<IDestinationRepository, DestinationRepository>();
            services.AddTransient<IDroitRepository, DroitRepository>();
            services.AddTransient<IDroitAutoriseRepository, DroitAutoriseRepository>();
            services.AddTransient<IEquipeRepository, EquipeRepository>();
            services.AddTransient<IEquipeOperateurRepository, EquipeOperateurRepository>();
            services.AddTransient<IEssenceRepository, EssenceRepository>();
            services.AddTransient<IFamilleRepository, FamilleRepository>();
            services.AddTransient<IFournisseurRepository, FournisseurRepository>();
            services.AddTransient<IGroupeRepository, GroupeRepository>();
            services.AddTransient<ILamelleChoixRepository, LamelleChoixRepository>();
            services.AddTransient<ILamelleCouleurRepository, LamelleCouleurRepository>();
            services.AddTransient<ILangueRepository, LangueRepository>();
            services.AddTransient<ILieuTransitRepository, LieuTransitRepository>();
            services.AddTransient<IListeServiceVenteRepository, ListeServiceVenteRepository>();
            services.AddTransient<ILoadingNavireRepository, LoadingNavireRepository>();
            services.AddTransient<IMaterielRepository, MaterielRepository>();
            services.AddTransient<IModeEnvoieRepository, ModeEnvoieRepository>();
            services.AddTransient<IModePaiementRepository, ModePaiementRepository>();
            services.AddTransient<IModeTransportRepository, ModeTransportRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IMotifRepository, MotifRepository>();
            services.AddTransient<IMoyenTransportRepository, MoyenTransportRepository>();
            services.AddTransient<INatureConteneurRepository, NatureConteneurRepository>();
            services.AddTransient<INatureMouvementRepository, NatureMouvementRepository>();
            services.AddTransient<INatureParcRepository, NatureParcRepository>();
            services.AddTransient<INaturePortRepository, NaturePortRepository>();
            services.AddTransient<INatureSiteRepository, NatureSiteRepository>();
            services.AddTransient<INatureSiteArriveRepository, NatureSiteArriveRepository>();
            services.AddTransient<INavireRepository, NavireRepository>();
            services.AddTransient<IObjetDeControleRepository, ObjetDeControleRepository>();
            services.AddTransient<IOperateurRepository, OperateurRepository>();
            services.AddTransient<IParcRepository, ParcRepository>(); 
            services.AddTransient<IPaysRepository, PaysRepository>();
            services.AddTransient<IPeriodeClotureRepository, PeriodeClotureRepository>(); 
            services.AddTransient<IPileGrumeRepository, PileGrumeRepository>();
            services.AddTransient<IPortRepository, PortRepository>();
            services.AddTransient<IPortArriveRepository, PortArriveRepository>();
            services.AddTransient<IPortEmbarquementRepository, PortEmbarquementRepository>();
            services.AddTransient<IProduitRepository, ProduitRepository>(); 
            services.AddTransient<IProfilAutoriseRepository, ProfilAutoriseRepository>();
            services.AddTransient<IQualiteBoisRepository, QualiteBoisRepository>();
            services.AddTransient<IQualiteIHCRepository, QualiteIHCRepository>();
            services.AddTransient<IRedevanceEtatiqueRepository, RedevanceEtatiqueRepository>();
            services.AddTransient<IRotationRepository, RotationRepository>();
            services.AddTransient<IScieRepository, SciesRepository>();
            services.AddTransient<ISechoirRepository, SechoirRepository>();
            services.AddTransient<ISectionAnalytiqueRepository, SectionAnalytiqueRepository>();
            services.AddTransient<ISepbcRepository, SepbcRepository>();
            services.AddTransient<IServiceVenteRepository, ServiceVenteRepository>();
            services.AddTransient<ISiegeRepository, SiegeRepository>();
            services.AddTransient<ISiteArriveRepository, SiteArriveRepository>();
            services.AddTransient<ISiteAutoriseRepository, SiteAutoriseRepository>();
            services.AddTransient<ISiteOperationRepository, SiteOperationRepository>();
            services.AddTransient<ISocieteRepository, SocieteRepository>();
            services.AddTransient<ISocieteMaritimeRepository, SocieteMaritimeRepository>();
            services.AddTransient<ISousFamilleRepository, SousFamilleRepository>();
            services.AddTransient<ISousTraitanceRepository, SousTraitanceRepository>();
            services.AddTransient<IStatutOperationRepository, StatutOperationRepository>();
            services.AddTransient<ITablesOperationRepository, TablesOperationRepository>();
            services.AddTransient<ITarifIHCRepository, TarifIHCRepository>();
            services.AddTransient<ITerminalPortRepository, TerminalPortRepository>();
            services.AddTransient<ITrancheHoraireRepository, TrancheHoraireRepository>();
            services.AddTransient<ITransitaireRepository, TransitaireRepository>();
            services.AddTransient<ITransporteurRepository, TransporteurRepository>();
            services.AddTransient<ITypeClientRepository, TypeClientRepository>();
            services.AddTransient<ITypeEquipeRepository, TypeEquipeRepository>();
            services.AddTransient<ITypeFactureRepository, TypeFactureRepository>();
            services.AddTransient<ITypeFournisseurRepository, TypeFournisseurRepository>();
            services.AddTransient<ITypeLongueurRepository, TypeLongueurRepository>();
            services.AddTransient<ITypeMaterielRepository, TypeMaterielRepository>();
            services.AddTransient<ITypeOperateurRepository, TypeOperateurRepository>();
            services.AddTransient<ITypeoperationControleRepository, TypeoperationControleRepository>();
            services.AddTransient<IVilleRepository, VilleRepository>();

<<<<<<< HEAD

            //Services
=======
            services.AddTransient<ILookUpRepository>(provider => {
                return new LookUpRepository(provider.GetRequiredService<SqlConnection>());
            });

>>>>>>> fd1d453f89614d20d2c78c3655e235df17810d96
            services.AddTransient<ILangueService, LangueService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUtilisateurService, UtilisateurService>();
            services.AddTransient<IAcconierService, AcconierService>();
            services.AddTransient<IAffecterEquipeService, AffecterEquipeService>();
            services.AddTransient<IBanqueService, BanqueService>();
            services.AddTransient<ICategorieBoisService, CategorieBoisService>();
            services.AddTransient<ICategorieEssenceService, CategorieEssenceService>();
            services.AddTransient<IChantierService, ChantierService>();
            services.AddTransient<IClasseEssenceService, ClasseEssenceService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientAdresseService, ClientAdresseService>();
            services.AddTransient<IClientConsignataireService, ClientConsignataireService>();
            services.AddTransient<IClientContactService, ClientContactService>();
            services.AddTransient<ICodePlaquetteService, CodePlaquetteService>();
            services.AddTransient<ICodificationService, CodificationService>();
            services.AddTransient<IComptabiliteService, ComptabiliteService>();
            services.AddTransient<ICompteBanqueService, CompteBanqueService>();
            services.AddTransient<ICompteProduitService, CompteProduitService>();
            services.AddTransient<ICompteTiersService, CompteTiersService>();
            services.AddTransient<IConteneurOrigineService, ConteneurOrigineService>();
            services.AddTransient<IContratFournisseurService, ContratFournisseurService>();
            services.AddTransient<IDensiteBoisService, DensiteBoisService>();
            services.AddTransient<IDestinationService, DestinationService>();
            services.AddTransient<IDroitService, DroitService>();
            services.AddTransient<IDroitAutoriseService, DroitAutoriseService>();
            services.AddTransient<IEquipeService, EquipeService>();
            services.AddTransient<IEquipeOperateurService, EquipeOperateurService>();
            services.AddTransient<IEssenceService, EssenceService>();
            services.AddTransient<IFamilleService, FamilleService>();
            services.AddTransient<IFournisseurService, FournisseurService>();
            services.AddTransient<IGroupeService, GroupeService>();
            services.AddTransient<ILamelleChoixService, LamelleChoixService>();
            services.AddTransient<ILamelleCouleurService, LamelleCouleurService>();
            services.AddTransient<ILangueService, LangueService>();
            services.AddTransient<ILieuTransitService, LieuTransitService>();
            services.AddTransient<IListeServiceVenteService, ListeServiceVenteService>();
            services.AddTransient<ILoadingNavireService, LoadingNavireService>();
            services.AddTransient<IMaterielService, MaterielService>();
            services.AddTransient<IModeEnvoieService, ModeEnvoieService>();
            services.AddTransient<IModePaiementService, ModePaiementService>();
            services.AddTransient<IModeTransportService, ModeTransportService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IMotifService, MotifService>();
            services.AddTransient<IMoyenTransportService, MoyenTransportService>();
            services.AddTransient<INatureConteneurService, NatureConteneurService>();
            services.AddTransient<INatureMouvementService, NatureMouvementService>();
            services.AddTransient<INatureParcService, NatureParcService>();
            services.AddTransient<INaturePortService, NaturePortService>();
            services.AddTransient<INatureSiteService, NatureSiteService>();
            services.AddTransient<INatureSiteArriveService, NatureSiteArriveService>();
            services.AddTransient<INavireService, NavireService>(); 
            services.AddTransient<IOperateurService, OperateurService>();
            services.AddTransient<IParcService, ParcService>(); 
            services.AddTransient<IPaysService, PaysService>();
            services.AddTransient<IPeriodeClotureService, PeriodeClotureService>(); 
            services.AddTransient<IPileGrumeService, PileGrumeService>();
            services.AddTransient<IPortService, PortService>();
            services.AddTransient<IPortArriveService, PortArriveService>();
            services.AddTransient<IPortEmbarquementService, PortEmbarquementService>();
            services.AddTransient<IProduitService, ProduitService>();
            services.AddTransient<IProfilService, ProfilService>();
            services.AddTransient<IProfilAutoriseService, ProfilAutoriseService>();
            services.AddTransient<IQualiteBoisService, QualiteBoisService>();
            services.AddTransient<IQualiteIHCService, QualiteIHCService>();
            services.AddTransient<IRedevanceEtatiqueService, RedevanceEtatiqueService>();
            services.AddTransient<IRotationService, RotationService>();
            services.AddTransient<ISciesService, SciesService>();
            services.AddTransient<ISechoirService, SechoirService>();
            services.AddTransient<ISectionAnalytiqueService, SectionAnalytiqueService>();
            services.AddTransient<ISepbcService, SepbcService>();
            services.AddTransient<IServiceVenteService, ServiceVenteService>();
            services.AddTransient<ISiegeService, SiegeService>();
            services.AddTransient<ISiteArriveService, SiteArriveService>();
            services.AddTransient<ISiteAutoriseService, SiteAutoriseService>();
            services.AddTransient<ISiteOperationService, SiteOperationService>();
            services.AddTransient<ISocieteService, SocieteService>();
            services.AddTransient<ISocieteMaritimeService, SocieteMaritimeService>();
            services.AddTransient<ISousFamilleService, SousFamilleService>();
            services.AddTransient<ISousTraitanceService, SousTraitanceService>();
            services.AddTransient<IStatutOperationService, StatutOperationService>(); 
            services.AddTransient<ITarifIHCService, TarifIHCService>();
            services.AddTransient<ITerminalPortService, TerminalPortService>();
            services.AddTransient<ITrancheHoraireService, TrancheHoraireService>();
            services.AddTransient<ITransitaireService, TransitaireService>();
            services.AddTransient<ITransporteurService, TransporteurService>();
            services.AddTransient<ITypeClientService, TypeClientService>();
            services.AddTransient<ITypeEquipeService, TypeEquipeService>();
            services.AddTransient<ITypeFactureService, TypeFactureService>();
            services.AddTransient<ITypeFournisseurService, TypeFournisseurService>();
            services.AddTransient<ITypeLongueurService, TypeLongueurService>();
            services.AddTransient<ITypeMaterielService, TypeMaterielService>();
            services.AddTransient<ITypeOperateurService, TypeOperateurService>();
            services.AddTransient<ITypeoperationControleService, TypeoperationControleService>();
            services.AddTransient<IVilleService, VilleService>();


            //BLL
            services.AddTransient<IProfileBLL, ProfileBLL>();
            services.AddTransient<ILangueBLL, LangueBLL>();
            services.AddTransient<IUtilisateurBLL, UtilisateurBLL>();
            services.AddTransient<IAcconierBLL, AcconierBLL>();
            services.AddTransient<IAffecterEquipeBLL, AffecterEquipeBLL>();
            services.AddTransient<IBanqueBLL, BanqueBLL>();
            services.AddTransient<ICategorieBoisBLL, CategorieBoisBLL>();
            services.AddTransient<ICategorieEssenceBLL, CategorieEssenceBLL>();
            services.AddTransient<IChantierBLL, ChantierBLL>();
            services.AddTransient<IClasseEssenceBLL, ClasseEssenceBLL>();
            services.AddTransient<IClientBLL, ClientBLL>();
            services.AddTransient<IClientAdresseBLL, ClientAdresseBLL>();
            services.AddTransient<IClientConsignataireBLL, ClientConsignataireBLL>();
            services.AddTransient<IClientContactBLL, ClientContactBLL>();
            services.AddTransient<ICodePlaquetteBLL, CodePlaquetteBLL>();
            services.AddTransient<ICodificationBLL, CodificationBLL>();
            services.AddTransient<IComptabiliteBLL, ComptabiliteBLL>();
            services.AddTransient<ICompteBanqueBLL, CompteBanqueBLL>();
            services.AddTransient<ICompteProduitBLL, CompteProduitBLL>();
            services.AddTransient<ICompteTiersBLL, CompteTiersBLL>();
            services.AddTransient<IConteneurOrigineBLL, ConteneurOrigineBLL>();
            services.AddTransient<IContratFournisseurBLL, ContratFournisseurBLL>();
            services.AddTransient<IDensiteBoisBLL, DensiteBoisBLL>();
            services.AddTransient<IDestinationBLL, DestinationBLL>();
            services.AddTransient<IDroitBLL, DroitBLL>();
            services.AddTransient<IDroitAutoriseBLL, DroitAutoriseBLL>();
            services.AddTransient<IEquipeBLL, EquipeBLL>();
            services.AddTransient<IEquipeOperateurBLL, EquipeOperateurBLL>();
            services.AddTransient<IEssenceBLL, EssenceBLL>();
            services.AddTransient<IFamilleBLL, FamilleBLL>();
            services.AddTransient<IFournisseurBLL, FournisseurBLL>();
            services.AddTransient<IGroupeBLL, GroupeBLL>();
            services.AddTransient<ILamelleChoixBLL, LamelleChoixBLL>();
            services.AddTransient<ILamelleCouleurBLL, LamelleCouleurBLL>();
            services.AddTransient<ILangueBLL, LangueBLL>();
            services.AddTransient<ILieuTransitBLL, LieuTransitBLL>();
            services.AddTransient<IListeServiceVenteBLL, ListeServiceVenteBLL>();
            services.AddTransient<ILoadingNavireBLL, LoadingNavireBLL>();
            services.AddTransient<IMaterielBLL, MaterielBLL>();
            services.AddTransient<IModeEnvoieBLL, ModeEnvoieBLL>();
            services.AddTransient<IModePaiementBLL, ModePaiementBLL>();
            services.AddTransient<IModeTransportBLL, ModeTransportBLL>();
            services.AddTransient<IModuleBLL, ModuleBLL>();
            services.AddTransient<IMotifBLL, MotifBLL>();
            services.AddTransient<IMoyenTransportBLL, MoyenTransportBLL>();
            services.AddTransient<INatureConteneurBLL, NatureConteneurBLL>();
            services.AddTransient<INatureMouvementBLL, NatureMouvementBLL>();
            services.AddTransient<INatureParcBLL, NatureParcBLL>();
            services.AddTransient<INaturePortBLL, NaturePortBLL>();
            services.AddTransient<INatureSiteBLL, NatureSiteBLL>();
            services.AddTransient<INatureSiteArriveBLL, NatureSiteArriveBLL>();
            services.AddTransient<INavireBLL, NavireBLL>(); 
            services.AddTransient<IOperateurBLL, OperateurBLL>();
            services.AddTransient<IParcBLL, ParcBLL>(); 
            services.AddTransient<IPaysBLL, PaysBLL>();
            services.AddTransient<IPeriodeClotureBLL, PeriodeClotureBLL>(); 
            services.AddTransient<IPileGrumeBLL, PileGrumeBLL>();
            services.AddTransient<IPortBLL, PortBLL>();
            services.AddTransient<IPortArriveBLL, PortArriveBLL>();
            services.AddTransient<IPortEmbarquementBLL, PortEmbarquementBLL>();
            services.AddTransient<IProduitBLL, ProduitBLL>(); 
            services.AddTransient<IProfilAutoriseBLL, ProfilAutoriseBLL>();
            services.AddTransient<IQualiteBoisBLL, QualiteBoisBLL>();
            services.AddTransient<IQualiteIHCBLL, QualiteIHCBLL>();
            services.AddTransient<IRedevanceEtatiqueBLL, RedevanceEtatiqueBLL>();
            services.AddTransient<IRotationBLL, RotationBLL>();
            services.AddTransient<ISciesBLL, SciesBLL>();
            services.AddTransient<ISechoirBLL, SechoirBLL>();
            services.AddTransient<ISectionAnalytiqueBLL, SectionAnalytiqueBLL>();
            services.AddTransient<ISepbcBLL, SepbcBLL>();
            services.AddTransient<IServiceVenteBLL, ServiceVenteBLL>();
            services.AddTransient<ISiegeBLL, SiegeBLL>();
            services.AddTransient<ISiteArriveBLL, SiteArriveBLL>();
            services.AddTransient<ISiteAutoriseBLL, SiteAutoriseBLL>();
            services.AddTransient<ISiteOperationBLL, SiteOperationBLL>();
            services.AddTransient<ISocieteBLL, SocieteBLL>();
            services.AddTransient<ISocieteMaritimeBLL, SocieteMaritimeBLL>();
            services.AddTransient<ISousFamilleBLL, SousFamilleBLL>();
            services.AddTransient<ISousTraitanceBLL, SousTraitanceBLL>();
            services.AddTransient<IStatutOperationBLL, StatutOperationBLL>(); 
            services.AddTransient<ITarifIHCBLL, TarifIHCBLL>();
            services.AddTransient<ITerminalPortBLL, TerminalPortBLL>();
            services.AddTransient<ITrancheHoraireBLL, TrancheHoraireBLL>();
            services.AddTransient<ITransitaireBLL, TransitaireBLL>();
            services.AddTransient<ITransporteurBLL, TransporteurBLL>();
            services.AddTransient<ITypeClientBLL, TypeClientBLL>();
            services.AddTransient<ITypeEquipeBLL, TypeEquipeBLL>();
            services.AddTransient<ITypeFactureBLL, TypeFactureBLL>();
            services.AddTransient<ITypeFournisseurBLL, TypeFournisseurBLL>();
            services.AddTransient<ITypeLongueurBLL, TypeLongueurBLL>();
            services.AddTransient<ITypeMaterielBLL, TypeMaterielBLL>();
            services.AddTransient<ITypeOperateurBLL, TypeOperateurBLL>();
            services.AddTransient<ITypeoperationControleBLL, TypeoperationControleBLL>();
            services.AddTransient<IVilleBLL, VilleBLL>();

        }
    }
}
