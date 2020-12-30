using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISocieteService
	{
		Task<IEnumerable<Societe>> ObtenireSocieteListe();
		Task<Societe> ObtenireSocieteParId(int Id);
		Task<int> CreationSociete(Societe entity);
		Task MisejourSociete(Societe entity);
		Task SuppressionSociete(int id);

	}
}
