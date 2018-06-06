using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MP_DeathCountMode_Zen : MonoBehaviour {

	public Text startText;
	public string startGameText;

	void Start()
	{
		startText.text = "";
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
}
