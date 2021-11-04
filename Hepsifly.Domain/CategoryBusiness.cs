using Hepsifly.Domain.Implementions;
using Hepsifly.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain
{
    public class CategoryBusiness : BaseBusiness<Category>
    {

        public override bool Delete(string Id)
        {
            return base.Delete(Id);
        }
    }
}
