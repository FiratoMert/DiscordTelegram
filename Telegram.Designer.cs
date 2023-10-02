namespace DiscordTelegram
{
    partial class Telegram
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TelegramApi = new System.Windows.Forms.TextBox();
            this.btn_TelegramApiSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_chatID = new System.Windows.Forms.TextBox();
            this.btn_chatIDSave = new System.Windows.Forms.Button();
            this.chk_OnlyKo = new System.Windows.Forms.CheckBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.num_Second = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Telegram Api :";
            // 
            // txt_TelegramApi
            // 
            this.txt_TelegramApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_TelegramApi.Location = new System.Drawing.Point(135, 30);
            this.txt_TelegramApi.Multiline = true;
            this.txt_TelegramApi.Name = "txt_TelegramApi";
            this.txt_TelegramApi.Size = new System.Drawing.Size(342, 20);
            this.txt_TelegramApi.TabIndex = 1;
            // 
            // btn_TelegramApiSave
            // 
            this.btn_TelegramApiSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_TelegramApiSave.Location = new System.Drawing.Point(46, 79);
            this.btn_TelegramApiSave.Name = "btn_TelegramApiSave";
            this.btn_TelegramApiSave.Size = new System.Drawing.Size(431, 44);
            this.btn_TelegramApiSave.TabIndex = 2;
            this.btn_TelegramApiSave.Text = "Telegram Api Kaydet";
            this.btn_TelegramApiSave.UseVisualStyleBackColor = true;
            this.btn_TelegramApiSave.Click += new System.EventHandler(this.btn_TelegramApiSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(353, 549);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Powered By : Sipirmin";
            // 
            // txt_chatID
            // 
            this.txt_chatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_chatID.Location = new System.Drawing.Point(135, 143);
            this.txt_chatID.Multiline = true;
            this.txt_chatID.Name = "txt_chatID";
            this.txt_chatID.Size = new System.Drawing.Size(342, 20);
            this.txt_chatID.TabIndex = 1;
            // 
            // btn_chatIDSave
            // 
            this.btn_chatIDSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_chatIDSave.Location = new System.Drawing.Point(46, 192);
            this.btn_chatIDSave.Name = "btn_chatIDSave";
            this.btn_chatIDSave.Size = new System.Drawing.Size(431, 44);
            this.btn_chatIDSave.TabIndex = 2;
            this.btn_chatIDSave.Text = "Chat ID Kaydet";
            this.btn_chatIDSave.UseVisualStyleBackColor = true;
            this.btn_chatIDSave.Click += new System.EventHandler(this.btn_chatIDSave_Click);
            // 
            // chk_OnlyKo
            // 
            this.chk_OnlyKo.AutoSize = true;
            this.chk_OnlyKo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_OnlyKo.Location = new System.Drawing.Point(46, 327);
            this.chk_OnlyKo.Name = "chk_OnlyKo";
            this.chk_OnlyKo.Size = new System.Drawing.Size(218, 19);
            this.chk_OnlyKo.TabIndex = 3;
            this.chk_OnlyKo.Text = "Sadece Knight Online Görüntüsü Al";
            this.chk_OnlyKo.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Start.Location = new System.Drawing.Point(46, 368);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(434, 72);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "Programı Başlat!";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Exit.Location = new System.Drawing.Point(46, 446);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(434, 72);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Programdan Çık!";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // num_Second
            // 
            this.num_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_Second.Location = new System.Drawing.Point(43, 292);
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
            this.num_Second.TabIndex = 5;
            this.num_Second.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(43, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hangi aralıklarla ekran görüntüsü almak istiyorsanız aşağıya saniye cinsinden\r\nya" +
    "zınız.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(76, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chat ID :";
            // 
            // Telegram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 606);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Second);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.chk_OnlyKo);
            this.Controls.Add(this.btn_chatIDSave);
            this.Controls.Add(this.txt_chatID);
            this.Controls.Add(this.btn_TelegramApiSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TelegramApi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Telegram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telegram";
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TelegramApi;
        private System.Windows.Forms.Button btn_TelegramApiSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_chatID;
        private System.Windows.Forms.Button btn_chatIDSave;
        private System.Windows.Forms.CheckBox chk_OnlyKo;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.NumericUpDown num_Second;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}