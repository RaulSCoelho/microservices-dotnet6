using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartVO
    {
        public CartHeaderVO CartHeader { get; set; }

        public IEnumerable<CartDetailVO> CartDetails { get; set; }
    }
}
