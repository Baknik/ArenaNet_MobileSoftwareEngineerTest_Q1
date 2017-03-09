using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class TurretSensor : MonoBehaviour {

	[Header("Configuration")]
	public float RotationSpeed = 5.0f;

	public Transform Target { get; private set; }
	public bool TargetInSight { get; private set; }

	// Use this for initialization
	void Start () {
		this.Target = null;
		this.TargetInSight = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.Target != null)
		{
			Vector3 direction = this.Target.position - this.transform.position;
			float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg * -1.0f;
			this.TargetInSight = Vector2.Dot(this.transform.up, direction.normalized) >= 0.99f;
			if (Vector2.Dot(this.transform.parent.up, direction.normalized) >= 0)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(targetAngle, Vector3.forward), Time.deltaTime * this.RotationSpeed);
			}
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
