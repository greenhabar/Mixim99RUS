using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;
using System.Timers;
using NAudio.Wave;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //Оно работает, но некрасивое(( 

    /*
    public class AudioPlayer
    {
        private WaveOutEvent waveOut;
        private Mp3FileReader reader;
        private Thread musThread;
        private bool isPlaying = false;

        public AudioPlayer()
        {
            waveOut = new WaveOutEvent();
            musThread = new Thread(PlayThread);

            reader = new Mp3FileReader(Properties.Resources.MainMenu1);
            waveOut.Init(reader);

            musThread.Start();
        }

        public void Play(string path)
        {
            if(path == "NULL!")
            {
                return;
            }
            Stop();
            reader = new Mp3FileReader(path);
            waveOut = new WaveOutEvent();
            waveOut.Init(reader);
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;

            isPlaying = true;
            musThread = new Thread(PlayThread);
            musThread.Start();
        }

        public void Stop()
        {
            isPlaying = false;
            if (musThread != null)
            {
                musThread.Join();
                musThread = null;
            }
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (!isPlaying) { return; }
            if (reader != null)
            {
                reader.Position = 0;
            }
            if (waveOut != null)
            {
                waveOut.Play();
            }
        }

        public void ChangeVolume()
        {
            GlobalVariables.volume = !GlobalVariables.volume;
            if (waveOut != null)
            {
                waveOut.Volume = (GlobalVariables.volume ? 1 : 0);
            }
        }

        private void PlayThread()
        {
            if (waveOut != null)
            {
                waveOut.Play();
                while (isPlaying) { }
            }
        }
    }
    */

    public struct AudioObject
    {
        public WaveOutEvent waveOut;
        public Mp3FileReader reader;
        public string paths;

        public AudioObject(string path, bool addPlaybackStopped = false)
        {
            waveOut = new WaveOutEvent();
            reader = new Mp3FileReader(path);
            paths = path;
            waveOut.Init(reader);

            if (addPlaybackStopped)
            {
                //waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            }
        }

        //private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        //{
        //    if (GlobalVariables.player.IsPlaying && reader != null)
        //    {
        //        MessageBox.Show(reader.ToString());
        //        reader.Dispose();
        //        reader = null;
        //        reader = new Mp3FileReader(paths);
        //        reader.Position = 0;
        //        waveOut.Init(reader);
        //        waveOut.Play();
        //    }
        //}

        public void Clear()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
        }
    }

    public class AudioPlayer
    {
        private List<AudioObject> waveOuts;
        private Thread musThread;
        private bool isPlaying = false;

        public bool IsPlaying => isPlaying;

        public AudioPlayer()
        {
            waveOuts = new List<AudioObject>();
        }

        public void Play(string path, bool addPlaybackStopped = true)
        {
            Stop(); // Остановка текущего воспроизведения

            AudioObject newAudioObject = new AudioObject(path, addPlaybackStopped);
            waveOuts.Add(newAudioObject);
            isPlaying = true;
            musThread = new Thread(PlayThread);
            musThread.Start();
        }

        public void Stop()
        {
            isPlaying = false;

            if (musThread != null)
            {
                musThread.Join();
                musThread = null;
            }

            foreach (var audioObject in waveOuts)
            {
                audioObject.Clear();
            }
            waveOuts.Clear();
        }

        public void ChangeVolume()
        {
            GlobalVariables.volume = !GlobalVariables.volume;
            if (waveOuts.Count > 0 && waveOuts[0].waveOut != null)
                waveOuts[0].waveOut.Volume = (GlobalVariables.volume ? 1 : 0);
        }

        private void PlayThread()
        {
            while (isPlaying && waveOuts.Count > 0)
            {
                foreach (var audioObject in waveOuts)
                {
                    if (audioObject.waveOut != null && audioObject.reader != null)
                    {
                        audioObject.waveOut.Play();
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void AddSound(string path, bool addPlaybackStopped = true)
        {
            AudioObject newAudioObject = new AudioObject(path, addPlaybackStopped);
            waveOuts.Add(newAudioObject);
        }
    }
}
