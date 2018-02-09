using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAI : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;

    // Use this for initialization
    void Start()
    {
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
    }
}
