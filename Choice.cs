using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;
using Tesseract;

namespace DiscordTelegram
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        // Dış işlevleri (API'ları) tanımlayın
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // RECT yapısı
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
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


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Hedef uygulamanın başlık metnini belirtin
                string targetWindowTitle = "Knight OnLine Client";

                // Hedef pencereyi bulun
                IntPtr targetWindowHandle = FindWindow(null, targetWindowTitle);

                if (targetWindowHandle != IntPtr.Zero)
                {
                    // Hedef pencere boyutunu ve konumunu alın
                    RECT targetWindowRect;
                    GetWindowRect(targetWindowHandle, out targetWindowRect);

                    // Ekran görüntüsünü alın
                    Bitmap bitmap = CaptureWindow(targetWindowHandle, targetWindowRect);

                    // Görüntüyü geçici bir dosyaya kaydet
                    var tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
                    bitmap.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png);

                    string recognizedText;

                    using (var engine = new TesseractEngine(@"C:\tessdata", "eng", EngineMode.Default))
                    {
                        using (var img = Pix.LoadFromFile(tempFilePath))
                        {
                            using (var page = engine.Process(img))
                            {
                                recognizedText = page.GetText();

                            }
                        }
                    }

                    // Geçici dosyayı sil
                    System.IO.File.Delete(tempFilePath);

                    MessageBox.Show($"{recognizedText}");


                }

                else
                {
                    

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static Bitmap CaptureWindow(IntPtr handle, RECT rect)
        {
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            Bitmap screenshot = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            }

            return screenshot;
        }
    }
}
