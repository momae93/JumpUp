using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{

	
	void Start() 
	{
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width/4.5f, Screen.height/3, Screen.width/5, Screen.height/10), "Play")) 
		{
            SceneManager.LoadScene(1);
        }

		if (GUI.Button (new Rect (Screen.width/4.5f, Screen.height/1.5f, Screen.width/5, Screen.height/10), "Instructions")) 
		{
            SceneManager.LoadScene(2);
        }

	}
}
