using Modules.Render.Actors;
using UnityEngine;

namespace Modules.Render.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Camera/Config")]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private CameraActor _main;
        [SerializeField] private CameraActor _uiCamera;
        
        public CameraActor MainCamera => _main;
        public CameraActor UICamera => _uiCamera;
    }
}