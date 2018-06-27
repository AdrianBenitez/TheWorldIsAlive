using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Re-using some code from Adrian here.
 * Also I'm using the character and animations from here: https://youtu.be/_rrcoptdnqE
 * I did it just temporarily because I don't now (yet) how to rig characters for mecanim
 */

public class mageController : MonoBehaviour {
    // Change speed at your desire.
    public float speed = -2f;
    Animator anim;
    bool holdingDown; // To know when a key is being pressed, if no key is being pressed hero should go to idle animation.

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        Input_Control(); // Do something when keys are pressed.
	}

    void Input_Control()
    {
        // Move hero to right
        if ( Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)  )
        {
            holdingDown = true;
            if (transform.localScale.z == -.08f)
            {
                transform.localScale += new Vector3(0, 0, +0.16f);
            }
            anim.SetBool("idle", false);
            anim.SetBool ("move", true);   
        }
        // Move hero to left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            holdingDown = true;
            if ( transform.localScale.z == .08f) {
                transform.localScale += new Vector3(0, 0, -0.16f);
            }
            anim.SetBool("idle", false);
            anim.SetBool("move", true);
        }
        // If no keys are being pressed go to idle.
        if (!Input.anyKey && holdingDown)
        {
            //Debug.Log("A key was released");
            holdingDown = false;
            anim.SetBool("move", false);
            anim.SetBool("idle", true);
        }
    }
}
