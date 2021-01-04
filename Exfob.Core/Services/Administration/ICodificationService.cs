using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICodificationService
	{
		Task<IEnumerable<Codification>> ObtenireCodificationListe();
		Task<Codification> ObtenireCodificationParId(int Id);
		Task<int> CreationCodification(Codification entity);
		Task MisejourCodification(Codification entity);
		Task SuppressionCodification(int id);

	}
}
