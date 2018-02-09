using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    #region Attributes

    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 40f;
    private bool isAlive = true;
    private float playerScore;
    private Text score;

    #endregion

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
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            anim.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space))
            transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
    }


    void setScore()
    {
        playerScore += 1;
        score.text += "Score: " + playerScore.ToString();  
    }
}
