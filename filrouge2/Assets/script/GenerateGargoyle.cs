using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateGargoyle : MonoBehaviour {
    public List<GameObject> arrayOfGargoyle;
    public GameObject player;
    private Transform playerTransform;
    private float x;
    private float y;
    private float z;
    public float delay;
    private float save;
    // Use this for initialization
    void Start () {
        arrayOfGargoyle.Add(GameObject.FindGameObjectWithTag("red"));
        arrayOfGargoyle.Add(GameObject.FindGameObjectWithTag("blue"));
        playerTransform = player.transform;
        save = delay ;
      
    }
	
	// Update is called once per frame
	void Update () {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }
        else
        {
            delay = save;
            SpawnGargoyle();
        }
    }

    private void SpawnGargoyle()
    {
        GameObject newGargoyle = Instantiate(arrayOfGargoyle[Random.Range(0, arrayOfGargoyle.Count )]) as GameObject;
        x = Random.Range(-9, 9);
        y = Random.Range(playerTransform.position.y + 2, playerTransform.position.y + 5);
        z = playerTransform.position.z;
        newGargoyle.transform.position = new Vector3(x, y, z);
    }
}
