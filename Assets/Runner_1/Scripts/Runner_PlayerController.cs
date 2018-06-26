using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_PlayerController : MonoBehaviour 
{
    public float speed;

    void Start () 
    {
    }
    
    void Update () 
    {
        updateVelocity();
        updateControllInput();
    }

    private void updateVelocity()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void updateControllInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = 
                Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
                            Time.time * speed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            transform.position = 
                Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            new Vector3(transform.position.x - 1, transform.position.y, transform.position.z),
                            Time.time * speed);
        }
    }
}
