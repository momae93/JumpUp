using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Transform background1;
    public Transform background2;
    public float posZ;
    public float height;
    private bool whichone = true;
    public Transform cam;
    private float currentheight;
    // Use this for initialization
    void Start () {
        currentheight = height;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentheight < cam.position.y)
        {
            if (whichone)
                background1.localPosition = new Vector3(0, background1.localPosition.y + height * 2, posZ);
            else
                background2.localPosition = new Vector3(0, background2.localPosition.y + height * 2, posZ);
            currentheight += height;
            whichone = !whichone;
        }
        if (currentheight > cam.position.y + 86)
        {
            if (whichone)
                background2.localPosition = new Vector3(0, background2.localPosition.y - height * 2, posZ);
            else
                background1.localPosition = new Vector3(0, background1.localPosition.y - height * 2, posZ);
            currentheight -= height;
            whichone = !whichone;
        }
    }
}
