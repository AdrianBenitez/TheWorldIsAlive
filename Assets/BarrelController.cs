using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour {

    public float Range = 2;
    public float Speed = 2f;

    bool move = true;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //if (move)
        //{
        //    transform.Translate(0, -Speed * Time.deltaTime, 0);
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Turning this off because when player respawns the vacuum won't move
            move = false;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("hit wall");
            //Speed = Speed * -1;
            //if (transform.localScale.y == 1)
            //{
            //    transform.localScale += new Vector3(0, -2, 0);
            //}
            //else
            //{
            //    transform.localScale += new Vector3(0, 2, 0);
            //}
        }
        else
        {
            move = true;
        }
    }
}
