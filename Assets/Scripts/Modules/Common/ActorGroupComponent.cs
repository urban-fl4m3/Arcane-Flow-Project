using System.Collections.Generic;
using Modules.Actors;
using UnityEngine;

namespace Modules.Common
{
    public class ActorGroupComponent : MonoBehaviour
    {
        [SerializeField] private List<Actor> _actors;
        public IEnumerable<IActor> Actors => _actors;
    }
}