using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Re-using some code from Adrian here.
 * Also I'm using the character and animations from here: https://youtu.be/_rrcoptdnqE
 * I did it just temporarily because I don't now (yet) how to rig characters for mecanim
 */

public class mageController : MonoBehaviour {
    // Change speed at your desire but use negative numbers.
    public float speed = 5f;
    public float jumpHeight = .0005f;
    public float respawnDelay = 2;

    Animator anim;
    Rigidbody myBody;
    //CapsuleCollider myCollider;
    bool holdingDown; // To know when a key is being pressed, if no key is being pressed hero should go to idle animation.
    bool goToKinematic;
    bool isDead = false; // Flag when the hero dies
    [SerializeField]
    bool canJump;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody>();
        //myCollider = GetComponent<CapsuleCollider>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!isDead) // We only move when alive
        {
            transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * Time.deltaTime * speed);
            Input_Control(); // Do something when keys are pressed.
        }
	}

    void Input_Control()
    {
        // Move hero to right
        if ( Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)  )
        {
            holdingDown = true; // We are holding a key or button
            if (transform.localScale.z == -.08f) // if hero is looking to the left switch to face right.
                //Note: I know this is not the correct way to do it but the lack of time.
            {
                transform.localScale += new Vector3(0, 0, +0.16f);
            }
            anim.SetBool("idle", false);
            anim.SetBool ("move", true);
            myBody.isKinematic = false; // This is used so hero does not slide down stairs, when that is the case we set it to true.
        }

        // Move hero to left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) )
        {
            holdingDown = true; // We are holding a key or button
            if ( transform.localScale.z == .08f)  // if hero is looking to the right switch to face left.
            {  
                transform.localScale += new Vector3(0, 0, -0.16f);
            }
            anim.SetBool("idle", false);
            anim.SetBool("move", true);
            myBody.isKinematic = false; // This is used so hero does not slide down stairs, when that is the case we set it to true
        }

        // Jump
        if ( ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )  && canJump )
        {
            holdingDown = true; // We are holding a key or button
            myBody.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }

        // If no keys are being pressed go to idle.
        if (!Input.anyKey && holdingDown)
        {
            //Debug.Log("A key was released");
            holdingDown = false;
            anim.SetBool("move", false);
            anim.SetBool("idle", true);
            if (goToKinematic == true) myBody.isKinematic = true; // Used so hero does not slide down stairs.
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stair")
        {
            goToKinematic = true;
        }
        if (collision.gameObject.tag == "HouseBody")
        {
            canJump = true;
            goToKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            anim.SetBool("idle", false);
            anim.SetBool("move", false);
            anim.SetBool("die", true);
            isDead = true;
            StartCoroutine(Respawn(respawnDelay));
        }

    }

    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    IEnumerator Respawn(float respawnDelay)
    {
        yield return new WaitForSeconds(respawnDelay);
        //SceneManager.LoadScene("Mini_1_House_byOrlando");
        transform.position = new Vector3(4.47f, 7.087f, 1.5f);
        anim.SetBool("die", false);
        anim.SetBool("idle", true);
        isDead = false;
    }
}
