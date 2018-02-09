using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour {

    public float WaveSpeed = 0.5f;
    public GameObject Player;
	void Start () {
	}
	
	void Update () {
        Vector3 v3 = transform.position;
        v3.y = Mathf.Lerp(v3.y, transform.position.y + WaveSpeed, Time.deltaTime);
        transform.position = v3;
    }
}
