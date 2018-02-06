using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
    private bool isPaused = false;
    private bool isAlive;

    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
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

    void OnGUI()
    {
        GUI.color = Color.white;
        if (isPaused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 40), "Continue"))
            {
                isPaused = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
        GUI.color = Color.red;
        if (!isAlive)
        {

            GUI.TextField(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 40), "Dead");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Restart"))
            {
                Application.LoadLevel(0);
            }
        }
    }


}
