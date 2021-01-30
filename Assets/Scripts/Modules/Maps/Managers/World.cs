﻿using System;
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
            _worldManagers.Add<CameraManager>(cameraManager);

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

        private void LoadMap()
        {
            _map = UnityEngine.Object.Instantiate(Settings.Map);
            var lightnings = UnityEngine.Object.Instantiate(Settings.Lightning);
            
            _worldManagers.Resolve<CameraManager>().InitThirdPersonBehaviours();
        }

        public void RunWorld()
        {
            LoadMap();
            var playerManager = _worldManagers.Resolve<PlayerManager>();
            var enemyManager = _worldManagers.Resolve<EnemyManager>();
            
            playerManager.SpawnPlayer();
            
            var enemy = enemyManager.SpawnEnemy();
            _map.AddPlayer(playerManager.PlayerActor);
            _map.AddEnemy(enemy);
            
            var tickManager = _worldManagers.Resolve<ITickManager>();
            
            if (Settings.WithEnemies) _worldManagers.Resolve<EnemyManager>().Resume();
            _worldManagers.Resolve<PlayerManager>().Resume();
            _worldManagers.Resolve<CameraManager>().Resume();
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
            if (Settings.WithEnemies) _worldManagers.Resolve<EnemyManager>().Stop();
            _worldManagers.Resolve<PlayerManager>().Stop();
            _worldManagers.Resolve<CameraManager>().Stop();

        }

        public void Dispose()
        {
            
        }
        
    }
}