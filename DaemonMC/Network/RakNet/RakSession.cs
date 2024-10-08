﻿namespace DaemonMC.Network.RakNet
{
    public class RakSession
    {
        public long GUID { get; set; }
        public bool initCompression { get; set; }
        public string username { get; set; }
        public string identity { get; set; }
        public long EntityID { get; set; }

        public RakSession(long guid, bool compression = false)
        {
            GUID = guid;
            initCompression = compression;
        }
    }
}
