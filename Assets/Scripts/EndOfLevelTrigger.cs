using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Don't use for other scenes except Mini_1_House_byOrlando please
// unless you make a new script and copy this code and modify it

public class EndOfLevelTrigger : MonoBehaviour 
{

    // This is the trigger that signals that the player made it out of the house.
    // We need to transition to next minigame.

    public GameObject character;
    public string scene;

    private void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Runner");
    }
}
