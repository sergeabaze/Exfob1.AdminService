using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeFactureService : ITypeFactureService
	{

		private readonly ITypeFactureRepository _repository;

		public TypeFactureService(ITypeFactureRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeFacture>> ObtenireTypeFactureListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeFacture> ObtenireTypeFactureParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeFacture(TypeFacture entity)
		{
			await _repository.Creation(entity);
			return entity.TypeFactureID;
		}

		public async  Task MisejourTypeFacture(TypeFacture entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeFacture(int id)
		{
			await _repository.Delete(id);
		}
	}
}
