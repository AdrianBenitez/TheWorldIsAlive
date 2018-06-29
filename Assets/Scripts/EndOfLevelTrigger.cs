using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTrigger : MonoBehaviour {

    GameObject character;
    // Use this for initialization
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO PLAY KILL FX
            //TODO FADE TO BLACK
            //TODO WAIT 1 second
            //TODO FADE TO SCENE
            collision.gameObject.transform.position = new Vector3(0, 0, 6);
        }

    }
}
