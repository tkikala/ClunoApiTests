using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Pricing
    {
        public double Price { get; set; }

        public string CurrencyIsoCode { get; set; }

        public string CurrencySymbol { get; set; }

    }
}
