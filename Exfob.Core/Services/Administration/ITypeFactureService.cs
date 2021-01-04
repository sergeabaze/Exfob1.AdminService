using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeFactureService
	{
		Task<IEnumerable<TypeFacture>> ObtenireTypeFactureListe();
		Task<TypeFacture> ObtenireTypeFactureParId(int Id);
		Task<int> CreationTypeFacture(TypeFacture entity);
		Task MisejourTypeFacture(TypeFacture entity);
		Task SuppressionTypeFacture(int id);

	}
}
