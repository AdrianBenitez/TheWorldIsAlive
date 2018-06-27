using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Very important to put enemies on the z axis at 2.5f so the enemies can interact with hero.
 * otherwise if character is on the z = 1.5f enemies cannot harm it. So the stairs is a safe zone by default.
*/ 
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
            if (character.transform.position.z == 1.5f) // if hero is on the stairs z axis then bring hero to front, away from stairs
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, 2.5f);
            }
            else // if the hero is not aligned with z axis of stairs bring hero back so hero can use stairs
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, 1.5f);
            }
        }
    }
}
