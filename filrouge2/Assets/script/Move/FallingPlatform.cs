using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    public Rigidbody rg;
     
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision detected");
        if (col.gameObject.tag == "Player")
            StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(1);
        rg.isKinematic = false;
        yield return 0;
    }
}
