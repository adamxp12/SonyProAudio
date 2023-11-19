using ExtendedSerialPort;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SonyProAudio
{
    public class MDS : SonyInterface
    {
        private ReliableSerialPort sPort;
        private string sPortStr;
        private int trackNo;
        private StringBuilder trackName;
        private StringBuilder discName;

        public event EventHandler<SonyEnums.RawDataReceivedArgs> RawDataReceived;
        public event EventHandler OnImpossibleCommand;
        public event EventHandler OnUndefinedCommand;
        public event EventHandler<SonyEnums.PowerStateArgs> OnPowerChange;
        public event EventHandler<SonyEnums.MechStateArgs> OnMechChange;
        public event EventHandler<SonyEnums.RemoteStateArgs> OnRemoteChange;
        public event EventHandler<SonyEnums.StatusArgs> OnStatus;
        public event EventHandler<SonyEnums.DiscDataArgs> OnDiscData;
        public event EventHandler<SonyEnums.ModelNameArgs> OnModelName;
        public event EventHandler<SonyEnums.DiscNameArgs> OnDiscName;
        public event EventHandler<SonyEnums.TrackNameArgs> OnTrackName;
        public event EventHandler<SonyEnums.ElapsedTImeArgs> OnElapsedTime;
        public event EventHandler<SonyEnums.TrackTimeArgs> OnRecRemainTime;
        public event EventHandler<SonyEnums.TocDataArgs> OnTocData;
        public event EventHandler<SonyEnums.TrackTimeArgs> OnTrackTime;
        public event EventHandler OnDiscExist;
        public event EventHandler OnTrackChange;
        public event EventHandler OnNoDiscName;
        public event EventHandler OnNoTrackName;
        public event EventHandler OnNoTocData;



        /// <summary>
        /// Sony MDS Minidisc machine (MDS-E11, MDS-E12, MDS-E52)
        /// </summary>
        /// <param name="port">Serial port to open</param>
        public MDS(String port)
        {
            if (port.Length < 1) port = "COM1";
            sPortStr = port;
        }

        public void Init()
        {
            sPort = new ReliableSerialPort(sPortStr, 9600);
            sPort.Open();
            sPort.DataReceived += DataReceived;
        }

        /// <summary>
        /// This function is disgusting. its long and horrible
        /// you will find many bad programming things in here
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DataReceived(object s, DataReceivedArgs e)
        {
            byte[] buf = e.Data;
            RawDataReceived?.Invoke(this, new SonyEnums.RawDataReceivedArgs { message = buf });

            if(buf[0].Equals(111) && buf[3].Equals(71))
            {
                // 40h
                if(buf[4].Equals(64))
                {
                    if (buf[5].Equals(1)) OnUndefinedCommand?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(3)) OnImpossibleCommand?.Invoke(this, EventArgs.Empty);
                }

                // 20h
                if(buf[4].Equals(32))
                {
                    if(buf[5].Equals(32))
                    {
                        // complicated status command
                        SonyEnums.StatusArgs sa = new SonyEnums.StatusArgs();

                        decimal dd1 = Convert.ToDecimal(buf[6]);
                        string bin1 = Convert.ToString(int.Parse(dd1.ToString()), 2).PadLeft(8, '0');
                        decimal dd2 = Convert.ToDecimal(buf[7]);
                        string bin2 = Convert.ToString(int.Parse(dd2.ToString()), 2).PadLeft(8, '0');
                        decimal dd3 = Convert.ToDecimal(buf[8]);
                        string bin3 = Convert.ToString(int.Parse(dd3.ToString()), 2).PadLeft(8, '0');
                        sa.trackno = int.Parse(Convert.ToDecimal(buf[10]).ToString());


                        string b3b2b1b0 = bin1[4].ToString() + bin1[5].ToString() + bin1[6].ToString() + bin1[7].ToString();
                        switch(b3b2b1b0)
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
                            case "0100":
                                sa.MechState = SonyEnums.MechState.rec;
                                break;
                            case "0101":
                                sa.MechState = SonyEnums.MechState.recpause;
                                break;
                            case "0110":
                                sa.MechState = SonyEnums.MechState.rehearsal;
                                break;
                            case "1111":
                                sa.MechState = SonyEnums.MechState.playunavailable;
                                break;
                            default:
                                break;
                        }

                        if (bin1[3].ToString().Equals("1")) sa.PowerState = SonyEnums.PowerState.poweroff; else sa.PowerState = SonyEnums.PowerState.poweron;
                        if (bin1[2].ToString().Equals("1")) sa.DiscExist = false; else sa.DiscExist = true;

                        if (bin2[0].ToString().Equals("1")) sa.TocReadDone = true; else sa.TocReadDone = false;
                        if (bin2[2].ToString().Equals("1")) sa.RecPossible = true; else sa.RecPossible = false;

                        sa.Stereo = (SonyEnums.Stereo) int.Parse(Convert.ToDecimal(bin3[3].ToString()).ToString());
                        if (bin3[1].ToString().Equals("1")) sa.CopyPossible = false; else sa.CopyPossible = true;
                        if (bin3[2].ToString().Equals("1")) sa.DinLock = false; else sa.DinLock = true;

                        string b2b1b0 = bin3[5].ToString() + bin3[6].ToString() + bin3[7].ToString();

                        switch(b2b1b0)
                        {
                            case "001":
                                sa.RecInput = SonyEnums.RecInput.analog;
                                break;
                            case "011":
                                sa.RecInput = SonyEnums.RecInput.optical;
                                break;
                            case "101":
                                sa.RecInput = SonyEnums.RecInput.coaxial;
                                break;
                            default:
                                break;
                        }

                        OnStatus?.Invoke(this, sa);

                    }


                    if (buf[5].Equals(33))
                    {
                        // Disc Data
                        decimal dd = Convert.ToDecimal(buf[7]);
                        string bin = Convert.ToString(int.Parse(dd.ToString()), 2).PadLeft(8, '0');
                        SonyEnums.DiscDataArgs dda = new SonyEnums.DiscDataArgs();

                        string b1b0 = bin[6].ToString() + bin[7].ToString();

                        switch(b1b0)
                        {
                            case "01":
                                dda.DiscType = SonyEnums.DiscType.recordable;
                                break;
                            case "10":
                                dda.DiscType = SonyEnums.DiscType.premaster;
                                break;
                            default:
                                dda.DiscType = SonyEnums.DiscType.premaster;
                                break;
                        }

                        dda.Protected = bin[5].ToString().Equals("1");
                        dda.DiscError = bin[4].ToString().Equals("1");
                        OnDiscData?.Invoke(this, dda);
                    }

                    if (buf[5].Equals(34)) parseModelName(buf);
                    if (buf[5].Equals(72) || buf[5].Equals(73)) parseDiscName(buf);
                    if (buf[5].Equals(74) || buf[5].Equals(75)) parseTrackName(buf);
                    

                    if (buf[5].Equals(96)) OnTocData?.Invoke(this, new SonyEnums.TocDataArgs {
                        firstTrack = int.Parse(Convert.ToDecimal(buf[7]).ToString()),
                        lastTrack = int.Parse(Convert.ToDecimal(buf[8]).ToString()),
                        mins = int.Parse(Convert.ToDecimal(buf[9]).ToString()), 
                        secs = int.Parse(Convert.ToDecimal(buf[10]).ToString()) 
                    });


                    if (buf[5].Equals(81)) OnElapsedTime?.Invoke(this, new SonyEnums.ElapsedTImeArgs {
                        trackno = int.Parse(Convert.ToDecimal(buf[6]).ToString()),
                        mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()),
                        secs = int.Parse(Convert.ToDecimal(buf[9]).ToString())
                    });
                    if (buf[5].Equals(84)) OnRecRemainTime?.Invoke(this, new SonyEnums.TrackTimeArgs { mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()), secs = int.Parse(Convert.ToDecimal(buf[9]).ToString()) });

                    if (buf[5].Equals(98)) OnTrackTime?.Invoke(this, new SonyEnums.TrackTimeArgs { mins = int.Parse(Convert.ToDecimal(buf[8]).ToString()), secs = int.Parse(Convert.ToDecimal(buf[9]).ToString()) });

                    if (buf[5].Equals(130)) OnDiscExist?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(131)) OnTrackChange?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(133)) OnNoDiscName?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(134)) OnNoTrackName?.Invoke(this, EventArgs.Empty);
                    if (buf[5].Equals(137)) OnNoTocData?.Invoke(this, EventArgs.Empty);
                }

                // 10h
                if(buf[4].Equals(16))
                {
                    OnRemoteChange?.Invoke(this, new SonyEnums.RemoteStateArgs { state = (SonyEnums.RemoteState)buf[5] });
                }

                // 1h
                if (buf[4].Equals(1))
                {
                    OnPowerChange?.Invoke(this, new SonyEnums.PowerStateArgs { state = (SonyEnums.PowerState)buf[5] });
                }

                // 2h
                if (buf[4].Equals(2))
                {
                    OnMechChange?.Invoke(this, new SonyEnums.MechStateArgs { state = (SonyEnums.MechState)buf[5] });
                }
            } 

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

        /// <summary>
        /// Parse the discname packets. this is annoying and I hate it. Wish it used a single packet instead
        /// </summary>
        /// <param name="b">byte array of packet to parse</param>
        private void parseDiscName(byte[] b)
        {
            if (b[5].Equals(72))
            {
                discName = new StringBuilder();
            }

            for (int i = 7; i < b.Length - 1; i++)
            {
                string c = Char.ConvertFromUtf32(b[i]);
                if (b[i].ToString().Equals("0"))
                {
                    if (discName != null)  OnDiscName?.Invoke(this, new SonyEnums.DiscNameArgs { discname = discName.ToString() });
                    break;
                }
                if(discName != null) discName.Append(c);
            }
        }


        /// <summary>
        /// Parse the trackname packets. this is annoying and I hate it. Wish it used a single packet instead
        /// </summary>
        /// <param name="b">byte array of packet to parse</param>
        private void parseTrackName(byte[] b)
        {
            if (b[5].Equals(74))
            {
                trackName = new StringBuilder();
                trackNo = int.Parse(Convert.ToDecimal(b[6]).ToString());
            }

            for (int i = 7; i < b.Length - 1; i++)
            {
                string c = Char.ConvertFromUtf32(b[i]);
                if (b[i].ToString().Equals("0"))
                {
                    if (trackName != null) OnTrackName?.Invoke(this, new SonyEnums.TrackNameArgs { trackno = trackNo, trackname = trackName.ToString() });
                    break;
                }
                if (trackName != null) trackName.Append(c);
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
            byte[] hex = { 0x7e, 0x7, 0x05, 0x47, 0x10, 0x03, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void RemoteOff()
        {
            byte[] hex = { 0x7e, 0x7, 0x05, 0x47, 0x10, 0x04, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Play()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x01, 0xFF };
            if(sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Pause()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x06, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void PlayPause()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x03, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Stop()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x02, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Acts like pressing the record button on the unit
        /// </summary>
        public void Rec()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x21, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Acts like pressing the select/enter button during record pause to activate time machine recording
        /// </summary>
        public void RecTimeMachine()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x28, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Set the name of the disc
        /// </summary>
        /// <param name="name">Disc Name</param>
        public void SetDiscName(string name)
        {
            byte[] startdisc = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x70, 0x01 };
            byte[] extradisc = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x71, 0x00 };
            WriteName(startdisc, extradisc, name);

        }

        /// <summary>
        /// Set the name of a track
        /// </summary>
        /// <param name="track">Track number 1-255</param>
        /// <param name="name">Track Name</param>
        public void SetTrackName(int track, string name)
        {
            byte val = Convert.ToByte(track);
            byte[] starttrack = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x72, val };
            byte[] extratrack = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x73, 0x00 };
            WriteName(starttrack, extratrack, name);

        }

        private void WriteName(byte[] start, byte[] extra, string name)
        {
            int count = 1;
            int bytecount = 0;
            int totalbytes = 0;
            
            ByteArrayOutputStream command = new ByteArrayOutputStream();
            ByteArrayOutputStream bname = new ByteArrayOutputStream();
            byte[] ff = { 0xFF };
            byte[] oo = { 0x00 };
            

            bname.Write(Encoding.UTF8.GetBytes(name));
            bname.Write(oo);
            byte[] baname = bname.ToByteArray();
            foreach (byte b in baname)
            {
                extra.SetValue(Convert.ToByte(count), 6);
                byte[] tb = { b };
                if (bytecount.Equals(0))
                {
                    if (count.Equals(1))
                    {
                        command.Write(start);
                    }
                    else
                    {
                        command.Write(extra);
                    }
                }

                command.Write(tb);
                bytecount++;
                totalbytes++;

                if (bytecount >= 16 || totalbytes.Equals(baname.Length))
                {
                    command.Write(ff);
                    byte[] commandba = command.ToByteArray();
                    commandba.SetValue(Convert.ToByte(commandba.Length), 1);
                    Console.WriteLine(BitConverter.ToString(commandba));
                    if (sPort.IsOpen) sPort.Write(commandba, 0, commandba.Length);
                    bytecount = 0;
                    count++;
                    command.Dispose();
                    command = new ByteArrayOutputStream();
                    if (totalbytes.Equals(baname.Length)) break;
                }
            }
        }


        /// <summary>
        /// <para>Erase the specified track</para>
        /// <para>Track number 0 will erase all tracks</para>
        /// </summary>
        /// <param name="track">Track number 1-255</param>
        public void EraseTrack(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x08, 0x05, 0x47, 0x0A, 0x04, val, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void PlayTrack(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x47, 0x03, 0x42, 0x01, val,  0xFF };
            if (sPort.IsOpen)  sPort.Write(hex, 0, hex.Length);
        }

        public void PauseTrack(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x47, 0x03, 0x43, 0x01, val, 0xFF };
            if (sPort.IsOpen)  sPort.Write(hex, 0, hex.Length);
        }

        public void NextTrack()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x16, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void BackTrack()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x15, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void CancelFfRew()
        {
            byte[] hex = { 0x7E, 0x06, 0x05, 0x47, 0x00, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Ff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x14, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Rew()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x13, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        public void Eject()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x40, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn off the auto pause feature</para>
        /// <para>The is literally no way to tell the status of the auto pause. this has no response from the MDS</para>
        /// <para>Sony gave up half way making this protocol</para>
        /// </summary>
        public void AutoPauseOff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x80, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Turn on the auto pause feature</para>
        /// <para>The is literally no way to tell the status of the auto pause. this has no response from the MDS</para>
        /// <para>Sony gave up half way making this protocol</para>
        /// </summary>
        public void AutoPauseOn()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x02, 0x81, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Turn on elapsed time output. This will fire OnElapsedTIme event every time the elapsed time is updated
        /// </summary>
        public void ElapsedTimeOn()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x07, 0x10, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Turn off elapsed time output
        /// </summary>
        public void ElapsedTimeOff()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x07, 0x11, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the TOC data
        /// </summary>
        public void RequestTocData()
        {
            byte[] hex = { 0x7E, 0x08, 0x05, 0x47, 0x20, 0x44, 0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>Request the length of a specific track</para>
        /// <para>If you request 0 it will return the free recording space</para>
        /// </summary>
        /// <param name="track">Track number 1-255</param>
        public void RequestTrackTime(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x09, 0x05, 0x47, 0x20, 0x45, 0x01, val, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the name of a specific track
        /// </summary>
        /// <param name="track">1-255</param>
        public void RequestTrackName(int track)
        {
            byte val = Convert.ToByte(track);
            byte[] hex = { 0x7E, 0x08, 0x05, 0x47, 0x20, 0x4A, val, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// <para>This is broken horribly. my MDS-E11 sends out complete garbage data</para>
        /// <para>Feel free to do a pull request if you figure it out</para>
        /// <para>Even in a terminal program I get garbage data that does not match the track name responses I expect</para>
        /// </summary>
        public void RequestAllTrackName()
        {
            byte[] hex = { 0x7E, 0x08, 0x05, 0x47, 0x20, 0x4C,0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }
        /// <summary>
        /// Request the name of the disc
        /// </summary>
        public void RequestDiscName()
        {
            byte[] hex = { 0x7E, 0x08, 0x05, 0x47, 0x20, 0x48, 0x01, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request the model name
        /// </summary>
        public void RequestModelName()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x22, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request DiscData
        /// </summary>
        public void RequestDiscData()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x21, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }

        /// <summary>
        /// Request unit status
        /// </summary>
        public void RequestStatus()
        {
            byte[] hex = { 0x7E, 0x07, 0x05, 0x47, 0x20, 0x20, 0xFF };
            if (sPort.IsOpen) sPort.Write(hex, 0, hex.Length);
        }
    }
}
