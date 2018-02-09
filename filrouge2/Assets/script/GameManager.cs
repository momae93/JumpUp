using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private float[] bearings;
    public float score;
    public int level;
    public float waveSpeed;
    public GameObject player;
    public float scoreMax;

    private int modulo = 10;
    // Use this for initialization
    void Start () {
        score = 0;
        level = 0;  
        waveSpeed = 2f;
        bearings = new float[] {75, 175, 300, 500 };
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
    }

    void UpdateScore()
    {
        float currentY = player.transform.position.y;
        if (currentY > scoreMax)
        {
            scoreMax = currentY;
            CheckLevel(currentY);
        }
    }
    void CheckLevel(float playerHeight)
    {
        if (scoreMax > bearings[level] && level < 3)
        {
            level += 1;
            PlatformManager.Notify();
            FloatingTextController.Initialize();
            FloatingTextController.CreateFloatingText("Level :" + level);
        }
    }
}
