using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    #region Attributes

    Animator anim;
    public float moveSpeed = 3f;
    public float jumpHeight = 40f;
    public bool isAlive = true;
    public GameObject gameOverPanel;

    #endregion

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", move);
        }
        isDead();
    }
    /// <summary>
    /// Function that determines the moves of the player
    /// </summary>
    /// Need to be optimize
    /// 
    private void isDead()
    { 
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
}
