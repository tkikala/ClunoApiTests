using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class DetailedPricing: Pricing
    {
        public double StartingFee { get; set; }

        public double DeliveryFee { get; set; }

        public string Note { get; set; }

        public string Underline { get; set; }

        public string Term { get; set; }

        public double ExcessKilometers { get; set; }

        public double MonthlyExcessKilometers { get; set; }

        public double UnusedKilometers { get; set; }

        public double IncludedAnnualKilometers { get; set; }

        public double DeductiblePartialCover { get; set; }

        public double DeductibleFullyComprehensive { get; set; }

        public BookableOption[] BookableOptions { get; set; }
    }
}
