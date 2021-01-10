using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SectionAnalytiqueService : ISectionAnalytiqueService
	{

		private readonly ISectionAnalytiqueRepository _repository;

		public SectionAnalytiqueService(ISectionAnalytiqueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SectionAnalytique>> ObtenireSectionAnalytiqueListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SectionAnalytique> ObtenireSectionAnalytiqueParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSectionAnalytique(SectionAnalytique entity)
		{
			await _repository.Creation(entity);
			return entity.SectionAnalytiqueID;
		}

		public async  Task MisejourSectionAnalytique(SectionAnalytique entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSectionAnalytique(int id)
		{
			await _repository.Delete(id);
		}
	}
}
