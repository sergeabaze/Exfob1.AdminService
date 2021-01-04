using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeFournisseurService
	{
		Task<IEnumerable<TypeFournisseur>> ObtenireTypeFournisseurListe();
		Task<TypeFournisseur> ObtenireTypeFournisseurParId(int Id);
		Task<int> CreationTypeFournisseur(TypeFournisseur entity);
		Task MisejourTypeFournisseur(TypeFournisseur entity);
		Task SuppressionTypeFournisseur(int id);

	}
}
