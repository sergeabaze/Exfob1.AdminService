using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeMaterielService
	{
		Task<IEnumerable<TypeMateriel>> ObtenireTypeMaterielListe();
		Task<TypeMateriel> ObtenireTypeMaterielParId(int Id);
		Task<int> CreationTypeMateriel(TypeMateriel entity);
		Task MisejourTypeMateriel(TypeMateriel entity);
		Task SuppressionTypeMateriel(int id);

	}
}
