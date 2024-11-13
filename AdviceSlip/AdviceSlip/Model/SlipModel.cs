using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceSlip.Model
{
    public class SlipModel
    {
        public Slip slip { get; set; }

        public class Slip
        {
            public int id { get; set; }
            public string advice { get; set; }
        }

    }
}
