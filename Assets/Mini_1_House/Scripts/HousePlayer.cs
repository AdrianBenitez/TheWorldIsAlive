using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayer : MonoBehaviour
{
	public float Speed = 4.0f;
	public float JumpSpeed = 4.0f;
	public bool FacingRight = true;

	public bool IsGrounded = false;

	private float _currentSpeed;
	private float _distanceToGround;

	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_distanceToGround = GetComponent<Collider>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetermineIsGrounded();
		DetermineCurrentSpeed();
		SetFacing();

		transform.Translate(_currentSpeed, 0, 0);

		Jump();
	}

	private void DetermineIsGrounded()
	{
		IsGrounded = Physics.Raycast(transform.position, -Vector3.up, _distanceToGround + 0.1f);
	}

	private void Jump()
	{
		if (Input.GetKey(KeyCode.Space) && IsGrounded)
		{
			_rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
		}
	}

	private void DetermineCurrentSpeed()
	{
		_currentSpeed = 0;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			_currentSpeed -= Speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.RightArrow))
		{
			_currentSpeed += Speed * Time.deltaTime;
		}
	}

	private void SetFacing()
	{
		if (_currentSpeed < 0)
		{
			FacingRight = false;
		}
		else if (_currentSpeed > 0)
		{
			FacingRight = true;
		}
	}
}
