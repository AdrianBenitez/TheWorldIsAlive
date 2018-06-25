using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
	public KeyCode Key;

	public float Duration = 3;
	public float GoodPercent = 0.2f;
	public float ExcellentPercent = 0.05f;

	public Color StartColor = Color.red;
	public Color GoodColor = Color.yellow;
	public Color ExcellentColor = Color.green;

	public string StartText;
	public string GoodText;
	public string ExcellentText;

	public Image BackgroundImage;
	public Image TimeImage;
	public Image CenterImage;
	public Text Text;

	public TimeButtonEvent OnComplete = new TimeButtonEvent();

	public bool Running = false;

	// Debugging only, will not be effected by inspector
	public float PercentLeft = 1.0f;

	private float _timeLeft;

	// Use this for initialization
	void Start () {
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (Running)
		{
			var keyPressed = Input.GetKey(Key);

			_timeLeft -= Time.deltaTime;
			PercentLeft = _timeLeft / Duration;
			TimeImage.fillAmount = PercentLeft;

			if (_timeLeft <= 0)
			{
				Complete(TimeButtonResult.Expired);
			}
			else if (PercentLeft < ExcellentPercent)
			{
				TimeImage.color = ExcellentColor;
				CenterImage.color = ExcellentColor;
				Text.text = ExcellentText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeButtonResult.Excellent);
				}
			}
			else if (PercentLeft < GoodPercent)
			{
				TimeImage.color = GoodColor;
				CenterImage.color = GoodColor;
				Text.text = GoodText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeButtonResult.Good);
				}
			}
			else
			{
				TimeImage.color = StartColor;
				CenterImage.color = Color.white;
				Text.text = StartText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeButtonResult.TooSoon);
				}
			}


		}
	}

	private void Complete(TimeButtonResult result)
	{
		OnComplete.Invoke(result);
		Running = false;
		Reset();
	}

	public void Reset()
	{
		_timeLeft = Duration;
		TimeImage.fillAmount = 1.0f;
		TimeImage.color = StartColor;
		CenterImage.color = Color.white;
	}
}

public enum TimeButtonResult
{
	Excellent,
	Good,
	TooSoon,
	Expired
}

public class TimeButtonEvent : UnityEvent<TimeButtonResult>
{
}
