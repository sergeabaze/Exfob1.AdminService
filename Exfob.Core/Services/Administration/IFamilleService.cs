using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IFamilleService
	{
		Task<IEnumerable<Famille>> ObtenireFamilleListe();
		Task<Famille> ObtenireFamilleParId(int Id);
		Task<int> CreationFamille(Famille entity);
		Task MisejourFamille(Famille entity);
		Task SuppressionFamille(int id);

	}
}
