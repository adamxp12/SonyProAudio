using System;
using System.Collections.Generic;
using System.Text;

namespace SonyProAudio
{
    public class SonyEnums
    {

        public enum RecInput
        {
            analog = 1,
            optical = 11,
            coaxial = 101
        }

        public enum Stereo
        {
            stereo = 0,
            mono = 1
        }

        public enum PowerState
        {
            poweron = 2,
            poweroff = 3
        }
        public enum MechState
        {
            play = 1,
            stop = 2,
            pause = 3,
            rec = 33,
            recpause = 35,
            eject = 64,
            rehearsal = 110,
            playunavailable = 1111

        }

        public enum RepeatMode
        {
            repeatoff = 0,
            repeatall = 1,
            repeatone = 10,
            repeatab = 11
        }

        public enum PlayMode
        {
            play = 0,
            shuffle = 1,
            program = 10
        }

        public enum RemoteState
        {
            remoteon = 3,
            remoteoff = 4
        }

        public enum DiscType
        {
            reserved = 0,
            recordable = 1,
            premaster = 10,
        }

        public enum MechStatus { }

        public class RawDataReceivedArgs : EventArgs
        {
            public byte[] message { get; set; }
        }

        public class MechStateArgs : EventArgs
        {
            public SonyEnums.MechState state { get; set; }
        }

        public class PowerStateArgs : EventArgs
        {
            public SonyEnums.PowerState state { get; set; }
        }

        public class RemoteStateArgs : EventArgs
        {
            public SonyEnums.RemoteState state { get; set; }
        }

        public class ModelNameArgs : EventArgs
        {
            public string modelname { get; set; }
        }

        public class DiscNameArgs : EventArgs
        {
            public string discname { get; set; }
        }

        public class TrackNameArgs : EventArgs
        {
            public int trackno { get; set; }
            public string trackname { get; set; }
        }

        public class TrackTimeArgs : EventArgs
        {
            public int mins { get; set; }
            public int secs { get; set; }
        }

        public class ElapsedTImeArgs : EventArgs
        {
            public int trackno { get; set; }
            public int mins { get; set; }
            public int secs { get; set; }
        }

        public class TocDataArgs : EventArgs
        {
            public int firstTrack { get; set; }
            public int lastTrack  { get; set; }
            public int mins { get; set; }
            public int secs { get; set; }
        }

        public class DiscDataArgs : EventArgs
        {
            public bool DiscError { get; set; }
            public bool Protected { get; set; }
            public DiscType DiscType { get; set; }
        }

        public class StatusArgs : EventArgs
        {
            public int trackno { get; set; }
            public bool DiscExist { get; set; }
            public bool TocReadDone { get; set; }
            public bool RecPossible { get; set; }
            public bool CopyPossible { get; set; }
            public bool DinLock { get; set; }
            public MechState MechState { get; set; }
            public PowerState PowerState { get; set; }
            public Stereo Stereo { get; set; }
            public RecInput RecInput { get; set; }
        }

        public class CDPStatusArgs : EventArgs
        {
            public int trackno { get; set; }
            public bool DiscExist { get; set; }
            public bool TocReadDone { get; set; }
            public MechState MechState { get; set; }
            public RepeatMode RepeatMode { get; set; }
            public PlayMode PlayMode { get; set; }
        }

    }
}
