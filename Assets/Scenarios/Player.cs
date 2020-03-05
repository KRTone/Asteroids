﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scenarios.Controllers;
using Assets.Scenarios.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 playerPos;
    Vector2 mousePos;

    IMoveController moveController;

    private void Start()
    {
        moveController = new MainMoveController();
    }

    void Update()
    {
        moveController.GetAxes(cam, out playerPos, out mousePos);;
    }

    private void FixedUpdate()
    {
        moveController.Move(rb, playerPos, mousePos, moveSpeed);
    }
}
