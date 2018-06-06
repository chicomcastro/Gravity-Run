using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrainingConditions : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D rb;
	public float Ymax;
	public float Ymin;
	public float Xmax;
	public float Xmin;

	private float deathCounter;

	public Text deathCounterText;
	public Text startText;
	public string startGameText;

	private playerMovement playerMovement;
	private DeathCountWinner gameController;

	void Start()
	{
		GameObject playerMovementObject = GameObject.FindWithTag ("Player");
		playerMovement = playerMovementObject.GetComponent<playerMovement>();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<DeathCountWinner>();

		startText.text = "";
		StartCoroutine (GameStartGame ());

		deathCounter = 0;
		deathCounterText.text = "Score: " + deathCounter;
	}

	IEnumerator GameStartGame()
	{
		for (int i = 0; i < startGameText.Length; i++) {
			startText.text += startGameText [i];
			yield return new WaitForSeconds (0.15f);
		}
		yield return new WaitForSeconds (1.5f);
		startText.text = "";
	}

	void Update () {

		if (player.transform.position.y > Ymax){

			rb.velocity = new Vector3 (0, -250, 0);
			playerMovement.count = 0;
			if (!gameController.acabou)
				deathCounter++;

		}
		else if (player.transform.position.y < Ymin) {

			rb.velocity = new Vector3 (0, 250, 0);
			playerMovement.count = 0;
			if (!gameController.acabou)
				deathCounter++;

		}
		else if (player.transform.position.x > Xmax) {
			
			if (player.transform.position.y < 0)
				rb.velocity = new Vector3 (-200, 50, 0);
			else if (player.transform.position.y >= 0)
				rb.velocity = new Vector3 (-200, -50, 0);

			if (!gameController.acabou)
				deathCounter++;

			playerMovement.count = 0;
		}
		else if (player.transform.position.x < Xmin) {
			
			if (player.transform.position.y < 0)
				rb.velocity = new Vector3 (200, 50, 0);
			else if (player.transform.position.y >= 0)
				rb.velocity = new Vector3 (200, -50, 0);

			if (!gameController.acabou)
				deathCounter++;

			playerMovement.count = 0;
		}

		deathCounterText.text = "Death Count: " + deathCounter;
	}
}
