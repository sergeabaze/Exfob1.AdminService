using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SiteOperationService : ISiteOperationService
	{

		private readonly ISiteOperationRepository _repository;

		public SiteOperationService(ISiteOperationRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SiteOperation>> ObtenireSiteOperationListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SiteOperation> ObtenireSiteOperationParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSiteOperation(SiteOperation entity)
		{
			await _repository.Creation(entity);
			return entity.SiteOperationID;
		}

		public async  Task MisejourSiteOperation(SiteOperation entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSiteOperation(int id)
		{
			await _repository.Delete(id);
		}
	}
}
