using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] BasicPlatforms;
    public GameObject player;
    private float spawnY = -2f;
    private float platformHeight = 2.0f;
    private int platformOnScreen = 4;
    private Transform playerTransform;
    public int boardSize;

    private GameObject last;


	void Start () {
        playerTransform = player.transform;
        for (int i = 0; i < platformOnScreen; i++)
            SpawnPlatForm();
	}

    // Update is called once per frame
    void Update () {
        if (playerTransform.position.y > spawnY - platformOnScreen * platformHeight)
            SpawnPlatForm();
	}

    private void SpawnPlatForm()
    {
        if (last == null)
        {
            GameObject newPlatform;
            newPlatform = Instantiate(BasicPlatforms[Random.Range(0, 2)]) as GameObject;
            newPlatform.transform.position = new Vector3(Random.Range(-6, 6), spawnY, 0);
            last = newPlatform;
        }
        else
        { 
            GameObject newPlatform;
            newPlatform = Instantiate(BasicPlatforms[Random.Range(0, 2)]) as GameObject;
            float add = newPlatform.transform.localScale.x / 2;
            if (last.transform.position.x - last.transform.localScale.x / 2 + 10 < 3f)
            {
                newPlatform.transform.position = new Vector3(last.transform.position.x + last.transform.localScale.x / 2 + 2f, spawnY, 0);
            }
            if (10 - (last.transform.position.x + last.transform.localScale.x / 2) < 3f)
                newPlatform.transform.position = new Vector3(last.transform.position.x - last.transform.localScale.x / 2 - 2f, spawnY, 0);
            else
            {
                float[] tab = new float[] {
                    last.transform.position.x + last.transform.localScale.x / 2 + 1f,
                    last.transform.position.x - last.transform.localScale.x / 2 - 1f };
                newPlatform.transform.position = new Vector3(tab[Random.Range(0,1)], spawnY, 0);
            }
            last = newPlatform;
        }

        spawnY += 2f;

    }

}
