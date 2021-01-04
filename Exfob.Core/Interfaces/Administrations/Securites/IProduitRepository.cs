using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IProduitRepository : IGenericRepository<Produit>
	{
		Task<IEnumerable<Produit>> GetListe();
		Task<Produit> GetById(int Id);
		Task<int> Creation(Produit entity);
		Task Update(Produit entity);
		Task Delete(int id);
	}
}
