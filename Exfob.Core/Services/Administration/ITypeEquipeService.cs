using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeEquipeService
	{
		Task<IEnumerable<TypeEquipe>> ObtenireTypeEquipeListe();
		Task<TypeEquipe> ObtenireTypeEquipeParId(int Id);
		Task<int> CreationTypeEquipe(TypeEquipe entity);
		Task MisejourTypeEquipe(TypeEquipe entity);
		Task SuppressionTypeEquipe(int id);

	}
}
