using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NatureSiteService : INatureSiteService
	{

		private readonly INatureSiteRepository _repository;

		public NatureSiteService(INatureSiteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NatureSite>> ObtenireNatureSiteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NatureSite> ObtenireNatureSiteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNatureSite(NatureSite entity)
		{
			await _repository.Creation(entity);
			return entity.NatureSiteID;
		}

		public async  Task MisejourNatureSite(NatureSite entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNatureSite(int id)
		{
			await _repository.Delete(id);
		}
	}
}
