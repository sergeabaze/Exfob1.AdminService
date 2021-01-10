using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICodePlaquetteService
	{
		Task<IEnumerable<CodePlaquette>> ObtenireCodePlaquetteListe();
		Task<CodePlaquette> ObtenireCodePlaquetteParId(int Id);
		Task<int> CreationCodePlaquette(CodePlaquette entity);
		Task MisejourCodePlaquette(CodePlaquette entity);
		Task SuppressionCodePlaquette(int id);

	}
}
