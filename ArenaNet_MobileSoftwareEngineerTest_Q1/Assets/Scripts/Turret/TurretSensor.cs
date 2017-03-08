using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class TurretSensor : MonoBehaviour {

	[Header("Configuration")]
	public float RotationSpeed = 5.0f;
	public float MinAngle = -90.0f;
	public float MaxAngle = 90.0f;

	public Transform Target { get; private set; }

	// Use this for initialization
	void Start () {
		this.Target = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.Target != null)
		{
			Vector3 direction = this.Target.position - transform.position;
			float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
			if (this.Target.position.x < this.transform.position.x)
			{
				targetAngle *= -1.0f;
			}
			targetAngle = Mathf.Clamp(targetAngle, this.MinAngle, this.MaxAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(targetAngle, Vector3.forward), Time.deltaTime * this.RotationSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player"))
		{
			this.Target = other.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag.Equals("Player"))
		{
			this.Target = null;
		}
	}
}
