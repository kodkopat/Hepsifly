using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Abstractions
{
    public interface IBaseBusiness<T> where T : class
    {
        IEnumerable<M> Get<M>();
        M Get<M>(string Id);
        S Add<M, S>(M model);
        S Update<M, S>(M Model);
        bool Delete(string Id);
    }
}
