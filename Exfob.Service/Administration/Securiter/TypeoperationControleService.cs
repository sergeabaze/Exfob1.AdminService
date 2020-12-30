using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeoperationControleService : ITypeoperationControleService
	{

		private readonly ITypeoperationControleRepository _repository;

		public TypeoperationControleService(ITypeoperationControleRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeoperationControle>> ObtenireTypeoperationControleListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeoperationControle> ObtenireTypeoperationControleParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeoperationControle(TypeoperationControle entity)
		{
			await _repository.Creation(entity);
			return entity.TypeOperationControleID;
		}

		public async  Task MisejourTypeoperationControle(TypeoperationControle entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeoperationControle(int id)
		{
			await _repository.Delete(id);
		}
	}
}
