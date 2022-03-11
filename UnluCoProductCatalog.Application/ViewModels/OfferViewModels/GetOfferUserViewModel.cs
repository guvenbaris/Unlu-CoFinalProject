using System;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
  public class GetOfferUserViewModel
    {
        public int Id { get; set; }
        public int PercentRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public GetProductUserViewModel Product { get; set; }
        public double OfferedPrice { get; set; }
        public bool IsApproved { get; set; }
    }
}
