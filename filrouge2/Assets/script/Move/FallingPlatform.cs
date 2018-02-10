using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    Rigidbody rigidbody;
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("A");
            Fall();
        }

    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(2);
        rigidbody.isKinematic = false;
        yield return 0;
    }
}
