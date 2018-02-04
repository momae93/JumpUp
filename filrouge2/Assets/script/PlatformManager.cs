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

	void Start () {
        playerTransform = player.transform;
        for (int i = 0; i < platformOnScreen; i++)
        {
            SpawnPlatForm();
        }
	}

    // Update is called once per frame
    void Update () {
        if (playerTransform.position.y > spawnY - platformOnScreen * platformHeight)
            SpawnPlatForm();
	}

    private void SpawnPlatForm(int prefabIndex = -1)
    {
        Debug.Log("SPAWN!");
        GameObject go;
        go = Instantiate(BasicPlatforms[Random.Range(0, 2)]) as GameObject;
        go.transform.SetParent(transform);

        go.transform.position = new Vector3(Random.Range(-6, 6), spawnY, 0);
        spawnY += platformHeight;
    }
}
