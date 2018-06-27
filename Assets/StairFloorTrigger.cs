using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairFloorTrigger : MonoBehaviour {
    GameObject character;
	// Use this for initialization
	void Start () {
        character = GameObject.FindWithTag("Player");
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something triggered stairfloortrigger");
        if (other.tag == "Player")
        {
            if (character.transform.position.z == 1.5f)
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, 2.5f);
            }
            else
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, 1.5f);
            }
        }
    }
}
