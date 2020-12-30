using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INatureConteneurService
	{
		Task<IEnumerable<NatureConteneur>> ObtenireNatureConteneurListe();
		Task<NatureConteneur> ObtenireNatureConteneurParId(int Id);
		Task<int> CreationNatureConteneur(NatureConteneur entity);
		Task MisejourNatureConteneur(NatureConteneur entity);
		Task SuppressionNatureConteneur(int id);

	}
}
