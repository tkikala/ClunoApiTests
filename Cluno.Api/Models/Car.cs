using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public int Kw { get; set; }

        public int Ps { get; set; }

        public string FuelType { get; set; }

        public string GearingType { get; set; }
    }
}
