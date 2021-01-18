using System.Collections.Generic;
using Modules.Behaviours;
using Modules.Render.Actors;
using UnityEngine;

namespace Modules.Render.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Camera/Config")]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private CameraActor _main;
        [SerializeField] private List<BaseBehaviour> _gameSceneBaseBehaviours;
        
        public CameraActor MainCamera => _main;
        public IReadOnlyList<BaseBehaviour> GameSceneBaseBehaviours => _gameSceneBaseBehaviours;
    }
}