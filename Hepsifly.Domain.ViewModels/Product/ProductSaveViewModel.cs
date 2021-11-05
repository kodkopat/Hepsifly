using Hepsifly.Domain.ViewModels.Base;
using Hepsifly.Domain.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.ViewModels.Product
{
    public class ProductSaveViewModel : BaseViewModelModel
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}
