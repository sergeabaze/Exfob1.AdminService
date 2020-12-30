using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICategorieEssenceService
	{
		Task<IEnumerable<CategorieEssence>> ObtenireCategorieEssenceListe();
		Task<CategorieEssence> ObtenireCategorieEssenceParId(int Id);
		Task<int> CreationCategorieEssence(CategorieEssence entity);
		Task MisejourCategorieEssence(CategorieEssence entity);
		Task SuppressionCategorieEssence(int id);

	}
}
