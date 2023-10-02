using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordTelegram
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private Choice choice;


        private void btn_Login_Click(object sender, EventArgs e)
        {
            string macAddress = GetMacAddress();

            choice = new Choice();
            choice.FormClosing += ChoiceClosing;
            choice.Show();
            this.Hide();
        }

        private void ChoiceClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        public static string GetMacAddress()
        {
            string macAddress = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Fiziksel (Physical) ağ kartını kontrol et
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddress;
        }

    }
}
