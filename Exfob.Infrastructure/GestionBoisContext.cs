using Exfob.Models.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exfob.Infrastructure
{
    public class GestionBoisContext : DbContext
    {
        public GestionBoisContext(DbContextOptions<GestionBoisContext> options)
             : base(options)
        {
            
           // this.Configuration.LazyLoadingEnabled = false;
        }

        public GestionBoisContext()
        {
           // this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<AffecterEquipe> AffecterEquipes { get; set; }
        public virtual DbSet<Banque> Banques { get; set; }
        public virtual DbSet<CategorieBois> CategorieBois { get; set; }
        public virtual DbSet<CategorieEssence> CategorieEssences { get; set; }
        public virtual DbSet<Chantier> Chantiers { get; set; }
        public virtual DbSet<ClasseEssence> ClasseEssences { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAdresse> ClientAdresses { get; set; }
        public virtual DbSet<ClientConsignataire> ClientConsignataires { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }
        public virtual DbSet<CodePlaquette> CodePlaquettes { get; set; }
        public virtual DbSet<Codification> Codifications { get; set; }
        public virtual DbSet<Comptabilite> Comptabilites { get; set; }
        public virtual DbSet<CompteBanque> CompteBanques { get; set; }
        public virtual DbSet<CompteProduit> CompteProduits { get; set; }
        public virtual DbSet<CompteTier> CompteTiers { get; set; }
        public virtual DbSet<ConteneurOrigine> ConteneurOrigines { get; set; }
        public virtual DbSet<ContratFournisseur> ContratFournisseurs { get; set; }
        public virtual DbSet<DensiteBois> DensiteBois { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Droit> Droits { get; set; }
        public virtual DbSet<DroitAutorise> DroitAutorises { get; set; }
        public virtual DbSet<Equipe> Equipes { get; set; }
        public virtual DbSet<EquipeOperateur> EquipeOperateurs { get; set; }
        public virtual DbSet<Essence> Essences { get; set; }
        public virtual DbSet<Famille> Familles { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<LamelleChoix> LamelleChoixes { get; set; }
        public virtual DbSet<LamelleCouleur> LamelleCouleurs { get; set; }
        public virtual DbSet<Langue> Langues { get; set; }
        public virtual DbSet<LieuTransit> LieuTransits { get; set; }
        public virtual DbSet<ListeServiceVente> ListeServiceVentes { get; set; }
        public virtual DbSet<LoadingNavire> LoadingNavires { get; set; }
        public virtual DbSet<Materiel> Materiels { get; set; }
        public virtual DbSet<ModeEnvoie> ModeEnvoies { get; set; }
        public virtual DbSet<ModePaiement> ModePaiements { get; set; }
        public virtual DbSet<ModeTransport> ModeTransports { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Motif> Motifs { get; set; }
        public virtual DbSet<MoyenTransport> MoyenTransports { get; set; }
        public virtual DbSet<NatureConteneur> NatureConteneurs { get; set; }
        public virtual DbSet<NatureMouvement> NatureMouvements { get; set; }
        public virtual DbSet<NatureParc> NatureParcs { get; set; }
        public virtual DbSet<NaturePort> NaturePorts { get; set; }
        public virtual DbSet<NatureSite> NatureSites { get; set; }
        public virtual DbSet<NatureSiteArrive> NatureSiteArrives { get; set; }
        public virtual DbSet<Navire> Navires { get; set; }
        public virtual DbSet<ObjetDeControle> ObjetDeControles { get; set; }
        public virtual DbSet<Operateur> Operateurs { get; set; }
        public virtual DbSet<Parc> Parcs { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<PeriodeCloture> PeriodeClotures { get; set; }
        public virtual DbSet<PileGrume> PileGrumes { get; set; }
        public virtual DbSet<Port> Ports { get; set; }
        public virtual DbSet<PortArrive> PortArrives { get; set; }
        public virtual DbSet<PortEmbarquement> PortEmbarquements { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Profil> Profils { get; set; }
        public virtual DbSet<ProfilAutorise> ProfilAutorises { get; set; }
        public virtual DbSet<QualiteBois> QualiteBois { get; set; }
        public virtual DbSet<QualiteIHC> QualiteIHCs { get; set; }
        public virtual DbSet<RedevanceEtatique> RedevanceEtatiques { get; set; }
        public virtual DbSet<Rotation> Rotations { get; set; }
        public virtual DbSet<Scie> Scies { get; set; }
        public virtual DbSet<Sechoir> Sechoirs { get; set; }
        public virtual DbSet<SectionAnalytique> SectionAnalytiques { get; set; }
        public virtual DbSet<Sepbc> Sepbcs { get; set; }
        public virtual DbSet<ServiceVente> ServiceVentes { get; set; }
        public virtual DbSet<Siege> Sieges { get; set; }
        public virtual DbSet<SiteArrive> SiteArrives { get; set; }
        public virtual DbSet<SiteAutorise> SiteAutorises { get; set; }
        public virtual DbSet<SiteOperation> SiteOperations { get; set; }
        public virtual DbSet<Societe> Societes { get; set; }
        public virtual DbSet<SocieteMaritime> SocieteMaritimes { get; set; }
        public virtual DbSet<SousFamille> SousFamilles { get; set; }
        public virtual DbSet<SousTraitance> SousTraitances { get; set; }
        public virtual DbSet<StatutOperation> StatutOperations { get; set; }
        public virtual DbSet<StockArbreForet> StockArbreForets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TablesOperation> TablesOperations { get; set; }
        public virtual DbSet<TarifIHC> TarifIHCs { get; set; }
        public virtual DbSet<TerminalPort> TerminalPorts { get; set; }
        public virtual DbSet<TrancheHoraire> TrancheHoraires { get; set; }
        public virtual DbSet<Transitaire> Transitaires { get; set; }
        public virtual DbSet<Transporteur> Transporteurs { get; set; }
        public virtual DbSet<TypeClient> TypeClients { get; set; }
        public virtual DbSet<TypeEquipe> TypeEquipes { get; set; }
        public virtual DbSet<TypeFacture> TypeFactures { get; set; }
        public virtual DbSet<TypeFournisseur> TypeFournisseurs { get; set; }
        public virtual DbSet<TypeLongueur> TypeLongueurs { get; set; }
        public virtual DbSet<TypeMateriel> TypeMateriels { get; set; }
        public virtual DbSet<TypeOperateur> TypeOperateurs { get; set; }
        public virtual DbSet<TypeoperationControle> TypeoperationControles { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BdQuizz.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                //optionsBuilder.UseSqlServer(
                //@"data source=CA-L7KB0VN2\SQLEXPRESS; initial catalog=BdQuizz;integrated security=True;MultipleActiveResultSets=True;");
                //optionsBuilder.UseSqlServer(
                //@"Server=DESKTOP-GCJBAJI\SQLEXPRESS; initial catalog=BdQuizz;User ID=sa;Password=pression2020;MultipleActiveResultSets=True;");
            }
            else
            {
                //optionsBuilder.UseSqlServer(
                //@"Server=DESKTOP-GCJBAJI\SQLEXPRESS; initial catalog=BdQuizz;User ID=sa;Password=pression2020;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Acconier>()
               .Property(e => e.Nom)
               .IsUnicode(false);

            modelBuilder.Entity<Acconier>()
                .Property(e => e.Localisation)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Sigle)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.CodeGuichet)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Iban)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Swift)
                .IsUnicode(false);

            modelBuilder.Entity<Banque>()
                .Property(e => e.Domiciliation)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieBois>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieBois>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieBois>()
                .HasMany(e => e.StockArbreForets)
                .WithOne(e => e.CategorieBois)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CategorieEssence>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieEssence>()
                .Property(e => e.BoisRougeBoisLong)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieEssence>()
                .HasMany(e => e.Essences)
                .WithOne(e => e.CategorieEssence)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.CodeChantier)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.GroupeAppart)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.CodeActivite)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.SeqBil)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.CreerPar)
                .IsUnicode(false);

            modelBuilder.Entity<Chantier>()
                .Property(e => e.MisejourPar)
                .IsUnicode(false);

            modelBuilder.Entity<ClasseEssence>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ClasseEssence>()
                .HasMany(e => e.Essences)
                .WithOne(e => e.ClasseEssence)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Client>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Nomclient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone1)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone2)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Faxe1)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Faxe2)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Observation)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.EorNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientAdresses)
                .WithOne(e => e.Client)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientConsignataires)
                .WithOne(e => e.Client)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientContacts)
                .WithOne(e => e.Client)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientAdresse>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAdresse>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAdresse>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAdresse>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAdresse>()
                .HasMany(e => e.ClientContacts)
                .WithOne(e => e.ClientAdresse)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientConsignataire>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ClientConsignataire>()
                .Property(e => e.NomConsignataire)
                .IsUnicode(false);

            modelBuilder.Entity<ClientContact>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ClientContact>()
                .Property(e => e.NomContact)
                .IsUnicode(false);

            modelBuilder.Entity<ClientContact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ClientContact>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.CodePlaq1)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.CodeIhc)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.PrixVenteLocale)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.PosAffic)
                .IsUnicode(false);

            modelBuilder.Entity<CodePlaquette>()
                .Property(e => e.LongueurRecuperation)
                .IsUnicode(false);

            //modelBuilder.Entity<CodePlaquette>()
            //    .HasOne(e => e.CodePlaquette1)
            //    .WithOne(e => e.CodePlaquette2);

           

            modelBuilder.Entity<Codification>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Codification>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Codification>()
                .Property(e => e.QualiteCode)
                .IsUnicode(false);

            modelBuilder.Entity<Codification>()
                .Property(e => e.ClasseCode)
                .IsUnicode(false);

            modelBuilder.Entity<Comptabilite>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<CompteBanque>()
                .Property(e => e.NumeroCompte)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CodeJournal)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CompteGeneral)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CompteTiers)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CompteProduit1)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CompteAnalytique)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.CodSig)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.LibelleEcriture)
                .IsUnicode(false);

            modelBuilder.Entity<CompteProduit>()
                .Property(e => e.TypeFacture)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.NumeroCompte)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.NumeroPrinc)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.CodePostal)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.BoiteNumero)
                .IsUnicode(false);

            modelBuilder.Entity<CompteTier>()
                .Property(e => e.CtNumero)
                .IsUnicode(false);

            modelBuilder.Entity<ConteneurOrigine>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ContratFournisseur>()
                .Property(e => e.NumeroAgrement)
                .IsUnicode(false);

            modelBuilder.Entity<ContratFournisseur>()
                .HasMany(e => e.Chantiers)
                .WithOne(e => e.ContratFournisseur)
                .OnDelete(DeleteBehavior.NoAction);
            /*

            modelBuilder.Entity<Destination>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Equipe>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Equipe>()
                .Property(e => e.Libelle)
                .IsUnicode(false);*/

            modelBuilder.Entity<Equipe>()
                .HasMany(e => e.AffecterEquipes)
                .WithOne(e => e.Equipe)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Equipe>()
                .HasMany(e => e.EquipeOperateurs)
                .WithOne(e => e.Equipe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Equipe>()
                .HasMany(e => e.Rotations)
                .WithOne(e => e.Equipe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Essence>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.NomScientifique)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeMesurage)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.MesurageAubier)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.NomSnt)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeCubagePlein)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeCubageCom)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeStat)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeCde)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.CodeIhc)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.Aupdate)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.EtatIc)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Essence>()
                .HasMany(e => e.DensiteBois)
                .WithOne(e => e.Essence)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Essence>()
                .HasMany(e => e.TarifIHCs)
                .WithOne(e => e.Essence)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Famille>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Famille>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Famille>()
                .HasMany(e => e.SousFamilles)
                .WithOne(e => e.Famille)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Designation)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Adresse1)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Adresse2)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.BoitePostal)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Telephone1)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Telephone2)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.ContratFournisseurs)
                .WithOne(e => e.Fournisseur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Groupe>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Groupe>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Groupe>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Groupe>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<LamelleChoix>()
                .Property(e => e.LibelleChoix)
                .IsUnicode(false);

            modelBuilder.Entity<LamelleCouleur>()
                .Property(e => e.Intitule)
                .IsUnicode(false);

            modelBuilder.Entity<Langue>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Langue>()
               .HasIndex(e => e.Code).IsUnique();
            modelBuilder.Entity<Langue>()
              .HasIndex(e => e.Libelle).IsUnique();



            modelBuilder.Entity<LieuTransit>()
                .Property(e => e.TypeSiteParc)
                .IsUnicode(false);

            modelBuilder.Entity<LieuTransit>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ListeServiceVente>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Materiel>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Materiel>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ModeEnvoie>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ModePaiement>()
                .Property(e => e.Intitule)
                .IsUnicode(false);

            modelBuilder.Entity<ModeTransport>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ModeTransport>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.Droits)
                .WithOne(e => e.Module)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.DroitAutorises)
                .WithOne(e => e.Module)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Motif>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Motif>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Motif>()
                .Property(e => e.Observation)
                .IsUnicode(false);

            modelBuilder.Entity<Motif>()
                .Property(e => e.Nature)
                .IsUnicode(false);

            modelBuilder.Entity<Motif>()
                .HasMany(e => e.StockArbreForets)
                .WithOne(e => e.Motif)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MoyenTransport>()
                .Property(e => e.NumeroTracteur)
                .IsUnicode(false);

            modelBuilder.Entity<MoyenTransport>()
                .Property(e => e.NumeroRemorque)
                .IsUnicode(false);

            modelBuilder.Entity<MoyenTransport>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<MoyenTransport>()
                .Property(e => e.Chauffeur)
                .IsUnicode(false);

            modelBuilder.Entity<NatureConteneur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<NatureConteneur>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<NatureMouvement>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<NatureMouvement>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<NatureMouvement>()
                .HasMany(e => e.StockArbreForets)
                .WithOne(e => e.NatureMouvement)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NatureParc>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<NatureParc>()
                .HasMany(e => e.Parcs)
                .WithOne(e => e.NatureParc)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NaturePort>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<NaturePort>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<NaturePort>()
                .HasMany(e => e.Ports)
                .WithOne(e => e.NaturePort)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NatureSite>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<NatureSite>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<NatureSite>()
                .HasMany(e => e.SiteArrives)
                .WithOne(e => e.NatureSite)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NatureSiteArrive>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<NatureSiteArrive>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Navire>()
                .Property(e => e.CodeNavire)
                .IsUnicode(false);

            modelBuilder.Entity<Navire>()
                .Property(e => e.NomNavire)
                .IsUnicode(false);

            modelBuilder.Entity<Operateur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Operateur>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Operateur>()
                .HasMany(e => e.AffecterEquipes)
                .WithOne(e => e.Operateur)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Operateur>()
              .HasMany(e => e.EquipeOperateurs)
               .WithOne(e => e.Operateur)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Parc>()
                .Property(e => e.CodeParc)
                .IsUnicode(false);

            modelBuilder.Entity<Parc>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Parc>()
                .Property(e => e.CodeArbre)
                .IsUnicode(false);

            modelBuilder.Entity<Parc>()
                .Property(e => e.CodeStockSechoir)
                .IsUnicode(false);

            modelBuilder.Entity<Parc>()
                .Property(e => e.CodeParcBois)
                .IsFixedLength();

            modelBuilder.Entity<Pays>()
                .Property(e => e.CodePays)
                .IsUnicode(false);

            modelBuilder.Entity<Pays>()
                .Property(e => e.NomPays)
                .IsUnicode(false);

            //modelBuilder.Entity<Pays()
            //    .Property(e => e.CodePostal)
            //    .IsUnicode(false);

            modelBuilder.Entity<Pays>()
                .HasMany(e => e.Clients)
                .WithOne(e => e.Pay)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pays>()
                .HasMany(e => e.Destinations)
                .WithOne(e => e.Pay)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pays>()
                .HasMany(e => e.SiteArrives)
                .WithOne(e => e.Pay)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pays>()
                .HasMany(e => e.Villes)
                .WithOne(e => e.Pay)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PeriodeCloture>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PeriodeCloture>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<PeriodeCloture>()
                .Property(e => e.CreerPar)
                .IsUnicode(false);

            modelBuilder.Entity<PeriodeCloture>()
                .Property(e => e.ModifierPar)
                .IsUnicode(false);

            modelBuilder.Entity<PileGrume>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PileGrume>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Port>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Port>()
                .Property(e => e.Numerodestination)
                .IsUnicode(false);

            modelBuilder.Entity<Port>()
                .HasMany(e => e.LieuTransits)
                .WithOne(e => e.Port)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Port>()
                .HasMany(e => e.RedevanceEtatiques)
                .WithOne(e => e.Port)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Port>()
                .HasMany(e => e.TerminalPorts)
                .WithOne(e => e.Port)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Port>()
                .HasMany(e => e.SiteArrives)
                .WithOne(e => e.Port)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PortArrive>()
                .Property(e => e.Libelle)
                .IsFixedLength();

            modelBuilder.Entity<PortEmbarquement>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<PortEmbarquement>()
                .Property(e => e.Sigle)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.CodeProduit)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.TypeQualite)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.TypeGroupe)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.CodeActivite)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.CodePlaque)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.PostAff)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.CodeSig)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.SDKDF)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Unites)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.DensiteBois)
                .WithOne(e => e.Produit)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.TarifIHCs)
                .WithOne(e => e.Produit)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profil>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Profil>()
                .HasMany(e => e.Droits)
                .WithOne(e => e.Profil)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profil>()
                .HasMany(e => e.Utilisateurs)
                .WithOne(e => e.Profil)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProfilAutorise>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<ProfilAutorise>()
                .HasMany(e => e.DroitAutorises)
                .WithOne(e => e.ProfilAutorise)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProfilAutorise>()
                .HasMany(e => e.SiteAutorises)
                .WithOne(e => e.ProfilAutorise)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.CodeQualite)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.CodeMercuriale)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.CodeActivite)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.CodePlaq1)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.CodeIhc)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.PosAffic)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .Property(e => e.LongueurRecuperation)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteBois>()
                .HasMany(e => e.CodePlaquettes)
                .WithOne(e => e.QualiteBois)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.CodeQualite)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.CodeMercuriale)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.CodePlaquette)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.CodePlaquette1)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.CodeIhc)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.PosAffic)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .Property(e => e.ObservationsQualiteIHC)
                .IsUnicode(false);

            modelBuilder.Entity<QualiteIHC>()
                .HasMany(e => e.TarifIHCs)
                .WithOne(e => e.QualiteIHC)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RedevanceEtatique>()
                .Property(e => e.Intitule)
                .IsUnicode(false);

            modelBuilder.Entity<Rotation>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Rotation>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.CodeNature)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.Sigle)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.CodeProduction)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.ScieOrg)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.FamilleProduction)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .Property(e => e.ScieProduit)
                .IsUnicode(false);

            modelBuilder.Entity<Scie>()
                .HasMany(e => e.CodePlaquettes)
                .WithOne(e => e.Scy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Scie>()
                .HasMany(e => e.Rotations)
                .WithOne(e => e.Scy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sechoir>()
                .Property(e => e.LibelleChambre)
                .IsUnicode(false);

            modelBuilder.Entity<SectionAnalytique>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<SectionAnalytique>()
                .Property(e => e.SectionAnalytiqueGb)
                .IsUnicode(false);

            modelBuilder.Entity<Sepbc>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Sepbc>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            //modelBuilder.Entity<Sepbc>()
            //    .HasOptional(e => e.Sepbc1)
            //    .WithOne(e => e.Sepbc2);

            modelBuilder.Entity<ServiceVente>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceVente>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .Property(e => e.Pays)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Siege>()
                .HasMany(e => e.Societes)
                .WithOne(e => e.Siege)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.CodePort)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Aactif)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Phyto)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Co)
                .IsUnicode(false);

            modelBuilder.Entity<SiteArrive>()
                .Property(e => e.Eur1)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .Property(e => e.PostAff)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .Property(e => e.Trajet)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.Chantiers)
                ;

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.Clients)
              ;

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.CodePlaquettes)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);
           

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.ContratFournisseurs)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);
            

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.Equipes)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.Fournisseurs)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.LieuTransits)
                .WithOne(e => e.SiteOperation)
                .HasForeignKey(e => e.SiteOperattionID);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.MoyenTransports)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.Parcs)
                .WithOne(e => e.SiteOperation)
                .HasForeignKey(e => e.SiteOperattionID);

            //modelBuilder.Entity<SiteOperation>()
            //    .HasMany(e => e.PortEmbarquements)
            //    .WithOptional(e => e.SiteOperation)
            //    .HasForeignKey(e => e.SiteOperationID);

            //modelBuilder.Entity<SiteOperation>()
            //    .HasMany(e => e.PortEmbarquements1)
            //    .WithOptional(e => e.SiteOperation1)
            //    .HasForeignKey(e => e.SiteOperationID);

            //modelBuilder.Entity<SiteOperation>()
            //    .HasMany(e => e.Rotations)
            //    .WithOne(e => e.SiteOperation)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SiteOperation>()
                .HasMany(e => e.SiteAutorises)
                .WithOne(e => e.SiteOperation)
                .OnDelete(DeleteBehavior.NoAction);

             //modelBuilder.Entity<SiteOperation>()
             //    .HasMany(e => e.Transporteurs)
             //    .WithOptional(e => e.SiteOperation)
             //    .WillCascadeOnDelete();

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Code)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Libelle)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Description)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.BoitePostale)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Adresse)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Ville)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.NatureActivite)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Regime)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Pw)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Fsc)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.Tltv)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.NumIdentite)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.LDevise)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .Property(e => e.NumeroCompte)
                  .IsUnicode(false);

              modelBuilder.Entity<Societe>()
                  .HasMany(e => e.Banques)
                  .WithOne(e => e.Societe)
                  .OnDelete(DeleteBehavior.NoAction);

              modelBuilder.Entity<Societe>()
                  .HasMany(e => e.CompteBanques)
                  .WithOne(e => e.Societe)
                  .OnDelete(DeleteBehavior.NoAction);

              modelBuilder.Entity<Societe>()
                  .HasMany(e => e.CompteProduits)
                  .WithOne(e => e.Societe)
                  .OnDelete(DeleteBehavior.NoAction);

              modelBuilder.Entity<Societe>()
                  .HasMany(e => e.Essences)
                  .WithOne(e => e.Societe)
                  .OnDelete(DeleteBehavior.NoAction);

              modelBuilder.Entity<Societe>()
                  .HasMany(e => e.ModeEnvoies)
                  .WithOne(e => e.Societe)
                  .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Societe>()
            //    .HasMany(e => e.Pays)
            //    .WithOptional(e => e.Societe)
            //    .WillCascadeOnDelete();

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.PeriodeClotures)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.Ports)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.Scies)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.SiteArrives)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Societe>()
            //    .HasMany(e => e.SiteOperations)
            //   // .WithOptional(e => e.Societe)
            //    .HasForeignKey(e => e.SocieteID);

            /* modelBuilder.Entity<Societe>()
                 .HasMany(e => e.SiteOperations1)
                 .HasForeignKey(e => e.SocieteID);*/

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.SocieteMaritimes)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Societe>()
                .HasMany(e => e.TarifIHCs)
                .WithOne(e => e.Societe)
                .OnDelete(DeleteBehavior.NoAction)
                ;

            modelBuilder.Entity<SocieteMaritime>()
                .Property(e => e.NomSociete)
                .IsUnicode(false);

            modelBuilder.Entity<SocieteMaritime>()
                .Property(e => e.ServiceContrat)
                .IsUnicode(false);

            modelBuilder.Entity<SocieteMaritime>()
                .Property(e => e.Mention)
                .IsUnicode(false);

            modelBuilder.Entity<SousFamille>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<SousFamille>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<StatutOperation>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<StatutOperation>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.SequenceNumeroForet)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.SequenceNumeroForet2)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.Observation)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.NumeroParc)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.CreerPar)
                .IsUnicode(false);

            modelBuilder.Entity<StockArbreForet>()
                .Property(e => e.MiseAjourPar)
                .IsUnicode(false);

            modelBuilder.Entity<TablesOperation>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TerminalPort>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<TrancheHoraire>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TrancheHoraire>()
               .HasMany(e => e.AffecterEquipes)
               .WithOne(e => e.TrancheHoraire)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrancheHoraire>()
                .HasMany(e => e.Rotations)
                .WithOne(e => e.TrancheHoraire)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transitaire>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.NomTransporteur)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Comptabilite1)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.Comptabilite2)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .HasMany(e => e.MoyenTransports)
                .WithOne(e => e.Transporteur)
                .HasForeignKey(e => e.TransporteurtID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeClient>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TypeClient>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeClient>()
                .HasMany(e => e.Clients)
                .WithOne(e => e.TypeClient)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeEquipe>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TypeEquipe>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeEquipe>()
                .HasMany(e => e.Equipes)
                .WithOne(e => e.TypeEquipe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeFacture>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeFournisseur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TypeFournisseur>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeFournisseur>()
                .HasMany(e => e.Fournisseurs)
                .WithOne(e => e.TypeFournisseur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeLongueur>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TypeLongueur>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeLongueur>()
                .HasMany(e => e.CodePlaquettes)
                .WithOne(e => e.TypeLongueur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeMateriel>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeMateriel>()
                .HasMany(e => e.Materiels)
                .WithOne(e => e.TypeMateriel)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeOperateur>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOperateur>()
                .HasMany(e => e.EquipeOperateurs)
                .WithOne(e => e.TypeOperateur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeOperateur>()
                .HasMany(e => e.Operateurs)
                .WithOne(e => e.TypeOperateur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeoperationControle>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TypeoperationControle>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            //modelBuilder.Entity<TypeoperationControle>()
            //    .HasMany(e => e.ObjetDeControles)
            //    .WithOptional(e => e.TypeoperationControle)
            //    .HasForeignKey(e => e.TypeOperationID);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.LoginUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.MotPasseHash)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.SelMotdePasse)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Matricule)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Fonction)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.CreerPar)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.MiseJourPar)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.SiteAutorises)
                .WithOne(e => e.Utilisateur)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ville>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Ville>()
                .Property(e => e.NomVille)
                .IsUnicode(false);

            modelBuilder.Entity<Ville>()
                .HasMany(e => e.Clients)
                .WithOne(e => e.Ville)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Langue>().HasData
            //  (
            //  new Langue {  LangueID = 1,  Code = "Fr",  Libelle = "Fr-fr" }
            //  );

            //modelBuilder.Entity<Profil>().HasData
            //  (
            //  new Profil { ProfilID = 1,  Libelle = "Admin" }
            //  );

            //modelBuilder.Entity<SiteOperation>().HasData
            // (
            // new SiteOperation  { SiteOperationID = 1, NatureSiteID=1, PaysID =1, SocieteID =1, Libelle = "Admin" }
            // );

            //modelBuilder.Entity<Utilisateur>().HasData
            //    (
            //    new Utilisateur { UtilisateurID = 1, LangueID =1, ProfilID =1, SiteOperationID = 1 }
            //    );

        }
    }
}
