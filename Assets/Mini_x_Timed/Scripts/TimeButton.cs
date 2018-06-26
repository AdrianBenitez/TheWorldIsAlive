using General.Signals;
using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
	public static Signal<TimeButtonResult> OnComplete = new Signal<TimeButtonResult>();

	public KeyCode Key;
	public string Id;

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
				Complete(TimeResponseResult.Expired);
			}
			else if (PercentLeft < ExcellentPercent)
			{
				TimeImage.color = ExcellentColor;
				CenterImage.color = ExcellentColor;
				Text.text = ExcellentText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeResponseResult.Excellent);
				}
			}
			else if (PercentLeft < GoodPercent)
			{
				TimeImage.color = GoodColor;
				CenterImage.color = GoodColor;
				Text.text = GoodText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeResponseResult.Good);
				}
			}
			else
			{
				TimeImage.color = StartColor;
				CenterImage.color = Color.white;
				Text.text = StartText.Replace("\\n", "\n");

				if (keyPressed)
				{
					Complete(TimeResponseResult.TooSoon);
				}
			}


		}
	}

	private void Complete(TimeResponseResult result)
	{
		OnComplete.Dispatch(new TimeButtonResult(Id, result));
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

public class TimeButtonResult
{
	public TimeResponseResult Result;
	public string ButtonId;

	public TimeButtonResult()
	{
	}

	public TimeButtonResult(string id, TimeResponseResult result)
	{
		ButtonId = id;
		Result = result;
	}
}

public enum TimeResponseResult
{
	Excellent,
	Good,
	TooSoon,
	Expired
}
