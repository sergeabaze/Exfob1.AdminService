using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class AffecterEquipeService : IAffecterEquipeService
	{

		private readonly IAffecterEquipeRepository _repository;

		public AffecterEquipeService(IAffecterEquipeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<AffecterEquipe>> ObtenireAffecterEquipeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<AffecterEquipe> ObtenireAffecterEquipeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationAffecterEquipe(AffecterEquipe entity)
		{
			await _repository.Creation(entity);
			return entity.AffecterEquipeID;
		}

		public async  Task MisejourAffecterEquipe(AffecterEquipe entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionAffecterEquipe(int id)
		{
			await _repository.Delete(id);
		}
	}
}
