using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Offers
    {
        public int Count { get; set; }

        public Offer[] Items { get; set; }

        public object Legal { get; set; }
    }
}
