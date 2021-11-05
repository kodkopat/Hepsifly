using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Base
{
    public interface IBaseBusiness<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(string Id, string Name);
        string Add(T model);
        string Update(T Model);
        bool Delete(string Id);
    }
}
