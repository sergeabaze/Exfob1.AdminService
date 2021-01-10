using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeFournisseurService : ITypeFournisseurService
	{

		private readonly ITypeFournisseurRepository _repository;

		public TypeFournisseurService(ITypeFournisseurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeFournisseur>> ObtenireTypeFournisseurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeFournisseur> ObtenireTypeFournisseurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeFournisseur(TypeFournisseur entity)
		{
			await _repository.Creation(entity);
			return entity.TypeFournisseurID;
		}

		public async  Task MisejourTypeFournisseur(TypeFournisseur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeFournisseur(int id)
		{
			await _repository.Delete(id);
		}
	}
}
