﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // 追加
using Codeplex.Data; // 追加

namespace SlackPostTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string actionMsg = "操作 : ";
            string sysUsername = "ユーザー名 : " + System.Environment.UserName; 
            string sendText = "";


            try
            {
                string startupPram;
                if (args.Length != 0)
                {
                    startupPram = args[0];

                    if (startupPram == "/login")
                    {
                        actionMsg += "ログイン";
                    }
                    else if (startupPram == "/logout")
                    {
                        actionMsg += "ログアウト";
                    }
                    else
                    {
                        actionMsg += "エ、ナニシタノ?";
                    }
                }
                else
                {
                    actionMsg += "エ、ナニシタノ?";
                }

                sendText = sysUsername + "\n" + actionMsg;



                loadSetting jsonObj = new loadSetting();
                jsonObj.loadJson();
                var url = jsonObj.webhookurl;
                var username = jsonObj.username;
                webRequest(sendText, url, username);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static bool webRequest(string sendMsg, string slackURL, string Botusername)
        {
            bool weRequestRes = true;
            var wc = new WebClient();
            var data = DynamicJson.Serialize(new
            {
                text = sendMsg,
                username = Botusername
            });

            wc.Headers.Add(HttpRequestHeader.ContentType, "application/json;Charset=UTF-8");
            wc.Encoding = Encoding.UTF8;

            wc.UploadString(slackURL, data);

            return weRequestRes;
        }

    }
}
