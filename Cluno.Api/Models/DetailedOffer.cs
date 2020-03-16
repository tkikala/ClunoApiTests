using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class DetailedOffer: Offer
    {
        public string Portfolio { get; set; }

        public string EstimatedDeliveryTime { get; set; }

        public int EarliestAvailabilityDays { get; set; }

        public new DetailedCar Car { get; set; }

        public Image[] Images { get; set; }

        public Conditions Conditions { get; set; }

        public new DetailedPricing Pricing { get; set; }

    }
}
