using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{

	public string ToScene;

	public void Transition()
	{
		SceneManager.LoadScene(ToScene, LoadSceneMode.Single);
	}
}
