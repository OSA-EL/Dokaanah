using Dokaanah.Models;

namespace Dokaanah.ViewModels
{
    public class shoppingCartViewModel
    {
        public List<ShoppingCartitem>? CartItems { get; set; }

        public float? TotalPrice { get; set; }

        public int? TotalQuantity { get; set;}
    }
}
