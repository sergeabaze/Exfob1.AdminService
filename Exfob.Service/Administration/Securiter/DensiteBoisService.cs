using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class DensiteBoisService : IDensiteBoisService
	{

		private readonly IDensiteBoisRepository _repository;

		public DensiteBoisService(IDensiteBoisRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<DensiteBois>> ObtenireDensiteBoisListe()
		{
			return await _repository.GetListe();
		}

		public async Task<DensiteBois> ObtenireDensiteBoisParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationDensiteBois(DensiteBois entity)
		{
			await _repository.Creation(entity);
			return entity.DensiteBoisID;
		}

		public async  Task MisejourDensiteBois(DensiteBois entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionDensiteBois(int id)
		{
			await _repository.Delete(id);
		}
	}
}
