using System;
using UnityEngine;

namespace Modules.SpellSystem.Models
{
    [Serializable]
    public class TransformContext
    {
        public TransformContext(Vector3 spawnPoint, Vector3 direction)
        {
            SpawnPoint = spawnPoint;
            Direction = direction;
        }
        
        public Vector3 SpawnPoint { get; }
        public Vector3 Direction { get; }
    }
}