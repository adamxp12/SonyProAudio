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
    public partial class Form2 : Form
    {
        CDP mds;
        public Form2()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            mds = new CDP(comBox.Text);
            try
            {       
                mds.Init();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            mds.RawDataReceived += Mds_RawDataReceived;
            mds.OnImpossibleCommand += Mds_OnImpossibleCommand;
            //mds.OnTrackTime += Mds_OnTrackTIme;
            mds.OnTocData += Mds_OnTocData;
            mds.OnElapsedTime += Mds_OnElapsedTime;
            mds.OnTrackChange += Mds_OnTrackChange;
            mds.OnModelName += Mds_OnModelName;
            mds.OnStatus += Mds_OnStatus;
            mds.RemoteOn();
            mds.RequestModelName();
        }

        private void Mds_OnStatus(object sender, SonyEnums.CDPStatusArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Disc Exist: " + e.DiscExist + Environment.NewLine);
            sb.Append("Mech: " + e.MechState + Environment.NewLine);
            sb.Append("TocReadDone: " + e.TocReadDone + Environment.NewLine);
            sb.Append("RepeatMode: " + e.RepeatMode + Environment.NewLine);
            sb.Append("PlayMode: " + e.PlayMode + Environment.NewLine);

            sb.Append("TrackNo: " + e.trackno + Environment.NewLine);

            Invoke(new Action(() =>
            {
                mechState.Text = e.MechState.ToString();
            }));

            status.Text = sb.ToString();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            mds.Close();
        }

        private void Mds_OnModelName(object sender, SonyEnums.ModelNameArgs e)
        {
            mdlNameLbl.Text = e.modelname;
        }

        private void Mds_OnElapsedTime(object sender, SonyEnums.ElapsedTImeArgs e)
        {
            string trk = e.trackno.ToString();
            if (!trkLbl.Text.Equals(trk)) {
                trkLbl.Text = trk;
            }
            elpLbl.Text = e.mins + "m " + e.secs + "s";
        }

        private void Mds_OnTocData(object sender, SonyEnums.TocDataArgs e)
        {
            tocLbl.Text = e.firstTrack + "/" + e.lastTrack + " - " + e.mins + "m " + e.secs + "s";
        }

        private void Mds_OnTrackChange(object sender, SonyEnums.ElapsedTImeArgs e)
        {
            trkTImeLbl.Text = e.trackno+"t "+e.mins+":"+e.secs.ToString("D2");
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


        private void reqMdlNameBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestModelName();
        }


       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reqDiscDataBtn_Click(object sender, EventArgs e)
        {
            //if (mds != null) mds.RequestDiscData();
        }

        private void reqStatusBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.RequestStatus();
        }
    }
}
