using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAI : MonoBehaviour {
    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 100f;
    GameObject red;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        red = GetComponent<GameObject>();

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
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (GameObject.FindGameObjectWithTag("blue").transform.position.x > 9)
        {

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Going left");
        }
        if (GameObject.FindGameObjectWithTag("blue").transform.position.x < -9)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
           
            Debug.Log("Going right");
        }
        if (GameObject.FindGameObjectWithTag("blue").transform.position.y < (GameObject.FindGameObjectWithTag("Player").transform.position.y + 4))
            transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
    }
}
