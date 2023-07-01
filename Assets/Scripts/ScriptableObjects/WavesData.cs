using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "New Waves Data", order = 2)]
    public class WavesData : ScriptableObject
    {
        [SerializeField] 
        private List<WaveInformation> wavesCounts;
        public List<WaveInformation> WavesCounts => wavesCounts;
    }
}
