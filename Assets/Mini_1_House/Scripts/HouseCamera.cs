using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCamera : MonoBehaviour
{
	public float Speed = 2.0f;

	public Transform LowerFloor;
	public Transform MidFloor;
	public Transform TopFloor;

	public Transform LowerView;
	public Transform MidView;
	public Transform TopView;

	public Camera Camera;
	public Transform Player;

	private Transform _target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetermineTarget();
		MoveToTarget();
	}

	private void MoveToTarget()
	{
		if (Mathf.Abs(Camera.transform.localPosition.y - _target.localPosition.y) > 0.1f)
		{
			Debug.LogFormat("Diff: {0}", Camera.transform.localPosition.y - _target.localPosition.y);
			var newPos = Vector3.Lerp(Camera.transform.localPosition, _target.localPosition, Speed * Time.deltaTime);
			Camera.transform.localPosition = newPos;
		}
	}

	private void DetermineTarget()
	{
		if (Player.position.y > TopFloor.position.y)
		{
			_target = TopView;
		} else if (Player.position.y > MidFloor.position.y)
		{
			_target = MidView;
		}
		else
		{
			_target = LowerView;
		}
	}
}
