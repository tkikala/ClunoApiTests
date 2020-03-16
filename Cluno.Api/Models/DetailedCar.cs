using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class DetailedCar: Car
    {
        public string Ccm { get; set; }

        public string Engine { get; set; }

        public string Drive { get; set; }

        public string Doors { get; set; }

        public string OfferExtColor { get; set; }

        public string[] EquipmentDetails { get; set; }

        public Environment Environment { get; set; }

    }
}
