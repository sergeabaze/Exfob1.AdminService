using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ILieuTransitService
	{
		Task<IEnumerable<LieuTransit>> ObtenireLieuTransitListe();
		Task<LieuTransit> ObtenireLieuTransitParId(int Id);
		Task<int> CreationLieuTransit(LieuTransit entity);
		Task MisejourLieuTransit(LieuTransit entity);
		Task SuppressionLieuTransit(int id);

	}
}
