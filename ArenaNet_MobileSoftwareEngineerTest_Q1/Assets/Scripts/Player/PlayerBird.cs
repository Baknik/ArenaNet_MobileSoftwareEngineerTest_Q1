using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBird : MonoBehaviour {

	public delegate void PlayerDeathDelegate();
	public static event PlayerDeathDelegate PlayerDeath;

	public delegate void RestartGameDelegate();
	public static event RestartGameDelegate RestartGame;

	public delegate void PlayerScoredDelegate();
	public static event PlayerScoredDelegate PlayerScored;

	[Header("Configuration")]
	public float FlapForce;
	public float GravityScale;

	private Rigidbody2D myRigidbody;
	private bool flapInput;
	private bool dead;

	void Awake()
	{
		this.myRigidbody = this.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		this.flapInput = false;
		this.dead = true;
		this.myRigidbody.gravityScale = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (this.dead)
			{
				RestartGame();
				this.transform.position = new Vector2(this.transform.position.x, 0.0f);
				this.dead = false;
				this.myRigidbody.gravityScale = this.GravityScale;
			}
			this.flapInput = true;
		}
	}

	void FixedUpdate()
	{
		if (this.flapInput)
		{
			this.myRigidbody.velocity = Vector2.up * this.FlapForce;
			this.flapInput = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Projectile"))
		{
			this.HandleDeath();
		}
		else if (other.tag.Equals("Score"))
		{
			PlayerScored();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag.Equals("Obstacle"))
		{
			this.HandleDeath();
		}
	}

	private void HandleDeath()
	{
		this.dead = true;
		PlayerDeath();
	}
}
