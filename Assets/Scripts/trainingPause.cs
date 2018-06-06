using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class trainingPause : MonoBehaviour {

	public GameObject button;
	public GameObject pause;
	public GameObject loadingImage;
	public Text loadingText;

	public bool MP = false;

	private string text = "Loading...";

	private bool finished;

	void Start()
	{
		button.SetActive (false);
	}

	void Update()
	{
		if (pause.activeInHierarchy) {
			button.SetActive (true);
			if (Input.GetKeyDown (KeyCode.R)) {
				StartCoroutine (Back());
			}
		}
		else
			button.SetActive (false);
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
