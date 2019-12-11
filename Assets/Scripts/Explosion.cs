using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player")
        {
            GameObject.Find("Game Handler").GetComponent<GameHandler>().HurtPlayer();
        }
    }
}