using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IQualiteBoisService
	{
		Task<IEnumerable<QualiteBois>> ObtenireQualiteBoisListe();
		Task<QualiteBois> ObtenireQualiteBoisParId(int Id);
		Task<int> CreationQualiteBois(QualiteBois entity);
		Task MisejourQualiteBois(QualiteBois entity);
		Task SuppressionQualiteBois(int id);

	}
}
