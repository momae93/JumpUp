using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCarving : MonoBehaviour {

    // Use this for initialization
    public GameObject ToCarve;
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.X))
            Carve();
    }

    void Carve()
    {
        MeshFilter mf = ToCarve.GetComponent<MeshFilter>();
        Debug.Log("Mesh size : " + mf.mesh.triangles.Length);
    }
}
