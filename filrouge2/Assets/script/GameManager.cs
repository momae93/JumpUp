using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float[] bearings;
    public float score;
    public int level;
    public float waveSpeed;
    public GameObject player;
    public float scoreMax;
    private float time;



    // Use this for initialization
    void Start()
    {
        score = 0;
        level = 1;
        waveSpeed = 2f;
        bearings = new float[] { 75, 175, 300, 500 };
        Time.timeScale = 1;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * level;
        time += Time.deltaTime;
        UpdateScore();
        isDead();
    }

    void UpdateScore()
    {
        float currentY = player.transform.position.y;
        if (time >= 15)
        {
            scoreMax = currentY;
            CheckLevel(currentY);
            time = 0;
        }
    }
    void CheckLevel(float playerHeight)
    {
        level += 1;
        PlatformManager.Notify();
        FloatingTextController.Initialize();
        FloatingTextController.CreateFloatingText("Level :" + level);
        GameObject water = GameObject.Find("Water");
        WavesController wave = water.GetComponent<WavesController>();
        wave.WaveSpeed += 1f;
        GameObject gargouille = GameObject.Find("GargoyleManager");
        GenerateGargoyle gargoyle = gargouille.GetComponent<GenerateGargoyle>();
        gargoyle.Save -= 0.5f;
    }

    private void isDead()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController player = Player.GetComponent<PlayerController>();
        bool isAlive = player.isAlive;

        if (isAlive == false)
            if (PlayerPrefs.GetFloat("HighScore") < score)
                PlayerPrefs.SetFloat("HighScore", score);
        PlayerPrefs.SetFloat("Score", score);
        scoreMax = PlayerPrefs.GetFloat("HighScore");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(score));

        GUI.Label(new Rect(100, 10, 100, 30), "HighScore: " + (int)(scoreMax));
    }
}
