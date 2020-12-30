using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IProduitService
	{
		Task<IEnumerable<Produit>> ObtenireProduitListe();
		Task<Produit> ObtenireProduitParId(int Id);
		Task<int> CreationProduit(Produit entity);
		Task MisejourProduit(Produit entity);
		Task SuppressionProduit(int id);

	}
}
