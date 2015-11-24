using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.ServiceModel.Syndication;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace AutoPaper
{
    internal class Wallpaper
    {
        //private static string pattern = @"<a href=""(?<href>.*?)"">\[link\]";
        //private static Regex rgx = new Regex(pattern);
        private static int changeCount;
        private static string currentPath;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public static void ChangeWallpaper(object sender, ElapsedEventArgs e)
        {
            ChangeWallpaper();
        }

        public static void ChangeWallpaper()
        {
            var path = GetNextBackground();

            var style = (string) Conf.GetConf("style");
            var s = new WebClient().OpenRead(path);

            var img = Image.FromStream(s);
            var tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(tempPath, ImageFormat.Bmp);

            var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == "Stretched")
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == "Centered")
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == "Tiled")
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            SystemParametersInfo(20,
                0,
                tempPath,
                0x01 | 0x02);
        }

        private static string DownloadAndSave(Uri uri)
        {
            var ext = uri.ToString().Split('.').Last();
            var path = $"{Path.GetTempPath()}AutoPaper_wallpaper{changeCount++}.{ext}";
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(uri.ToString(), path);
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
            Conf.SetConf("lastUri", uri);
            currentPath = path;
            return path;
        }

        internal static void SaveTo()
        {
            if (currentPath == null)
            {
                MessageBox.Show("You can't save until you've changed the wallpaper.", "Save Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var saveFile = new SaveFileDialog();
            saveFile.FileName = currentPath.Split(Path.DirectorySeparatorChar).Last();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(saveFile.FileName);
                File.Copy(currentPath, saveFile.FileName);
            }
        }

        private static string GetNextBackground()
        {
            var policyA = (string) Conf.GetConf("policyA");
            var policyB = ((string) Conf.GetConf("policyB")).ToLower();
            var filter = (string) Conf.GetConf("filter");
            filter = null;
            var rssUri = new Uri($"https://www.reddit.com/r/WQHD_Wallpaper/{policyB}/.rss");
            Uri result = null;
            var lastUri = (Uri) Conf.GetConf("lastUri");
            using (var feedReader = XmlReader.Create(rssUri.ToString()))
            {
                var list = SyndicationFeed.Load(feedReader).Items.ToList();
                var i = -1;
                var rnd = new Random((int) DateTime.Now.Ticks);
                while (true)
                {
                    if (policyA == "Random")
                        i = rnd.Next(0, list.Count);
                    else if (policyA == "Top")
                    {
                        i++;
                        if (i >= list.Count)
                            return DownloadAndSave(result);
                    }
                    if (!string.IsNullOrEmpty(filter) && !list[i].Title.Text.Contains(filter))
                    {
                        list.RemoveAt(i);
                        continue;
                    }
                    //Match match = rgx.Match(list[i].Summary.Text);
                    //result = new Uri(match.Groups["href"].Value);
                    var res = list[i].Summary.Text.Substring(0,
                        list[i].Summary.Text.LastIndexOf("\">[link]", StringComparison.Ordinal));
                    var lastI = res.LastIndexOf("\"", StringComparison.Ordinal) + 1;
                    res = res.Substring(lastI, res.Length - lastI);
                    result = new Uri(res);
                    if (res.Split(Path.DirectorySeparatorChar).Last().Split('.').Length > 1 &&
                        (lastUri == null || (result.ToString() != lastUri.ToString())))
                        return DownloadAndSave(result);
                    if (policyA == "Random")
                        list.RemoveAt(i);
                }
            }
        }
    }
}