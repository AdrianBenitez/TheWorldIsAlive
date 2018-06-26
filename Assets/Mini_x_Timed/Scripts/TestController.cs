using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{

	public Text ResultText;
	public TimeButton TimeButton;

	// Use this for initialization
	void Start () {
		TimeButton.OnComplete.AddListener(TimeButtonCompleteHandler);
	}

	private void TimeButtonCompleteHandler(TimeButtonResult result)
	{
		ResultText.text = result.Result.ToString();
	}

	public void StartTimeButton()
	{
		TimeButton.Reset();
		TimeButton.Running = true;
		ResultText.text = "";
	}
}
