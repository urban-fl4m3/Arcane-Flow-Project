using System;
using Generics;
using Modules.Enemies.Managers;
using Modules.Maps.Actors;
using Modules.Maps.Configs;
using Modules.Player.Managers;
using Modules.Render.Managers;
using Modules.SpellSystem.Managers;
using Modules.Ticks.Managers;

namespace Modules.Maps.Managers
{
    public class World : IDisposable
    {
        public static World CurrentInstance
        {
            get => _currentInstance;
            set
            {
                if (value == null)
                {
                    _currentInstance.Dispose();
                    _currentInstance = null;
                    return;
                }

                _currentInstance = value;
            }
        }
        private static World _currentInstance;
        
        public event EventHandler MapReset;
        
        public readonly WorldSettings Settings;


        private readonly TypeContainer _worldManagers = new TypeContainer();

        private MapActor _map;
        
        public World(ITickManager tickManager, ICameraManager cameraManager, ISpellManager spellManager,
            WorldSettings settings)
        {
            CurrentInstance = this;
         
            Settings = settings;
            
            _worldManagers.Add<ITickManager>(tickManager);
            _worldManagers.Add<ISpellManager>(spellManager);
            _worldManagers.Add<ICameraManager>(cameraManager);

            var playerManager = new PlayerManager();
            _worldManagers.Add<PlayerManager>(playerManager);
            
            if (Settings.WithEnemies)
            {
                var enemyManager = new EnemyManager();
                _worldManagers.Add<EnemyManager>(enemyManager);
            }

            foreach (var manager in _worldManagers.Map)
            {
                var baseManager = manager.Value as BaseManager;
                baseManager?.Init();
            }
        }

        public T ResolveManager<T>() where T : class
        {
            return _worldManagers.Resolve<T>();
        }

        public void LoadMap()
        {
            _map = UnityEngine.Object.Instantiate(Settings.Map);
            var lightnings = UnityEngine.Object.Instantiate(Settings.Lightning);
            
            _worldManagers.Resolve<ICameraManager>().InitThirdPersonBehaviours();
        }

        public void RunWorld()
        {
            var playerManager = _worldManagers.Resolve<PlayerManager>();
            var enemyManager = _worldManagers.Resolve<EnemyManager>();
            
            playerManager.SpawnPlayer();
            
            var enemy = enemyManager.SpawnEnemy();
            _map.AddPlayer(playerManager.PlayerActor);
            _map.AddEnemy(enemy);
            
            var tickManager = _worldManagers.Resolve<ITickManager>();
            tickManager.CheckActorTicksState(true);
        }

        public void RestartWorld()
        {
            var playerManager = _worldManagers.Resolve<PlayerManager>();
            var enemyManager = _worldManagers.Resolve<EnemyManager>();
            
            playerManager.RemovePlayer();
            enemyManager.ClearAllEnemies();
            _map.Dispose();

            RunWorld();
            
            MapReset?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            var tickManager = _worldManagers.Resolve<ITickManager>();
            tickManager.CheckActorTicksState(false);
        }

        public void Dispose()
        {
            
        }
    }
}