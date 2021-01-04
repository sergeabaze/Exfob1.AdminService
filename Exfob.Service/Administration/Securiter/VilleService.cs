using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class VilleService : IVilleService
	{

		private readonly IVilleRepository _repository;

		public VilleService(IVilleRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Ville>> ObtenireVilleListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Ville> ObtenireVilleParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationVille(Ville entity)
		{
			await _repository.Creation(entity);
			return entity.VilleID;
		}

		public async  Task MisejourVille(Ville entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionVille(int id)
		{
			await _repository.Delete(id);
		}
	}
}
