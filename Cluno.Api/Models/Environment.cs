using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Environment
    {
        public double ConsumptionCity { get; set; }

        public double ConsumptionCombined { get; set; }

        public double ConsumptionCountry { get; set; }

        public string EmissionClass { get; set; }

        public double EmissionCO2 { get; set; }

        public string EmissionLabel { get; set; }

        public EmissionLabelChart EmissionLabelChart { get; set; }

        public string Underline { get; set; }

    }
}
