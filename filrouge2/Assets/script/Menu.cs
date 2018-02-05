using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{

	
	void Start() 
	{
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width/4.5f, Screen.height/3, Screen.width/5, Screen.height/10), "Play")) 
		{
			Application.LoadLevel(1);

		}

		if (GUI.Button (new Rect (Screen.width/4.5f, Screen.height/1.5f, Screen.width/5, Screen.height/10), "Instructions")) 
		{
			Application.LoadLevel(2);

		}

	}
}
