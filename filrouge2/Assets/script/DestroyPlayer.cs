using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    private bool isPaused = false;
    void OnCollisionEnter(Collision col)
    {
        Time.timeScale = 0f;
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("pooooooooooooooooooooooop");
            isPaused = true;
            
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            
        }
        else
            Destroy(this.gameObject);
    }

    void OnGUI()
    {
        GUI.color = Color.white;
        if (isPaused)
        {
            GUI.TextField(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 40), "Game Over");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Restart"))
            {
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
