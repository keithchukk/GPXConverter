using Newtonsoft.Json;

namespace GPXConverter.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class EdgeTX_TBS_CrossFire
    {
        public string Date { get; set; }
        public string Time { get; set; }

        [JsonProperty("1RSS(dB)")]
        public string _1RSSdB { get; set; }

        [JsonProperty("2RSS(dB)")]
        public string _2RSSdB { get; set; }

        [JsonProperty("RQly(%)")]
        public string RQly { get; set; }

        [JsonProperty("RSNR(dB)")]
        public string RSNRdB { get; set; }
        public string ANT { get; set; }
        public string RFMD { get; set; }

        [JsonProperty("TPWR(mW)")]
        public string TPWRmW { get; set; }

        [JsonProperty("TRSS(dB)")]
        public string TRSSdB { get; set; }

        [JsonProperty("TQly(%)")]
        public string TQly { get; set; }

        [JsonProperty("TSNR(dB)")]
        public string TSNRdB { get; set; }

        [JsonProperty("Ptch(rad)")]
        public string Ptchrad { get; set; }

        [JsonProperty("Roll(rad)")]
        public string Rollrad { get; set; }

        [JsonProperty("Yaw(rad)")]
        public string Yawrad { get; set; }

        [JsonProperty("RxBt(V)")]
        public string RxBtV { get; set; }

        [JsonProperty("Curr(A)")]
        public string CurrA { get; set; }

        [JsonProperty("Capa(mAh)")]
        public string CapamAh { get; set; }

        [JsonProperty("Bat%(%)")]
        public string Bat { get; set; }
        public string FM { get; set; }
        public string GPS { get; set; }

        [JsonProperty("GSpd(kmh)")]
        public string GSpdkmh { get; set; }

        [JsonProperty("Hdg(°)")]
        public string Hdg { get; set; }

        [JsonProperty("Alt(m)")]
        public string Altm { get; set; }
        public string Sats { get; set; }
        public string Rud { get; set; }
        public string Ele { get; set; }
        public string Thr { get; set; }
        public string Ail { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string SA { get; set; }
        public string SB { get; set; }
        public string SC { get; set; }
        public string SD { get; set; }
        public string SE { get; set; }
        public string SF { get; set; }
        public string LSW { get; set; }

        [JsonProperty("CH1(us)")]
        public string CH1us { get; set; }

        [JsonProperty("CH2(us)")]
        public string CH2us { get; set; }

        [JsonProperty("CH3(us)")]
        public string CH3us { get; set; }

        [JsonProperty("CH4(us)")]
        public string CH4us { get; set; }

        [JsonProperty("CH5(us)")]
        public string CH5us { get; set; }

        [JsonProperty("CH6(us)")]
        public string CH6us { get; set; }

        [JsonProperty("CH7(us)")]
        public string CH7us { get; set; }

        [JsonProperty("CH8(us)")]
        public string CH8us { get; set; }

        [JsonProperty("CH9(us)")]
        public string CH9us { get; set; }

        [JsonProperty("CH10(us)")]
        public string CH10us { get; set; }

        [JsonProperty("CH11(us)")]
        public string CH11us { get; set; }

        [JsonProperty("CH12(us)")]
        public string CH12us { get; set; }

        [JsonProperty("CH13(us)")]
        public string CH13us { get; set; }

        [JsonProperty("CH14(us)")]
        public string CH14us { get; set; }

        [JsonProperty("CH15(us)")]
        public string CH15us { get; set; }

        [JsonProperty("CH16(us)")]
        public string CH16us { get; set; }

        [JsonProperty("CH17(us)")]
        public string CH17us { get; set; }

        [JsonProperty("CH18(us)")]
        public string CH18us { get; set; }

        [JsonProperty("CH19(us)")]
        public string CH19us { get; set; }

        [JsonProperty("CH20(us)")]
        public string CH20us { get; set; }

        [JsonProperty("CH21(us)")]
        public string CH21us { get; set; }

        [JsonProperty("CH22(us)")]
        public string CH22us { get; set; }

        [JsonProperty("CH23(us)")]
        public string CH23us { get; set; }

        [JsonProperty("CH24(us)")]
        public string CH24us { get; set; }

        [JsonProperty("CH25(us)")]
        public string CH25us { get; set; }

        [JsonProperty("CH26(us)")]
        public string CH26us { get; set; }

        [JsonProperty("CH27(us)")]
        public string CH27us { get; set; }

        [JsonProperty("CH28(us)")]
        public string CH28us { get; set; }

        [JsonProperty("CH29(us)")]
        public string CH29us { get; set; }

        [JsonProperty("CH30(us)")]
        public string CH30us { get; set; }

        [JsonProperty("CH31(us)")]
        public string CH31us { get; set; }

        [JsonProperty("CH32(us)")]
        public string CH32us { get; set; }

        [JsonProperty("TxBat(V)")]
        public string TxBatV { get; set; }

        public DateTime _DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }


}
