using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeOperateurService : ITypeOperateurService
	{

		private readonly ITypeOperateurRepository _repository;

		public TypeOperateurService(ITypeOperateurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeOperateur>> ObtenireTypeOperateurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeOperateur> ObtenireTypeOperateurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeOperateur(TypeOperateur entity)
		{
			await _repository.Creation(entity);
			return entity.TypeOperateurID;
		}

		public async  Task MisejourTypeOperateur(TypeOperateur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeOperateur(int id)
		{
			await _repository.Delete(id);
		}
	}
}
