using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SciesService : ISciesService
	{

		private readonly IScieRepository _repository;

		public SciesService(IScieRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Scie>> ObtenireScieListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Scie> ObtenireScieParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationScie(Scie entity)
		{
			await _repository.Creation(entity);
			return entity.SciesID;
		}

		public async  Task MisejourScie(Scie entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionScie(int id)
		{
			await _repository.Delete(id);
		}
	}
}
