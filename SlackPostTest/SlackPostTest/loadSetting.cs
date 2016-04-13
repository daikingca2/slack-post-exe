using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // 追加
using Codeplex.Data; // 追加

namespace SlackPostTest
{
    class loadSetting
    {
        // 設定ファイルとして読み込むファイル名
        public string file = "setting.json";

        // 設定をメンバで持っておく(暫定
        public string webhookurl = "";
        public string username = "";


        public bool loadJson()
        {
            bool res = true;
            string jsonString;

            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8")))
                {
                    jsonString = reader.ReadToEnd();
                }
                var setting = DynamicJson.Parse(jsonString);
                webhookurl = setting["webhookurl"];
                username   = setting["username"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }
    }
}
