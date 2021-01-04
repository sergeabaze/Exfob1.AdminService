using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IFournisseurService
	{
		Task<IEnumerable<Fournisseur>> ObtenireFournisseurListe();
		Task<Fournisseur> ObtenireFournisseurParId(int Id);
		Task<int> CreationFournisseur(Fournisseur entity);
		Task MisejourFournisseur(Fournisseur entity);
		Task SuppressionFournisseur(int id);

	}
}
