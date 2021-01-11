using UnityEngine;

namespace Modules.Datas.Movement
{
    public interface IMovementData
    {
        bool IsMoving { get; set; }
        Vector2 MovementAxis { get; set; }
    }
}