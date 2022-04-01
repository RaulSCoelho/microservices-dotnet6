using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartVO
    {
        [ValidateNever]
        public CartHeaderVO CartHeader { get; set; }

        [ValidateNever]
        public IEnumerable<CartDetailVO> CartDetails { get; set; }
    }
}
