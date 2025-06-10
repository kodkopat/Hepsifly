using Hepsifly.Domain.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hepsifly.Domain.ViewModels.Reservation
{
    public class ReservationSaveViewModel : BaseViewModelModel
    {
        [Required(ErrorMessage = "ProductId is required")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
