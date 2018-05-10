using BespokeFusion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VocabularyUI.Utils
{
    public class Helper
    {
        public static MediaPlayer mediaPlayer = new MediaPlayer();
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static void PlaySoundFromBytes(byte[] soundBytes, string word)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory())
                  .Parent
                  .FullName;
            string path = String.Concat(projectPath, $@"\bin\Debug\temp\{word}.mp3");
            try
            {
                if (File.Exists(path))
                {
                    mediaPlayer.Open(new Uri(path, UriKind.Relative));
                    mediaPlayer.Play();
                }
                else
                {
                    using (FileStream fs = File.Create(path))
                    {
                        fs.Write(soundBytes, 0, soundBytes.Length);
                    }
                    mediaPlayer.Open(new Uri(path, UriKind.Relative));
                    mediaPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
    }
}
