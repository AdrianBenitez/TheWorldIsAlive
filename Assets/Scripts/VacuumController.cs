using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

    public float Range = 2;
    public float Speed = 2;
    public float LeftFacingY = 90;
    public float RightFacingY = -90;

    private float _leftRange;
    private float _rightRange;

    private bool _facingRight;
    private float _target;

    // Use this for initialization
    void Start()
    {
        //_rightRange = transform.position.x + Range / 2;
        //_leftRange = transform.position.x - Range / 2;
        //_target = _leftRange;
        //_facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
            
        //} 
        if (other.gameObject.CompareTag("Wall") )
        {
            Speed = Speed * -1;
            if (transform.localScale.y == 1)
            {
                transform.localScale += new Vector3(0, -2, 0);
            }
            else
            {
                transform.localScale += new Vector3(0, 2, 0);
            }
        }
    }
}
