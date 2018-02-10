using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
    public Text highScore;
    void Start()
    {
        highScore.text = "Highscore : " + (int)PlayerPrefs.GetFloat("HighScore");
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        Debug.Log("Instructions");
    }
}
