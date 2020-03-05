using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRate = 2f;
    public float asteroidSpeed = 3f;
    float nextSpawn;
    Dictionary<int, Transform> sides = new Dictionary<int, Transform>();

    const string Top = "Top", Left = "Left", Right = "Right", Bottom = "Bottom";
    const int TopInt = 0, LeftInt = 1, RightInt = 2, BottomInt = 3;

    Dictionary<string, int> sidesConsts = new Dictionary<string, int>
    {
        { Top, TopInt },
        { Bottom, BottomInt },
        { Right, RightInt },
        { Left, LeftInt }
    };

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Time.time;

        sides.Add(sidesConsts[Top], transform.Find(Top));
        sides.Add(sidesConsts[Left], transform.Find(Left));
        sides.Add(sidesConsts[Right], transform.Find(Right));
        sides.Add(sidesConsts[Bottom], transform.Find(Bottom));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn += spawnRate;

            GameObject enemy = Instantiate(enemyPrefab, GetRandomPosition(sides), Quaternion.identity);
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            rb.AddForce(player.transform.position * asteroidSpeed, ForceMode2D.Impulse);
        }
    }
    Vector2 GetRandomPosition(Dictionary<int, Transform> sides)
    {
        int key = Random.Range(0, sides.Count);
        Transform side = sides[key];
        BoxCollider2D collider = side.GetComponent<BoxCollider2D>();
        switch (key)
        {
            case TopInt:
            case BottomInt:
                float randX = Random.Range(side.position.x, collider.size.x + side.position.x);
                return new Vector2(randX, side.position.y);
            case LeftInt:
            case RightInt:
                float randY = Random.Range(side.position.y, collider.size.y + side.position.y);
                return new Vector2(side.position.x, randY);
            default:
                throw new System.ArgumentException(nameof(side));
        }
    }
}
