using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class EquipeService : IEquipeService
	{

		private readonly IEquipeRepository _repository;

		public EquipeService(IEquipeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Equipe>> ObtenireEquipeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Equipe> ObtenireEquipeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationEquipe(Equipe entity)
		{
			await _repository.Creation(entity);
			return entity.EquipeID;
		}

		public async  Task MisejourEquipe(Equipe entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionEquipe(int id)
		{
			await _repository.Delete(id);
		}
	}
}
