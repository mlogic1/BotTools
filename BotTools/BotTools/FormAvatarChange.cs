using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTools
{
    public partial class FormAvatarChange : Form
    {

        private ContextMenu rightClickMenuToken;
        private ContextMenu rightClickMenuImagePath;
        private ContextMenu rightClickMenuButton;

        public FormAvatarChange()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon_avatar;
            InitializeContextMenusClear();
        }

        public FormAvatarChange(String botToken)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon_avatar;
            textBoxToken.Text = botToken;
            buttonRemoveAvatar.Enabled = true;
            InitializeContextMenusClear();
        }

        private void InitializeContextMenusClear()
        {
            rightClickMenuToken = new ContextMenu();         // Initialize the menu strips
            rightClickMenuImagePath = new ContextMenu();
            rightClickMenuButton = new ContextMenu();
            rightClickMenuToken.MenuItems.Add("Clear").Click += ClearToken;
            rightClickMenuImagePath.MenuItems.Add("Clear").Click += ClearImagePath;
            rightClickMenuButton.MenuItems.Add("Clear").Click += ClearImagePath;

            textBoxToken.ContextMenu = rightClickMenuToken;
            textBoxImagePath.ContextMenu = rightClickMenuImagePath;
            buttonChooseImage.ContextMenu = rightClickMenuButton;     
        }

        private void ClearToken(object sender, EventArgs e)
        {
            textBoxToken.Clear();
        }

        private void ClearImagePath(object sender, EventArgs e)
        {
            textBoxImagePath.Clear();
        }

        private void buttonChooseImage_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImagePath.Text = openFileDialog1.FileName;
            }else
            {
                // do nothing
            }
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            if (textBoxToken.Text.Equals(String.Empty) && textBoxImagePath.Text.Equals(String.Empty))           // happens when there's no token and no image. Disable both buttons
            {
                buttonChangeAvatar.Enabled = false;
                buttonRemoveAvatar.Enabled = false;
            }else if(!textBoxToken.Text.Equals(String.Empty) && textBoxImagePath.Text.Equals(String.Empty))     // when there's a token but no image
            {
                buttonChangeAvatar.Enabled = false;
                buttonRemoveAvatar.Enabled = true;
            }else if(textBoxToken.Text.Equals(String.Empty) && !textBoxImagePath.Text.Equals(String.Empty))     // when there's image but no token
            {
                buttonChangeAvatar.Enabled = false;
                buttonRemoveAvatar.Enabled = false;
            }else                                                                                               // happens when there's both image and token
            {
                buttonChangeAvatar.Enabled = true;
                buttonRemoveAvatar.Enabled = true;
            }
        }


        private void FormAvatarChange_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeAvatar_Click(object sender, EventArgs e)
        {
            String BotToken = textBoxToken.Text.ToString();
            String imagepath = textBoxImagePath.Text.ToString();
            String base64img = String.Empty;
            String dataType = String.Empty;
            String currentBotNickname = String.Empty;

            // set up the data type
            if (openFileDialog1.FileName.EndsWith("png"))
            {
                dataType = "\"data:image/png;base64,";
            }else if (openFileDialog1.FileName.EndsWith("jpg"))
            {
                dataType = "\"data:image/jpg;base64,";
            }
            else if(openFileDialog1.FileName.EndsWith("jpeg"))
            {
                dataType = "\"data:image/jpeg;base64,";
            }else
            {
                MessageBox.Show("Error with file extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the current bot nickname (so it stays the same after the avatar change)
            currentBotNickname = GeneralFunctions.GetCurrentBotUsername(BotToken);

            if (currentBotNickname.Equals("ProtocolError-V"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentBotNickname.Equals("ProtocolError-W"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and try again.", "Error - Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base64img = imageToBase64(textBoxImagePath.Text);

            // When all required data is collected, prepare the PATCH data
            base64img = imageToBase64(imagepath);
            String patchData = "{\"username\": \"" + currentBotNickname + "\", \"avatar\": " + dataType + base64img + "\"}";


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp("https://discordapp.com/api/users/@me");
            webRequest.Method = "PATCH";
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("Authorization", "Bot " + BotToken);
            webRequest.UserAgent = "BotToolsLib (#7657, 1.0)";
            webRequest.Timeout = 10000;

            UTF8Encoding encoder = new UTF8Encoding();    // Encoding used to convert string to byte array
            byte[] byteData = encoder.GetBytes(patchData);
            webRequest.ContentLength = byteData.Length;

        

            try
            {
                Stream strm = webRequest.GetRequestStream();
                
                strm.Write(byteData, 0, byteData.Length);
                strm.Close();

                WebResponse response = webRequest.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String strResponse = reader.ReadToEnd();

                // Cleanup
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (ProtocolViolationException ex)
            {
                MessageBox.Show("There was an error getting information from Discord servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.WriteAllText("Error.txt", ex.ToString());
                return;
            }catch(WebException webEx)
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please note that you can only change bot username / avatar 2 times per hour.", "Error - Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                webEx.ToString();
                return;
            }

            MessageBox.Show("Avatar successfully changed, if your bot is offline, please connect it to see the change.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private String imageToBase64(String path)
        {
            string base64String = string.Empty;
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    // Convert byte[] to Base64 String
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            return base64String;
        }

        private void buttonRemoveAvatar_Click(object sender, EventArgs e)
        {
            String BotToken = textBoxToken.Text.ToString();
            String dataType = String.Empty;
            String currentBotNickname = String.Empty;



            // Get the current bot nickname (so it stays the same after the avatar change)
            currentBotNickname = GeneralFunctions.GetCurrentBotUsername(BotToken);

            if (currentBotNickname.Equals("ProtocolError-V"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentBotNickname.Equals("ProtocolError-W"))             // check if the information was obtained correctly
            {
                MessageBox.Show("There was an error getting information from Discord servers. Please check your Token and try again.", "Error - Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // When all required data is collected, prepare the PATCH data
            String patchData = "{\"username\": \"" + currentBotNickname + "\"}";


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp("https://discordapp.com/api/users/@me");
            webRequest.Method = "PATCH";
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("Authorization", "Bot " + BotToken);
            webRequest.UserAgent = "BotToolsLib (#7657, 1.0)";
            webRequest.Timeout = 10000;

            UTF8Encoding encoder = new UTF8Encoding();    // Encoding used to convert string to byte array
            byte[] byteData = encoder.GetBytes(patchData);
            webRequest.ContentLength = byteData.Length;
            MessageBox.Show(patchData);
            
            
            try
            {
                Stream strm = webRequest.GetRequestStream();

                strm.Write(byteData, 0, byteData.Length);
                strm.Close();

                WebResponse response = webRequest.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String strResponse = reader.ReadToEnd();

                // Cleanup
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (ProtocolViolationException ex)
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

            MessageBox.Show("Avatar successfully removed, if your bot is offline, please connect it to see the change.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
