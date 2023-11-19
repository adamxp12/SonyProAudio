using SonyProAudio;
using SonyMDSDemo.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SonyMDSDemo
{
    public partial class Form1 : Form
    {
        MDS mds;
        public Form1()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            mds = new MDS(comBox.Text);
            try
            {       
                mds.Init();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            mds.RawDataReceived += Mds_RawDataReceived;
            mds.OnImpossibleCommand += Mds_OnImpossibleCommand;
            mds.OnRemoteChange += Mds_OnRemoteChange;
            mds.OnTrackTime += Mds_OnTrackTIme;
            mds.OnTocData += Mds_OnTocData;
            mds.OnElapsedTime += Mds_OnElapsedTime;
            mds.OnTrackName += Mds_OnTrackName;
            mds.OnDiscName += Mds_OnDiscName;
            mds.OnModelName += Mds_OnModelName;
            mds.OnDiscData += Mds_OnDiscData;
            mds.OnStatus += Mds_OnStatus;
            mds.RemoteOn();
            mds.RequestModelName();
        }

        private void Mds_OnStatus(object sender, SonyEnums.StatusArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Disc Exist: " + e.DiscExist + Environment.NewLine);
            sb.Append("Power: " + e.PowerState + Environment.NewLine);
            sb.Append("Mech: " + e.MechState + Environment.NewLine);
            sb.Append("TocReadDone: " + e.TocReadDone + Environment.NewLine);
            sb.Append("RecPossible: " + e.RecPossible + Environment.NewLine);
            sb.Append("Stereo: " + e.Stereo + Environment.NewLine);
            sb.Append("CopyPossible: " + e.CopyPossible + Environment.NewLine);
            sb.Append("DinLock: " + e.DinLock + Environment.NewLine);
            sb.Append("RecInput: " + e.RecInput + Environment.NewLine);
            sb.Append("TrackNo: " + e.trackno + Environment.NewLine);

            Invoke(new Action(() =>
            {
                mechState.Text = e.MechState.ToString();
            }));

            status.Text = sb.ToString();
        }

        private void Mds_OnDiscData(object sender, SonyEnums.DiscDataArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (e.DiscError) sb.Append("DiscError "); else sb.Append("NoDiscError ");
            if (e.Protected) sb.Append("Protected "); else sb.Append("Unprotected ");
            sb.Append(e.DiscType.ToString());
            discDataLbl.Text = sb.ToString();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            mds.Close();
        }

        private void Mds_OnModelName(object sender, SonyEnums.ModelNameArgs e)
        {
            mdlNameLbl.Text = e.modelname;
        }

        private void Mds_OnDiscName(object sender, SonyEnums.DiscNameArgs e)
        {
            discNameLbl.Text = e.discname;
        }

        private void Mds_OnTrackName(object sender, SonyEnums.TrackNameArgs e)
        {
            trkName.Text = e.trackname;
            status.AppendText(e.trackno + " - " + e.trackname + Environment.NewLine);
        }

        private void Mds_OnElapsedTime(object sender, SonyEnums.ElapsedTImeArgs e)
        {
            string trk = e.trackno.ToString();
            if (!trkLbl.Text.Equals(trk)) {
                trkLbl.Text = trk;
                if (mds != null) mds.RequestTrackTime(int.Parse(trk));
                if (mds != null) mds.RequestTrackName(int.Parse(trk));
            }
            elpLbl.Text = e.mins + "m " + e.secs + "s";
        }

        private void Mds_OnTocData(object sender, SonyEnums.TocDataArgs e)
        {
            if (mds != null) mds.RequestDiscName();
            tocLbl.Text = e.firstTrack + "/" + e.lastTrack + " - " + e.mins + "m " + e.secs + "s";
        }

        private void Mds_OnTrackTIme(object sender, SonyEnums.TrackTimeArgs e)
        {
            trkTImeLbl.Text = e.mins+":"+e.secs.ToString("D2");
        }

        private void Mds_OnRemoteChange(object sender, SonyEnums.RemoteStateArgs e)
        {
            alertLbl.Text = DateTime.Now.ToString() + " " + e.state.ToString();
        }

        private void Mds_OnImpossibleCommand(object sender, EventArgs e)
        {
            alertLbl.Text = DateTime.Now.ToString() + " impossible command" ;
        }

        private void Mds_RawDataReceived(object sender, SonyEnums.RawDataReceivedArgs e)
        {
            textBox1.AppendText(BitConverter.ToString(e.message) + Environment.NewLine);
            Invoke(new Action(() =>
            {
                
            }));
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Play();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Pause();
        }

        private void playpauseBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.PlayPause();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Stop();
        }

        private void rmOnBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RemoteOn();
        }

        private void rmOffBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RemoteOff();
        }

        private void trackPlayBtn_Click(object sender, EventArgs e)
        {
            if (mds != null)
            {
                if (mechState.Text.Equals("pause")) mds.Stop(); Thread.Sleep(50); // Fuck Sony. Should not have to do this
                mds.PlayTrack((int)numericUpDown1.Value);
            }
        }

        private void trackPauseBtn_Click(object sender, EventArgs e)
        {
            if (mechState.Text.Equals("pause")) mds.Stop(); Thread.Sleep(50);
            if (mds != null) mds.PauseTrack((int)numericUpDown1.Value);
        }

        private void autoOnBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.AutoPauseOn();
        }

        private void autoOffBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.AutoPauseOff();
        }

        private void ejectBtn_Click(object sender, EventArgs e)
        {
            tocLbl.Text = "";
            trkTImeLbl.Text = "";
            trkName.Text = "";
            discNameLbl.Text = "";
            discDataLbl.Text = "";
            mechState.Text = "";
            elpLbl.Text = "";
            trkLbl.Text = "";

            if (mds != null) mds.Eject();
        }
        private void requestTrackTimeBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestTrackTime((int)numericUpDown1.Value);
        }

        private void requestTocDataBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestTocData();
        }

        private void elpOnBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.ElapsedTimeOn();
        }

        private void elpOffBtn_Click(object sender, EventArgs e)
        {
            if(mds != null) mds.ElapsedTimeOff();
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void nxTrkBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.NextTrack();
        }

        private void bkTrkBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.BackTrack();
        }

        private void reqTrkNameBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestTrackName((int)numericUpDown1.Value);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestDiscName();
        }

        private void reqMdlNameBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestModelName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Rec();
        }

        private void setTrkName_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.SetTrackName((int)numericUpDown1.Value, trkNameBox.Text);
        }

        private void setDskNameBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.SetDiscName( trkNameBox.Text);
        }

        private void eraseBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.EraseTrack((int)numericUpDown1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reqDiscDataBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestDiscData();
        }

        private void reqStatusBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestStatus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestAllTrackName();
        }
    }
}
