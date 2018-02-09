using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player (1)");
            PlayerController life = player.GetComponent<PlayerController>();
        }
        else
            Destroy(this.gameObject);
    }
}
