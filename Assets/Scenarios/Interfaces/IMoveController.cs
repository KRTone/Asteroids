using UnityEngine;

namespace Assets.Scenarios.Interfaces
{
    public interface IMoveController
    {
        void GetAxes(Camera cam, out Vector2 position, out Vector2 mousePosition);
        void Move(Rigidbody2D rb, Vector2 playerPos, Vector2 mousePos, float moveSpeed);
    }
}