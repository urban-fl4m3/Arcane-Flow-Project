﻿using Modules.Render.Actors;
using UnityEngine;

namespace Modules.Render.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Camera/Config")]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private CameraActor _camera2D;
        [SerializeField] private CameraActor _camera3D;
        
        public CameraActor Camera2D => _camera2D;
        public CameraActor Camera3D => _camera3D;
    }
}