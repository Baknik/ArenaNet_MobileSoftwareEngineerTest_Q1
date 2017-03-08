using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CannonBody : MonoBehaviour {

	[Header("Configuration")]
	public Sprite IdleSprite;
	public Sprite AggressiveSprite;

	private TurretSensor sensor;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		this.sensor = this.GetComponentInChildren<TurretSensor>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		this.spriteRenderer.sprite = this.IdleSprite;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.sensor != null && this.sensor.Target != null)
		{
			this.spriteRenderer.sprite = this.AggressiveSprite;
		}
		else
		{
			this.spriteRenderer.sprite = this.IdleSprite;
		}
	}
}
