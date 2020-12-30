using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IMaterielService
	{
		Task<IEnumerable<Materiel>> ObtenireMaterielListe();
		Task<Materiel> ObtenireMaterielParId(int Id);
		Task<int> CreationMateriel(Materiel entity);
		Task MisejourMateriel(Materiel entity);
		Task SuppressionMateriel(int id);

	}
}
