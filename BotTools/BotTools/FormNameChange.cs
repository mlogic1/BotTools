using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTools
{

    public partial class FormNameChange : Form
    {
        public FormNameChange()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon_tag;  // set icon
        }

        public FormNameChange(String botToken)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon_tag;  // set icon
            textBoxToken.Text = botToken;
        }

        private void FormNameChange_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void buttonChangeNickname_Click(object sender, EventArgs e)
        {
            String BotToken = textBoxToken.Text.ToString();
            String nickname = textBoxNickname.Text.ToString();
            String currentBotAvatar = String.Empty;
            

            if(BotToken.Equals(String.Empty) || nickname.Equals(String.Empty)){
                MessageBox.Show("Both fiels are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentBotAvatar = GeneralFunctions.GetCurrentBotAvatar(BotToken);

            if (currentBotAvatar.Equals("ProtocolError-V"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentBotAvatar.Equals("ProtocolError-W"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and try again.", "Error - Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            String patchData = "{\"username\": \"" + nickname + "\", \"avatar\": \"" + currentBotAvatar + "\"}";


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp("https://discordapp.com/api/users/@me");
            webRequest.Method = "PATCH";                // set the method
            webRequest.ContentType = "application/json";   // content type
            webRequest.Headers.Add("Authorization", "Bot " + BotToken);
            webRequest.UserAgent = "BotToolsLib (#7657, 1.0)";
            webRequest.Timeout = 10000;

            UTF8Encoding encoder = new UTF8Encoding();    // encoder
            byte[] byteData = encoder.GetBytes(patchData);
            webRequest.ContentLength = byteData.Length;     // set request length


            File.WriteAllText("NameChangeDLL.txt", patchData);
            
            try
            {
                Stream outStream = webRequest.GetRequestStream();
                outStream.Write(byteData, 0, byteData.Length);
                outStream.Close();  // end

                WebResponse response = webRequest.GetResponse();
                Stream inStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(inStream);
                String responseStr = reader.ReadToEnd();
                reader.Close();
                inStream.Close();
                response.Close();
            }catch(ProtocolViolationException ex)
            {
                MessageBox.Show("There was an error getting information from Discord servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.WriteAllText("Error.txt", ex.ToString());
                return;
            }
            catch (WebException webEx)
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please note that you can only change bot username / avatar 2 times per hour.", "Error - Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                webEx.ToString();
                return;
            }

            MessageBox.Show("Nickname successfully changed, if your bot is offline, please connect it to see the change.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
