using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IOperateurService
	{
		Task<IEnumerable<Operateur>> ObtenireOperateurListe();
		Task<Operateur> ObtenireOperateurParId(int Id);
		Task<int> CreationOperateur(Operateur entity);
		Task MisejourOperateur(Operateur entity);
		Task SuppressionOperateur(int id);

	}
}
