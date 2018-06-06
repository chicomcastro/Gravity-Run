using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float speedIncrease;
	//public float maxSpeed;

	void Start()
	{
		StartCoroutine (SpeedUp ());
	}

	IEnumerator SpeedUp ()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			speed *= (1 + speedIncrease / 100);
			//if (speed > maxSpeed)
			//	speedIncrease = 0;
		}
	}

	void Update ()
	{
		float dt = Time.deltaTime;
		transform.Translate( -speed * dt, 0, 0);
	}
}