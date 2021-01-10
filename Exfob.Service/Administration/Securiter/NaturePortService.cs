using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NaturePortService : INaturePortService
	{

		private readonly INaturePortRepository _repository;

		public NaturePortService(INaturePortRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NaturePort>> ObtenireNaturePortListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NaturePort> ObtenireNaturePortParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNaturePort(NaturePort entity)
		{
			await _repository.Creation(entity);
			return entity.NaturePortID;
		}

		public async  Task MisejourNaturePort(NaturePort entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNaturePort(int id)
		{
			await _repository.Delete(id);
		}
	}
}
