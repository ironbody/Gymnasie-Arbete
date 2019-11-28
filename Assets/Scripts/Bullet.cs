using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.transform.tag);
        Debug.Log(other.transform.name);

        if (other.transform.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            other.gameObject.GetComponent<EnemyDie>().Die();
            Destroy(this.gameObject);
        }
        if (other.transform.tag == "Player")
        {
            
            other.gameObject.GetComponent<PlayerDie>().Die();
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

}