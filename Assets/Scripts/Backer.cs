using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Backer : MonoBehaviour {
	
	public GameObject loadingImage;
	public Text loadingText;

	private string text = "Loading...";

	private bool finished;

	void Start()
	{
		loadingImage.SetActive (false);
		loadingText.text = "";
	}
		
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			StartCoroutine (Back());
		
	}

	IEnumerator Back()
	{
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
			SceneManager.LoadScene ("First");
		}
	}
}
