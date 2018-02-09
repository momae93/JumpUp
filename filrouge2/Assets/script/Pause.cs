using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
    private bool isPaused = false;
    private bool isAlive;

	void Start()
	{
		pausePanel.SetActive(isPaused);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UpdatePanel();
    }

    private void UpdatePanel()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void Resume()
    {
        UpdatePanel();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Audio()
    {
        Debug.Log("Audio");
    }

    public void save()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        GameObject player = GameObject.Find("Player (1)");
        PlayerController life = player.GetComponent<PlayerController>();
        isAlive = life.alive;
        Debug.Log(!isAlive);


        if (isPaused || !isAlive)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Time.timeScale = 0f; // Le temps s'arrete
        }

        else
            Time.timeScale = 1.0f; // Le temps reprend
    }

    //void saveOnGUI()
    //{
    //	GUI.color = Color.white;
    //	if (isPaused)
    //	{
    //		if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 40), "Continue"))
    //		{
    //			isPaused = false;
    //		}
    //		if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Exit"))
    //		{
    //			Application.LoadLevel(0);
    //		}
    //	}
    //	GUI.color = Color.red;
    //	if (!isAlive)
    //	{

    //		GUI.TextField(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 40), "Dead");
    //		if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Restart"))
    //		{
    //			Application.LoadLevel(0);
    //		}
    //	}
    //}
}
