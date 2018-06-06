using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public GameObject[] activeButtons;
	public GameObject[] desactiveButtons;

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
