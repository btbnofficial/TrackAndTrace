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
        private string charg;

        public Batch() { }

        public Batch(string charg)
        {
            this.Charg = charg;
        }

        public Batch(DataRow row)
        {
            this.Charg = row["Charg"].ToString();
        }

        public string Charg { get => charg; set => charg = value; }
    }
}
