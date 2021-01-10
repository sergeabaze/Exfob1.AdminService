using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ProfilService : IProfilService
	{

		private readonly IProfileRepository _repository;

		public ProfilService(IProfileRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Profil>> ObtenireProfilListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Profil> ObtenireProfilParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationProfil(Profil entity)
		{
			await _repository.Creation(entity);
			return entity.ProfilID;
		}

		public async  Task MisejourProfil(Profil entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionProfil(int id)
		{
			await _repository.Delete(id);
		}
	}
}
