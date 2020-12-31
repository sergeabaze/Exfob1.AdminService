using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class TarifIHCRepository : GenericRepository<TarifIHC>, ITarifIHCRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public TarifIHCRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<TarifIHC> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<TarifIHC>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(TarifIHC entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.TarifIHCID ;
		}

		public async  Task Update(TarifIHC entity)
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
