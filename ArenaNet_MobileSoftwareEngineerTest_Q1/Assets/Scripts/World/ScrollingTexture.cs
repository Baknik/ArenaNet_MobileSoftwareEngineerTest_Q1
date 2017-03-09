using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ScrollingTexture : MonoBehaviour {

	[Header("Configuration")]
	public float ScrollSpeed;

	private MeshRenderer myMeshRenderer;
	private bool moving;

	void Awake()
	{
		this.myMeshRenderer = this.GetComponent<MeshRenderer>();
	}

	// Use this for initialization
	void Start () {
		this.moving = true;
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
		if (this.moving)
		{
			this.myMeshRenderer.material.mainTextureOffset =
				new Vector2(
					this.myMeshRenderer.material.mainTextureOffset.x + this.ScrollSpeed,
					this.myMeshRenderer.material.mainTextureOffset.y
				);
		}
	}

	private void HandleRestartGame()
	{
		this.moving = true;
	}

	private void HandlePlayerDeath()
	{
		this.moving = false;
	}
}
