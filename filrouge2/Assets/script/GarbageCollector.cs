using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GarbageCollector : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text highScore;

    void Start()
    {
        highScore.text = "Score : " + (int)PlayerPrefs.GetFloat("Score") + " " + "Highscore : " + (int)PlayerPrefs.GetFloat("HighScore");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {   
            GameObject Player = GameObject.Find("Player");
            PlayerController player = Player.GetComponent<PlayerController>();
            player.isAlive = false;
            EnablePanel();
        }
            
        else
            Destroy(other.gameObject, 0);
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
        SceneManager.LoadScene(0);
    }
    #endregion
}