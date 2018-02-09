﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAI : MonoBehaviour {
    Animator anim;
    public float moveSpeed;
    public float jumpHeight;
    GameObject red;
    public GameObject player;
    private Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        red = GetComponent<GameObject>();
        playerTransform = player.transform;


    }
    void Update()
    {
        Movement();
    }
    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
   /* void OnCollisionEnter(Collision col)
    {
        transform.localRotation = transform.localRotation != Quaternion.Euler(0, 0, 0) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
    }*/

    void Movement()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x > 9)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (transform.position.x < -9)
            transform.localRotation = Quaternion.Euler(0, 180, 0);   

        if (transform.position.y <= (playerTransform.position.y + 1) || transform.position.y <= (playerTransform.position.y))
            anim.SetBool("attack", true);
        else
            anim.SetBool("attack", false);
    }
}
