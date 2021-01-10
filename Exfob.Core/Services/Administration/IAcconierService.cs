using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IAcconierService
	{
		Task<IEnumerable<Acconier>> ObtenireAcconierListe();
		Task<Acconier> ObtenireAcconierParId(int Id);
		Task<int> CreationAcconier(Acconier entity);
		Task MisejourAcconier(Acconier entity);
		Task SuppressionAcconier(int id);

	}
}
