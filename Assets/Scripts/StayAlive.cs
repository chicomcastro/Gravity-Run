using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StayAlive : MonoBehaviour {

	public GameObject player;
	public float Ymax;
	public float Ymin;
	public float Xmax;
	public float Xmin;

	public GameObject loadingImage;
	public Text loadingText;
	private string textL = "Loading...";
	private bool finished;

	public GameObject gameOverImage;
	public Text gameOverText;
	public Text restartText;
	public Text startText;
	public string startGameText;
	public string levelName;

	public AudioSource deathSoundEffect;
	public AudioSource deathMusic;

	private string text = "GAME OVER!";
	public bool acabou = false;

	MusicManager musicPlayer;

	GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		GameObject musicPlayerObject = GameObject.FindWithTag ("GameController");
		musicPlayer = musicPlayerObject.GetComponent<MusicManager> ();

		restartText.text = "";
		gameOverText.text = "";
		startText.text = "";
		gameOverImage.SetActive (false);

		loadingImage.SetActive (false);
		loadingText.text = "";

		StartCoroutine (GameStartGame ());
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
		if ((player.transform.position.y > Ymax || player.transform.position.y < Ymin
		    || player.transform.position.x > Xmax || player.transform.position.x < Xmin) && !acabou) {
			StartCoroutine (GameOver ());
			acabou = true;
		}
		if (acabou) {
			if (Input.GetKey (KeyCode.R))
				SceneManager.LoadScene (levelName);
			if (Input.GetKeyDown (KeyCode.Escape))
				StartCoroutine (Back());
		}
	}

	IEnumerator GameOver()
	{
		musicPlayer.music.Pause ();
		deathSoundEffect.Play ();
		deathMusic.Play ();
		startGameText = "";
		startText.text = "";
		gameOverImage.SetActive (true);
		player.SetActive (false);
		for (int i = 0; i < text.Length; i++) {
			gameOverText.text += text [i];
			yield return new WaitForSeconds (0.15f);
		}
		gameOverText.text += "\nScore: " + gameController.score;
		restartText.text = "Press R to restart";
	}

	IEnumerator Back()
	{
		loadingImage.SetActive (true);
		for (int i = 0; i < textL.Length; i++) {
			loadingText.text += textL [i];
			yield return new WaitForSeconds (0.1f);
		}

		for (int j = 0; j < 5; j++) {
			loadingText.text = "Loading";
			for (int i = text.Length - 3; i < textL.Length; i++) {
				loadingText.text += textL [i];
				yield return new WaitForSeconds (0.08f);
			}
			if (j == 4)
				finished = true;
		}

		if (finished) {
			SceneManager.LoadScene ("Main");
		}
	}
}
