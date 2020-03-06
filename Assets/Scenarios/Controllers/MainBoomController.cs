using Assets.Scenarios.Interfaces;
using UnityEngine;

namespace Assets.Scenarios.Controllers
{
    public class MainBoomController : IBoomController
    {
        public void BoomAndDestroy(MonoBehaviour behaviour, GameObject boomEffect, float boomDuration)
        {
            GameObject effect = Object.Instantiate(boomEffect, behaviour.transform.position, Quaternion.identity);
            Object.Destroy(effect, boomDuration);
            Object.Destroy(behaviour.gameObject);
        }
    }
}
