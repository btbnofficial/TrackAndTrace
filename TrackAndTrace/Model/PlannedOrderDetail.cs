using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlannedOrderDetail
    {
        private int plnum;//planned order
        private string matnr;//ma san pham con
        private string maktx;//ten san pham con
        private double erfmg;//So luong
        private string erfme;//don vi tinh
        private string plwrk;//plan
        private string lgpro;//kho
        private string charg;//so batch
        private int posnr;//so thu tu

        public int Plnum { get => plnum; set => plnum = value; }
        public string Matnr { get => matnr; set => matnr = value; }
        public string Maktx { get => maktx; set => maktx = value; }
        public double Erfmg { get => erfmg; set => erfmg = value; }
        public string Erfme { get => erfme; set => erfme = value; }
        public string Plwrk { get => plwrk; set => plwrk = value; }
        public string Lgpro { get => lgpro; set => lgpro = value; }
        public string Charg { get => charg; set => charg = value; }
        public int Posnr { get => posnr; set => posnr = value; }

        public PlannedOrderDetail() { }

        public PlannedOrderDetail(int plnum, string matnr, string maktx, double erfmg, string erfme, 
            string plwrk, string lgpro, string charg, int posnr)
        {
            this.Plnum = plnum;
            this.Matnr = matnr;
            this.Maktx = maktx;
            this.Erfmg = erfmg;
            this.Erfme = erfme;
            this.Plwrk = plwrk;
            this.Lgpro = lgpro;
            this.Charg = charg;
            this.Posnr = posnr;
        }

        public PlannedOrderDetail(DataRow row)
        {
            this.Plnum = (int)row["Plnum"];
            this.Matnr = row["Matnr"].ToString();
            this.Maktx = row["Maktx"].ToString();
            this.Erfmg = Double.Parse(row["Erfmg"].ToString());
            this.Erfme = row["Erfme"].ToString();
            this.Plwrk = row["Plwrk"].ToString();
            this.Lgpro = row["Lgpro"].ToString();
            this.Charg = row["Charg"].ToString();
            this.Posnr = (int)row["Posnr"];
        }
    }
}
