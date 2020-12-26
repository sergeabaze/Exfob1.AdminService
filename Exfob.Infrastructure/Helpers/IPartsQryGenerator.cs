using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob.Infrastructure.Repository
{
    public interface IPartsQryGenerator<TEntity> where TEntity : class
    {
        string GenerateSelect();
        string GenerateSelect(object fieldsFilter);
        string GeneratePartInsert(string identityField = null);
        string GenerateDelete(object parameters);
        string GenerateUpdate(object pks);
    }
}
