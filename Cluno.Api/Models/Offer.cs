using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Offer
    {
        public string Id { get; set; }

        public bool Available { get; set; }

        public string Segment { get; set; }

        public object Legal { get; set; }

        public bool IsEnvironmentallyFriendly { get; set; }

        public bool HasTowBar { get; set; }

        public bool IsAvailableAtShortNotice { get; set; }

        public string DetailUrl { get; set; }

        public Car Car { get; set; }

        public Teaser Teaser { get; set; }

        public string[] Labels { get; set; }

        public Pricing Pricing { get; set; }

    }
}
