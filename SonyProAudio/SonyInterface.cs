using System;
using System.Collections.Generic;

namespace SonyProAudio
{
    public interface SonyInterface
    {
        /// <summary>
        /// Init the Sony object and Open the SerialPort
        /// </summary>
        void Init();
        /// <summary>
        /// Check if the serial port is open
        /// </summary>
        bool IsOpen();
        /// <summary>
        /// Close the serial port
        /// </summary>
        void Close();
        /// <summary>
        /// Enable remote mode. Required to send any commands
        /// </summary>
        void RemoteOn();
        /// <summary>
        /// Disable remote mode. Required to relinquish control back to the local unit
        /// </summary>
        void RemoteOff();
        /// <summary>
        /// Acts like pressing the play button on the front of the unit
        /// </summary>
        void Play();
        /// <summary>
        /// Acts like pressing the pause button on the front of the unit
        /// </summary>
        void Pause();
        /// <summary>
        /// Toggle between play and pause mode
        /// </summary>
        void PlayPause();
        /// <summary>
        /// Acts like the stop button on the front of the unit
        /// </summary>
        void Stop();
        /// <summary>
        /// Acts like the Next track button (or AMS scroll right)
        /// </summary>
        void NextTrack();
        /// <summary>
        /// Acts like the Back track button (or AMS scroll left)
        /// </summary>
        void BackTrack();
        /// <summary>
        /// Start FastForward mode. use <see cref="CancelFfRew">CancelFfRew()</see> to stop
        /// </summary>
        void Ff();
        /// <summary>
        /// Start Rewind mode. use <see cref="CancelFfRew">CancelFfRew()</see> to stop
        /// </summary>
        void Rew();
        /// <summary>
        /// Cancels FastForward or Rewind mode
        /// </summary>
        void CancelFfRew();
        /// <summary>
        /// <para>Play a specific track</para>
        /// <para>Does not work in pause mode. Because Sony</para>
        /// </summary>
        /// <param name="track">Track number to play 1-255</param>
        void PlayTrack(int track);
        /// <summary>
        /// <para>Pause at start of a specific track</para>
        /// <para>Does not work in pause mode. Because Sony</para>
        /// </summary>
        /// <param name="track">Track number to play 1-255</param>
        void PauseTrack(int track);
        /// <summary>
        /// Eject the disc
        /// </summary>
        void Eject();
    }
}
