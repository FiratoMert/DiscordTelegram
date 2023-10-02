using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;

namespace DiscordTelegram
{
    public partial class Discord : Form
    {
        public Discord()
        {
            InitializeComponent();
        }

        private string webhookUrl = "";
        private System.Threading.Timer screenshotTimer;
        private string token = "";
        private DiscordSocketClient client;

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

        private Bitmap TakeScreenshot()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }
            return screenshot;
        }

        private async Task SendDiscordWebhook(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    content = message
                };

                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                await client.PostAsync(webhookUrl, httpContent);
            }
        }

        private async Task SendScreenshotToDiscord(Bitmap screenshot)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    // Ekran görüntüsünü bir geçici dosyaya kaydet
                    string tempFilePath = Path.GetTempFileName();
                    screenshot.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png);

                    // Geçici dosyayı Discord'a yükle
                    using (var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(tempFilePath)))
                    {
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                        content.Add(fileContent, "file", "screenshot.png");

                        // Discord Webhook'uyla ekran görüntüsünü gönder
                        await client.PostAsync(webhookUrl, content);
                    }

                    // Geçici dosyayı sil
                    System.IO.File.Delete(tempFilePath);
                }
            }
        }


        private async void TimerCallBackFullScreen(object state)
        {
            // Ekran görüntüsü al
            Bitmap screenshot = TakeScreenshot();

            // Ekran görüntüsünü Discord Webhook'uyla gönder
            await SendScreenshotToDiscord(screenshot);
        }

        private async void TimerCallBackKnightOnlineClient(object sender)
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
                Bitmap screenshot = CaptureWindow(targetWindowHandle, targetWindowRect);

                SendScreenshotToDiscord(screenshot);
            }

            else
            {
                string message = "Knight Online Açık Değil!";

                SendDiscordWebhook(message);

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

        private async Task MessageReceived(SocketMessage message)
        {
            // Gelen mesaj bir bot mesajıysa veya içeriğinde "/ss" geçmiyorsa işlem yapma
            if (message.Author.IsBot || !message.Content.Contains("$ss"))
            {
                return;
            }

            // Ekran görüntüsü al
            Bitmap screenshot = TakeScreenshot();

            // Ekran görüntüsünü Discord'a gönder
            await SendScreenshotToDiscord(message.Channel, screenshot);
        }

        private async Task SendScreenshotToDiscord(ISocketMessageChannel channel, Bitmap screenshot)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);

                await channel.SendFileAsync(stream, "screenshot.png");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private void btn_webhookUrlSave_Click(object sender, EventArgs e)
        {
            if (txt_webhookUrl.Text != "")
            {
                webhookUrl = txt_webhookUrl.Text;
                txt_webhookUrl.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir webhook url giriniz.");
            }

        }
    }
}
