using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CannonBall : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	void Awake()
	{
		this.myRigidbody = this.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetInitialVelocity(Vector2 velocity)
	{
		this.myRigidbody.velocity = velocity;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Obstacle") ||
			other.tag.Equals("Boundary") ||
			other.tag.Equals("Player"))
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
