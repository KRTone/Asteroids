using System;
using Assets.Scenarios.Controllers;
using Assets.Scenarios.Interfaces;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float hitDuration = 0.2f;

    IBoomController boomController;

    [Inject]
    public void Construct(IBoomController boomController)
    {
        this.boomController = boomController ?? throw new ArgumentNullException(nameof(boomController));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boomController.BoomAndDestroy(this, hitEffect, hitDuration);
    }
}
