using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordTelegram
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private Telegram telegram;
        private Discord discord;

        private void btn_Discord_Click(object sender, EventArgs e)
        {
            discord = new Discord();
            discord.FormClosing += DiscordClosing;
            discord.Show();
            this.Hide();
        }

        private void btn_Telegram_Click(object sender, EventArgs e)
        {
            telegram = new Telegram();
            telegram.FormClosing += TelegramClosing;
            telegram.Show();
            this.Hide();
        }

        private void TelegramClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void DiscordClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void Choice_Load(object sender, EventArgs e)
        {
            btn_Discord.Enabled = false;
        }
    }
}
