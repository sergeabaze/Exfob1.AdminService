using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IQualiteIHCService
	{
		Task<IEnumerable<QualiteIHC>> ObtenireQualiteIHCListe();
		Task<QualiteIHC> ObtenireQualiteIHCParId(int Id);
		Task<int> CreationQualiteIHC(QualiteIHC entity);
		Task MisejourQualiteIHC(QualiteIHC entity);
		Task SuppressionQualiteIHC(int id);

	}
}
