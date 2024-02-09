using Microsoft.Win32;
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
using Tesseract;

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
        private System.Threading.Timer timer2;
        private System.Threading.Timer timer3;

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

            if (chk_RememberMe.Checked == true)
            {
                Registry.CurrentUser.CreateSubKey("discordtelegram").CreateSubKey("telegram").SetValue("TelegramApi", txt_TelegramApi.Text);
                Registry.CurrentUser.CreateSubKey("discordtelegram").CreateSubKey("telegram").SetValue("ChatId", txt_chatID.Text);
            }
            else
            {
                Registry.CurrentUser.CreateSubKey("discordtelegram").CreateSubKey("telegram").SetValue("TelegramApi", "");
                Registry.CurrentUser.CreateSubKey("discordtelegram").CreateSubKey("telegram").SetValue("ChatId", "");
            }
            

            #region ButonAktifPasif
            btn_Start.Enabled = false;
            num_Second.Enabled = false;
            chk_Disconnected.Enabled = false;
            chk_onlyProblem.Enabled = false;
            chk_DeathControl.Enabled = false;
            btn_Start.Text = "Program Başlatıldı!";
            #endregion

            try
            {
                MessageBox.Show("Program Başlatıldı. Lütfen Telegram'a bakınız. Mesaj geldiyse her şey yolundadır.");

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

                if (chk_Disconnected.Checked == true)
                {
                    timer2 = new System.Threading.Timer(DisconnectedControl, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
                }

                if (chk_DeathControl.Checked == true)
                {
                    timer3 = new System.Threading.Timer(DeathControl, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
                }

                if (chk_onlyProblem.Checked == false)
                {
                    ScreenShotControl();
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
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (WebResponse response = request.GetResponse())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (Stream stream = response.GetResponseStream())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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

        private void ScreenShotControl()
        {
            int aralik = (int)num_Second.Value;

            if (btn_Start.Enabled == false)
            {
                if (num_Second.Value != 0)
                {
                    if (chk_OnlyKo.Checked == true)
                    {
                        timer = new System.Threading.Timer(TimerCallBackKnightOnlineClient, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                    else
                    {
                        timer = new System.Threading.Timer(TimerCallBackFullScreen, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                }
            }
        }

        private void Telegram_Load(object sender, EventArgs e)
        {
            chk_Ks.Enabled = false;
            num_avgExp.Enabled = false;

            if (Registry.CurrentUser.OpenSubKey("discordtelegram") != null && Registry.CurrentUser.OpenSubKey("discordtelegram") != null)
            {
                txt_TelegramApi.Text = Registry.CurrentUser.OpenSubKey("discordtelegram").OpenSubKey("telegram").GetValue("TelegramApi").ToString();
                txt_chatID.Text = Registry.CurrentUser.OpenSubKey("discordtelegram").OpenSubKey("telegram").GetValue("ChatId").ToString();
                chk_RememberMe.Checked = true;
            }

        }

        private void chk_OnlyKo_CheckedChanged(object sender, EventArgs e)
        {
            timer = null;
            ScreenShotControl();
        }

        public void DisconnectedControl(object state)
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

                    if (recognizedText.ToLower().Contains("disconnected"))

                    {
                        SendPhotoTelegram(bitmap);
                        string message = "DC var dikkat!";
                        string apiUrl2 = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";
                        TelegramWebResponse(apiUrl2);

                    }
                }

                else
                {
                    string message = "Knight Online Açık Değil!";

                    string apiUrl = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";

                    TelegramWebResponse(apiUrl);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeathControl(object state)
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

                    if (recognizedText.ToLower().Contains("press ok"))

                    {
                        SendPhotoTelegram(bitmap);
                        string message = "Karakter öldü! Oyuna Bak!";
                        string apiUrl2 = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";
                        TelegramWebResponse(apiUrl2);

                    }
                }

                else
                {
                    string message = "Knight Online Açık Değil!";

                    string apiUrl = $"https://api.telegram.org/bot{telegramApi}/sendMessage?chat_id={chatID}&text={message}";

                    TelegramWebResponse(apiUrl);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void chk_onlyProblem_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_onlyProblem.Checked == true)
            {
                num_Second.Value = 0;
                num_Second.Enabled = false;
                chk_OnlyKo.Enabled = false;
                chk_DeathControl.Checked = true;
                chk_DeathControl.Enabled = false;
                chk_DeathControl.Text = "Ölüm kontrolü yapılacak!";
                chk_Disconnected.Checked = true;
                chk_Disconnected.Enabled = false;
                chk_Disconnected.Text = "Dc kontrolü yapılacak!";
            }

            else
            {
                num_Second.Value = 1;
                num_Second.Enabled = true;
                chk_OnlyKo.Enabled = true;
                chk_DeathControl.Checked = false;
                chk_DeathControl.Enabled = true;
                chk_Disconnected.Checked = false;
                chk_Disconnected.Enabled = true;
                chk_DeathControl.Text = "Ölüm kontrolü yap!";
                chk_Disconnected.Text = "Dc kontrolü yap!";
            }
        }
    }
}
