using BespokeFusion;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace VocabularyUI.Utils
{
    public class Helper
    {
        private static Mp3FileReader mp3FileReader;
        private static WaveOut waveOut;

        public static BitmapImage LoadImage(byte[] imageData)
        {
            try
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
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
                return null;
            }
         
        }
        public static void PlaySoundFromBytes(byte[] soundBytes)
        {
            try
            {
                Task.Run(() =>
                {
                    using (MemoryStream ms = new MemoryStream(soundBytes))
                    {
                        mp3FileReader = new Mp3FileReader(ms);
                        waveOut = new WaveOut();
                        waveOut.Stop();
                        waveOut.Init(mp3FileReader);
                        waveOut.Play();
                        while(waveOut.PlaybackState == PlaybackState.Playing) { }
                    }
                });
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}