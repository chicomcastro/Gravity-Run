using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject[] activeButtons;
	public GameObject[] desactiveButtons;

	void Start()
	{
		ChangeButtons ();
	}

	public void ChangeButtons()
	{
		for (int i = 0; i < desactiveButtons.Length; i++) {
			desactiveButtons [i].SetActive (false);
		}
		for (int i = 0; i < activeButtons.Length; i++) {
			activeButtons [i].SetActive (true);
		}
	}
}
