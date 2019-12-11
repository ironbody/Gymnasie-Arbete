using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootPos;
    public float waitTime;
    public string soundName;

    private float nextTimeToFire;

    private float randomTime;



    // Start is called before the first frame update
    void Start()
    {
        EnemyMove.AddEnemy(this.gameObject);

        randomTime = Random.Range(0f, 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if (!GameHandler.paused && !GameHandler.spawningWave)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + waitTime + randomTime;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootPos.position, Quaternion.identity);

    }
}