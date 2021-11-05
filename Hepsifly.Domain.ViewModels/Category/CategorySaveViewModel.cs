using Hepsifly.Domain.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.ViewModels.Category
{
    public class CategorySaveViewModel: BaseViewModelModel
    {
        [Required(ErrorMessage ="Ad Alanı Zorunludur")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
