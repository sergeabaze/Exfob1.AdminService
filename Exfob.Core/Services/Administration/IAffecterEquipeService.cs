using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IAffecterEquipeService
	{
		Task<IEnumerable<AffecterEquipe>> ObtenireAffecterEquipeListe();
		Task<AffecterEquipe> ObtenireAffecterEquipeParId(int Id);
		Task<int> CreationAffecterEquipe(AffecterEquipe entity);
		Task MisejourAffecterEquipe(AffecterEquipe entity);
		Task SuppressionAffecterEquipe(int id);

	}
}
