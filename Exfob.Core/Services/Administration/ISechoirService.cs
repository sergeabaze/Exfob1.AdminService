using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISechoirService
	{
		Task<IEnumerable<Sechoir>> ObtenireSechoirListe();
		Task<Sechoir> ObtenireSechoirParId(int Id);
		Task<int> CreationSechoir(Sechoir entity);
		Task MisejourSechoir(Sechoir entity);
		Task SuppressionSechoir(int id);

	}
}
