using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageController : MonoBehaviour {
    public float speed = -2f;
    Animator anim;
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
            if (transform.localScale.z == -.12f)
            {
                transform.localScale += new Vector3(0, 0, +0.24f);
            }
            anim.SetBool("idle", false);
            anim.SetBool ("move", true);   
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if ( transform.localScale.z == .12f) {
                transform.localScale += new Vector3(0, 0, -0.24f);
            }
            anim.SetBool("idle", false);
            anim.SetBool("move", true);
        }
    }
}
