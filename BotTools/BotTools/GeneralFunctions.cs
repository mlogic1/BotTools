using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace BotTools
{

    static class GeneralFunctions
    {
        public static String GetCurrentBotAvatar(String Token)
        {
            String BotToken = Token;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/users/@me");
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("Authorization", "Bot " + BotToken);
            webRequest.UserAgent = "Chachanka (#7657, 0.14)";
            webRequest.Timeout = 10000;

            String currentBotAvatar;    // this will be the return result

            try
            {
                WebResponse response = webRequest.GetResponse();
                Stream inStream = response.GetResponseStream();
                StreamReader sReader = new StreamReader(inStream);
                String responseString = sReader.ReadToEnd();

                // Cleanup
                sReader.Close();
                sReader.Close();
                inStream.Close();
                response.Close();

                // Parse data
                JToken token = JObject.Parse(responseString);

                currentBotAvatar = token.SelectToken("avatar").ToString();

            }
            catch (ProtocolViolationException protoViolationEx)
            {
                protoViolationEx.ToString();
                return "ProtocolError-V";
            }catch(WebException WebEx)
            {
                WebEx.ToString();
                return "ProtocolError-W";
            }
            return currentBotAvatar;
        }

        public static String GetCurrentBotUsername(String Token)
        {
            String BotToken = Token;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/users/@me");
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("Authorization", "Bot " + BotToken);
            webRequest.UserAgent = "Chachanka (#7657, 0.14)";
            webRequest.Timeout = 10000;

            String currentBotNickname;  // this will be the return result

            try
            {
                WebResponse response = webRequest.GetResponse();
                Stream inStream = response.GetResponseStream();
                StreamReader sReader = new StreamReader(inStream);
                String responseString = sReader.ReadToEnd();

                // Cleanup
                sReader.Close();
                sReader.Close();
                inStream.Close();
                response.Close();

                // Parse data
                JToken token = JObject.Parse(responseString);

                currentBotNickname = token.SelectToken("username").ToString();
            }
            catch (ProtocolViolationException protoViolationEx)
            {
                protoViolationEx.ToString();
                return "ProtocolError-V";
            }
            catch (WebException WebEx)
            {
                WebEx.ToString();
                return "ProtocolError-W";
            }

            return currentBotNickname;
        }
    }

}
