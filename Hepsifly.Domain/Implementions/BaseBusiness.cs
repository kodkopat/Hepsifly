using Hepsifly.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Implementions
{
    public class BaseBusiness<T> : IBaseBusiness<T> where T : class
    {
        public virtual S Add<M, S>(M model)
        {
            throw new NotImplementedException();
        }
        public virtual bool Delete(string Id)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<M> Get<M>()
        {
            throw new NotImplementedException();
        }
        public virtual M Get<M>(string Id)
        {
            throw new NotImplementedException();
        }
        public virtual S Update<M, S>(M Model)
        {
            throw new NotImplementedException();
        }
    }
}
