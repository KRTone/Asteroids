using UnityEngine;

namespace Assets.Scenarios.Interfaces
{
    public interface IBoomController
    {
        void BoomAndDestroy(MonoBehaviour behaviour, GameObject boomEffect, float boomDuration);
    }
}
