using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            PlayerController life = player.GetComponent<PlayerController>();
            life.isAlive = false;
        }
        else
            Destroy(this.gameObject);
    }
}
