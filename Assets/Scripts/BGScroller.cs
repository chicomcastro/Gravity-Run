using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;
	public float increase;

	private Vector3 startPosition;

	void Start () {
		startPosition = new Vector3(transform.position.x,transform.position.y,0);
	}

	void Update () {
		float newPosition = Mathf.Repeat (Time.timeSinceLevelLoad * scrollSpeed, tileSizeZ);
		transform.position = startPosition + new Vector3(1,0,0) * newPosition;
		scrollSpeed *= (1 + increase / 100);
	}
}