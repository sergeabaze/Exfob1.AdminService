using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IDensiteBoisService
	{
		Task<IEnumerable<DensiteBois>> ObtenireDensiteBoisListe();
		Task<DensiteBois> ObtenireDensiteBoisParId(int Id);
		Task<int> CreationDensiteBois(DensiteBois entity);
		Task MisejourDensiteBois(DensiteBois entity);
		Task SuppressionDensiteBois(int id);

	}
}
