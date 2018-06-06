using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text gameNameText;
	public GameObject[] things;

	private string text = "The Running Game";

	void Start () {
		gameNameText.text = "";

		things [0].SetActive (false);
		things [1].SetActive (false);
		things [2].SetActive (false);

		StartCoroutine (GameStart ());
	}

	IEnumerator GameStart()
	{
		yield return new WaitForSeconds (0.6f);
		for (int i = 0; i < text.Length; i++)
		{
			gameNameText.text += text [i];
			yield return new WaitForSeconds (0.25f);
		}
		yield return new WaitForSeconds (0.4f);
		things [0].SetActive (true);
		yield return new WaitForSeconds (0.4f);
		things [1].SetActive (true);
		yield return new WaitForSeconds (0.4f);
		things [2].SetActive (true);
		yield return new WaitForSeconds (1.8f);

		for (int i = 0; i < 6; i++) {
			yield return new WaitForSeconds (2.9f);
			gameNameText.text = " ";
			yield return new WaitForSeconds (0.1f);
			gameNameText.text = text;
			yield return new WaitForSeconds (0.05f);
			gameNameText.text = " ";
			yield return new WaitForSeconds (0.05f);
			gameNameText.text = text;
			yield return new WaitForSeconds (0.05f);
			gameNameText.text = " ";
			gameNameText.fontSize = 44;
			yield return new WaitForSeconds (0.05f);
			gameNameText.text = text;
			yield return new WaitForSeconds (0.1f);
			gameNameText.text = " ";
			yield return new WaitForSeconds (0.1f);
			gameNameText.text = text;
			yield return new WaitForSeconds (0.05f);
			gameNameText.fontSize = 38;
		}
		while (true) {
			gameNameText.fontSize = 50;
			gameNameText.text = text;
			yield return new WaitForSeconds (0.058f);
			yield return new WaitForSeconds (0.058f);	
			yield return new WaitForSeconds (0.058f);
			gameNameText.fontSize = 44;
			yield return new WaitForSeconds (0.058f);
			gameNameText.text = text;
		}

	}
}
