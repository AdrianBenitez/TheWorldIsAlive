using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
	public  HousePlayer Player;
	void OnTriggerEnter(Collider other) 
	{
		if (!other.gameObject.CompareTag("Player"))
		{
			Player.IsGrounded = true;
		}
	}


}
