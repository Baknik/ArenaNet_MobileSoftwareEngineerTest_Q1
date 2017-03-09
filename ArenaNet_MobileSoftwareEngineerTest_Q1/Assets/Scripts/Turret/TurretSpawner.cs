using UnityEngine;
using System.Collections;

public class TurretSpawner : MonoBehaviour {

	[Header("Configuration")]
	public float SecondsBetweenSpawns = 4.0f;
	public float MinOffset = 0.5f;
	public float MaxOffset = 2.0f;

	[Header("Prefabs")]
	public Transform CannonTurretPrefab;

	private float lastSpawnTime;
	private bool active;

	// Use this for initialization
	void Start () {
		this.lastSpawnTime = Time.time;
		this.active = false;
	}

	void OnEnable()
	{
		PlayerBird.RestartGame += HandleRestartGame;
		PlayerBird.PlayerDeath += HandlePlayerDeath;
	}

	void OnDisable()
	{
		PlayerBird.RestartGame -= HandleRestartGame;
		PlayerBird.PlayerDeath -= HandlePlayerDeath;
	}

	// Update is called once per frame
	void Update () {
		if ((Time.time - this.lastSpawnTime) >= this.SecondsBetweenSpawns && this.active)
		{
			int flipped = Random.Range(0, 2);
			float zRotationAngle = 180.0f * flipped;
			float offset = Random.Range(this.MinOffset, this.MaxOffset) * (flipped == 0 ? -1.0f : 1.0f);
			Instantiate(this.CannonTurretPrefab, this.transform.position + (this.transform.up * offset), Quaternion.AngleAxis(zRotationAngle, Vector3.forward));

			this.lastSpawnTime = Time.time;
		}
	}

	private void HandleRestartGame()
	{
		this.active = true;
	}

	private void HandlePlayerDeath()
	{
		this.active = false;
	}
}
