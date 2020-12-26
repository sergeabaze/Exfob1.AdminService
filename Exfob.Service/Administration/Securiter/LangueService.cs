using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Service.Administration.Securiter
{
    public class LangueService : ILangueService
    {
        private readonly ILangueRepository _repository;
       

        public LangueService(ILangueRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
           
        }

        public async Task<IEnumerable<Langue>> ObtenireLangueListe()
        {
            return await _repository.GetListe();
        }

        public async Task<Langue> ObtenireLangueParId(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async  Task<int> CreationLangue(Langue entity)
        {
             await _repository.Creation(entity);
            return entity.LangueID;
        }

        public async  Task MisejourLangue(Langue entity)
        {
            await _repository.Update(entity);
        }

      

        public async  Task SuppressionLangue(int id)
        {
            await _repository.Delete(id);
        }
       
    }
}
