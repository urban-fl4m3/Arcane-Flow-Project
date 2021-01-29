using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Ticks.Processors
{
    //Todo create generic update controller for each tick type
    public class TickProcessor : MonoBehaviour, ITickProcessor
    {
        public GameObject Processor => gameObject;

        private readonly List<ITickUpdate> _tickUpdates = new List<ITickUpdate>();
        private readonly List<ITickLateUpdate> _tickLateUpdates = new List<ITickLateUpdate>();
        private readonly List<ITickFixedUpdate> _tickFixedUpdates = new List<ITickFixedUpdate>();

        #region Update

        public void AddTick(ITickUpdate tick)
        {
            _tickUpdates.Add(tick);
        }

        public void RemoveTick(ITickUpdate tick)
        {
            _tickUpdates.Remove(tick);
        }

        private void Update()
        {
            foreach (var tick in _tickUpdates)
            {
                tick.Tick();
            }
        }

        #endregion

        #region LateUpdate

        public void AddTick(ITickLateUpdate tick)
        {
            _tickLateUpdates.Add(tick);
        }

        public void RemoveTick(ITickLateUpdate tick)
        {
            _tickLateUpdates.Remove(tick);
        }

        private void LateUpdate()
        {
            foreach (var tick in _tickLateUpdates)
            {
                tick.Tick();
            }
        }

        #endregion

        #region FixedUpdate
        public void AddTick(ITickFixedUpdate tick)
        {
            _tickFixedUpdates.Add(tick);
        }
        
        public void RemoveTick(ITickFixedUpdate tick)
        {
            _tickFixedUpdates.Remove(tick);
        }

        private void FixedUpdate()
        {
            foreach (var tick in _tickFixedUpdates)
            {
                tick.Tick();
            }
        }

        #endregion

        public void FindAndRemoveTick(ITick tick)
        {
            foreach (var tickUpdate in _tickUpdates.Where(tickUpdate => tickUpdate == tick))
            {
                _tickUpdates.Remove(tickUpdate);
                return;
            }    
            
            foreach (var tickLateUpdate in _tickLateUpdates.Where(tickLateUpdate => tickLateUpdate == tick))
            {
                _tickLateUpdates.Remove(tickLateUpdate);
                return;
            }    
            
            foreach (var tickFixedUpdate in _tickFixedUpdates.Where(tickFixedUpdate => tickFixedUpdate == tick))
            {
                _tickFixedUpdates.Remove(tickFixedUpdate);
                return;
            }    
        }
        
        public void Dispose()
        {
            _tickUpdates.Clear();
            _tickFixedUpdates.Clear();
            _tickLateUpdates.Clear();
        }
    }
}