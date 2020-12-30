using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ILamelleCouleurService
	{
		Task<IEnumerable<LamelleCouleur>> ObtenireLamelleCouleurListe();
		Task<LamelleCouleur> ObtenireLamelleCouleurParId(int Id);
		Task<int> CreationLamelleCouleur(LamelleCouleur entity);
		Task MisejourLamelleCouleur(LamelleCouleur entity);
		Task SuppressionLamelleCouleur(int id);

	}
}
