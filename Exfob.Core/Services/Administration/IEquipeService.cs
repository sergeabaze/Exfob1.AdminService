using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IEquipeService
	{
		Task<IEnumerable<Equipe>> ObtenireEquipeListe();
		Task<Equipe> ObtenireEquipeParId(int Id);
		Task<int> CreationEquipe(Equipe entity);
		Task MisejourEquipe(Equipe entity);
		Task SuppressionEquipe(int id);

	}
}
