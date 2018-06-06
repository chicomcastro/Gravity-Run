using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Winner : MonoBehaviour {

	public GameObject[] players;

	public GameObject winImage;
	public Text winText;
	public Text restartText;

	private int vencedor;
	private bool player1vivo = true;
	private bool player2vivo = true;
	private bool player3vivo = true;
	private bool player4vivo = true;
	private bool acabou = false;
	private bool finished = false;
	private string text;

	void Start()
	{
		winImage.SetActive (false);
		winText.text = "";
		restartText.text = "";
	}

	void Update()
	{
		if (!players [0].activeInHierarchy)
			player1vivo = false;
		if (!players [1].activeInHierarchy)
			player2vivo = false;
		if (!players [2].activeInHierarchy)
			player3vivo = false;
		if (!players [3].activeInHierarchy)
			player4vivo = false;

		if (!finished) {
			if (player1vivo && !player2vivo && !player3vivo && !player4vivo) {
				vencedor = 1;
				acabou = true;
			}
			if (!player1vivo && player2vivo && !player3vivo && !player4vivo) {
				vencedor = 2;
				acabou = true;
			}
			if (!player1vivo && !player2vivo && player3vivo && !player4vivo) {
				vencedor = 3;
				acabou = true;
			}
			if (!player1vivo && !player2vivo && !player3vivo && player4vivo) {
				vencedor = 4;
				acabou = true;
			}
		}

		if (acabou) {
			text = "Winner: player " + vencedor;
			StartCoroutine (GameOver ());
			acabou = false;
			finished = true;
		}

		if (finished)
			if (Input.GetKeyDown (KeyCode.R))
				SceneManager.LoadScene ("MP_Zen");
	}

	IEnumerator GameOver()
	{
		for (int i = 0; i < text.Length; i++) {
			winText.text += text [i];
			yield return new WaitForSeconds (0.15f);
		}
		yield return new WaitForSeconds (1.5f);
		restartText.text = "Press R to restart";
	}

}
