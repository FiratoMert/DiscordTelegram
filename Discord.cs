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
using System.Net;
using Tesseract;
using Discord.Commands;
using System.Reflection;

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
        private System.Threading.Timer screenshotTimer2;
        private System.Threading.Timer screenshotTimer3;        
        private DiscordSocketClient client;
        private CommandService _commands;
        private readonly IServiceProvider _services;


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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                client = new DiscordSocketClient();
                _commands = new CommandService();

                client.Log += Log;

                RegisterCommandsAsync();

                client.LoginAsync(TokenType.Bot, "MTE1ODk5Mjc2NDA4MDQ5Njc2Mw.GOr6Ys.s7xw0c42FvY3jInoujK3uDUAcIxOcSUatW-sQc");
                client.StartAsync();
                Task.Delay(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public async Task RegisterCommandsAsync()
        {
            client.UserVoiceStateUpdated += HandleUserVoiceStateUpdated;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleUserVoiceStateUpdated(SocketUser user, SocketVoiceState oldState, SocketVoiceState newState)
        {
            // Örnek: Kullanıcı belirli bir odaya katıldığında davet gönder
            ulong targetUserId = 953748749740556312; // Davet gönderilecek kullanıcının ID'si
            ulong targetVoiceChannelId = 1158993150023565343; // Davet gönderilecek sesli kanalın ID'si

            if (user.Id == targetUserId && newState.VoiceChannel?.Id == targetVoiceChannelId)
            {
                var voiceChannel = client.GetChannel(targetVoiceChannelId) as IVoiceChannel;
                var invite = await voiceChannel.CreateInviteAsync();

                await user.SendMessageAsync($"Hey, gel ve bize katıl! {invite.Url}");
            }
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

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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
                GetWindowRect(targetWindowHandle, out RECT targetWindowRect);

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
                btn_webhookUrlSave.Enabled = false;
                MessageBox.Show("Webhook Url Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir webhook url giriniz.");
            }

        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Program Başlatıldı. Lütfen Discord'a bakınız. Mesaj geldiyse her şey yolundadır.");


                string message = "Eğer bu mesajı aldıysanız discord ile başarıyla iletişim kurulmuştur.";

                SendDiscordWebhook(message);


                if (chk_Disconnected.Checked == true)
                {

                    screenshotTimer2 = new System.Threading.Timer(DisconnectedControl, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
                }

                if (chk_DeathControl.Checked == true)
                {
                    screenshotTimer3 = new System.Threading.Timer(DeathControl, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
                }

                if (chk_onlyProblem.Checked == false)
                {
                    ScreenShotControl();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                        screenshotTimer = new System.Threading.Timer(TimerCallBackKnightOnlineClient, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                    else
                    {
                        screenshotTimer = new System.Threading.Timer(TimerCallBackFullScreen, null, TimeSpan.Zero, TimeSpan.FromSeconds(aralik));
                    }
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Discord_Load(object sender, EventArgs e)
        {
            chk_Ks.Enabled = false;
            num_avgExp.Enabled = false;
        }

        private void chk_OnlyKo_CheckedChanged(object sender, EventArgs e)
        {
            screenshotTimer = null;
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
                    GetWindowRect(targetWindowHandle, out RECT targetWindowRect);

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
                        SendScreenshotToDiscord(bitmap);
                        string message = "DC var dikkat!";
                        SendDiscordWebhook(message);

                    }

                }

                else
                {
                    string message = "Knight Online Açık Değil!";

                    SendDiscordWebhook(message);

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
                    GetWindowRect(targetWindowHandle, out RECT targetWindowRect);

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
                        SendScreenshotToDiscord(bitmap);
                        string message = "Karakter öldü! Oyuna Bak!";
                        SendDiscordWebhook(message);

                    }

                }

                else
                {
                    string message = "Knight Online Açık Değil!";

                    SendDiscordWebhook(message);

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
