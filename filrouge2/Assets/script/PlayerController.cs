using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    #region Attributes

    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 40f;
    public bool isAlive = true;
    public GameObject gameOverPanel;
    private float move;
    private bool isGrounded;
    private List<float> highscore;

    #endregion

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        move = 0;
        isGrounded = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement();
        anim.SetFloat("Speed", move);
    
        isDead();
    }
    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
    /// 
    private void isDead()
    {
        GameObject Scores = GameObject.Find("Player");
        Score scores = Scores.GetComponent<Score>();
        highscore.Add(scores.score);
        if (isAlive == false)
            EnablePanel();
    }

    #region GameOver
    public void EnablePanel()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    // Use this for initialization
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isGrounded = true;
        }
    }

    /*void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isGrounded = false;
        }
    }*/
    void Movement()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            anim.SetBool("Left", true);
            move = -1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            anim.SetBool("Left", false);
            move = 1;
        }
        else
            move = 0;
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space) && isGrounded)
        {
                transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
        }
            
    }
}
