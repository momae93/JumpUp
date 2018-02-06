using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player (1)");
            PlayerController life = player.GetComponent<PlayerController>();
            life.alive = false;
        }
        else
            Destroy(other.gameObject, 0);
    }
}
