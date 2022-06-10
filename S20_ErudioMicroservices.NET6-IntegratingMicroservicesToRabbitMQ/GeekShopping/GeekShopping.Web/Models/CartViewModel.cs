using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GeekShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; }

        [ValidateNever]
        public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
    }
}
