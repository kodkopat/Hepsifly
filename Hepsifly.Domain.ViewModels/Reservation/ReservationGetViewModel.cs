using Hepsifly.Domain.ViewModels.Base;
using Hepsifly.Domain.ViewModels.Product;
using System;

namespace Hepsifly.Domain.ViewModels.Reservation
{
    public class ReservationGetViewModel : BaseViewModelModel
    {
        public ProductGetViewModel Product { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
    }
}
