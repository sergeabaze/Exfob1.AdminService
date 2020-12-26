INSERT INTO [Utilisateur] (
      [SiteOperationID]
     , [ProfilID]
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
	  ,[CreerPar]
 )
     VALUES
     (
      @pn_InSiteOperationID
      ,@pn_InProfilID
      ,@pc_InNom
      ,@pc_InLoginUtilisateur
      ,@pc_InMotPasseHash
      ,@pc_InSelMotdePasse
      ,@pc_InEmail
      ,@pc_InMatricule
      ,@pc_InFonction
      ,@pb_InEstActif
	  ,@pn_InLangueID
	  ,getdate()
	  ,@pn_InCreerPar
     )
	 

  SET @pn_OutUtilisateurID=SCOPE_IDENTITY()