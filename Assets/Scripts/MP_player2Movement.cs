using UnityEngine;
using System.Collections;

public class MP_player2Movement : MonoBehaviour {

	public Rigidbody2D rb;
	public float walkForce;
	public float g;
	public float jumpSpeed;
	public int jumpCount = 2;
	public int count2 = 0;
	public float walkIncrease;
	public AudioSource jumpingSound;

	private bool ladodireito;

	Animator anim;

	bool pulando;
	bool direit;

	Movement movement;

	void Start ()
	{
		GameObject movementObject = GameObject.FindWithTag ("Platform");
		movement = movementObject.GetComponent<Movement>();

		pulando = true;
		direit = true;
		StartCoroutine (SpeedUp ());
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	IEnumerator SpeedUp ()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			walkForce *= (1 + walkIncrease/100);
			//if (movement.speed > movement.maxSpeed)
			//	walkIncrease = 0;
		}
	}


	void Update() {

		//Animating ();
		if (Input.GetKey (KeyCode.F)) {
			direit = false;
			anim.SetBool ("Direita", direit);
		} else {
			direit = true;
			anim.SetBool ("Direita", direit);
		}


		float dT = Time.deltaTime;

		if (Input.GetKey (KeyCode.H)) {
			rb.transform.Translate ( new Vector3 (walkForce * dT, 0, 0));
		}

		if(Input.GetKey (KeyCode.F)){
			rb.transform.Translate ( new Vector3 (-walkForce * dT, 0, 0));
		}

		if (transform.position.y > 0) {
			rb.gravityScale = -g;
			rb.transform.rotation = new Quaternion (180, 0, 0, 0);  
			if (Input.GetKeyDown (KeyCode.T) && count2 < jumpCount) {

				rb.velocity = new Vector2 (0, -jumpSpeed);

				jumping ();

				count2++;
				Debug.Log (count2);
			}
		}

		if (transform.position.y < 0) {
			rb.gravityScale = g;
			rb.transform.rotation = new Quaternion (0, 0, 0, 0);  
			if (Input.GetKeyDown (KeyCode.T) && count2 < jumpCount) {

				rb.velocity = new Vector2 (0, jumpSpeed);

				jumping ();

				count2++;
				Debug.Log (count2);
			}
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		if (((rb.transform.position.y > 0) && (rb.transform.position.y - other.transform.position.y < 0))
			|| ((rb.transform.position.y < 0) && (rb.transform.position.y - other.transform.position.y > 0))) {
			count2 = 0;

			NotJumping ();

			//Animating ();
		}
	}

	void jumping()
	{
		pulando = true;
		anim.SetBool ("pulando", pulando);

		jumpingSound.Play ();
	}

	void NotJumping()
	{
		pulando = false;
		anim.SetBool ("pulando", pulando);
	}
}
