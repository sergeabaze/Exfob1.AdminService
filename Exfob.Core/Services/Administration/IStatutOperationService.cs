using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IStatutOperationService
	{
		Task<IEnumerable<StatutOperation>> ObtenireStatutOperationListe();
		Task<StatutOperation> ObtenireStatutOperationParId(int Id);
		Task<int> CreationStatutOperation(StatutOperation entity);
		Task MisejourStatutOperation(StatutOperation entity);
		Task SuppressionStatutOperation(int id);

	}
}
