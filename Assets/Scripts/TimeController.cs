using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour {

	public Text timeShower;

	private int timeInt;

	DeathCountWinner dcw;

	void Start()
	{
		GameObject dcwObject = GameObject.FindWithTag ("GameController");
		dcw = dcwObject.GetComponent<DeathCountWinner> ();

		timeShower.text = "Time: ";
	}

	void Update()
	{
		if (Time.timeSinceLevelLoad <= dcw.maxTime + 1)
			timeShower.text = "Time: " + (int) Time.timeSinceLevelLoad + "/" + dcw.maxTime;
	}
}
