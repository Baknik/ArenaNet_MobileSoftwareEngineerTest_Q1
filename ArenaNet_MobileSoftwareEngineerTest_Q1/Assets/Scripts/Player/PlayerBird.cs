using UnityEngine;
using System.Collections;

public class PlayerBird : MonoBehaviour {

	[Header("Configuration")]
	public float FlapForce;

	private Rigidbody2D myRigidbody;
	private bool flapInput;

	void Awake()
	{
		this.myRigidbody = this.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		this.flapInput = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
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
}
