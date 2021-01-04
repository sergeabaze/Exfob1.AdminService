using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISepbcService
	{
		Task<IEnumerable<Sepbc>> ObtenireSepbcListe();
		Task<Sepbc> ObtenireSepbcParId(int Id);
		Task<int> CreationSepbc(Sepbc entity);
		Task MisejourSepbc(Sepbc entity);
		Task SuppressionSepbc(int id);

	}
}
