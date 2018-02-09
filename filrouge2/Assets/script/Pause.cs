using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
    private bool isPaused = false;

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
}
