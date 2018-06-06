using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

	void update(){
		float dt = Time.deltaTime;

		transform.Rotate (new Vector3 (0, 0, 10));
	}
}
