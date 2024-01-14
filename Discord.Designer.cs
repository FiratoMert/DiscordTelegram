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
            this.btn_webhookUrlSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_webhookUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_avgExp = new System.Windows.Forms.NumericUpDown();
            this.chk_Ks = new System.Windows.Forms.CheckBox();
            this.chk_Disconnected = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chk_DeathControl = new System.Windows.Forms.CheckBox();
            this.chk_onlyProblem = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_avgExp)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(51, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 30);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hangi aralıklarla ekran görüntüsü almak istiyorsanız aşağıya saniye cinsinden\r\nya" +
    "zınız.";
            // 
            // num_Second
            // 
            this.num_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_Second.Location = new System.Drawing.Point(48, 179);
            this.num_Second.Maximum = new decimal(new int[] {
            100000000,
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
            this.btn_Exit.Location = new System.Drawing.Point(48, 409);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(434, 72);
            this.btn_Exit.TabIndex = 14;
            this.btn_Exit.Text = "Programdan Çık!";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Start.Location = new System.Drawing.Point(48, 331);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(434, 72);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.Text = "Programı Başlat!";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // chk_OnlyKo
            // 
            this.chk_OnlyKo.AutoSize = true;
            this.chk_OnlyKo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_OnlyKo.Location = new System.Drawing.Point(48, 206);
            this.chk_OnlyKo.Name = "chk_OnlyKo";
            this.chk_OnlyKo.Size = new System.Drawing.Size(218, 19);
            this.chk_OnlyKo.TabIndex = 13;
            this.chk_OnlyKo.Text = "Sadece Knight Online Görüntüsü Al";
            this.chk_OnlyKo.UseVisualStyleBackColor = true;
            this.chk_OnlyKo.CheckedChanged += new System.EventHandler(this.chk_OnlyKo_CheckedChanged);
            // 
            // btn_webhookUrlSave
            // 
            this.btn_webhookUrlSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_webhookUrlSave.Location = new System.Drawing.Point(48, 99);
            this.btn_webhookUrlSave.Name = "btn_webhookUrlSave";
            this.btn_webhookUrlSave.Size = new System.Drawing.Size(434, 44);
            this.btn_webhookUrlSave.TabIndex = 12;
            this.btn_webhookUrlSave.Text = "Webhook Url Kaydet";
            this.btn_webhookUrlSave.UseVisualStyleBackColor = true;
            this.btn_webhookUrlSave.Click += new System.EventHandler(this.btn_webhookUrlSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(355, 512);
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
            this.txt_webhookUrl.Size = new System.Drawing.Size(342, 62);
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
            // num_avgExp
            // 
            this.num_avgExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_avgExp.Location = new System.Drawing.Point(358, 280);
            this.num_avgExp.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.num_avgExp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_avgExp.Name = "num_avgExp";
            this.num_avgExp.Size = new System.Drawing.Size(115, 21);
            this.num_avgExp.TabIndex = 22;
            this.num_avgExp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chk_Ks
            // 
            this.chk_Ks.AutoSize = true;
            this.chk_Ks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_Ks.Location = new System.Drawing.Point(48, 281);
            this.chk_Ks.Name = "chk_Ks";
            this.chk_Ks.Size = new System.Drawing.Size(113, 19);
            this.chk_Ks.TabIndex = 19;
            this.chk_Ks.Text = "Ks Kontrolü Yap";
            this.chk_Ks.UseVisualStyleBackColor = true;
            // 
            // chk_Disconnected
            // 
            this.chk_Disconnected.AutoSize = true;
            this.chk_Disconnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_Disconnected.Location = new System.Drawing.Point(48, 256);
            this.chk_Disconnected.Name = "chk_Disconnected";
            this.chk_Disconnected.Size = new System.Drawing.Size(114, 19);
            this.chk_Disconnected.TabIndex = 20;
            this.chk_Disconnected.Text = "Dc Kontrolü Yap";
            this.chk_Disconnected.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(228, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ortalama Gelen Exp :";
            // 
            // chk_DeathControl
            // 
            this.chk_DeathControl.AutoSize = true;
            this.chk_DeathControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_DeathControl.Location = new System.Drawing.Point(48, 231);
            this.chk_DeathControl.Name = "chk_DeathControl";
            this.chk_DeathControl.Size = new System.Drawing.Size(129, 19);
            this.chk_DeathControl.TabIndex = 13;
            this.chk_DeathControl.Text = "Ölüm Kontrolü Yap";
            this.chk_DeathControl.UseVisualStyleBackColor = true;
            // 
            // chk_onlyProblem
            // 
            this.chk_onlyProblem.AutoSize = true;
            this.chk_onlyProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_onlyProblem.Location = new System.Drawing.Point(48, 306);
            this.chk_onlyProblem.Name = "chk_onlyProblem";
            this.chk_onlyProblem.Size = new System.Drawing.Size(300, 19);
            this.chk_onlyProblem.TabIndex = 19;
            this.chk_onlyProblem.Text = "Sadece Ölüm - Dc - Ks gibi durumlarda bilgilendir.";
            this.chk_onlyProblem.UseVisualStyleBackColor = true;
            this.chk_onlyProblem.CheckedChanged += new System.EventHandler(this.chk_onlyProblem_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Discord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num_avgExp);
            this.Controls.Add(this.chk_onlyProblem);
            this.Controls.Add(this.chk_Ks);
            this.Controls.Add(this.chk_Disconnected);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Second);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.chk_DeathControl);
            this.Controls.Add(this.chk_OnlyKo);
            this.Controls.Add(this.btn_webhookUrlSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_webhookUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Discord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord";
            this.Load += new System.EventHandler(this.Discord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_avgExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Second;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.CheckBox chk_OnlyKo;
        private System.Windows.Forms.Button btn_webhookUrlSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_webhookUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_avgExp;
        private System.Windows.Forms.CheckBox chk_Ks;
        private System.Windows.Forms.CheckBox chk_Disconnected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chk_DeathControl;
        private System.Windows.Forms.CheckBox chk_onlyProblem;
        private System.Windows.Forms.Button button1;
    }
}