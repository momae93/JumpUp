using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
	
    public GameObject[] BasicPlatforms;
    public GameObject player;
    private static int level;
    private float spawnY = -2f;
    private float platformHeight = 3.0f;
    private int platformOnScreen = 5;
    private Transform playerTransform;
    private GameObject lastPlatform;

	void Start () {
        playerTransform = player.transform;
        level = 0;
		Spawn (Random.Range(-10,10), spawnY);
        for (int i = 0; i < platformOnScreen; i++)
            LevelManager();
    }

    void Update () {
        if (playerTransform.position.y > spawnY - platformOnScreen * platformHeight)
            LevelManager();
	}

    public static void Notify()
    {
        level += 1;
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

    public void LevelManager()
    {
        GameObject basicPlatform = SpawnPlatForm();
        switch (level)
        {
            case 0:
                Debug.Log("Behavior : " + level);
                break;
            case 1:
                Debug.Log("Behavior : " + level);
                break;
            case 2:
                SetMovingBehavior(ref basicPlatform, 5);
                break;
            case 3:
                Debug.Log("Behavior : " + level);
                break;
            default:
                SetMovingBehavior(ref basicPlatform, 5);
                break;
        }
    }

	private GameObject Spawn(float x, float y, float z = 0)
	{
		GameObject newPlatform = Instantiate(BasicPlatforms[Random.Range(0, 3)]) as GameObject;
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
