using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public float speed = 1.0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.y = Mathf.Lerp(v3.y, player.transform.position.y, Time.deltaTime * speed);
        transform.position = v3;
    }
}
