using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float offset = 3f;
    public float speed = 2.0f;

    void Start()
    { }

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.y = Mathf.Lerp(v3.y, player.transform.position.y + offset, Time.deltaTime * speed);
        transform.position = v3;
    }
}
