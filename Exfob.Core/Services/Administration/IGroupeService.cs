using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IGroupeService
	{
		Task<IEnumerable<Groupe>> ObtenireGroupeListe();
		Task<Groupe> ObtenireGroupeParId(int Id);
		Task<int> CreationGroupe(Groupe entity);
		Task MisejourGroupe(Groupe entity);
		Task SuppressionGroupe(int id);

	}
}
