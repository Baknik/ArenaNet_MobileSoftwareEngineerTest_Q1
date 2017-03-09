using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TurretSensor))]
public class Cannon : MonoBehaviour {

	[Header("Prefabs")]
	public CannonBall CannonBallPrefab;

	[Header("Configuration")]
	public float ShotVelocity;
	public float CooldownSeconds;
	public float ShotDelayAfterSight;
	public float CannonBallSpawnOffset;

	private TurretSensor sensor;
	private float timeOfLastShot;

	void Awake()
	{
		this.sensor = this.GetComponent<TurretSensor>();
	}

	// Use this for initialization
	void Start () {
		this.timeOfLastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.sensor != null && this.sensor.TargetInSight)
		{
			if ((Time.time - this.timeOfLastShot) >= this.CooldownSeconds)
			{
				CannonBall cannonBallInstance = (CannonBall)Instantiate(this.CannonBallPrefab, this.transform.position + (Vector3)(this.transform.up * this.CannonBallSpawnOffset), Quaternion.identity);
				cannonBallInstance.SetInitialVelocity(this.transform.up * this.ShotVelocity);

				this.timeOfLastShot = Time.time;
			}
		}
	}
}
