using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob.Infrastructure.Repository
{
    public interface IIDentityInspector<TEntity> where TEntity : class
    {
        string GetColumnsIdentityForType();
    }
}
