using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    public float moveSpeed = 3f;
    public float jumpHeight = 10f;

    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
    void Movement()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
    }
}
