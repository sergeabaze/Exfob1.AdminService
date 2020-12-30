using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPileGrumeService
	{
		Task<IEnumerable<PileGrume>> ObtenirePileGrumeListe();
		Task<PileGrume> ObtenirePileGrumeParId(int Id);
		Task<int> CreationPileGrume(PileGrume entity);
		Task MisejourPileGrume(PileGrume entity);
		Task SuppressionPileGrume(int id);

	}
}
