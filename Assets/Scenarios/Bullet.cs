using Assets.Scenarios.Controllers;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float hitDuration = 0.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoomController.BoomAndDestroy(this, hitEffect, hitDuration);
    }
}
