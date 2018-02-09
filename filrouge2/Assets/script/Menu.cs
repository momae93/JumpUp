using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
	void Start() 
	{ }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        Debug.Log("Instructions");
    }
}
