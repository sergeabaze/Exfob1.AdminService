using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeOperateurService
	{
		Task<IEnumerable<TypeOperateur>> ObtenireTypeOperateurListe();
		Task<TypeOperateur> ObtenireTypeOperateurParId(int Id);
		Task<int> CreationTypeOperateur(TypeOperateur entity);
		Task MisejourTypeOperateur(TypeOperateur entity);
		Task SuppressionTypeOperateur(int id);

	}
}
