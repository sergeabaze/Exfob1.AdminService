using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeEquipeService : ITypeEquipeService
	{

		private readonly ITypeEquipeRepository _repository;

		public TypeEquipeService(ITypeEquipeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeEquipe>> ObtenireTypeEquipeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeEquipe> ObtenireTypeEquipeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeEquipe(TypeEquipe entity)
		{
			await _repository.Creation(entity);
			return entity.TypeEquipeID;
		}

		public async  Task MisejourTypeEquipe(TypeEquipe entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeEquipe(int id)
		{
			await _repository.Delete(id);
		}
	}
}
