using System;
using Assets.Scenarios.Controllers;
using Assets.Scenarios.Interfaces;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject boomEffect;
    public float boomDuration = 0.3f;

    Vector2 playerPos;
    Vector2 mousePos;

    IMoveController moveController;
    IBoomController boomController;

    [Inject]
    public void Construct(IMoveController moveController, IBoomController boomController)
    {
        this.moveController = moveController ?? throw new ArgumentNullException(nameof(moveController));
        this.boomController = boomController ?? throw new ArgumentNullException(nameof(boomController));
    }

    void Update()
    {
        moveController.GetAxes(cam, out playerPos, out mousePos);;
    }

    private void FixedUpdate()
    {
        moveController.Move(rb, playerPos, mousePos, moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boomController.BoomAndDestroy(this, boomEffect, boomDuration);
    }
}
