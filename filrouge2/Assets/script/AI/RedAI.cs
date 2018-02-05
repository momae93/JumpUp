using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : MonoBehaviour {
    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 100f;
    GameObject red;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        red = GetComponent<GameObject>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        // Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        {
            float move = Input.GetAxis("Horizontal");

        }
    }


    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
    void Movement()
    {
         transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
         
        
         if (this.gameObject.transform.position.x > 9)
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);

             Debug.Log("Going left");
         }
         if (this.gameObject.transform.position.x < -9)
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
             Debug.Log("Going right");
         }
        // if (GameObject.FindGameObjectWithTag("red").transform.position.y < (GameObject.FindGameObjectWithTag("Player").transform.position.y ))
        //   transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
        if (this.gameObject.transform.position.y <= (target.transform.position.y + 1)  || this.gameObject.transform.position.y <= (target.transform.position.y))
            anim.SetBool("attack", true);
        else
            anim.SetBool("attack", false);
    }
}
