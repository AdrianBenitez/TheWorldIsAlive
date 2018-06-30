using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_PlayerController : MonoBehaviour 
{
    public float speed;
    Animator animator;

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
}
