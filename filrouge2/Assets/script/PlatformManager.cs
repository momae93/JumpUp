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
    private int lastSize;

    public static void Notify()
    {
        level += 1;
    }

	void Start () {
        playerTransform = player.transform;
		Spawn (Random.Range(-10,10), spawnY);
        for (int i = 0; i < platformOnScreen; i++)
            Create();
	}

    void Update () {
        if (playerTransform.position.y > spawnY - platformOnScreen * platformHeight)
            Create();
	}

    public void Create()
    {
        GameObject platform = SpawnPlatForm();
        switch (level)
        {
            case 1:
                if (Random.Range(0, 2) == 1)
                    SetFallingBehavior(ref platform);
                break;
            case 2:
                if (Random.Range(0, 2) == 1)
                    SetMovingBehavior(ref platform, 5);
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
		float leftPos = lastPlatform.transform.position.x - lastSize / 2;
		float rightPos = lastPlatform.transform.position.x + lastSize / 2;
        Debug.Log("Left : " + leftPos.ToString());
        Debug.Log("Right : " + rightPos.ToString());
		float[] tab = new float[] {	rightPos + 2f,	leftPos - 2f };
        if (leftPos + 10 < 2f && 10 - (rightPos) < 2f)
        {
            Debug.Log("Left right");
            return Spawn(tab[Random.Range(0, 2)], spawnY);
        }
        else if (leftPos + 10 < 3f)
        { 
            Debug.Log("Left");
            return Spawn(tab[0], spawnY);
        }
        return Spawn(tab[1], spawnY);
    }

	private GameObject Spawn(float x, float y, float z = 0)
	{
        int rdn = Random.RandomRange(0, 3);
        GameObject newPlatform = Instantiate(basicPlatforms[rdn]) as GameObject;
        lastSize = GetSize(rdn);
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

    private void SetFallingBehavior(ref GameObject gameObject)
    {
        gameObject.AddComponent<FallingPlatform>();
    }

    /// <summary>
    /// G
    /// </summary>
    private int GetSize(int prefab)
    {
        if (prefab == 0)
            return 2;
        if (prefab == 1)
            return 5;
        return 7;
    }
}
