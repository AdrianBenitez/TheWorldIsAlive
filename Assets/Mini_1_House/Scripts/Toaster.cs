using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
	public float Range = 2;
	public float Speed = 3;

	private float _leftRange;
	private float _rightRange;

	private bool _facingRight;
	private float _target;

	// Use this for initialization
	void Start ()
	{
		_rightRange = transform.position.x + Range / 2;
		_leftRange = transform.position.x - Range / 2;
		_target = _leftRange;
		_facingRight = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_facingRight)
		{
			if (_target - transform.position.x <= 0)
			{
				_target = _leftRange;
				_facingRight = false;
			}
			else
			{
				transform.Translate(Mathf.Min(Speed * Time.deltaTime, _target - transform.position.x), 0, 0);
			}
		}
		else
		{
			if (transform.position.x - _target <= 0)
			{
				_target = _rightRange;
				_facingRight = true;
			}
			else
			{
				transform.Translate(Mathf.Min(-Speed * Time.deltaTime, transform.position.x - _target), 0, 0);
			}
		}
	}
}
