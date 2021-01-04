using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class NatureMouvementRepository : GenericRepository<NatureMouvement>, INatureMouvementRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public NatureMouvementRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<NatureMouvement> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<NatureMouvement>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(NatureMouvement entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.NatureMouvementID ;
		}

		public async  Task Update(NatureMouvement entity)
		{
		if (entity == null) throw new Exception("Erreur. Objet nul détecté");
		await this.UpdateAsync(entity, true);
		}
		public async  Task Delete(int id)
		{
			await this.DeleteAsync(id, true);
		}

		#endregion
	}
}
