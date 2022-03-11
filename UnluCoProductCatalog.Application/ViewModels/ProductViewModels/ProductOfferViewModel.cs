using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class ProductOfferViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
    }
}
