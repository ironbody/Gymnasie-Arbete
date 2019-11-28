using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed;
    public float speedMult;
    public float moveDownAmount;

    public float leftEdge;
    public float rightEdge;

    private List<GameObject> enemies = new List<GameObject>();

    static private int moveDirection = 1; // Either 1 (right) or -1 (left)
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                var worldToScreen = Camera.main.WorldToViewportPoint(enemy.transform.position);
                if (worldToScreen.x < leftEdge)
                {
                    changeDirection(1);
                    // Debug.Log("Moved Right: " + enemy.name);
                }
                if (worldToScreen.x > rightEdge)
                {
                    changeDirection(-1);
                    // Debug.Log("Moved Left: " + enemy.name);
                }
            }
        }

        // Debug.Log(rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (GameHandler.paused == false)
        {
            rb.velocity = new Vector2(speed * moveDirection, 0);

        }
    }

    void changeDirection(int direction)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (moveDownAmount / 6));

        moveDirection = direction;

        if (speed <= 10)
        {
            speed = speed * speedMult;
        }

    }

    public void RemoveEnemy(GameObject e)
    {
        if (enemies.Contains(e))
        {
            Debug.Log("Removed enemy");
            enemies.Remove(e);

        }
    }
}