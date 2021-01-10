using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPortEmbarquementService
	{
		Task<IEnumerable<PortEmbarquement>> ObtenirePortEmbarquementListe();
		Task<PortEmbarquement> ObtenirePortEmbarquementParId(int Id);
		Task<int> CreationPortEmbarquement(PortEmbarquement entity);
		Task MisejourPortEmbarquement(PortEmbarquement entity);
		Task SuppressionPortEmbarquement(int id);

	}
}
