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
    private Platform lastPlatform;

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
        Platform platform = SpawnPlatForm();
        switch (level)
        {
            case 0:
                break;
            case 1:
                if (Random.Range(0, 2) == 1)
                    platform.SetFallingBehavior();
                break;
            case 2:
                int rdn = Random.Range(0, 3);
                if (rdn == 1)
                    platform.SetFallingBehavior();
                if (rdn == 2)
                    platform.SetMovingBehavior(lastPlatform.Position.x, level);
                break;
            default:
                int rdn2 = Random.Range(0, 2);
                if (rdn2 == 0)
                    platform.SetFallingBehavior();
                if (rdn2 == 1)
                    platform.SetMovingBehavior(lastPlatform.Position.x, level);
                break;
        }
    }

    private Platform SpawnPlatForm()
    {
        float leftPos = lastPlatform.Position.x - lastPlatform.Size / 2;
        float rightPos = lastPlatform.Position.x + lastPlatform.Size / 2;
        float[] tab = new float[] { rightPos + 2f, leftPos - 2f };
        if (leftPos + 10 < 2f && 10 - (rightPos) < 2f)
            return Spawn(tab[Random.Range(0, 2)], spawnY);
        else if (leftPos + 10 < 3f)
            return Spawn(tab[0], spawnY);
        return Spawn(tab[1], spawnY);
    }

    private Platform Spawn(float x, float y, float z = 0)
    {
        int rdn = Random.Range(0, 3);
        Platform newPlatform = new Platform(basicPlatforms[rdn], GetSize(rdn));
        newPlatform.Position = new Vector3(x, y, z);
        lastPlatform = newPlatform;
        spawnY += 3f;
        return newPlatform;
    }

    private int GetSize(int prefab)
    {
        if (prefab == 0)
            return 2;
        if (prefab == 1)
            return 5;
        return 7;
    }
}
