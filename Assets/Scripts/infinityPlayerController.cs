using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class infinityPlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	public float walkForce;
	public float g;
	public float jumpSpeed;
	public int jumpCount = 2;
	public float walkIncrease;
	public AudioSource jumpingSound;
	public AudioSource deathSound;

	public bool player1 = true;
	public bool player2 = false;
	public bool player3 = false;
	public bool player4 = false;

	private bool left;
	private bool right;
	private bool jump;
	private int count = 0;

	private float Ymax = 105.00f;
	private float Ymin = -105.00f;
	private float Xmax = 230.00f;
	private float Xmin = -230.00f;

	private bool ladodireito;

	Animator anim;

	bool pulando;
	bool direit;

	void Start ()
	{
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
		}
	}


	void Update() {

		if (player1) {
			left = Input.GetKey (KeyCode.A);
			right = Input.GetKey (KeyCode.D);
			jump = Input.GetKeyDown (KeyCode.W);
		}
		else if (player2) {
			left = Input.GetKey (KeyCode.F);
			right = Input.GetKey (KeyCode.H);
			jump = Input.GetKeyDown (KeyCode.T);
		}
		else if (player3) {
			left = Input.GetKey (KeyCode.J);
			right = Input.GetKey (KeyCode.L);
			jump = Input.GetKeyDown (KeyCode.I);
		}
		else if (player4) {
			left = Input.GetKey (KeyCode.LeftArrow);
			right = Input.GetKey (KeyCode.RightArrow);
			jump = Input.GetKeyDown (KeyCode.UpArrow);
		}

		if (transform.position.y > Ymax){

			gameObject.SetActive(false);
			count = 0;
			deathSound.Play ();

		}
		else if (transform.position.y < Ymin) {

			gameObject.SetActive(false);
			count = 0;
			deathSound.Play ();

		}
		else if (transform.position.x > Xmax) {

			gameObject.SetActive(false);
			count = 0;
			deathSound.Play ();

		}
		else if (transform.position.x < Xmin) {

			gameObject.SetActive(false);
			count = 0;
			deathSound.Play ();

		}

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
			rb.gravityScale = g;
			rb.transform.rotation = new Quaternion (0, 0, 0, 0);  
			if (jump && (count < jumpCount)) {

				rb.velocity = new Vector2 (0, jumpSpeed);

				jumping ();

				count++;
				Debug.Log (count);
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
				Debug.Log (count);
			}
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		if (((rb.transform.position.y > 0) && (rb.transform.position.y - other.transform.position.y > 0))
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
