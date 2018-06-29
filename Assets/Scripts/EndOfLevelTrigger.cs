using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTrigger : MonoBehaviour {

    GameObject character;
    // Use this for initialization
    void Start()
    {
        character = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Runner");
    }
}
