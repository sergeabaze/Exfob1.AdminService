using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IMotifService
	{
		Task<IEnumerable<Motif>> ObtenireMotifListe();
		Task<Motif> ObtenireMotifParId(int Id);
		Task<int> CreationMotif(Motif entity);
		Task MisejourMotif(Motif entity);
		Task SuppressionMotif(int id);

	}
}
