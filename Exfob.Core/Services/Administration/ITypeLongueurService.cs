using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeLongueurService
	{
		Task<IEnumerable<TypeLongueur>> ObtenireTypeLongueurListe();
		Task<TypeLongueur> ObtenireTypeLongueurParId(int Id);
		Task<int> CreationTypeLongueur(TypeLongueur entity);
		Task MisejourTypeLongueur(TypeLongueur entity);
		Task SuppressionTypeLongueur(int id);

	}
}
