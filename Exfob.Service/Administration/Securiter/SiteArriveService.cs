using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SiteArriveService : ISiteArriveService
	{

		private readonly ISiteArriveRepository _repository;

		public SiteArriveService(ISiteArriveRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SiteArrive>> ObtenireSiteArriveListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SiteArrive> ObtenireSiteArriveParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSiteArrive(SiteArrive entity)
		{
			await _repository.Creation(entity);
			return entity.SiteArriveID;
		}

		public async  Task MisejourSiteArrive(SiteArrive entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSiteArrive(int id)
		{
			await _repository.Delete(id);
		}
	}
}
