using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeMaterielService : ITypeMaterielService
	{

		private readonly ITypeMaterielRepository _repository;

		public TypeMaterielService(ITypeMaterielRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeMateriel>> ObtenireTypeMaterielListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeMateriel> ObtenireTypeMaterielParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeMateriel(TypeMateriel entity)
		{
			await _repository.Creation(entity);
			return entity.TypeMaterielID;
		}

		public async  Task MisejourTypeMateriel(TypeMateriel entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeMateriel(int id)
		{
			await _repository.Delete(id);
		}
	}
}
