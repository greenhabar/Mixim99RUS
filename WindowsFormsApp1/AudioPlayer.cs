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
    public class AudioPlayer
    {
        private static WaveOutEvent waveOut;
        private static Mp3FileReader reader;
        private Thread musThread;
        private static bool isPlaying = false;
        public AudioPlayer()
        {
            waveOut = new WaveOutEvent();

            musThread = new Thread(PlayThread);
        }

        public void Play(System.IO.UnmanagedMemoryStream ms)
        {
            Stop();
            reader = new Mp3FileReader(ms);
            waveOut = new WaveOutEvent();
            waveOut.Init(reader);
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;

            isPlaying = true;
            musThread = new Thread(PlayThread);
            musThread.Start();
        }
        public void Stop()
        {
            isPlaying=false;
            musThread.Abort();
            waveOut.Stop();
            waveOut.Dispose();
        }
        static void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if(!isPlaying) { return; }
            reader.Position = 0;
            waveOut.Play();
        }
        public void ChangeVolume()
        {
            GlobalVariables.volume = !GlobalVariables.volume;
            waveOut.Volume = (GlobalVariables.volume ? 1 : 0);
        }
        private void PlayThread()
        {
            waveOut.Play();
            while(isPlaying) { }
        }
    }
}
