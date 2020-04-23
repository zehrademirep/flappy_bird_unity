using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
   public void enterTheGame()
    {
        SceneManager.LoadScene("Level 1");
    }
   public void exit()
    {
        Application.Quit();
    }
}
