using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class LoadingNavireService : ILoadingNavireService
	{

		private readonly ILoadingNavireRepository _repository;

		public LoadingNavireService(ILoadingNavireRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<LoadingNavire>> ObtenireLoadingNavireListe()
		{
			return await _repository.GetListe();
		}

		public async Task<LoadingNavire> ObtenireLoadingNavireParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationLoadingNavire(LoadingNavire entity)
		{
			await _repository.Creation(entity);
			return entity.LoadingNavireID;
		}

		public async  Task MisejourLoadingNavire(LoadingNavire entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionLoadingNavire(int id)
		{
			await _repository.Delete(id);
		}
	}
}
