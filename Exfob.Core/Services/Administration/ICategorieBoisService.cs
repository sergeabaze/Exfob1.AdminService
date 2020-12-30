using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICategorieBoisService
	{
		Task<IEnumerable<CategorieBois>> ObtenireCategorieBoisListe();
		Task<CategorieBois> ObtenireCategorieBoisParId(int Id);
		Task<int> CreationCategorieBois(CategorieBois entity);
		Task MisejourCategorieBois(CategorieBois entity);
		Task SuppressionCategorieBois(int id);

	}
}
