using System;
using System.Collections.Generic;
using System.Text;

namespace Cluno.Api.Models
{
    public class Teaser
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Ribbon { get; set; }

        public string TeaserImage { get; set; }

        public string[] EquipmentHighlights { get; set; }
    }
}
