﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float leftEdge;
    public float rightEdge;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 worldToScreen;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);

        var worldToScreen = Camera.main.WorldToViewportPoint(transform.position);
        worldToScreen.x = Mathf.Clamp(worldToScreen.x, leftEdge, rightEdge);
        transform.position = Camera.main.ViewportToWorldPoint(worldToScreen);


    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}