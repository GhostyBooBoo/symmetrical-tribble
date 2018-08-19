using System;
using System.Collections.Generic;
using System.Text;

namespace Stitchy.Models
{
    public class Stitch
    {
        public string Comments { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public TimeSpan Duration
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }
    }
}
