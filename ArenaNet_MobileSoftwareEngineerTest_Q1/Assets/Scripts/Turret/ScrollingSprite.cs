using UnityEngine;
using System.Collections;

public class ScrollingSprite : MonoBehaviour {

	[Header("Configuration")]
	public float ScrollSpeed;

	private bool moving;

	// Use this for initialization
	void Start () {
		this.moving = true;
	}

	void OnEnable()
	{
		PlayerBird.PlayerDeath += HandlePlayerDeath;
	}

	void OnDisable()
	{
		PlayerBird.PlayerDeath -= HandlePlayerDeath;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.moving)
		{
			Vector3 movement = new Vector3(this.ScrollSpeed * -1.0f, 0.0f, 0.0f);
			this.transform.Translate(movement * Time.deltaTime, Space.World);
		}
	}

	private void HandlePlayerDeath()
	{
		this.moving = false;
	}
}
