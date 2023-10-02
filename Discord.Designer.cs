namespace DiscordTelegram
{
    partial class Discord
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
            this.label3 = new System.Windows.Forms.Label();
            this.num_Second = new System.Windows.Forms.NumericUpDown();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.chk_OnlyKo = new System.Windows.Forms.CheckBox();
            this.btn_chatIDSave = new System.Windows.Forms.Button();
            this.txt_chatID = new System.Windows.Forms.TextBox();
            this.btn_webhookUrlSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_webhookUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(45, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 30);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hangi aralıklarla ekran görüntüsü almak istiyorsanız aşağıya saniye cinsinden\r\nya" +
    "zınız.";
            // 
            // num_Second
            // 
            this.num_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_Second.Location = new System.Drawing.Point(45, 293);
            this.num_Second.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.num_Second.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Second.Name = "num_Second";
            this.num_Second.Size = new System.Drawing.Size(434, 21);
            this.num_Second.TabIndex = 16;
            this.num_Second.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Exit.Location = new System.Drawing.Point(48, 447);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(434, 72);
            this.btn_Exit.TabIndex = 14;
            this.btn_Exit.Text = "Programdan Çık!";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Start.Location = new System.Drawing.Point(48, 369);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(434, 72);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.Text = "Programı Başlat!";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // chk_OnlyKo
            // 
            this.chk_OnlyKo.AutoSize = true;
            this.chk_OnlyKo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_OnlyKo.Location = new System.Drawing.Point(48, 328);
            this.chk_OnlyKo.Name = "chk_OnlyKo";
            this.chk_OnlyKo.Size = new System.Drawing.Size(218, 19);
            this.chk_OnlyKo.TabIndex = 13;
            this.chk_OnlyKo.Text = "Sadece Knight Online Görüntüsü Al";
            this.chk_OnlyKo.UseVisualStyleBackColor = true;
            // 
            // btn_chatIDSave
            // 
            this.btn_chatIDSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_chatIDSave.Location = new System.Drawing.Point(48, 193);
            this.btn_chatIDSave.Name = "btn_chatIDSave";
            this.btn_chatIDSave.Size = new System.Drawing.Size(431, 44);
            this.btn_chatIDSave.TabIndex = 11;
            this.btn_chatIDSave.Text = "Chat ID Kaydet";
            this.btn_chatIDSave.UseVisualStyleBackColor = true;
            // 
            // txt_chatID
            // 
            this.txt_chatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_chatID.Location = new System.Drawing.Point(137, 144);
            this.txt_chatID.Multiline = true;
            this.txt_chatID.Name = "txt_chatID";
            this.txt_chatID.Size = new System.Drawing.Size(342, 20);
            this.txt_chatID.TabIndex = 9;
            // 
            // btn_webhookUrlSave
            // 
            this.btn_webhookUrlSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_webhookUrlSave.Location = new System.Drawing.Point(48, 80);
            this.btn_webhookUrlSave.Name = "btn_webhookUrlSave";
            this.btn_webhookUrlSave.Size = new System.Drawing.Size(431, 44);
            this.btn_webhookUrlSave.TabIndex = 12;
            this.btn_webhookUrlSave.Text = "Webhook Url Kaydet";
            this.btn_webhookUrlSave.UseVisualStyleBackColor = true;
            this.btn_webhookUrlSave.Click += new System.EventHandler(this.btn_webhookUrlSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(355, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Powered By : Sipirmin";
            // 
            // txt_webhookUrl
            // 
            this.txt_webhookUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_webhookUrl.Location = new System.Drawing.Point(137, 31);
            this.txt_webhookUrl.Multiline = true;
            this.txt_webhookUrl.Name = "txt_webhookUrl";
            this.txt_webhookUrl.Size = new System.Drawing.Size(342, 20);
            this.txt_webhookUrl.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Webhook Url : ";
            // 
            // Discord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 610);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Second);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.chk_OnlyKo);
            this.Controls.Add(this.btn_chatIDSave);
            this.Controls.Add(this.txt_chatID);
            this.Controls.Add(this.btn_webhookUrlSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_webhookUrl);
            this.Controls.Add(this.label1);
            this.Name = "Discord";
            this.Text = "Discord";
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Second;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.CheckBox chk_OnlyKo;
        private System.Windows.Forms.Button btn_chatIDSave;
        private System.Windows.Forms.TextBox txt_chatID;
        private System.Windows.Forms.Button btn_webhookUrlSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_webhookUrl;
        private System.Windows.Forms.Label label1;
    }
}