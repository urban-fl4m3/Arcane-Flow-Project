using System.Collections.Generic;
using Modules.Behaviours;
using Modules.Render.Actors;
using UnityEngine;

namespace Modules.Render.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Camera/Config")]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private CameraActor _camera2D;
        [SerializeField] private CameraActor _camera3D;
        [SerializeField] private List<BaseBehaviour> _gameSceneBaseBehaviours;
        
        public CameraActor Camera2D => _camera2D;
        public CameraActor Camera3D => _camera3D;
        public IReadOnlyList<BaseBehaviour> GameSceneBaseBehaviours => _gameSceneBaseBehaviours;
    }
}