using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zagrScenGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    public void NewGame()
    {
        Application.LoadLevel(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
