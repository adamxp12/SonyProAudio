using ExtendedSerialPort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonyProAudio
{
    public class CDP : SonyInterface
    {
        private ReliableSerialPort sPort;
        private string sPortStr;

        public event EventHandler<SonyEnums.RawDataReceivedArgs> RawDataReceived;
        public event EventHandler OnImpossibleCommand;
        public event EventHandler OnUndefinedCommand;
        public event EventHandler<SonyEnums.MechStateArgs> OnMechChange;
        public event EventHandler<SonyEnums.ElapsedTImeArgs> OnElapsedTime;
        public event EventHandler<SonyEnums.TrackTimeArgs> OnTrackTime;
        public event EventHandler<SonyEnums.ElapsedTImeArgs> OnTrackChange;
        public event EventHandler<SonyEnums.TocDataArgs> OnTocData;
        public event EventHandler<SonyEnums.CDPStatusArgs> OnStatus;
        public event EventHandler<SonyEnums.ModelNameArgs> OnModelName;
        public event EventHandler OnDiscExist;

        public CDP(String port)
        {
            sPortStr = port;
        }

        public void Init()
        {
            sPort = new ReliableSerialPort(sPortStr, 9600);
            sPort.Open();
            sPort.DataReceived += DataReceived;
        }

        private void DataReceived(object sender, DataReceivedArgs e)
        {
            byte[] buf = e.Data;
            RawDataReceived?.Invoke(this, new SonyEnums.RawDataReceivedArgs { message = buf });
            if (buf[0].Equals(111) && buf[3].Equals(65))
            {
                // 40h
                if (buf[4].Equals(64))
                {
                    if (buf[5].Equals(1)) OnUndefinedCommand?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(3)) OnImpossibleCommand?.Invoke(this, EventArgs.Empty);
                }

                // 20h
                if (buf[4].Equals(32))
                {

                    if (buf[5].Equals(32))
                    {
                        // complicated status command
                        SonyEnums.CDPStatusArgs sa = new SonyEnums.CDPStatusArgs();

                        decimal dd1 = Convert.ToDecimal(buf[6]);
                        string bin1 = Convert.ToString(int.Parse(dd1.ToString()), 2).PadLeft(8, '0');
                        decimal dd2 = Convert.ToDecimal(buf[7]);
                        string bin2 = Convert.ToString(int.Parse(dd2.ToString()), 2).PadLeft(8, '0');
                        sa.trackno = int.Parse(Convert.ToDecimal(buf[10]).ToString());


                        string b3b2b1b0 = bin1[4].ToString() + bin1[5].ToString() + bin1[6].ToString() + bin1[7].ToString();
                        switch (b3b2b1b0)
                        {
                            case "0000":
                                sa.MechState = SonyEnums.MechState.stop;
                                break;
                            case "0001":
                                sa.MechState = SonyEnums.MechState.play;
                                break;
                            case "0010":
                                sa.MechState = SonyEnums.MechState.pause;
                                break;
                            case "0011":
                                sa.MechState = SonyEnums.MechState.eject;
                                break;
                            case "1111":
                                sa.MechState = SonyEnums.MechState.playunavailable;
                                break;
                            default:
                                break;
                        }

                        if (bin1[2].ToString().Equals("1")) sa.DiscExist = false; else sa.DiscExist = true;

                        if (bin2[0].ToString().Equals("1")) sa.TocReadDone = true; else sa.TocReadDone = false;
                        string b5b4 = bin2[2].ToString() + bin2[3].ToString();

                        switch (b5b4)
                        {
                            case "00":
                                sa.RepeatMode = SonyEnums.RepeatMode.repeatoff;
                                break;
                            case "01":
                                sa.RepeatMode = SonyEnums.RepeatMode.repeatall;
                                break;
                            case "10":
                                sa.RepeatMode = SonyEnums.RepeatMode.repeatone;
                                break;
                            case "11":
                                sa.RepeatMode = SonyEnums.RepeatMode.repeatab;
                                break;
                            default:
                                break;
                        }

                        b3b2b1b0 = bin2[4].ToString() + bin2[5].ToString() + bin2[6].ToString() + bin2[7].ToString();
                        switch (b3b2b1b0)
                        {
                            case "0000":
                                sa.PlayMode = SonyEnums.PlayMode.play;
                                break;
                            case "0001":
                                sa.PlayMode = SonyEnums.PlayMode.shuffle;
                                break;
                            case "0010":
                                sa.PlayMode = SonyEnums.PlayMode.program;
                                break;
                            default:
                                break;
                        }

                        OnStatus?.Invoke(this, sa);

                    }

                    if (buf[5].Equals(34)) parseModelName(buf);

                    if (buf[5].Equals(80)) OnTrackChange?.Invoke(this, new SonyEnums.ElapsedTImeArgs
                    {
                        trackno = int.Parse(Convert.ToDecimal(buf[7]).ToString()),
                        mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()),
                        secs = int.Parse(Convert.ToDecimal(buf[9]).ToString())
                    });



                    if (buf[5].Equals(81)) OnElapsedTime?.Invoke(this, new SonyEnums.ElapsedTImeArgs
                    {
                        trackno = int.Parse(Convert.ToDecimal(buf[6]).ToString()),
                        mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()),
                        secs = int.Parse(Convert.ToDecimal(buf[9]).ToString())
                    });

                    if (buf[5].Equals(98)) OnTrackTime?.Invoke(this, new SonyEnums.TrackTimeArgs { mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()), secs = int.Parse(Convert.ToDecimal(buf[9]).ToString()) });

                    if (buf[5].Equals(96)) OnTocData?.Invoke(this, new SonyEnums.TocDataArgs
                    {
                        firstTrack = int.Parse(Convert.ToDecimal(buf[7]).ToString()),
                        lastTrack = int.Parse(Convert.ToDecimal(buf[8]).ToString()),
                        mins = int.Parse(Convert.ToDecimal(buf[9]).ToString()),
                        secs = int.Parse(Convert.ToDecimal(buf[10]).ToString())
                    });

                    if (buf[5].Equals(130)) OnDiscExist?.Invoke(this, EventArgs.Empty);
                }

                // 2h
                if (buf[4].Equals(2))
                {
                    OnMechChange?.Invoke(this, new SonyEnums.MechStateArgs { state = (SonyEnums.MechState)buf[5] });
                }

            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Parse the modelname packet into a string
        /// </summary>
        /// <param name="b">byte array of packet to parse</param>
        private void parseModelName(byte[] b)
        {
            StringBuilder model = new StringBuilder();

            for (int i = 6; i < b.Length - 1; i++)
            {
                string c = Char.ConvertFromUtf32(b[i]);
                if (b[i].ToString().Equals("0"))
                {
                    OnModelName?.Invoke(this, new SonyEnums.ModelNameArgs { modelname = model.ToString() });
                    break;
                }
                model.Append(c);
            }
        }

        public Boolean IsOpen()
        {
            if (sPort.IsOpen) return true;
            return false;
        }

        public void Close()
        {
            sPort.Close();
        }

        public void RemoteOn()
        {
            byte[] hex = { 0x7e, 0x7, 0x05, 0x41, 0x10, 0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void RemoteOff()
        {
            byte[] hex = { 0x7e, 0x7, 0x05, 0x41, 0x10, 0x02, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Play()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Pause()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x06, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void PlayPause()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x03, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Stop()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x02, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void PlayTrack(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x41, 0x03, 0x42, 0x01, val, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void PauseTrack(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x41, 0x03, 0x43, 0x01, val, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void NextTrack()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x16, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void BackTrack()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x15, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void CancelFfRew()
        {
            byte[] hex = { 0x7E, 0x06, 0x05, 0x41, 0x00, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Ff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x14, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Rew()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x13, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Eject()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0x40, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn off the auto pause/cue feature</para>
        /// </summary>
        public void AutoOff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xB0, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn off the auto pause feature</para>
        /// </summary>
        public void AutoPauseOff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xB0, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn on the auto pause feature</para>
        /// </summary>
        public void AutoPauseOn()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xB1, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn on the auto cue feature</para>
        /// </summary>
        public void AutoCueOn()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x02, 0xB2, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Turn on elapsed time output. This will fire OnElapsedTIme event every time the elapsed time is updated
        /// </summary>
        public void ElapsedTimeOn()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x07, 0x10, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Turn off elapsed time output
        /// </summary>
        public void ElapsedTimeOff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x07, 0x11, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the TOC data
        /// </summary>
        public void RequestTocData()
        {
            byte[] hex = { 0x7E, 0x08, 0x05, 0x41, 0x20, 0x44, 0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the model name
        /// </summary>
        public void RequestModelName()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x22, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the track time
        /// <para>Totally broken. returns a "NO FUNCTIONS" response</para>
        /// </summary>
        [Obsolete("CDP does not accept time requests for some reason. OnTrackChange does return track length just cant request it. but feel free to try")]
        public void RequestTrackTime(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x41, 0x20, 0x25, 0x01, 0x0A, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request DiscData
        /// </summary>
        public void RequestDiscData()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x21, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request unit status
        /// </summary>
        public void RequestStatus()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x41, 0x20, 0x20, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }
    }
}
