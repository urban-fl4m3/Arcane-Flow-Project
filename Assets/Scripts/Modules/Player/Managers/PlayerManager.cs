using Generics;
using Modules.Actors;
using Modules.Maps.Managers;
using Modules.Player.Configs;
using Modules.Render.Managers;
using Modules.SpellSystem.Data;
using Modules.SpellSystem.Managers;
using Modules.Ticks.Managers;
using Object = UnityEngine.Object;

namespace Modules.Player.Managers
{
    public class PlayerManager : BaseManager
    {
        private readonly IPlayerConfig _playerConfig;
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;
        private readonly ISpellManager _spellManager;

        private Actor _playerActor;

        public IActor PlayerActor => _playerActor;

        private readonly World _world;
        
        public PlayerManager()
        {
            _world = World.CurrentInstance;
            
            _playerConfig = _world.Settings.PlayerConfig;
            _tickManager = _world.ResolveManager<ITickManager>();
            _cameraManager = _world.ResolveManager<ICameraManager>();
            _spellManager = _world.ResolveManager<ISpellManager>();
        }

        public void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init(_tickManager, _cameraManager.GameCamera);
            _playerActor.GetData<SpellData>().Add(_spellManager.GetDefaultSpell());
            _cameraManager.SetCameraTarget(_playerActor);
        }

        public void RemovePlayer()
        {
            _cameraManager.GameCamera.StopFollowing();
            _playerActor.DestroyActor();
            _playerActor = null;
        }
    }
}