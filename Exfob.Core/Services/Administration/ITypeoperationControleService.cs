using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeoperationControleService
	{
		Task<IEnumerable<TypeoperationControle>> ObtenireTypeoperationControleListe();
		Task<TypeoperationControle> ObtenireTypeoperationControleParId(int Id);
		Task<int> CreationTypeoperationControle(TypeoperationControle entity);
		Task MisejourTypeoperationControle(TypeoperationControle entity);
		Task SuppressionTypeoperationControle(int id);

	}
}
