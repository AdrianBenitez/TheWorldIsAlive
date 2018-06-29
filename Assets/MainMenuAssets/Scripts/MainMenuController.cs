using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClick()
    {
        //Loads the first scene (inside house mini-game)
		var td = GameObject.FindWithTag("TransitionData").GetComponent<TransitionData>() as TransitionData;
		td.SetTransition(
			"The sounds coming from your house wakes you up in the middle of the night. You decide to investigate...",
			"Mini_1_House");
		SceneManager.LoadScene("Transition");
    }
}
