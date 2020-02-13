using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Native.Csharp.Tool.Http;

namespace Rm.json
{
    public class Get
    {
        StringBuilder builder = new StringBuilder();
        public string Getjson(string city)
        {
            string msg = "";
            byte[] getbyte = HttpWebClient.Get("https://xiaojieapi.cn/API/epidemic.php?city=" + city);
            string getJson = Encoding.UTF8.GetString(getbyte);
            //Root rt = JsonConvert.DeserializeObject<Root>(getJson);
            //Total tal = JsonConvert.DeserializeObject<Total>(getJson);
            string json = getJson ;
            JObject root = JObject.Parse(json);
            JObject total = root["total"].Value<JObject>();
            var keys = total.GetEnumerator();
            while (keys .MoveNext ())
            {
                msg += keys.Current.ToString()+"\r";
            }
            var re = msg;
            re.Replace("[", "");
            re.Replace("]", "");
            return re;
        }


    }

    public class Total
    {
        /// <summary>
        /// 确认46例，死亡0例，治愈6例-共52例
        /// </summary>
        public string 昆明 { get; set; }
        /// <summary>
        /// 确认15例，死亡0例，治愈2例-共17例
        /// </summary>
        public string 西双版纳 { get; set; }
        /// <summary>
        /// 确认14例，死亡0例，治愈2例-共16例
        /// </summary>
        public string 玉溪 { get; set; }
        /// <summary>
        /// 确认14例，死亡0例，治愈1例-共15例
        /// </summary>
        public string 昭通 { get; set; }
        /// <summary>
        /// 确认13例，死亡0例，治愈1例-共14例
        /// </summary>
        public string 曲靖 { get; set; }
        /// <summary>
        /// 确认13例，死亡0例，治愈2例-共15例
        /// </summary>
        public string 大理州 { get; set; }
        /// <summary>
        /// 确认9例，死亡0例，治愈0例-共9例
        /// </summary>
        public string 保山 { get; set; }
        /// <summary>
        /// 确认7例，死亡0例，治愈2例-共9例
        /// </summary>
        public string 丽江 { get; set; }
        /// <summary>
        /// 确认6例，死亡0例，治愈2例-共8例
        /// </summary>
        public string 红河州 { get; set; }
        /// <summary>
        /// 确认5例，死亡0例，治愈0例-共5例
        /// </summary>
        public string 德宏州 { get; set; }
        /// <summary>
        /// 确认4例，死亡0例，治愈0例-共4例
        /// </summary>
        public string 普洱 { get; set; }
        /// <summary>
        /// 确认4例，死亡0例，治愈0例-共4例
        /// </summary>
        public string 楚雄州 { get; set; }
        /// <summary>
        /// 确认2例，死亡0例，治愈0例-共2例
        /// </summary>
        public string 文山州 { get; set; }
        /// <summary>
        /// 确认1例，死亡0例，治愈0例-共1例
        /// </summary>
        public string 临沧 { get; set; }
        /// <summary>
        /// 确认0例，死亡0例，治愈2例-共2例
        /// </summary>
        public string 待明确地区 { get; set; }
    }


    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 成功
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 云南省
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 确诊153 死亡0 治愈20-共173例
        /// </summary>
        public string statistics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Total total { get; set; }
    }

}
