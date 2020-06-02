using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class BatchBusiness
    {
        public static List<Batch> GetBatchList()
        {
            List<Batch> lstBatch = new List<Batch>();

            lstBatch.Add(new Batch("X411"));
            lstBatch.Add(new Batch("X412"));
            lstBatch.Add(new Batch("X413"));

            return lstBatch;
        }
    }
}
