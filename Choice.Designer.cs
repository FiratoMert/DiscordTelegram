namespace DiscordTelegram
{
    partial class Choice
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
            this.btn_Discord = new System.Windows.Forms.Button();
            this.btn_Telegram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Discord
            // 
            this.btn_Discord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Discord.Location = new System.Drawing.Point(29, 33);
            this.btn_Discord.Name = "btn_Discord";
            this.btn_Discord.Size = new System.Drawing.Size(117, 128);
            this.btn_Discord.TabIndex = 0;
            this.btn_Discord.Text = "DISCORD";
            this.btn_Discord.UseVisualStyleBackColor = true;
            this.btn_Discord.Click += new System.EventHandler(this.btn_Discord_Click);
            // 
            // btn_Telegram
            // 
            this.btn_Telegram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Telegram.Location = new System.Drawing.Point(152, 33);
            this.btn_Telegram.Name = "btn_Telegram";
            this.btn_Telegram.Size = new System.Drawing.Size(117, 128);
            this.btn_Telegram.TabIndex = 0;
            this.btn_Telegram.Text = "TELEGRAM";
            this.btn_Telegram.UseVisualStyleBackColor = true;
            this.btn_Telegram.Click += new System.EventHandler(this.btn_Telegram_Click);
            // 
            // Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 194);
            this.Controls.Add(this.btn_Telegram);
            this.Controls.Add(this.btn_Discord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Choice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Discord;
        private System.Windows.Forms.Button btn_Telegram;
    }
}