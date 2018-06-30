using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnRunnerSceneControl : MonoBehaviour {

    // Change speed at your desire but use negative numbers.
    public float speed = 5f;
    public float jumpHeight = .0005f;
    public float respawnDelay = 3;

    Animator anim;
    Rigidbody myBody;
    //CapsuleCollider myCollider;
    bool holdingDown; // To know when a key is being pressed, if no key is being pressed hero should go to idle animation.
    bool goToKinematic;
    bool isDead = false; // Flag when the hero dies
    [SerializeField]
    bool canJump;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody>();
        //myCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) // We only move when alive
        {
            //transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * Time.deltaTime * speed);
            Input_Control(); // Do something when keys are pressed.
        }
    }

    void Input_Control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var newX = transform.position.x + 1;
            if (newX > 1f) { newX = 1f; }
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                            new Vector3(newX, transform.position.y, transform.position.z),
                                              Time.time * speed);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var newX = transform.position.x - 1;
            if (newX < -1f) { newX = -1f; }

            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                            new Vector3(newX, transform.position.y, transform.position.z),
                                              Time.time * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("A lamp hit me!");
            anim.SetBool("move", false);
            anim.SetBool("die", true);
            isDead = true;
            StartCoroutine(Respawn(respawnDelay));
        }
    }

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.z += speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    IEnumerator Respawn(float respawnDelay)
    {
        yield return new WaitForSeconds(respawnDelay);

        string m_Scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(m_Scene);
        
        anim.SetBool("die", false);
        isDead = false;
    }
}
