using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct MovementParameters
    {
        public Transform body;
        public float forwardSpeed;
        public float zigzagAmplitude;
        public float zigzagFrequency;
    }
}