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
        Debug.Log("Resume");
        UpdatePanel();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Audio()
    {
        Debug.Log("Audio");
    }
}
