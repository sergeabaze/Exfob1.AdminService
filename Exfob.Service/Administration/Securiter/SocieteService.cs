using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SocieteService : ISocieteService
	{

		private readonly ISocieteRepository _repository;

		public SocieteService(ISocieteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Societe>> ObtenireSocieteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Societe> ObtenireSocieteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSociete(Societe entity)
		{
			await _repository.Creation(entity);
			return entity.SocieteID;
		}

		public async  Task MisejourSociete(Societe entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSociete(int id)
		{
			await _repository.Delete(id);
		}
	}
}
