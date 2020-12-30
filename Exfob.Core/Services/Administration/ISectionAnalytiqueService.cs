using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISectionAnalytiqueService
	{
		Task<IEnumerable<SectionAnalytique>> ObtenireSectionAnalytiqueListe();
		Task<SectionAnalytique> ObtenireSectionAnalytiqueParId(int Id);
		Task<int> CreationSectionAnalytique(SectionAnalytique entity);
		Task MisejourSectionAnalytique(SectionAnalytique entity);
		Task SuppressionSectionAnalytique(int id);

	}
}
