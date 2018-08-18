using System;
using System.Collections.Generic;
using System.Text;

namespace Stitchy.Models
{
    public class Stitch
    {
        public string Comments { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
