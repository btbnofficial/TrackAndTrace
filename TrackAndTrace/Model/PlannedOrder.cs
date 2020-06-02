using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlannedOrder
    {
        private int plnum; // so plan
        private string matnr; // ma san pham
        private double gsmng;// so luong
        private string plwrk; // plan
        private string lgort; // kho
        private string maktx; // Ten san pham

        public int Plnum { get => plnum; set => plnum = value; }
        public string Matnr { get => matnr; set => matnr = value; }
        public double Gsmng { get => gsmng; set => gsmng = value; }
        public string Plwrk { get => plwrk; set => plwrk = value; }
        public string Lgort { get => lgort; set => lgort = value; }
        public string Maktx { get => maktx; set => maktx = value; }

        public PlannedOrder(int plnum, string matnr, double gsmng, string plwrk, string lgort, string maktx)
        {
            this.Plnum = plnum;
            this.Matnr = matnr;
            this.Gsmng = gsmng;
            this.Plwrk = plwrk;
            this.Lgort = lgort;
            this.Maktx = maktx;
        }

        public PlannedOrder(DataRow row)
        {
            this.Plnum = (int)row["Plnum"];
            this.Matnr = row["Matnr"].ToString();
            this.Gsmng = double.Parse(row["Gsmng"].ToString());
            this.Plwrk = row["Plwrk"].ToString();
            this.Lgort = row["Lgort"].ToString();
            this.Maktx = row["Maktx"].ToString();
        }

        public PlannedOrder() { }

    }
}
