using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CategorieBoisService : ICategorieBoisService
	{

		private readonly ICategorieBoisRepository _repository;

		public CategorieBoisService(ICategorieBoisRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CategorieBois>> ObtenireCategorieBoisListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CategorieBois> ObtenireCategorieBoisParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCategorieBois(CategorieBois entity)
		{
			await _repository.Creation(entity);
			return entity.CategorieBoisID;
		}

		public async  Task MisejourCategorieBois(CategorieBois entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCategorieBois(int id)
		{
			await _repository.Delete(id);
		}
	}
}
