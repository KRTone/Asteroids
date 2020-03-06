using System;
using Assets.Scenarios.Interfaces;
using UnityEngine;
using Zenject;

public class AsteroidCollision : MonoBehaviour
{
    public GameObject partLT;
    public GameObject partLB;
    public GameObject partRT;
    public GameObject partRB;
    public GameObject boomEffect;
    public float multiplyVelocity = 1.5f;
    public float boomDuration = 0.3f;

    IBoomController boomController;

    [Inject]
    public void Construct(IBoomController boomController)
    {
        this.boomController = boomController ?? throw new ArgumentNullException(nameof(boomController));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                SplitAsteroid(gameObject, collision.relativeVelocity);
                boomController.BoomAndDestroy(this, boomEffect, boomDuration);
                break;
            case "Asteroid":
            case "Player":
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }

    void CreatePart(GameObject part, float x, float y)
    {
        if (part != null)
        {
            Vector2 center = new Vector2(x, y);
            GameObject gObj = Instantiate(part, center, Quaternion.identity);
            Rigidbody2D rb = gObj.GetComponent<Rigidbody2D>();
            Vector2 direction = center - (Vector2)gameObject.transform.position;
            rb.AddForce(direction.normalized * multiplyVelocity, ForceMode2D.Impulse);
        }
    }

    void SplitAsteroid(GameObject asteroid, Vector2 velocity)
    {
        Vector2 center = asteroid.transform.position;
        CreatePart(partLT, center.x - 1f, center.y + 1f);
        CreatePart(partLB, center.x - 1f, center.y - 1f);
        CreatePart(partRT, center.x + 1f, center.y + 1f);
        CreatePart(partRB, center.x + 1f, center.y - 1f);
    }
}
