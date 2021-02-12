using System;
using Generics;
using Modules.Core.Managers;
using Modules.Enemies.Managers;
using Modules.Maps.Actors;
using Modules.Maps.Configs;
using Modules.Player.Managers;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using UnityEngine;

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
        
        public World(ITickManager tickManager, ICameraManager cameraManager, WorldSettings settings)
        {
            CurrentInstance = this;
         
            Settings = settings;
            
            _worldManagers.Add<ITickManager>(tickManager);
            _worldManagers.Add<ICameraManager>(cameraManager);

            var playerManager = new PlayerManager();
            _worldManagers.Add<IPlayerManager>(playerManager);
            
            if (Settings.WithEnemies)
            {
                var enemyManager = new EnemyManager();
                _worldManagers.Add<IEnemyManager>(enemyManager);
            }

            foreach (var manager in _worldManagers.Map)
            {
                var baseManager = manager.Value as IManager;
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
            UnityEngine.Object.Instantiate(Settings.Lightning);
        }

        public void RunWorld()
        {
            var playerManager = _worldManagers.Resolve<IPlayerManager>();
            var enemyManager = _worldManagers.Resolve<IEnemyManager>();
            
            playerManager.SpawnPlayer();
            
            _map.AddPlayer(playerManager.PlayerActor);
            
            var enemyWave = enemyManager.SpawnEnemyWave();
            if (enemyWave != null)
            {
                _map.AddWave(enemyWave);
            }

            if (Settings.WithEnemies) _worldManagers.Resolve<IEnemyManager>().Resume();
            _worldManagers.Resolve<IPlayerManager>().Resume();
            _worldManagers.Resolve<ICameraManager>().Resume();
        }

        public void RestartWorld()
        {
            var playerManager = _worldManagers.Resolve<IPlayerManager>();
            var enemyManager = _worldManagers.Resolve<IEnemyManager>();
            
            playerManager.RemovePlayer();
            enemyManager.ClearAllEnemies();
            _map.Dispose();

            RunWorld();
            
            MapReset?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            if (Settings.WithEnemies) _worldManagers.Resolve<IEnemyManager>().Stop();
            _worldManagers.Resolve<IPlayerManager>().Stop();
            _worldManagers.Resolve<ICameraManager>().Stop();

        }

        public void Dispose()
        {
            
        }
        
    }
}