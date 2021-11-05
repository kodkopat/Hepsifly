using Hepsifly.Domain.Models.Enums;
using Hepsifly.Domain.ViewModels.Base;
using Hepsifly.Domain.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.ViewModels.Product
{
    public class ProductSaveViewModel : BaseViewModelModel
    {
        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Fiyat Alanı Zorunludur")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Para Birimi Alanı Zorunludur")]
        public CurrencyType Currency { get; set; }
        public string CategoryId { get; set; }
    }
}
