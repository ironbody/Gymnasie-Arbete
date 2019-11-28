using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootPos;
    public float waitTime;

    private float nextTimeToFire;

    // Start is called before the first frame update
    void Start()
    {
        EnemyMove.AddEnemy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.paused == false)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + waitTime;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootPos.position, Quaternion.identity);

    }
}