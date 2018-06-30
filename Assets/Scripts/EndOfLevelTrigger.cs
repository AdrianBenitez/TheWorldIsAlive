using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTrigger : MonoBehaviour 
{

    // This is the trigger that signals that the player made it out of the house.
    // We need to transition to next minigame.

    public GameObject character;
    public string scene;

    private void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene(scene);
    }
}
