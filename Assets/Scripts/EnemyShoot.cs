﻿using System.Collections;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + waitTime;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootPos.position, Quaternion.identity);

    }
}