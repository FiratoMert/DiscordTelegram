using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace DiscordTelegram
{
    public partial class Telegram : Form
    {
        public Telegram()
        {
            InitializeComponent();
        }

        TelegramBotClient botClient;
        object sender;

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

        string telegramApi;
        string chatID;
        private System.Threading.Timer timer;

        private void btn_TelegramApiSave_Click(object sender, EventArgs e)
        {
            if (txt_TelegramApi.Text != "")
            {
                telegramApi = txt_TelegramApi.Text;
                botClient = new TelegramBotClient(telegramApi);
                btn_TelegramApiSave.Enabled = false;
                txt_TelegramApi.Enabled = false;
                MessageBox.Show("Telegram Api kaydedildi!");
            }

            else
            {
                MessageBox.Show("Lütfen geçerli bir api giriniz.");
            }


        }

        private void btn_chatIDSave_Click(object sender, EventArgs e)
        {

            if (txt_chatID.Text != "")
            {
                chatID = txt_chatID.Text;
                btn_chatIDSave.Enabled = false;
                txt_chatID.Enabled = false;
                MessageBox.Show("Chat ID kaydedildi!");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir chat id giriniz.");
            }

        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
                      
            Application.Exit();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

            #region ButonAktifPasif
            btn_Start.Enabled = false;
            chk_OnlyKo.Enabled = false;
            num_Second.Enabled = false;
            btn_Start.Text = "Program Başlatıldı!";
            #endregion

            try
            {
                MessageBox.Show("Program Başlatıldı!");

                string message = "";

                message = "Eğer bu mesajı aldıysanız telegram ile başarıyla iletişim kurulmuştur. /ss yazarak istediğiniz zaman ekran görüntüsü alabilirsiniz.";

                string apiUrl = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";

                try
                {
                    TelegramWebResponse(apiUrl);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Telegram API'ye erişim sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (num_Second.Value != 0)
                {

                    int aralik = (int)num_Second.Value;

                    if (chk_OnlyKo.Checked == true)
                    {
                        timer = new System.Threading.Timer(TimerCallBackKnightOnlineClient, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                    else
                    {
                        timer = new System.Threading.Timer(TimerCallBackFullScreen, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                }

                StartReceiver();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private static void TelegramWebResponse(string apiUrl)
        {
            WebRequest request = WebRequest.Create(apiUrl);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string result = reader.ReadToEnd();
                }
            }
        }

        public async Task StartReceiver()
        {
            var token = new CancellationTokenSource();
            var cancelToken = token.Token;
            var reOpt = new ReceiverOptions { AllowedUpdates = { } };
            await botClient.ReceiveAsync(OnMessage, ErrorMessage, reOpt, cancelToken);
        }

        public async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellation)
        {

            if (update.Message is global::Telegram.Bot.Types.Message message && !string.IsNullOrEmpty(message.Text))
            {

                if (message.Text.ToLower() == "/ss")
                {

                    if (chk_OnlyKo.Checked == true)
                    {

                        TimerCallBackKnightOnlineClient(sender);
                    }

                    else
                    {
                        Bitmap screenshot = ScreenShot();

                        SendPhotoTelegram(screenshot);
                    }

                }
            }

        }


        public async Task ErrorMessage(ITelegramBotClient telegramBot, Exception e, CancellationToken cancellation)
        {
            if (e is ApiRequestException requestException)
            {
                await botClient.SendTextMessageAsync("", e.Message.ToString());
            }
        }

        private static Bitmap ScreenShot()
        {
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }

        private async void TimerCallBackFullScreen(object state)
        {
            Bitmap bmpScreenshot = ScreenShot();
            await SendPhotoTelegram(bmpScreenshot);
        }

        private async Task SendPhotoTelegram(Bitmap bmpScreenshot)
        {
            using (var stream = new MemoryStream())
            {
                bmpScreenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                var fileName = $"{DateTime.Now.ToString()} tarihindeki ekran görüntüsü.jpg";
                await botClient.SendPhotoAsync(chatID, stream, fileName);
            }
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

                SendPhotoTelegram(screenshot);
            }

            else
            {
                string message = "Knight Online Açık Değil!";

                string apiUrl = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";

                TelegramWebResponse(apiUrl);

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
