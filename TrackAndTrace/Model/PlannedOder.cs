using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlannedOderx
    {
        public string tanum { get; set; }
        public string matnr { get; set; }
        public string tbpos { get; set; }
        public string charg { get; set; }
        public float nsola { get; set; }
        public string zuser { get; set; }
        public string nlpla { get; set; }

    }

    public class Pnl
    {
        public string plnum { get; set; }
        public string idnrk { get; set; }
        public string posnr { get; set; }
        public string charg { get; set; }
        public float menge { get; set; }
        public string matnr { get; set; }
    }

    public class PlannedOder
    {
        public string tanum { get; set; }
        public string tbpos { get; set; }
        public string matnr { get; set; }
        public string charg { get; set; }
        public string nlpla { get; set; }
        public float nsola { get; set; }
        public string zuser { get; set; }
    }

}
