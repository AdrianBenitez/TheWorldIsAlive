using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner_PlayerController : MonoBehaviour 
{
    public float speed;
    Animator animator;

    public float respawnDelay = 3;

    Rigidbody myBody;
    //CapsuleCollider myCollider;
    bool holdingDown; // To know when a key is being pressed, if no key is being pressed hero should go to idle animation.
    bool goToKinematic;
    bool isDead = false; // Flag when the hero dies
    [SerializeField]
    bool canJump;

    void Start () 
    {
        animator = GetComponent<Animator>();
    }
    
    void Update () 
    {
        updateVelocity();
        updateControllInput();
    }

    private void updateVelocity()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void updateControllInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var newX = transform.position.x + 1;
            if (newX > 1f) { newX = 1f;   }
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



    IEnumerator Respawn(float respawnDelay)
    {
        yield return new WaitForSeconds(respawnDelay);

        string m_Scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(m_Scene);

        animator.SetBool("die", false);
        isDead = false;
    }
}
