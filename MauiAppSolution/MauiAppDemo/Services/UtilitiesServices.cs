using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppDemo.Services
{
    public class UtilitiesServices : IUtilitiesServices
    {
        private const decimal BaseDiscount = 0.10m; //10%

        public decimal ApplyDiscount(decimal originalPrice)
        {   
            return originalPrice * (1 - BaseDiscount);
        }
    }
}
