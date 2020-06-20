using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class Batch
    {
        public string matnr { get; set; }
        public string charg { get; set; }
        public string vfdat { get; set; }
        public string hsdat { get; set; }
        public string lgort { get; set; }

        public Batch() { }

        public Batch(DataRow row)
        {
            this.matnr = row["matnr"].ToString();
            this.matnr = row["charg"].ToString();
            this.matnr = row["vfdat"].ToString();
            this.matnr = row["hsdat"].ToString();
            this.matnr = row["lgort"].ToString();
        }
    }

    
}
