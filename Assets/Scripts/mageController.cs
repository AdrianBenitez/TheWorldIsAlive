using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageController : MonoBehaviour {
    public float speed = -2f;
    Animator anim;
    bool holdingDown;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        Input_Control();
	}

    void Input_Control()
    {
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            holdingDown = true;
            if ( transform.localScale.z == .08f) {
                transform.localScale += new Vector3(0, 0, -0.16f);
            }
            anim.SetBool("idle", false);
            anim.SetBool("move", true);
        }
        if (!Input.anyKey && holdingDown)
        {
            //Debug.Log("A key was released");
            holdingDown = false;
            anim.SetBool("move", false);
            anim.SetBool("idle", true);
        }
    }
}
