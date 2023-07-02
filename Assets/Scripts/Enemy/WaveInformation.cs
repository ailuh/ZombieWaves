using System;

namespace Enemy
{
    [Serializable]
    public class WaveInformation
    {
        public int WaveNumber { set; get; }
        public int ZombiesCount { set; get; }
    }
}

