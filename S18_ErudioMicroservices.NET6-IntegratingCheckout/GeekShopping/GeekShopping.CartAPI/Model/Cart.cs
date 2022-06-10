using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;

namespace GeekShopping.CartAPI.Model
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }

        [ValidateNever]
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
