using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public Text loadingText;

	private string text = "Loading...";

	private bool finished;

	void Start()
	{
		finished = false;
		Time.timeScale = 1;
		loadingImage.SetActive (false);
		loadingText.text = "";
	}

	public void LoadLevel(string levelName)
	{
		StartCoroutine (Loading (levelName));
	}

	IEnumerator Loading(string levelName)
	{
		loadingImage.SetActive (true);
		for (int i = 0; i < text.Length; i++) {
			loadingText.text += text [i];
			yield return new WaitForSeconds (0.08f);
		}

		for (int j = 0; j < 3; j++) {
			loadingText.text = "Loading";
			for (int i = text.Length - 3; i < text.Length; i++) {
				loadingText.text += text [i];
				yield return new WaitForSeconds (0.08f);
			}
			if (j == 2)
				finished = true;
		}

		if (finished) {
			SceneManager.LoadScene (levelName);
			//loadingImage.SetActive (false);
			//loadingText.text = "";
		}
	}
}
