using UnityEngine;

namespace Assets.Scenarios.Controllers
{
    class BoomController
    {
        public static void BoomAndDestroy(MonoBehaviour behaviour, GameObject boomEffect, float boomDuration)
        {
            GameObject effect = Object.Instantiate(boomEffect, behaviour.transform.position, Quaternion.identity);
            Object.Destroy(effect, boomDuration);
            Object.Destroy(behaviour.gameObject);
        }
    }
}
