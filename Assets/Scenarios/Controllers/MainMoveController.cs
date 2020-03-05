using System;
using Assets.Scenarios.Interfaces;
using UnityEngine;

namespace Assets.Scenarios.Controllers
{
    public class MainMoveController : IMoveController
    {
        public void GetAxes(Camera cam, out Vector2 position, out Vector2 mousePosition)
        {
            position.x = Input.GetAxisRaw("Horizontal");
            position.y = Input.GetAxisRaw("Vertical");
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        public void Move(Rigidbody2D rb, Vector2 playerPos, Vector2 mousePos, float moveSpeed)
        {
            rb.MovePosition(rb.position + playerPos * moveSpeed * Time.fixedDeltaTime);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
