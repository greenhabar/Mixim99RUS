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

namespace WindowsFormsApp1
{
    //Оно работает, но некрасивое(( 

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
}
