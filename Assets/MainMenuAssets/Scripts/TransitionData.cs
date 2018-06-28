using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionData : MonoBehaviour {

	public string Description;
	public string TargetScene;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	public void SetTransition(string description, string targetScene)
	{
		Description = description;
		TargetScene = targetScene;
	}

}
