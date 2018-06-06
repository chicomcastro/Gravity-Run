using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class multiplayerMovement : MonoBehaviour {

	private Rigidbody2D rb;

	public float walkForce;
	public float g;
	public float jumpSpeed;
	public int jumpCount = 2;
	//public int[] count = {0, 0, 0, 0};
	public float walkIncrease;
	public AudioSource jumpingSound;

	public GameObject deathCounterUI;

	public bool player1 = true;
	public bool player2 = false;
	public bool player3 = false;
	public bool player4 = false;

	private bool left;
	private bool right;
	private bool jump;
	private int player;
	private int count = 0;

	private float Ymax = 105.00f;
	private float Ymin = -105.00f;
	private float Xmax = 230.00f;
	private float Xmin = -230.00f;

	public float[] deathCounter = {0, 0, 0, 0};

	public Text deathCounterText;

	private bool ladodireito;
	public bool acabou = false;

	Animator anim;

	bool pulando;
	bool direit;
	public bool InfinityMode = false;

	DeathCountWinner dcw;

	void Start ()
	{
		GameObject dcwObject = GameObject.FindWithTag ("GameController");
		dcw = dcwObject.GetComponent<DeathCountWinner> ();

		pulando = true;
		direit = true;
		StartCoroutine (SpeedUp ());
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

		deathCounterUI.SetActive (true);

		deathCounter[player] = 0;

		deathCounterText.text = "";
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
		if (!dcw.acabou) {
			if (player1) {
				left = Input.GetKey (KeyCode.A);
				right = Input.GetKey (KeyCode.D);
				jump = Input.GetKeyDown (KeyCode.W);
				player = 0;
			} else if (player2) {
				left = Input.GetKey (KeyCode.F);
				right = Input.GetKey (KeyCode.H);
				jump = Input.GetKeyDown (KeyCode.T);
				player = 1;
			} else if (player3) {
				left = Input.GetKey (KeyCode.J);
				right = Input.GetKey (KeyCode.L);
				jump = Input.GetKeyDown (KeyCode.I);
				player = 2;
			} else if (player4) {
				left = Input.GetKey (KeyCode.LeftArrow);
				right = Input.GetKey (KeyCode.RightArrow);
				jump = Input.GetKeyDown (KeyCode.UpArrow);
				player = 3;
			}
		}

		if (transform.position.y > Ymax){

			rb.velocity = new Vector3 (0, -250, 0);
			//count[player] = 0;
			count = 0;
			if(!dcw.acabou)
				deathCounter[player]++;

		}
		else if (transform.position.y < Ymin) {

			rb.velocity = new Vector3 (0, 250, 0);
			//count[player] = 0;
			count = 0;
			if(!dcw.acabou)
				deathCounter[player]++;

		}
		else if (transform.position.x > Xmax) {

			if (transform.position.y < 0)
				rb.velocity = new Vector3 (-200, 50, 0);
			else if (transform.position.y >= 0)
				rb.velocity = new Vector3 (-200, -50, 0);

			if(!dcw.acabou)
				deathCounter[player]++;

			//count[player] = 0;
			count = 0;
		}
		else if (transform.position.x < Xmin) {

			if (transform.position.y < 0)
				rb.velocity = new Vector3 (200, 50, 0);
			else if (transform.position.y >= 0)
				rb.velocity = new Vector3 (200, -50, 0);

			if(!dcw.acabou)
				deathCounter[player]++;

			//count[player] = 0;
			count = 0;
		}

		deathCounterText.text = "DC " + (player + 1) + ": " + deathCounter[player];

		if (left) {
			direit = false;
			anim.SetBool ("Direita", direit);
		} else {
			direit = true;
			anim.SetBool ("Direita", direit);
		}

		float dT = Time.deltaTime;

		if (right) {
			rb.transform.Translate ( new Vector3 (walkForce * dT, 0, 0));
		}

		if(left){
			rb.transform.Translate ( new Vector3 (-walkForce * dT, 0, 0));
		}

		if (transform.position.y > 0) {
			rb.gravityScale = -g;
			rb.transform.rotation = new Quaternion (180, 0, 0, 0);  
			if (jump && (count < jumpCount)) {

				rb.velocity = new Vector2 (0, -jumpSpeed);

				jumping ();

				//count[player]++;
				count++;
			}
		}

		if (transform.position.y < 0) {
			rb.gravityScale = g;
			rb.transform.rotation = new Quaternion (0, 0, 0, 0);  
			if (jump && (count < jumpCount)) {

				rb.velocity = new Vector2 (0, jumpSpeed);

				jumping ();

				//count[player]++;
				count++;
			}
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		if (((rb.transform.position.y > 0) && (rb.transform.position.y - other.transform.position.y < 0))
			|| ((rb.transform.position.y < 0) && (rb.transform.position.y - other.transform.position.y > 0))) {

			//count[player] = 0;
			count = 0;

			NotJumping ();
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
