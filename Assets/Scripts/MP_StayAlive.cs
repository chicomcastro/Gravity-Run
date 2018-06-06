using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MP_StayAlive : MonoBehaviour {

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

	public AudioSource[] musics;

	private AudioSource music;

	GameController gameController;

	private string text = "GAME OVER!";
	public bool acabou = false;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();

		restartText.text = "";
		gameOverText.text = "";
		startText.text = "";
		gameOverImage.SetActive (false);

		loadingImage.SetActive (false);
		loadingText.text = "";

		music = musics [Random.Range (0, musics.Length)];
		music.Play ();

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
		
		if (acabou) {
			if (Input.GetKey (KeyCode.R))
				SceneManager.LoadScene (levelName);
			if (Input.GetKeyDown (KeyCode.Escape))
				StartCoroutine (Back());
		}
	}

	/*IEnumerator GameOver()
	{
		deathSoundEffect.SetActive (true);
		music.Pause();
		deathMusic.SetActive (true);
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
	}*/

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
