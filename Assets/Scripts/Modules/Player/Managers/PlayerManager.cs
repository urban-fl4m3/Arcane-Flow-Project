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
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayerConfig _playerConfig;
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;
        private readonly ISpellManager _spellManager;

        private Actor _playerActor;

        public void Init()
        {
        }

        public IActor PlayerActor => _playerActor;

        public PlayerManager(IPlayerConfig playerConfig, ITickManager tickManager,
            ICameraManager cameraManager, ISpellManager spellManager)
        {
            _playerConfig = playerConfig;
            _tickManager = tickManager;
            _cameraManager = cameraManager;
            _spellManager = spellManager;
        }

        public void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init(_tickManager.Processor, _cameraManager.CameraActor);
            _playerActor.GetData<SpellData>().Add(_spellManager.GetDefaultSpell());
            _cameraManager.SetCameraTarget(_playerActor);
        }
    }
}