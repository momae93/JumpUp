using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour {
    public GameObject gameOverPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            EnablePanel();
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
        Application.Quit();
    }
    #endregion
}
