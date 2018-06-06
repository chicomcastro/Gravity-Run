using UnityEngine;
using System.Collections; 

public class playerMovement: MonoBehaviour {

	public Rigidbody2D	rb;
	public int forceJump;
	public float walkForce;
	public float g;
	public float jumpSpeed;
	public int jumpCount = 2;
	public int count = 0;
	public float walkIncrease;
	public AudioSource jumpingSound;

	private bool ladodireito;

	Animator anim;

	bool pulando;
	bool direit;

	Movement movement;
	DeathCountWinner gameController;

	void Start ()
	{
		//GameObject movementObject = GameObject.FindWithTag ("Platform");
		//movement = movementObject.GetComponent<Movement>();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<DeathCountWinner>();

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

		if (!gameController.acabou) {
			if (Input.GetButton ("Left")) {
				direit = false;
				anim.SetBool ("Direita", direit);
			} else {
				direit = true;
				anim.SetBool ("Direita", direit);
			}


			float dT = Time.deltaTime;

			if (Input.GetButton ("Right")) {
				rb.transform.Translate (new Vector3 (walkForce * dT, 0, 0));
			}

			if (Input.GetButton ("Left")) {
				rb.transform.Translate (new Vector3 (-walkForce * dT, 0, 0));
			}

			if (transform.position.y > 0) {
				rb.gravityScale = -g;
				rb.transform.rotation = new Quaternion (180, 0, 0, 0);  
				if (Input.GetButtonDown ("Jump") && count < jumpCount) {

					rb.velocity = new Vector2 (0, -jumpSpeed);

					jumping ();

					count++;
				}
			}

			if (transform.position.y < 0) {
				rb.gravityScale = g;
				rb.transform.rotation = new Quaternion (0, 0, 0, 0);  
				if (Input.GetButtonDown ("Jump") && count < jumpCount) {

					rb.velocity = new Vector2 (0, jumpSpeed);

					jumping ();

					count++;
				}
			}
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		if (((rb.transform.position.y > 0) && (rb.transform.position.y - other.transform.position.y < 0))
		    || ((rb.transform.position.y < 0) && (rb.transform.position.y - other.transform.position.y > 0))) {
			count = 0;

			NotJumping ();

			//Animating ();
		}
	}

	/*void OnCollisionStay2D (Collision2D other)
	{
		NotJumping ();
	}

	void FixedUpdate()
	{
		Animating ();
	}

	void Animating ()
	{
		bool direit = true;
		if (Input.GetButton ("Right")) {
			direit = true;
		}
		if(Input.GetButton("Left")){
			direit = false;
			NotJumping ();
			anim.SetBool ("Direita", direit);
		}
	}*/

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