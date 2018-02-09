using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
	
    public GameObject[] basicPlatforms;
    public GameObject player;

    private static int level;
    private float spawnY = -2f;
    private float platformHeight = 3.0f;
    private int platformOnScreen = 5;
    private Transform playerTransform;
    private GameObject lastPlatform;

    public static void Notify()
    {
        level += 1;
    }

	void Start () {
        playerTransform = player.transform;
		Spawn (Random.Range(-10,10), spawnY);
        for (int i = 0; i < platformOnScreen; i++)
            SpawnPlatForm();
	}

    void Update () {
        if (playerTransform.position.y > spawnY - platformOnScreen * platformHeight)
            SpawnPlatForm();
	}

    public void Create()
    {
        GameObject platform = SpawnPlatForm();
        switch (level)
        {
            case 1:
                SetMovingBehavior(ref platform, 5);
                break;
            case 2:
                Debug.Log("Level " + level);
                break;
            case 3:
                Debug.Log("Level " + level);
                break;
            default:
                Debug.Log("Level " + level);
                break;
        }
    }

    private GameObject SpawnPlatForm()
    {
		float leftPos = lastPlatform.transform.position.x - lastPlatform.transform.localScale.x / 2;
		float rightPos = lastPlatform.transform.position.x + lastPlatform.transform.localScale.x / 2;
		float[] tab = new float[] {	rightPos + 2f,	leftPos - 2f };
		if (leftPos + 10 < 3f && 10 - (rightPos) < 3f)
			return Spawn(tab[Random.Range(0,2)], spawnY);
		else if (leftPos + 10 < 3f)
			return Spawn(tab[0], spawnY);
		return Spawn(tab[1], spawnY);
    }

	private GameObject Spawn(float x, float y, float z = 0)
	{
		GameObject newPlatform = Instantiate(basicPlatforms[Random.Range(0, 3)]) as GameObject;
		newPlatform.transform.position = new Vector3(x, y, z);
		lastPlatform = newPlatform;
		spawnY += 3f;
        return newPlatform;
	}

	private void SetMovingBehavior(ref GameObject gameObject, int border, int speed = 2)
	{
		gameObject.AddComponent<GameObjectMove>();
		gameObject.GetComponent<GameObjectMove>().leftLimit = - border;
		gameObject.GetComponent<GameObjectMove>().rightLimit = border;
        gameObject.GetComponent<GameObjectMove>().speed = speed;
    }
}
