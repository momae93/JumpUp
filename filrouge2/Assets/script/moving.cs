using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		{
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", move);
       
		}
        

    }

	void Movement()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.localRotation = Quaternion.Euler(0,180,0);
			transform.Translate (Vector2.right * 3f * Time.deltaTime);
            anim.SetBool("Left", true);

        }
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.localRotation = Quaternion.Euler(0,0,0);
			transform.Translate (Vector2.right * 3f * Time.deltaTime);
            anim.SetBool("Left", false);

        }
	}
}
