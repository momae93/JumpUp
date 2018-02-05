using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private float playerScore = 0;
    // Use this for initialization
    void Update()
    {
        playerScore += Time.deltaTime;
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore));
    }
}
