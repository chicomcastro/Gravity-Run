using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {

	public GameObject[] buttonsForChange;

	public void HaveClicked()
	{
		for (int i = 0; i < buttonsForChange.Length; i++) {
			if ( buttonsForChange [i].activeInHierarchy )
				buttonsForChange [i].SetActive (false);
			else
				buttonsForChange [i].SetActive (true);
		}
	}
}
