using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SiteAutoriseService : ISiteAutoriseService
	{

		private readonly ISiteAutoriseRepository _repository;

		public SiteAutoriseService(ISiteAutoriseRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SiteAutorise>> ObtenireSiteAutoriseListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SiteAutorise> ObtenireSiteAutoriseParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSiteAutorise(SiteAutorise entity)
		{
			await _repository.Creation(entity);
			return entity.SiteAutoriseID;
		}

		public async  Task MisejourSiteAutorise(SiteAutorise entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSiteAutorise(int id)
		{
			await _repository.Delete(id);
		}
	}
}
