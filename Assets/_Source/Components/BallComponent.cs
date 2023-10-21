using System;
using UnityEngine;

namespace Components {
    [Serializable]
    public struct BallComponent
    {
        public GameObject prefab;
        public int count;
    }
}