using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SonyProAudio;

namespace SonyMDSDemo
{
    public partial class MainFrm : Form
    {
        MDS mds;
        int trackno;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            mds = new MDS("COM5");
            mds.Init();
            mds.RemoteOn();
            mds.RequestDiscData();
            mds.RequestDiscName();
            mds.RequestModelName();
            mds.RequestStatus();
            mds.RequestTocData();
            mds.ElapsedTimeOn();

            mds.OnStatus += Mds_OnStatus;
            mds.OnElapsedTime += Mds_OnElapsedTime;
            mds.OnTrackName += Mds_OnTrackName;
            mds.OnTocData += Mds_OnTocData;
            mds.OnDiscName += Mds_OnDiscName;


            playBtn.ImageList = Func.SetupImageList("playbtn1", "playbtngreen");
            stopBtn.ImageList = Func.SetupImageList("stopbtn", "stopbtnred");
            pauseBtn.ImageList = Func.SetupImageList("pausebtn", "pausebtnorange");
            recBtn.ImageList = Func.SetupImageList("recbtn", "recbtnred");
            playBtn.ImageIndex = 0;
            stopBtn.ImageIndex = 1;
            pauseBtn.ImageIndex = 0;
            recBtn.ImageIndex = 0;
        }

        private void Mds_OnDiscName(object sender, SonyEnums.DiscNameArgs e)
        {
            trkName.Text = e.discname;
        }

        private void Mds_OnTocData(object sender, SonyEnums.TocDataArgs e)
        {
            if (e.lastTrack.Equals(0)) {
                elpLbl.Text = "Blank Disc";
            } else
            {
                elpLbl.Text = e.lastTrack + "t  " + e.mins.ToString("D2") + "m " + e.secs.ToString("D2") + "s ";
                if (mds != null) mds.RequestDiscName();
            }
            
        }

        private void Mds_OnTrackName(object sender, SonyEnums.TrackNameArgs e)
        {
            trkName.Text = e.trackname;
        }

        private void Mds_OnElapsedTime(object sender, SonyEnums.ElapsedTImeArgs e)
        {
            elpLbl.Text = e.trackno + "t " + e.mins.ToString("D2") + "m " + e.secs.ToString("D2") + "s ";
            if (trackno != e.trackno) mds.RequestTrackName(e.trackno);
            trackno = e.trackno;
        }

        private void Mds_OnStatus(object sender, SonyEnums.StatusArgs e)
        {
            
            if (e.MechState.Equals(SonyEnums.MechState.play)) playBtn.ImageIndex = 1; else playBtn.ImageIndex = 0;
            if (e.MechState.Equals(SonyEnums.MechState.stop)) stopBtn.ImageIndex = 1; else stopBtn.ImageIndex = 0;
            if (e.MechState.Equals(SonyEnums.MechState.rec)) recBtn.ImageIndex = 1; else recBtn.ImageIndex = 0;
            if (e.MechState.Equals(SonyEnums.MechState.recpause))
            {
                recBtn.ImageIndex = 1;
                pauseBtn.ImageIndex = 1;
            }
            else
            {
                recBtn.ImageIndex = 0;
                if (e.MechState.Equals(SonyEnums.MechState.pause)) pauseBtn.ImageIndex = 1; else pauseBtn.ImageIndex = 0;
            }

            if (!e.TocReadDone) elpLbl.Text = "Reading Toc";
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Play();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (mds != null)
            {
                mds.Stop();
                mds.RequestDiscName();
                mds.RequestTocData();
            }
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Pause();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.BackTrack();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.NextTrack();
        }

        private void ejectBtn_Click(object sender, EventArgs e)
        {
            if (mds != null) mds.Eject();
            trkName.Text = "";
            elpLbl.Text = "Eject";
            ejectTimer.Start();
        }

        private void ejectTimer_Tick(object sender, EventArgs e)
        {
            elpLbl.Text = "No Disc";
            ejectTimer.Stop();
        }
    }
}
