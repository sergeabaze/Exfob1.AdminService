using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IContratFournisseurService
	{
		Task<IEnumerable<ContratFournisseur>> ObtenireContratFournisseurListe();
		Task<ContratFournisseur> ObtenireContratFournisseurParId(int Id);
		Task<int> CreationContratFournisseur(ContratFournisseur entity);
		Task MisejourContratFournisseur(ContratFournisseur entity);
		Task SuppressionContratFournisseur(int id);

	}
}
