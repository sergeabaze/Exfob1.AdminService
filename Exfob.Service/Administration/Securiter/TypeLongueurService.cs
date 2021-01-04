using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeLongueurService : ITypeLongueurService
	{

		private readonly ITypeLongueurRepository _repository;

		public TypeLongueurService(ITypeLongueurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeLongueur>> ObtenireTypeLongueurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeLongueur> ObtenireTypeLongueurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeLongueur(TypeLongueur entity)
		{
			await _repository.Creation(entity);
			return entity.TypeLongueurID;
		}

		public async  Task MisejourTypeLongueur(TypeLongueur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeLongueur(int id)
		{
			await _repository.Delete(id);
		}
	}
}
