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

    static private int moveRight;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftEdge || transform.position.x > rightEdge)   
        {
            changeDirection();
        }

        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * moveRight, 0);
    }

    void changeDirection()
    {
        moveRight = moveRight * -1;
        speed = speed * speedMult;
        transform.position = new Vector2(transform.position.x, transform.position.y - moveDownAmount);
    }
}
