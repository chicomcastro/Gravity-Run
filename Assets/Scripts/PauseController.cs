using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseController : MonoBehaviour {

	public Text pauseText;
	public GameObject pauseImage;
	public GameObject loadingImage;
	public Text loadingText;

	public bool MP = false;

	private string text = "Loading...";

	private bool finished;

	StayAlive stayAlive;

	void Start () {

		GameObject stayAliveObject = GameObject.FindWithTag ("GameController");
		stayAlive = stayAliveObject.GetComponent<StayAlive>();

		pauseText.text = "";
		pauseImage.SetActive (false);
		loadingImage.SetActive (false);
		loadingText.text = "";

		AudioListener.pause = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P) && !stayAlive.acabou) {
			Time.timeScale = 1 - Time.timeScale;
			if (Time.timeScale == 0) {
				pauseText.text = "PAUSED";
				pauseImage.SetActive (true);
				AudioListener.pause = true;
			} else {
				pauseText.text = "";
				pauseImage.SetActive (false);
				AudioListener.pause = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape) && Time.timeScale == 0)
			StartCoroutine (Back());
	}

	IEnumerator Back()
	{
		Time.timeScale = 1;
		loadingImage.SetActive (true);
		for (int i = 0; i < text.Length; i++) {
			loadingText.text += text [i];
			yield return new WaitForSeconds (0.1f);
		}

		for (int j = 0; j < 5; j++) {
			loadingText.text = "Loading";
			for (int i = text.Length - 3; i < text.Length; i++) {
				loadingText.text += text [i];
				yield return new WaitForSeconds (0.08f);
			}
			if (j == 4)
				finished = true;
		}

		if (finished) {
			if (!MP)
				SceneManager.LoadScene ("Main");
			else
				SceneManager.LoadScene ("MP_Main");
		}
	}
}
