using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public float scoreAddTime = 2.0f;
	public float decrease;

	StayAlive stayAlive;

	public int score = 0;

	void Start()
	{
		Time.timeScale = 1;
		GameObject stayAliveObject = GameObject.FindWithTag ("GameController");
		stayAlive = stayAliveObject.GetComponent<StayAlive>();

		score = 0;
		scoreText.text = "Score: " + score;
		StartCoroutine (AddScore());
	}

	IEnumerator AddScore()
	{
		while (!stayAlive.acabou) {
			yield return new WaitForSeconds (scoreAddTime);
			scoreAddTime *= (1 - decrease / 100);
			score += 10;
		}
	}

	void Update()
	{
		scoreText.text = "Score: " + score;
	}
}
