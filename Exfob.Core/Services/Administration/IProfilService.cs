using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IProfilService
	{
		Task<IEnumerable<Profil>> ObtenireProfilListe();
		Task<Profil> ObtenireProfilParId(int Id);
		Task<int> CreationProfil(Profil entity);
		Task MisejourProfil(Profil entity);
		Task SuppressionProfil(int id);

	}
}
