using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour {

    public float WaveSpeed = 0.5f;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v3 = transform.position;
        v3.y = Mathf.Lerp(v3.y, transform.position.y + WaveSpeed, Time.deltaTime);
        transform.position = v3;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Player.GetComponent<PlayerController>().jumpHeight /= 1.5f;
    //        Debug.Log("Height : " + Player.GetComponent<PlayerController>().jumpHeight);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Player.GetComponent<PlayerController>().jumpHeight *= 1.5f;
    //        Debug.Log("Height : " + Player.GetComponent<PlayerController>().jumpHeight);
    //    }
    //}
}
