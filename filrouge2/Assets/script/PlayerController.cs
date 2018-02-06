using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 100f;
    public bool alive = true;
    private float playerScore;
    private Text score;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerScore = 0;
        setScore();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", move);

        }
    }


    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
   void Movement()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            anim.SetBool("Left", true);
            Debug.Log("Going left");

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            anim.SetBool("Left", false);
            Debug.Log("Going right");
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
        }

    }


    void setScore()
    {
            playerScore += 1;
            score.text += "Score: " + playerScore.ToString();  
    }
}
