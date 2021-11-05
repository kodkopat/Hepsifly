using Hepsifly.Domain.Models.Enums;
using Hepsifly.Domain.ViewModels.Base;
using Hepsifly.Domain.ViewModels.Category;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.ViewModels.Product
{
    public class ProductGetViewModel : BaseViewModelModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public ObjectId CategoryId { get; set; }
        public CategoryGetViewModel Category { get; set; }

    }
}
