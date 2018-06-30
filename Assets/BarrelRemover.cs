using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
