using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class Itemcode
    {
        public string matnr { get; set; }
        public string maktx { get; set; }
        public string umrez { get; set; }
        public string eaN11 { get; set; }
        public string gS1 { get; set; }

        public Itemcode() { }

        public Itemcode(DataRow row)
        {
            this.matnr = row["matnr"].ToString();
            this.matnr = row["maktx"].ToString();
            this.matnr = row["umrez"].ToString();
            this.matnr = row["eaN11"].ToString();
            this.matnr = row["gS1"].ToString();
        }
    }
}
