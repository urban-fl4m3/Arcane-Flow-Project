using System;
using UnityEngine;

namespace Modules.SpellSystem.Models
{
    [Serializable]
    public class TransformContext
    {
        public TransformContext()
        {
            
        }
        
        public TransformContext(Vector3 spawnPoint, Vector3 direction)
        {
            SpawnPoint = spawnPoint;
            Direction = direction;
        }
        
        public Vector3 SpawnPoint { get; set; }
        public Vector3 SelectedPoint { get; set; }
        public Vector3 Direction { get; set; }
    }
}