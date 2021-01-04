using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISousFamilleService
	{
		Task<IEnumerable<SousFamille>> ObtenireSousFamilleListe();
		Task<SousFamille> ObtenireSousFamilleParId(int Id);
		Task<int> CreationSousFamille(SousFamille entity);
		Task MisejourSousFamille(SousFamille entity);
		Task SuppressionSousFamille(int id);

	}
}
