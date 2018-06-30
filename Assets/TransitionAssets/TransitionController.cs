using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

	public Text Target;
	public string Description;
	public string TargetScene;

	// Use this for initialization
	void Start () {
		var tdObj = GameObject.FindWithTag("TransitionData");
		if (tdObj != null)
		{
			var td = tdObj.GetComponent<TransitionData>() as TransitionData;
			if (td != null)
			{
				Description = td.Description;
				TargetScene = td.TargetScene;
				Target.text = Description;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonClick()
	{
        SceneManager.LoadScene("Mini_1_House_byOrlando");
	}
}
