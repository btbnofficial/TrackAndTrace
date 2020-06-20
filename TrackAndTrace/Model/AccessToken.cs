using Newtonsoft.Json;
using System;
using System.Data;

namespace TrackAndTrace.Model
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string accessToken { get; set; }

        [JsonProperty("token_type")]
        public string tokenType { get; set; }

        [JsonProperty("expires_in")]
        public int expiresIn { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty(".issued")]
        public string issued { get; set; }

        [JsonProperty(".expires")]
        public string expires { get; set; }
    }


    //public class PlandOrders
    //{
    //    public PlandOrder[] PlandOrde { get; set; }
    //}

    //public class PlandOrder
    //{
    //    public string plnum { get; set; }
    //    public string matnr { get; set; }
    //    public float gsmng { get; set; }
    //    public string plwrk { get; set; }
    //    public string lgort { get; set; }
    //    public string maktx { get; set; }
    //    public PlandOrderDetail[] detail { get; set; }
    //}

    //public class PlandOrderDetail
    //{
    //    public string plnum { get; set; }
    //    public string matnr { get; set; }
    //    public string maktx { get; set; }
    //    public float erfmg { get; set; }
    //    public string erfme { get; set; }
    //    public string plwrk { get; set; }
    //    public string lgpro { get; set; }
    //    public string charg { get; set; }
    //    public string posnr { get; set; }
    //}
}