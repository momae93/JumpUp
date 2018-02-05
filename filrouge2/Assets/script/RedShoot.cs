﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

    private Transform target;
    private Transform firepoint;
    public float fireRate = 0;

    public Rigidbody projectile;
    public float speed = 20;


    private float counter = 1;
    public float power;

 

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        go = GameObject.FindGameObjectWithTag("FirePoint");
        firepoint = go.transform;
    }

    void Update()
    {
        Attack();
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("poop");
            Destroy(col.gameObject);
      
    }
    void Attack()
    {
        if (this.gameObject.transform.position.y <= (target.transform.position.y + 1) || this.gameObject.transform.position.y <= (target.transform.position.y))
        {
            counter += Time.deltaTime;
            if (counter > 1)
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                Destroy(instantiatedProjectile.gameObject, 5);
                counter = 0;
            }
        }
    }
}
