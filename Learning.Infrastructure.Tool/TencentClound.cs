



using Newtonsoft.Json;

namespace Learning.Infrasturcture.Tool
{
    public class TencentClound
    {

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone">要发送的电话号码</param>
        /// <param name="msg">要发送的信息</param>
        /// <param name="key">发送密钥</param>
        /// <returns></returns>
        public static TencentClound SendMessage(string key, string appID, string appKey, string phone, string msg,string mSign,string mUrl)
        {
            string ext = "";
            string extend = "";
            long time = Config.GetTimeStamp();
            int random = Config.GetRandom(10000000, 999999999);
            var paramss = new[] { msg, "3" };
            string sig =EncryptUtil.Sha256($"appkey={appKey}&random={random}&time={time}&mobile={phone}");
         
            string url = mUrl + $"?sdkappid={appID}&random={random}";
            var v = new
            {
                ext = ext,
                extend = extend,
                @params = paramss,
                sig = sig,
                sign = mSign,
                tel = new
                {
                    mobile = phone,
                    nationcode = "86"
                },
                time = time,
                tpl_id = 415658
            };
            var result = JsonConvert.DeserializeObject<TencentClound>(Http.Post(url, Newtonsoft.Json.JsonConvert.SerializeObject(v)));
            return result;

        }

    }
}
