using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IEquipeOperateurService
	{
		Task<IEnumerable<EquipeOperateur>> ObtenireEquipeOperateurListe();
		Task<EquipeOperateur> ObtenireEquipeOperateurParId(int Id);
		Task<int> CreationEquipeOperateur(EquipeOperateur entity);
		Task MisejourEquipeOperateur(EquipeOperateur entity);
		Task SuppressionEquipeOperateur(int id);

	}
}
