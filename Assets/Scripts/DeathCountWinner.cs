using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathCountWinner : MonoBehaviour {

	public GameObject[] players;
	public int maxTime;
	public Text winText;
	public Text restartText;
	public string levelName;
	public GameObject gameOverImage;

	private string text;
	//private int vencedor = 0;
	public bool acabou = false;

	/*multiplayerMovement multiplayerMovement1;
	multiplayerMovement multiplayerMovement2;
	multiplayerMovement multiplayerMovement3;
	multiplayerMovement multiplayerMovement4;*/

	void Start()
	{
		winText.text = "";
		restartText.text = "";
		gameOverImage.SetActive (false);

		/*GameObject multiplayerMovementObject1 = GameObject.FindWithTag ("Player1");
		multiplayerMovement1 = multiplayerMovementObject1.GetComponent<multiplayerMovement> ();

		GameObject multiplayerMovementObject2 = GameObject.FindWithTag ("2");
		multiplayerMovement2 = multiplayerMovementObject2.GetComponent<multiplayerMovement> ();

		GameObject multiplayerMovementObject3 = GameObject.FindWithTag ("Player3");
		multiplayerMovement3 = multiplayerMovementObject3.GetComponent<multiplayerMovement> ();

		GameObject multiplayerMovementObject4 = GameObject.FindWithTag ("Player4");
		multiplayerMovement4 = multiplayerMovementObject4.GetComponent<multiplayerMovement> ();*/

	}

	void Update()
	{		
		if ( Time.timeSinceLevelLoad >= maxTime && !acabou)
		{
			/*multiplayerMovement1.acabou = true;
			multiplayerMovement2.acabou = true;
			multiplayerMovement3.acabou = true;
			multiplayerMovement4.acabou = true;

			if (multiplayerMovement1.deathCounter [0] < multiplayerMovement2.deathCounter [1]
			    && multiplayerMovement1.deathCounter [0] < multiplayerMovement3.deathCounter [2]
				&& multiplayerMovement1.deathCounter [0] < multiplayerMovement4.deathCounter [3])
				vencedor = 1;
			else if (multiplayerMovement2.deathCounter [1] < multiplayerMovement1.deathCounter [0]
				&& multiplayerMovement2.deathCounter [1] < multiplayerMovement3.deathCounter [2]
				&& multiplayerMovement2.deathCounter [1] < multiplayerMovement4.deathCounter [3])
				vencedor = 2;
			else if (multiplayerMovement3.deathCounter [2] < multiplayerMovement2.deathCounter [1]
				&& multiplayerMovement3.deathCounter [2] < multiplayerMovement1.deathCounter [0]
				&& multiplayerMovement3.deathCounter [2] < multiplayerMovement4.deathCounter [3])
				vencedor = 3;
			else if (multiplayerMovement4.deathCounter [3] < multiplayerMovement2.deathCounter [1]
				&& multiplayerMovement4.deathCounter [3] < multiplayerMovement3.deathCounter [2]
				&& multiplayerMovement4.deathCounter [3] < multiplayerMovement1.deathCounter [0])
				vencedor = 4;*/

			text = "Time is over!";
			acabou = true;
			StartCoroutine (EndGame ());
		}

		if (acabou)
			if(Input.GetKeyDown(KeyCode.R))
				SceneManager.LoadScene(levelName);
			
	}

	IEnumerator EndGame()
	{
		gameOverImage.SetActive (true);
		for (int i = 0; i < text.Length; i++) {
			winText.text += text [i];
			yield return new WaitForSeconds (0.15f);
		}
		yield return new WaitForSeconds (1.5f);
		restartText.text = "Press R to restart";
	}
}
