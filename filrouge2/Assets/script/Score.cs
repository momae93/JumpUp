using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private float playerScore = 0;
    private int difficulty = 1;
    private int modulo = 10;
   

    public float score
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    // Use this for initialization
    void Update()
    {
        playerScore += Time.deltaTime * difficulty;
        if ((playerScore / modulo >= 1) && (playerScore / modulo < 10))
        {
            modulo *= 10;
            difficulty += 1;
           // GameObject water = GameObject.Find("Water");
           // WavesController wave = water.GetComponent<WavesController>();
           // wave.WaveSpeed += 1;
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore));
    }
}
