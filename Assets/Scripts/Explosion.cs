using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.zero);

        if (hit != false && hit.transform.tag == "Player")
        {
            GameObject.Find("Game Handler").GetComponent<GameHandler>().HurtPlayer();
        }
        Destroy(this.gameObject, 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}