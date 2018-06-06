using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayersManager : MonoBehaviour {
	
	public GameObject[] players;

	ActivePlayers playersManager;

	void Start()
	{
		GameObject playersManagerObject = GameObject.FindWithTag ("PlayersManager");
		playersManager = playersManagerObject.GetComponent<ActivePlayers>();

		for (int i = 0; i < playersManager.numberOfPlayers; i++) {
			players [i].SetActive (true);
		}
		for (int i = playersManager.numberOfPlayers; i < players.Length; i++) {
			players [i].SetActive (false);
		}
	}
}
