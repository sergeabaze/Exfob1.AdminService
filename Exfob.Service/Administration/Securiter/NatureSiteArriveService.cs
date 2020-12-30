using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NatureSiteArriveService : INatureSiteArriveService
	{

		private readonly INatureSiteArriveRepository _repository;

		public NatureSiteArriveService(INatureSiteArriveRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NatureSiteArrive>> ObtenireNatureSiteArriveListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NatureSiteArrive> ObtenireNatureSiteArriveParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNatureSiteArrive(NatureSiteArrive entity)
		{
			await _repository.Creation(entity);
			return entity.NatureSiteArriveID;
		}

		public async  Task MisejourNatureSiteArrive(NatureSiteArrive entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNatureSiteArrive(int id)
		{
			await _repository.Delete(id);
		}
	}
}
