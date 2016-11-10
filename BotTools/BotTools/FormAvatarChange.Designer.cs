namespace BotTools
{
    partial class FormAvatarChange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonChangeAvatar = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRemoveAvatar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.buttonChooseImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonChangeAvatar);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemoveAvatar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 186);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(464, 33);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // buttonChangeAvatar
            // 
            this.buttonChangeAvatar.Enabled = false;
            this.buttonChangeAvatar.Location = new System.Drawing.Point(321, 3);
            this.buttonChangeAvatar.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.buttonChangeAvatar.Name = "buttonChangeAvatar";
            this.buttonChangeAvatar.Size = new System.Drawing.Size(134, 23);
            this.buttonChangeAvatar.TabIndex = 0;
            this.buttonChangeAvatar.Text = "Change avatar";
            this.buttonChangeAvatar.UseVisualStyleBackColor = true;
            this.buttonChangeAvatar.Click += new System.EventHandler(this.buttonChangeAvatar_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(240, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRemoveAvatar
            // 
            this.buttonRemoveAvatar.Enabled = false;
            this.buttonRemoveAvatar.Location = new System.Drawing.Point(10, 3);
            this.buttonRemoveAvatar.Margin = new System.Windows.Forms.Padding(3, 3, 125, 3);
            this.buttonRemoveAvatar.Name = "buttonRemoveAvatar";
            this.buttonRemoveAvatar.Size = new System.Drawing.Size(102, 23);
            this.buttonRemoveAvatar.TabIndex = 2;
            this.buttonRemoveAvatar.Text = "Remove avatar";
            this.buttonRemoveAvatar.UseVisualStyleBackColor = true;
            this.buttonRemoveAvatar.Click += new System.EventHandler(this.buttonRemoveAvatar_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(2, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 2);
            this.label1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(438, 45);
            this.label5.TabIndex = 14;
            this.label5.Text = "Change your bot\'s avatar image using this tool. Simply specify your token and the" +
    "\r\nimage file click Change avatar. If you just want to remove current avatar, cli" +
    "ck\r\nthe Remove avatar button.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Image file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Token";
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Location = new System.Drawing.Point(12, 153);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.ReadOnly = true;
            this.textBoxImagePath.Size = new System.Drawing.Size(409, 23);
            this.textBoxImagePath.TabIndex = 11;
            this.textBoxImagePath.TextChanged += new System.EventHandler(this.InputTextChanged);
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(12, 96);
            this.textBoxToken.MaxLength = 100;
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(440, 23);
            this.textBoxToken.TabIndex = 10;
            this.textBoxToken.TextChanged += new System.EventHandler(this.InputTextChanged);
            // 
            // buttonChooseImage
            // 
            this.buttonChooseImage.Location = new System.Drawing.Point(427, 153);
            this.buttonChooseImage.Name = "buttonChooseImage";
            this.buttonChooseImage.Size = new System.Drawing.Size(25, 23);
            this.buttonChooseImage.TabIndex = 15;
            this.buttonChooseImage.Text = "...";
            this.buttonChooseImage.UseVisualStyleBackColor = true;
            this.buttonChooseImage.Click += new System.EventHandler(this.buttonChooseImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Supported images |*.jpg;*.jpeg;*.png;";
            this.openFileDialog1.Title = "Select an image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "* Please note that you can only change bot avatar / username 2 times per hour.";
            // 
            // FormAvatarChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(464, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChooseImage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.textBoxToken);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAvatarChange";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change bot avatar";
            this.Load += new System.EventHandler(this.FormAvatarChange_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonChangeAvatar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Button buttonChooseImage;
        private System.Windows.Forms.Button buttonRemoveAvatar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
    }
}