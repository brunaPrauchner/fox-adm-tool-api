using System.Collections.Generic;

namespace FoxAdmTool.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IList<UserProduct> UserProducts { get; set; }
    }
}